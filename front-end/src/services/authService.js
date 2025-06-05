import apiClient from './api';

export const authService = {
    // Đăng nhập
    async login(credentials) {
        try {
            const response = await apiClient.post('/api/auth/login', credentials);
            if (response.data.token) {
                localStorage.setItem('token', response.data.token);
            }
            return response.data;
        } catch (error) {
            throw error;
        }
    },

    // Đăng xuất
    async logout() {
        try {
            await apiClient.post('/api/auth/logout');
            localStorage.removeItem('token');
        } catch (error) {
            throw error;
        }
    },

    // Kiểm tra trạng thái đăng nhập
    isAuthenticated() {
        return !!localStorage.getItem('token');
    }
}; 