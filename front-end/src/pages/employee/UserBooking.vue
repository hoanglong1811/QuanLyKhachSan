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
              <th>Phòng</th>
              <th>Ngày đặt</th>
              <th>Ngày trả</th>
              <th>Trạng thái</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="booking in filteredBookings" :key="booking.id">
              <td>{{ booking.customerName }}</td>
              <td>{{ booking.phone }}</td>
              <td>{{ booking.room }}</td>
              <td>{{ booking.checkInDate }}</td>
              <td>{{ booking.checkOutDate }}</td>
              <td :class="booking.status === 'Đã xác nhận' ? 'status-confirmed' : 'status-pending'">
                {{ booking.status }}
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue';

export default {
  components: { Navbar },
  data() {
    return {
      searchPhone: '',
      bookings: [
        { id: 1, customerName: 'Nguyễn Văn A', phone: '0901234567', room: 'Phòng 101', checkInDate: '2025-05-20', checkOutDate: '2025-05-23', status: 'Đã xác nhận' },
        { id: 2, customerName: 'Nguyễn Văn C', phone: '0912345678', room: 'Phòng 102', checkInDate: '2025-05-21', checkOutDate: '2025-05-24', status: 'Đã xác nhận' },
        { id: 3, customerName: 'Huỳnh Văn D', phone: '0923456789', room: 'Phòng 103', checkInDate: '2025-05-22', checkOutDate: '2025-05-25', status: 'Đang chờ' },
        { id: 4, customerName: 'Chu Văn L', phone: '0934567890', room: 'Phòng 104', checkInDate: '2025-05-23', checkOutDate: '2025-05-26', status: 'Đã xác nhận' },
        { id: 5, customerName: 'Hoàng Văn H', phone: '0945678901', room: 'Phòng VIP 201', checkInDate: '2025-05-23', checkOutDate: '2025-05-27', status: 'Đang chờ' },
        { id: 6, customerName: 'Lê Văn P', phone: '0956789012', room: 'Phòng VIP 202', checkInDate: '2025-05-22', checkOutDate: '2025-05-24', status: 'Đã xác nhận' },
        { id: 7, customerName: 'Trần Thị B', phone: '0967890123', room: 'Phòng 105', checkInDate: '2025-05-20', checkOutDate: '2025-05-22', status: 'Đã xác nhận' },
        { id: 8, customerName: 'Phạm Văn E', phone: '0978901234', room: 'Phòng 106', checkInDate: '2025-05-21', checkOutDate: '2025-05-23', status: 'Đang chờ' },
      ],
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
  background-color: #5bb790;
  color: white;
  font-weight: 600;
}
.booking-table tr:nth-child(even) {
  background-color: #f5f5f5;
}
.booking-table tr:hover {
  background-color: #e0f7fa;
  transition: background-color 0.3s;
}
.status-confirmed {
  color: #4caf50;
  font-weight: 500;
}
.status-pending {
  color: #ff9800;
  font-weight: 500;
}
</style>