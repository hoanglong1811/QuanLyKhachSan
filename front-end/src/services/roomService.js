import apiClient from './api';

export const roomService = {
    // Lấy danh sách phòng
    async getAllRooms() {
        const response = await apiClient.get('/api/Phong');
        return response.data;
    },

    // Lấy danh sách loại phòng
    async getRoomTypes() {
        const response = await apiClient.get('/api/LoaiPhong');
        return response.data;
    },

    // Lấy thông tin đặt phòng của một phòng
    async getRoomBookingInfo(roomId) {
        try {
            const response = await apiClient.get(`/api/ChiTietDatPhong/phong/${roomId}`);
            if (response.data && response.data.length > 0) {
                // Lấy thông tin chi tiết của đặt phòng mới nhất
                const latestBooking = response.data[0];
                const datPhongResponse = await apiClient.get(`/api/DatPhong/${latestBooking.idDatPhong}`);
                const khachHangResponse = await apiClient.get(`/api/KhachHang/${datPhongResponse.data.idKhachHang}`);
                
                return {
                    tenKhachHang: khachHangResponse.data.tenKhachHang,
                    ngayDatPhong: datPhongResponse.data.ngayDatPhong,
                    ngayTraPhong: datPhongResponse.data.ngayTraPhong,
                    trangThaiDatPhong: datPhongResponse.data.trangThaiDatPhong
                };
            }
            return null;
        } catch (error) {
            console.error('Lỗi khi lấy thông tin đặt phòng:', error);
            return null;
        }
    },

    // Cập nhật thông tin phòng
    async updateRoom(roomId, updateData) {
        const response = await apiClient.put(`/api/Phong/${roomId}`, {
            idLoaiPhong: updateData.idLoaiPhong,
            soPhong: updateData.soPhong,
            sucChua: updateData.sucChua,
            trangThai: updateData.trangThai
        });
        return response.data;
    },

    // Lấy thông tin chi tiết phòng
    async getRoomDetails(roomId) {
        const response = await apiClient.get(`/api/Phong/${roomId}`);
        return response.data;
    }
}; 