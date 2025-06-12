<template>
  <div class="user-booking-container">
    <!-- Thanh điều hướng -->
    <Navbar />
    <!-- Nội dung chính -->
    <div class="content-section">
      <div class="booking-header">
        <span>Thông tin đặt phòng của khách hàng:</span>
        <input
          type="text"
          v-model="searchPhone"
          placeholder="Nhập số điện thoại..."
          class="search-input"
          @input="filterBookings"
        />
      </div>
      <div class="table-container">
        <table class="booking-table">
          <thead>
            <tr>
              <th>Tên khách hàng</th>
              <th>Số điện thoại</th>
              <th>CCCD</th>
              <th>Phòng</th>
              <th>Ngày nhận</th>
              <th>Ngày trả</th>
              <th>Trạng thái</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="booking in filteredBookings" :key="booking.id" @click="openDetailModal(booking)" style="cursor:pointer;">
              <td>{{ booking.customerName }}</td>
              <td>{{ booking.phone }}</td>
              <td>{{ booking.cccd }}</td>
              <td>{{ booking.room }}</td>
              <td>{{ booking.checkInDate }}</td>
              <td>{{ booking.checkOutDate }}</td>
              <td :class="booking.status === 'Đang thuê' ? 'status-rented' : 'status-booked'">
                {{ booking.status }}
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <!-- Detail Modal -->
    <div v-if="showDetailModal" class="modal-overlay" @click="closeDetailModal">
      <div class="modal-content" @click.stop>
        <h3>Chi tiết đặt phòng</h3>
        <div class="modal-body">
          <p><strong>Tên khách hàng:</strong> {{ selectedBooking.customerName }}</p>
          <p><strong>Số điện thoại:</strong> {{ selectedBooking.phone }}</p>
          <p><strong>CCCD:</strong> {{ selectedBooking.cccd }}</p>
          <p><strong>Phòng:</strong> {{ selectedBooking.room }}</p>
          <p><strong>Ngày nhận:</strong> {{ selectedBooking.checkInDate }}</p>
          <p><strong>Ngày trả:</strong> {{ selectedBooking.checkOutDate }}</p>
          <p><strong>Số người lớn:</strong> {{ selectedBooking.adults }}</p>
          <p><strong>Số trẻ em:</strong> {{ selectedBooking.children }}</p>
          <p><strong>Ghi chú:</strong> {{ selectedBooking.note || '---' }}</p>
        </div>
        <div class="modal-footer">
          <button @click="closeDetailModal" class="btn-close">Đóng</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import Navbar from '@/components/navbar.vue';
import { bookingService } from '@/services/bookingService';
import { roomService } from '@/services/roomService';
import { userService } from '@/services/userService';
import { authService } from '@/services/authService';

export default {
  components: { Navbar },
  data() {
    return {
      searchPhone: '',
      bookings: [],
      loading: false,
      error: '',
      user: null,
      showDetailModal: false,
      selectedBooking: {}
    };
  },
  computed: {
    filteredBookings() {
      if (!this.searchPhone) {
        return this.bookings;
      }
      return this.bookings.filter(booking =>
        booking.phone.toLowerCase().includes(this.searchPhone.toLowerCase())
      );
    },
  },
  methods: {
    async fetchBookings() {
      this.loading = true;
      this.error = '';
      try {
        // Lấy danh sách chi tiết đặt phòng
        const [details, rooms, customers] = await Promise.all([
          bookingService.getAllBookingDetails(),
          roomService.getAllRooms(),
          userService.getAllCustomers()
        ]);

        // Map theo id để tra nhanh
        const roomMap = Object.fromEntries(rooms.map(r => [r.idPhong, r]));
        const customerMap = Object.fromEntries(customers.map(c => [c.idKhachHang || c.IdKhachHang, c]));

        const now = new Date();

        // Chỉ lấy những booking chưa hết hạn
        const list = details.map(d => {
          const cust = customerMap[d.idKhachHang];
          const room = roomMap[d.idPhong];
          const checkIn = new Date(d.ngayDatPhong);
          const checkOut = new Date(d.ngayTraPhong);
          let status = 'Đã đặt';
          if (now >= checkIn && now <= checkOut) status = 'Đang thuê';
          const meta = d.meta ? JSON.parse(d.meta) : {};
          return {
            id: d.idChiTietDatPhong,
            customerName: cust?.hoTen || cust?.HoTen || 'N/A',
            phone: cust?.dienThoai || cust?.DienThoai || 'N/A',
            cccd: cust?.cccd || cust?.Cccd || 'N/A',
            room: room?.soPhong || room?.SoPhong || d.idPhong,
            checkInDate: checkIn.toLocaleDateString('vi-VN'),
            checkOutDate: checkOut.toLocaleDateString('vi-VN'),
            status,
            note: meta.note || '',
            adults: meta.adults || 0,
            children: meta.children || 0
          };
        });

        this.bookings = list;
      } catch (err) {
        this.error = 'Không thể tải danh sách đặt phòng';
        console.error(err);
      } finally {
        this.loading = false;
      }
    },
    async filterBookings() {
      await this.fetchBookings();
    },
    openDetailModal(booking) {
      this.selectedBooking = booking;
      this.showDetailModal = true;
    },
    closeDetailModal() {
      this.showDetailModal = false;
      this.selectedBooking = {};
    }
  },
  async created() {
    this.user = authService.getCurrentUser();
    if (!this.user) {
      this.$router.push('/login');
      return;
    }
    await this.fetchBookings();
  }
};
</script>

<style>
.user-booking-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background-color: #fff;
}
.content-section {
  flex: 1;
  display: flex;
  flex-direction: column;
  padding: 1.5rem;
  background-color: #f9f9f9;
  gap: 1rem;
  overflow-y: auto;
}
.booking-header {
  display: flex;
  align-items: center;
  gap: 1rem;
  font-size: 1rem;
  color: #333;
  font-weight: 500;
  margin-bottom: 1rem;
}
.search-input {
  padding: 0.5rem;
  border: 1px solid #ccc;
  border-radius: 0.25rem;
  font-size: 0.875rem;
  width: 200px;
  transition: border-color 0.3s;
}
.search-input:focus {
  outline: none;
  border-color: #5bb790;
}
.table-container {
  overflow-x: auto;
}
.booking-table {
  width: 100%;
  border-collapse: collapse;
  background-color: #fff;
  border-radius: 0.5rem;
  overflow: hidden;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}
.booking-table th,
.booking-table td {
  padding: 0.75rem;
  text-align: left;
  border-bottom: 1px solid #ddd;
}
.booking-table th {
  background: linear-gradient(135deg, var(--primary-dark), var(--primary-light));
  color: #fff;
  font-weight: 600;
}
.booking-table tr:nth-child(even) {
  background-color: #f5f5f5;
}
.booking-table tr:hover {
  background-color: rgba(52, 152, 219, 0.05);
  transition: background-color 0.3s;
}
.status-booked {
  color: #ef6c00;
  font-weight: 500;
}
.status-rented {
  color: #1976d2;
  font-weight: 500;
}
/* Modal styles */
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0,0,0,0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 2000;
}

.modal-content {
  background: #fff;
  border-radius: 8px;
  padding: 1.5rem;
  width: 90%;
  max-width: 400px;
  box-shadow: 0 2px 10px rgba(0,0,0,0.2);
}

.modal-body p {
  margin: 0.25rem 0;
}

.modal-footer {
  margin-top: 1rem;
  text-align: right;
}

.btn-close {
  padding: 0.5rem 1rem;
  background: var(--primary-light);
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.btn-close:hover {
  background: var(--primary-dark);
}

.booking-header span {
  color: var(--primary-dark);
}

.search-input {
  border-color: var(--primary-light);
}

.search-input:focus {
  border-color: var(--primary-light);
  box-shadow: 0 0 0 2px rgba(52, 152, 219, 0.2);
}

.modal-content h3 {
  margin-top: 0;
  margin-bottom: 1rem;
  color: var(--primary-dark);
  text-align: center;
}
</style>