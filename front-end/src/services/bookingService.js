import apiClient from './api';

export const bookingService = {
    // Lấy lịch sử đặt phòng
    async getBookingHistory(phoneNumber = '') {
        const response = await apiClient.get('/api/DatPhong', {
            params: { phoneNumber }
        });
        return response.data;
    },

    // Lấy chi tiết đặt phòng
    async getBookingDetails(bookingId) {
        const response = await apiClient.get(`/api/DatPhong/${bookingId}`);
        return response.data;
    },

    // Tạo đặt phòng mới
    async createBooking(bookingData) {
        const response = await apiClient.post('/api/DatPhong', bookingData);
        return response.data;
    },

    // Tạo chi tiết đặt phòng mới
    async createBookingDetail(bookingDetailData) {
        const response = await apiClient.post('/api/ChiTietDatPhong', bookingDetailData);
        return response.data;
    },

    // Lấy tất cả chi tiết đặt phòng
    async getAllBookingDetails() {
        const response = await apiClient.get('/api/ChiTietDatPhong');
        return response.data;
    }
}; 