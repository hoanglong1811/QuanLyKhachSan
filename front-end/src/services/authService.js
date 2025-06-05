import apiClient from './api';

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
            console.log('Response data structure:', {
                hasData: !!response.data,
                dataType: typeof response.data,
                dataKeys: response.data ? Object.keys(response.data) : [],
                dataValues: response.data
            });

            if (response.data) {
                // Tạm thời tạo một token giả cho phiên đăng nhập
                const tempToken = btoa(JSON.stringify({
                    id: response.data.idTaiKhoan,
                    username: response.data.tenDangNhap,
                    role: response.data.idVaiTro,
                    exp: new Date().getTime() + (24 * 60 * 60 * 1000) // 24 giờ
                }));

                // Lưu token
                localStorage.setItem('token', tempToken);
                console.log('Temporary token saved to localStorage');

                // Lưu thông tin user
                const userInfo = {
                    id: response.data.idTaiKhoan,
                    username: response.data.tenDangNhap,
                    email: response.data.email,
                    role: response.data.idVaiTro
                };
                localStorage.setItem('user', JSON.stringify(userInfo));
                console.log('User info saved:', userInfo);

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
                status: error.response?.status,
                stack: error.stack
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
            // Giải mã token để kiểm tra hết hạn
            const tokenData = JSON.parse(atob(token));
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
            return userStr ? JSON.parse(userStr) : null;
        } catch {
            return null;
        }
    },

    // Lấy role của user
    getUserRole() {
        const user = this.getCurrentUser();
        return user ? user.role : null;
    }
};