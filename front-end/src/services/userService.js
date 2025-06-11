import apiClient from './api';
import { authService } from './authService';

export const userService = {
    // Lấy thông tin nhân viên theo ID tài khoản
    async getEmployeeInfo(accountId) {
        if (!accountId) {
            console.error('getEmployeeInfo called with invalid accountId:', accountId);
            throw new Error('Invalid account ID');
        }
        
        // Kiểm tra xác thực
        if (!authService.isAuthenticated()) {
            console.error('User is not authenticated');
            throw new Error('Unauthorized - Please login again');
        }
        
        console.log('Calling getEmployeeInfo with account ID:', accountId);
        try {
            const url = `/api/NhanVien/account/${accountId}`;
            console.log('Making API request to:', url);
            
            const response = await apiClient.get(url);
            console.log('API Response:', {
                status: response.status,
                headers: response.headers,
                data: response.data
            });
            return response.data;
        } catch (error) {
            console.error('API Error:', {
                message: error.message,
                response: error.response?.data,
                status: error.response?.status,
                url: `/api/NhanVien/account/${accountId}`
            });
            throw error;
        }
    },

    // Cập nhật thông tin nhân viên
    async updateEmployeeInfo(employeeId, employeeData) {
        console.log('Updating employee info:', { employeeId, employeeData });
        try {
            const response = await apiClient.put(`/api/NhanVien/${employeeId}`, employeeData);
            console.log('Update response:', response.data);
            return response.data;
        } catch (error) {
            console.error('Update error:', {
                message: error.message,
                response: error.response?.data,
                status: error.response?.status
            });
            throw error;
        }
    },

    // Lấy danh sách người dùng (cho admin)
    async getAllUsers() {
        const response = await apiClient.get('/api/TaiKhoan');
        return response.data;
    },

    // Cập nhật quyền người dùng
    async updateUserRole(userId, roleId) {
        const response = await apiClient.put(`/api/TaiKhoan/${userId}/role`, { roleId });
        return response.data;
    },

    // Lấy danh sách khách hàng
    async getAllCustomers() {
        try {
            console.log('Fetching all customers...');
            const response = await apiClient.get('/api/KhachHang');
            console.log('Customers data received:', response.data);
            return response.data;
        } catch (error) {
            console.error('Error fetching customers:', {
                message: error.message,
                response: error.response?.data,
                status: error.response?.status
            });
            if (error.response?.status === 401) {
                throw new Error('Vui lòng đăng nhập lại');
            }
            throw new Error('Không thể tải danh sách khách hàng: ' + (error.response?.data?.message || error.message));
        }
    },

    // Tìm kiếm khách hàng theo số điện thoại
    async searchCustomersByPhone(phone) {
        try {
            console.log('Searching customers by phone:', phone);
            const response = await apiClient.get(`/api/KhachHang/search?phone=${phone}`);
            console.log('Search results:', response.data);
            return response.data;
        } catch (error) {
            console.error('Error searching customers:', {
                message: error.message,
                response: error.response?.data,
                status: error.response?.status
            });
            throw new Error('Không thể tìm kiếm khách hàng: ' + (error.response?.data?.message || error.message));
        }
    }
}; 