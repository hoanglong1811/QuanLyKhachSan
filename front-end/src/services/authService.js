import apiClient from './api';

const normalizeRole = (role) => {
    if (!role) return '';
    // Chuyển đổi role về lowercase và bỏ dấu
    const normalized = role.toLowerCase()
        .normalize('NFD')
        .replace(/[\u0300-\u036f]/g, '')
        .replace(/đ/g, 'd')
        .replace(/\s+/g, '');
    
    // Map các role tương đương
    const roleMap = {
        'quantrivien': 'admin',
        'admin': 'admin',
        'administrator': 'admin',
        'nhanvien': 'staff',
        'staff': 'staff',
        'khachhang': 'customer',
        'customer': 'customer'
    };

    return roleMap[normalized] || normalized;
};

export const authService = {
    // Đăng nhập
    async login(credentials) {
        try {
            console.log('Sending login request with credentials:', {
                username: credentials.tenDangNhap,
                password: '***'
            });

            const response = await apiClient.post('/api/TaiKhoan/login', credentials);
            
            console.log('Raw response:', response);

            if (response.data) {
                const normalizedRole = normalizeRole(response.data.tenVaiTro);
                console.log('Original role:', response.data.tenVaiTro);
                console.log('Normalized role:', normalizedRole);

                // Lưu thông tin user
                const userInfo = {
                    id: response.data.idTaiKhoan,
                    idTaiKhoan: response.data.idTaiKhoan,
                    username: response.data.tenDangNhap,
                    email: response.data.email,
                    role: normalizedRole,
                    originalRole: response.data.tenVaiTro,
                    idVaiTro: response.data.idVaiTro
                };
                
                // Tạo token với role đã chuẩn hóa
                const tokenData = {
                    id: response.data.idTaiKhoan,
                    username: response.data.tenDangNhap,
                    role: normalizedRole,
                    exp: new Date().getTime() + (24 * 60 * 60 * 1000) // 24 giờ
                };

                // Encode token sử dụng encodeURIComponent để xử lý Unicode
                const tempToken = btoa(encodeURIComponent(JSON.stringify(tokenData)));

                // Lưu token và user info
                localStorage.setItem('token', tempToken);
                localStorage.setItem('user', JSON.stringify(userInfo));
                
                console.log('Saved user info:', userInfo);

                return {
                    ...response.data,
                    token: tempToken
                };
            } else {
                throw new Error('Invalid response data');
            }
        } catch (error) {
            console.error('Login error:', {
                message: error.message,
                response: error.response?.data,
                status: error.response?.status
            });
            throw error;
        }
    },

    // Đăng xuất
    async logout() {
        try {
            await apiClient.post('/api/TaiKhoan/logout');
            this.clearAuth();
            console.log('Logged out successfully');
        } catch (error) {
            // Ngay cả khi có lỗi, vẫn xóa thông tin đăng nhập local
            this.clearAuth();
            console.error('Logout error:', error);
            throw error;
        }
    },

    // Xóa thông tin xác thực
    clearAuth() {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
    },

    // Kiểm tra trạng thái đăng nhập
    isAuthenticated() {
        const token = localStorage.getItem('token');
        if (!token) return false;

        try {
            // Giải mã token
            const tokenData = JSON.parse(decodeURIComponent(atob(token)));
            const isExpired = tokenData.exp < new Date().getTime();
            
            if (isExpired) {
                this.clearAuth();
                return false;
            }
            
            return true;
        } catch {
            this.clearAuth();
            return false;
        }
    },

    // Lấy thông tin user
    getCurrentUser() {
        try {
            const userStr = localStorage.getItem('user');
            if (!userStr) return null;
            
            const user = JSON.parse(userStr);
            // Đảm bảo role luôn được chuẩn hóa
            if (user.role) {
                user.role = normalizeRole(user.role);
            }
            return user;
        } catch {
            return null;
        }
    },

    // Lấy role của user
    getUserRole() {
        const user = this.getCurrentUser();
        return user ? user.role : null;
    },

    // Kiểm tra xem user có phải là admin không
    isAdmin() {
        const user = this.getCurrentUser();
        const role = user ? normalizeRole(user.role) : null;
        console.log('Checking admin access:', {
            originalRole: user?.originalRole,
            normalizedRole: role,
            isAdmin: role === 'admin'
        });
        return role === 'admin';
    }
};