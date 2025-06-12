<template>
  <div class="dashboard-container">
    <!-- Thanh điều hướng -->
    <Navbar/>
    <!-- Nội dung chính -->
    <div class="content-section">
      <div class="status-header">
        <div class="filter-section">
          <span>Loại phòng:</span>
          <select v-model="selectedRoomType" @change="filterRooms">
            <option value="all">Tất cả</option>
            <option v-for="type in roomTypes" :key="type.idLoaiPhong" :value="type.idLoaiPhong">
              {{ type.tenLoaiPhong }}
            </option>
          </select>
        </div>
      </div>

      <!-- Loading state -->
      <div v-if="loading" class="loading-overlay">
        <div class="spinner"></div>
      </div>

      <!-- Error message -->
      <div v-if="error" class="error-message">
        {{ error }}
      </div>

      <div class="room-grid">
        <div :class="['room-card', statusClass(room.trangThai)]" v-for="room in filteredRooms" :key="room.idPhong" @click="handleRoomClick(room)">
          <div class="room-header">
            <span class="room-number">Phòng {{ room.soPhong }}</span>
            <span :class="['room-status', room.trangThai?.toLowerCase()]">{{ room.trangThai }}</span>
          </div>
          
          <div class="room-info">
            <div class="info-row">
              <span class="label">Loại phòng:</span>
              <span class="value">{{ getRoomTypeName(room.idLoaiPhong) }}</span>
            </div>
            <div class="info-row">
              <span class="label">Sức chứa:</span>
              <span class="value">{{ room.sucChua }} người</span>
            </div>
            
            <!-- Thông tin đặt phòng/thuê phòng -->
            <div v-if="room.bookingInfo" class="booking-info">
              <div class="info-row">
                <span class="label">Khách hàng:</span>
                <span class="value">{{ room.bookingInfo.tenKhachHang }}</span>
              </div>
              <div class="info-row">
                <span class="label">Thời gian:</span>
                <span class="value">
                  {{ formatDate(room.bookingInfo.ngayDatPhong) }} - 
                  {{ formatDate(room.bookingInfo.ngayTraPhong) }}
                </span>
              </div>
              <div class="info-row">
                <span class="label">Trạng thái:</span>
                <span :class="['booking-status', room.bookingInfo.trangThaiDatPhong?.toLowerCase()]">
                  {{ room.bookingInfo.trangThaiDatPhong }}
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Modal cập nhật trạng thái phòng -->
    <div v-if="showUpdateModal" class="modal-overlay" @click="closeUpdateModal">
      <div class="modal-content" @click.stop>
        <h2>Cập nhật thông tin phòng {{ selectedRoom?.soPhong }}</h2>
        
        <div class="modal-body">
          <div class="form-group">
            <label>Số phòng:</label>
            <input type="number" v-model="updateForm.soPhong" readonly class="readonly-input" />
          </div>

          <div class="form-group">
            <label>Trạng thái phòng:</label>
            <select v-model="updateForm.trangThai">
              <option value="Trống">Trống</option>
              <option value="Đã đặt">Đã đặt</option>
              <option value="Đang thuê">Đang thuê</option>
              <option value="Đang dọn">Đang dọn</option>
              <option value="Đang bảo trì">Đang bảo trì</option>
            </select>
          </div>

          <div class="form-group">
            <label>Sức chứa:</label>
            <input type="number" v-model="updateForm.sucChua" min="1" />
          </div>
        </div>

        <div class="modal-footer">
          <button class="btn-cancel" @click="closeUpdateModal">Hủy</button>
          <button class="btn-save" @click="saveRoomUpdate" :disabled="loading">
            {{ loading ? 'Đang lưu...' : 'Lưu thay đổi' }}
          </button>
        </div>
      </div>
    </div>

    <!-- Modal đặt phòng -->
    <div v-if="showBookingModal" class="modal-overlay" @click="closeBookingModal">
      <div class="modal-content" @click.stop>
        <h2>Đặt phòng {{ selectedRoom?.soPhong }}</h2>

        <div class="modal-body">
          <div class="form-group">
            <label>Số điện thoại:</label>
            <div style="display:flex; gap:0.5rem; align-items:center;">
              <input type="tel" v-model="bookingForm.phone" placeholder="Nhập SĐT khách hàng" style="flex:1;" />
              <button class="btn-save" @click="searchCustomer" :disabled="!bookingForm.phone || loadingSearch">
                {{ loadingSearch ? 'Đang tìm...' : 'Tìm' }}
              </button>
            </div>
          </div>

          <div class="form-group">
            <label>Tên khách hàng:</label>
            <input type="text" v-model="bookingForm.name" :readonly="customerFound" placeholder="Nhập tên khách hàng" />
          </div>

          <div class="form-group">
            <label>CCCD:</label>
            <input type="text" v-model="bookingForm.cccd" :readonly="customerFound" placeholder="Nhập CCCD khách hàng" />
          </div>

          <div class="form-group">
            <label>Ngày nhận phòng:</label>
            <input type="date" v-model="bookingForm.checkIn" />
          </div>

          <div class="form-group">
            <label>Ngày trả phòng:</label>
            <input type="date" v-model="bookingForm.checkOut" :min="bookingForm.checkIn" />
          </div>

          <div class="form-group">
            <label>Số người lớn:</label>
            <input type="number" v-model.number="bookingForm.adults" min="1" />
          </div>

          <div class="form-group">
            <label>Số trẻ em:</label>
            <input type="number" v-model.number="bookingForm.children" min="0" />
          </div>

          <div class="form-group">
            <label>Ghi chú:</label>
            <textarea v-model="bookingForm.note" rows="2" placeholder="Ghi chú (tuỳ chọn)"></textarea>
          </div>
        </div>

        <div class="modal-footer">
          <button class="btn-cancel" @click="closeBookingModal">Hủy</button>
          <button class="btn-save" @click="confirmBooking" :disabled="loading">
            {{ loading ? 'Đang lưu...' : 'Đặt phòng' }}
          </button>
        </div>
      </div>
    </div>

    <!-- Modal thêm dịch vụ -->
    <div v-if="showServiceModal" class="modal-overlay" @click="closeServiceModal">
      <div class="modal-content" @click.stop>
        <h2>Thêm dịch vụ cho phòng {{ selectedRoom?.soPhong }}</h2>

        <div class="modal-body">
          <div class="form-group">
            <label>Dịch vụ:</label>
            <select v-model="serviceForm.serviceId" @change="handleServiceSelect">
              <option value="">Chọn dịch vụ</option>
              <option v-for="service in services" :key="service.id" :value="service.id">
                {{ service.name }} - {{ formatPrice(service.price) }}
              </option>
            </select>
          </div>

          <div class="form-group">
            <label>Số lượng:</label>
            <input type="number" v-model="serviceForm.quantity" min="1" />
          </div>

          <div class="form-group">
            <label>Ghi chú:</label>
            <textarea v-model="serviceForm.note" rows="2" placeholder="Ghi chú (tuỳ chọn)"></textarea>
          </div>

          <div class="total-price" v-if="serviceForm.serviceId && serviceForm.quantity">
            <span>Tổng tiền:</span>
            <span class="price">{{ formatPrice(calculateTotalPrice()) }}</span>
          </div>
        </div>

        <div class="modal-footer">
          <button class="btn-cancel" @click="closeServiceModal">Hủy</button>
          <button class="btn-save" @click="handleAddService" :disabled="loading">
            {{ loading ? 'Đang lưu...' : 'Thêm dịch vụ' }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '../../components/navbar.vue';
import { roomService } from '@/services/roomService';
import { authService } from '@/services/authService';
import { userService } from '@/services/userService';
import { bookingService } from '@/services/bookingService';
import axios from 'axios';

export default {
  components: {
    Navbar,
  },
  data() {
    return {
      selectedRoomType: 'all',
      rooms: [],
      roomTypes: [],
      loading: false,
      error: '',
      user: null,
      showUpdateModal: false,
      selectedRoom: null,
      updateForm: {
        trangThai: '',
        sucChua: 1,
        soPhong: null,
        idLoaiPhong: null
      },
      showBookingModal: false,
      bookingForm: {
        phone: '',
        name: '',
        cccd: '',
        checkIn: '',
        checkOut: '',
        adults: 1,
        children: 0,
        note: '',
        customerId: null
      },
      customerFound: false,
      loadingSearch: false,
      showServiceModal: false,
      serviceForm: {
        serviceId: '',
        quantity: 1,
        note: ''
      },
      services: [],
      roomServices: []
    };
  },
  computed: {
    filteredRooms() {
      if (this.selectedRoomType === 'all') {
        return this.rooms;
      }
      return this.rooms.filter(room => room.idLoaiPhong === this.selectedRoomType);
    },
    selectedService() {
      return this.services.find(s => s.id === this.serviceForm.serviceId);
    }
  },
  methods: {
    formatDate(date) {
      if (!date) return '';
      return new Date(date).toLocaleDateString('vi-VN', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
      });
    },
    getRoomTypeName(idLoaiPhong) {
      const roomType = this.roomTypes.find(type => type.idLoaiPhong === idLoaiPhong);
      return roomType ? roomType.tenLoaiPhong : 'Không xác định';
    },
    async fetchRoomTypes() {
      try {
        const response = await roomService.getRoomTypes();
        this.roomTypes = response;
      } catch (err) {
        console.error('Lỗi khi lấy danh sách loại phòng:', err);
      }
    },
    async fetchRooms() {
      this.loading = true;
      this.error = '';
      try {
        const response = await roomService.getAllRooms();
        this.rooms = await Promise.all(response.map(async room => {
          let bookingInfo = null;
          if (room.trangThai && room.trangThai.toLowerCase() !== 'trống') {
            bookingInfo = await roomService.getRoomBookingInfo(room.idPhong);
          }
          return {
            ...room,
            soPhong: room.soPhong || '',
            bookingInfo
          };
        }));
      } catch (err) {
        this.error = 'Không thể tải danh sách phòng';
        console.error(err);
      } finally {
        this.loading = false;
      }
    },
    openUpdateModal(room) {
      this.selectedRoom = { ...room };  // Tạo bản sao của room
      this.updateForm = {
        trangThai: room.trangThai || 'Trống',
        sucChua: room.sucChua || 1,
        soPhong: room.soPhong,
        idLoaiPhong: room.idLoaiPhong
      };
      this.showUpdateModal = true;
    },
    closeUpdateModal() {
      this.showUpdateModal = false;
      this.selectedRoom = null;
      this.updateForm = {
        trangThai: '',
        sucChua: 1,
        soPhong: null,
        idLoaiPhong: null
      };
    },
    async saveRoomUpdate() {
      if (!this.selectedRoom) return;

      this.loading = true;
      try {
        const updateData = {
          trangThai: this.updateForm.trangThai,
          sucChua: this.updateForm.sucChua,
          soPhong: this.selectedRoom.soPhong, // Sử dụng số phòng từ selectedRoom
          idLoaiPhong: this.selectedRoom.idLoaiPhong
        };
        await roomService.updateRoom(this.selectedRoom.idPhong, updateData);
        if (updateData.trangThai.toLowerCase() === 'trống') {
          this.selectedRoom.bookingInfo = null;
        }
        await this.fetchRooms();
        this.closeUpdateModal();
      } catch (err) {
        this.error = 'Không thể cập nhật thông tin phòng';
        console.error(err);
      } finally {
        this.loading = false;
      }
    },
    filterRooms() {
      // Trigger computed property
    },
    handleRoomClick(room) {
      // Nếu phòng trống thì mở modal đặt phòng
      if (room.trangThai?.toLowerCase() === 'trống') {
        this.openBookingModal(room);
      } 
      // Nếu phòng đã đặt hoặc đang thuê thì mở modal thêm dịch vụ
      else if (room.trangThai?.toLowerCase() === 'đã đặt' || room.trangThai?.toLowerCase() === 'đang thuê') {
        this.selectedRoom = { ...room };
        this.openServiceModal();
      }
      // Các trường hợp khác mở modal cập nhật thông tin
      else {
        this.openUpdateModal(room);
      }
    },
    openBookingModal(room) {
      this.selectedRoom = { ...room };
      this.bookingForm = {
        phone: '',
        name: '',
        cccd: '',
        checkIn: '',
        checkOut: '',
        adults: 1,
        children: 0,
        note: '',
        customerId: null
      };
      this.customerFound = false;
      this.showBookingModal = true;
    },
    closeBookingModal() {
      this.showBookingModal = false;
      this.selectedRoom = null;
    },
    async searchCustomer() {
      if (!this.bookingForm.phone) return;
      this.loadingSearch = true;
      try {
        const result = await userService.searchCustomersByPhone(this.bookingForm.phone);
        if (result && result.length > 0) {
          const customer = result[0];
          this.bookingForm.name = customer.hoTen || customer.HoTen || '';
          this.bookingForm.cccd = customer.cccd || customer.Cccd || '';
          this.customerFound = true;
          this.bookingForm.customerId = customer.idKhachHang || customer.IdKhachHang;
        } else {
          this.customerFound = false;
          this.$toast?.info?.('Không tìm thấy khách hàng, vui lòng nhập tên để tạo mới.');
        }
      } catch (error) {
        console.error('searchCustomer error:', error);
        this.$toast?.error?.('Lỗi khi tìm khách hàng');
      } finally {
        this.loadingSearch = false;
      }
    },
    async confirmBooking() {
      // Kiểm tra dữ liệu bắt buộc
      if (!this.bookingForm.phone || !this.bookingForm.name || !this.bookingForm.checkIn || !this.bookingForm.checkOut) {
        alert('Vui lòng nhập đầy đủ thông tin bắt buộc');
        return;
      }
      this.loading = true;
      try {
        // B1: Lấy hoặc tạo khách hàng
        let customerId = this.bookingForm.customerId;
        if (!customerId) {
          const newCustomer = await userService.createCustomer({
            hoTen: this.bookingForm.name,
            dienThoai: parseInt(this.bookingForm.phone, 10),
            cccd: this.bookingForm.cccd || ''
          });
          customerId = newCustomer.idKhachHang || newCustomer.IdKhachHang;
        }

        // B2: Tạo đặt phòng
        const booking = await bookingService.createBooking({ idKhachHang: customerId });
        const bookingId = booking.idDatPhong || booking.IdDatPhong;

        // B3: Tạo chi tiết đặt phòng
        const totalGuests = parseInt(this.bookingForm.adults) + parseInt(this.bookingForm.children);
        await bookingService.createBookingDetail({
          idPhong: this.selectedRoom.idPhong,
          idDatPhong: bookingId,
          idKhachHang: customerId,
          ngayDatPhong: this.bookingForm.checkIn,
          ngayTraPhong: this.bookingForm.checkOut,
          soLuongNguoi: totalGuests,
          phuongThucThanhToan: JSON.stringify({ note: this.bookingForm.note, adults: this.bookingForm.adults, children: this.bookingForm.children }),
          thanhTien: null
        });

        // B4: Cập nhật trạng thái phòng sang "Đã đặt"
        await roomService.updateRoom(this.selectedRoom.idPhong, {
          trangThai: 'Đã đặt',
          sucChua: this.selectedRoom.sucChua,
          soPhong: this.selectedRoom.soPhong,
          idLoaiPhong: this.selectedRoom.idLoaiPhong
        });

        this.$toast?.success?.('Đặt phòng thành công!');
        await this.fetchRooms();
        this.closeBookingModal();
      } catch (err) {
        console.error(err);
        this.$toast?.error?.('Không thể đặt phòng');
      } finally {
        this.loading = false;
      }
    },
    statusClass(trangThai) {
      if (!trangThai) return '';
      const key = trangThai.toLowerCase();
      if (key.includes('đã đặt')) return 'booked';
      if (key.includes('đang thuê')) return 'rented';
      if (key.includes('đang dọn')) return 'cleaning';
      if (key.includes('đang bảo trì')) return 'maintenance';
      return '';
    },
    openServiceModal() {
      this.showServiceModal = true;
      this.fetchServices();
    },
    closeServiceModal() {
      this.showServiceModal = false;
      this.serviceForm = {
        serviceId: '',
        quantity: 1,
        note: ''
      };
    },
    async fetchServices() {
      try {
        const response = await axios.get('http://localhost:5012/api/DichVu', {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });
        this.services = response.data.map(service => ({
          id: service.idDichVu,
          name: service.tenDichVu,
          price: service.gia,
          description: service.moTa,
          unit: service.donViTinh
        }));
      } catch (error) {
        console.error('Error fetching services:', error);
        alert('Không thể tải danh sách dịch vụ. Vui lòng thử lại sau.');
      }
    },
    handleServiceSelect() {
      this.serviceForm.quantity = 1;
    },
    calculateTotalPrice() {
      if (!this.selectedService) return 0;
      return this.selectedService.price * this.serviceForm.quantity;
    },
    async handleAddService() {
      if (!this.serviceForm.serviceId || !this.serviceForm.quantity) {
        alert('Vui lòng điền đầy đủ thông tin');
        return;
      }

      this.loading = true;
      try {
        // 1. Lấy thông tin đặt phòng từ ChiTietDatPhongController
        const datPhongResponse = await axios.get(`http://localhost:5012/api/ChiTietDatPhong/room/${this.selectedRoom.idPhong}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        // 2. Tạo chi tiết dịch vụ
        const chiTietDichVu = await axios.post('http://localhost:5012/api/ChiTietDichVu', {
          idDatPhong: datPhongResponse.data.idDatPhong,
          idDichVu: this.serviceForm.serviceId,
          soLuong: this.serviceForm.quantity,
          donGia: this.selectedService.price,
          thanhTien: this.calculateTotalPrice(),
          ghiChu: this.serviceForm.note,
          ngaySuDung: new Date().toISOString(),
          trangThai: 'Chưa thanh toán'
        }, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        // 3. Tạo chi tiết hóa đơn
        await axios.post('http://localhost:5012/api/ChiTietHoaDon', {
          idDatPhong: datPhongResponse.data.idDatPhong,
          idChiTietDichVu: chiTietDichVu.data.idChiTietDichVu,
          thanhTien: this.calculateTotalPrice(),
          ghiChu: this.serviceForm.note
        }, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        alert('Thêm dịch vụ thành công!');
        this.serviceForm = {
          serviceId: '',
          quantity: 1,
          note: ''
        };
        this.closeServiceModal();
      } catch (error) {
        console.error('Error adding service:', error);
        alert('Không thể thêm dịch vụ. Vui lòng thử lại sau.');
      } finally {
        this.loading = false;
      }
    },
    formatPrice(price) {
      return price.toLocaleString('vi-VN') + ' VND';
    }
  },
  async created() {
    this.user = authService.getCurrentUser();
    if (!this.user) {
      this.$router.push('/login');
      return;
    }
    await this.fetchRoomTypes();
    await this.fetchRooms();
  },
};
</script>

<style scoped>
.dashboard-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background-color: #f5f5f5;
}

.content-section {
  flex: 1;
  padding: 1.5rem;
  overflow-y: auto;
}

.loading-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(255, 255, 255, 0.8);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.spinner {
  width: 50px;
  height: 50px;
  border: 5px solid #f3f3f3;
  border-top: 5px solid #5bb790;
  border-radius: 50%;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.error-message {
  background-color: #ffebee;
  color: #c62828;
  padding: 1rem;
  margin: 1rem;
  border-radius: 0.5rem;
  text-align: center;
}

.room-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 1rem;
  padding: 1rem;
}

.room-card {
  background: white;
  border-radius: 0.5rem;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
  padding: 1rem;
  transition: transform 0.2s, box-shadow 0.3s;
  cursor: pointer;
}

.room-card:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 8px rgba(0,0,0,0.15);
}

.room-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
  padding-bottom: 0.5rem;
  border-bottom: 1px solid #eee;
}

.room-number {
  font-size: 1.25rem;
  font-weight: 600;
  color: #2c3e50;
}

.room-status {
  padding: 0.25rem 0.75rem;
  border-radius: 1rem;
  font-size: 0.875rem;
  font-weight: 500;
}

.room-status.trống {
  background-color: #e8f5e9;
  color: #2e7d32;
}

.room-status.đã-đặt {
  background-color: #fff3e0;
  color: #ef6c00;
}

.room-status.đang-thuê {
  background-color: #e3f2fd;
  color: #1976d2;
}

.info-row {
  display: flex;
  justify-content: space-between;
  margin-bottom: 0.5rem;
}

.label {
  color: #666;
  font-size: 0.875rem;
}

.value {
  color: #2c3e50;
  font-weight: 500;
}

.booking-info {
  margin-top: 1rem;
  padding-top: 1rem;
  border-top: 1px dashed #eee;
}

.booking-status {
  padding: 0.25rem 0.5rem;
  border-radius: 0.25rem;
  font-size: 0.75rem;
  font-weight: 500;
}

.booking-status.đã-xác-nhận {
  background-color: #e8f5e9;
  color: #2e7d32;
}

.booking-status.chờ-xác-nhận {
  background-color: #fff3e0;
  color: #ef6c00;
}

.filter-section {
  display: flex;
  align-items: center;
  gap: 1rem;
  margin-bottom: 1rem;
}

.filter-section select {
  padding: 0.5rem;
  border: 1px solid #ddd;
  border-radius: 0.25rem;
  font-size: 0.875rem;
  color: #333;
  min-width: 150px;
}

.filter-section select:focus {
  outline: none;
  border-color: #5bb790;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal-content {
  background: white;
  border-radius: 0.5rem;
  padding: 1.5rem;
  width: 90%;
  max-width: 500px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.modal-content h2 {
  margin: 0 0 1.5rem 0;
  color: #2c3e50;
  font-size: 1.25rem;
}

.modal-body {
  margin-bottom: 1.5rem;
}

.form-group {
  margin-bottom: 1rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  color: #666;
  font-weight: 500;
}

.form-group select,
.form-group input {
  width: 100%;
  padding: 0.5rem;
  border: 1px solid #ddd;
  border-radius: 0.25rem;
  font-size: 1rem;
  color: #333;
}

.form-group select:focus,
.form-group input:focus {
  outline: none;
  border-color: #5bb790;
}

.modal-footer {
  display: flex;
  justify-content: flex-end;
  gap: 1rem;
}

.btn-cancel,
.btn-save {
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 0.25rem;
  font-size: 0.875rem;
  cursor: pointer;
  transition: all 0.3s;
}

.btn-cancel {
  background: #e0e0e0;
  color: #333;
}

.btn-save {
  background: #5bb790;
  color: white;
}

.btn-cancel:hover {
  background: #bdbdbd;
}

.btn-save:hover {
  background: #4caf50;
}

.btn-save:disabled {
  background: #a5d6a7;
  cursor: not-allowed;
}

/* Thêm style cho input readonly */
.readonly-input {
  background-color: #f5f5f5;
  cursor: not-allowed;
}

.readonly-input:focus {
  border-color: #ddd;
}

.room-card.booked {
  border: 2px solid #ef6c00;
  background-color: #fff3e0;
}

.room-card.rented {
  border: 2px solid #1976d2;
  background-color: #e3f2fd;
}

.room-card.cleaning {
  border: 2px solid #fdd835;
  background-color: #fffde7;
}

.room-card.maintenance {
  border: 2px solid #c62828;
  background-color: #ffebee;
}

/* Header border color */
.room-card.booked .room-header { border-bottom-color: #ef6c00; }
.room-card.rented .room-header { border-bottom-color: #1976d2; }
.room-card.cleaning .room-header { border-bottom-color: #fdd835; }
.room-card.maintenance .room-header { border-bottom-color: #c62828; }

/* Status pill colors already exist; bổ sung thêm */
.room-status.đang-dọn {
  background-color: #fffde7;
  color: #fbc02d;
}

.room-status.đang-bảo-trì {
  background-color: #ffebee;
  color: #c62828;
}

.status-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1.5rem;
}

@media (max-width: 768px) {
  .status-header {
    flex-direction: column;
    gap: 1rem;
  }
}
</style>