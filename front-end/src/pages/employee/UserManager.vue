<template>
  <div class="user-manager-container">
    <!-- Thanh điều hướng -->
    <Navbar />
    <!-- Nội dung chính -->
    <div class="content-section">
      <div class="search-header">
        <span>Tìm kiếm thông tin khách hàng:</span>
        <input
          type="text"
          v-model="searchPhone"
          placeholder="Nhập số điện thoại..."
          class="search-input"
          @input="filterCustomers"
        />
      </div>
      <div class="table-container">
        <table class="customer-table">
          <thead>
            <tr>
              <th>Tên khách hàng</th>
              <th>Số cccd</th>
              <th>Số điện thoại</th>
              <th>Mã hóa đơn</th>
              <th>Lịch sử đặt phòng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="customer in filteredCustomers" :key="customer.name">
              <td>{{ customer.name }}</td>
              <td>{{ customer.cccd }}</td>
              <td>{{ customer.phone }}</td>
              <td>{{ customer.invoice }}</td>
              <td>{{ customer.history }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/navbar.vue';

export default {
  components: { Navbar },
  data() {
    return {
      searchPhone: '',
      customers: [
        { name: 'Nguyễn Văn A', cccd: 'Đôi', phone: '0901234567', invoice: 'HD001', history: 'Phòng 101, 2025-05-20' },
        { name: 'Nguyễn Văn C', cccd: 'Đơn', phone: '0912345678', invoice: 'HD002', history: 'Phòng 102, 2025-05-21' },
        { name: 'Huỳnh Văn D', cccd: 'Đôi', phone: '0923456789', invoice: 'HD003', history: 'Phòng 103, 2025-05-22' },
        { name: 'Chu Văn L', cccd: 'Đơn', phone: '0934567890', invoice: 'HD004', history: 'Phòng 104, 2025-05-23' },
        { name: 'Hoàng Văn H', cccd: 'Premium', phone: '0945678901', invoice: 'HD005', history: 'Phòng VIP 201, 2025-05-23' },
        { name: 'Lê Văn P', cccd: 'Premium', phone: '0956789012', invoice: 'HD006', history: 'Phòng VIP 202, 2025-05-22' },
        { name: 'Huỳnh Văn D', cccd: 'Đôi', phone: '0923456789', invoice: 'HD007', history: 'Phòng 105, 2025-05-20' },
        { name: 'Chu Văn L', cccd: 'Đơn', phone: '0934567890', invoice: 'HD008', history: 'Phòng 106, 2025-05-21' },
        { name: 'Hoàng Văn H', cccd: 'Premium', phone: '0945678901', invoice: 'HD009', history: 'Phòng VIP 203, 2025-05-22' },
        { name: 'Lê Văn P', cccd: 'Premium', phone: '0956789012', invoice: 'HD010', history: 'Phòng VIP 204, 2025-05-23' },
      ],
    };
  },
  computed: {
    filteredCustomers() {
      if (!this.searchPhone) {
        return this.customers;
      }
      return this.customers.filter(customer =>
        customer.phone.toLowerCase().includes(this.searchPhone.toLowerCase())
      );
    },
  },
};
</script>

<style>
.user-manager-container {
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
.search-header {
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
.customer-table {
  width: 100%;
  border-collapse: collapse;
  background-color: #fff;
  border-radius: 0.5rem;
  overflow: hidden;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}
.customer-table th,
.customer-table td {
  padding: 0.75rem;
  text-align: left;
  border-bottom: 1px solid #ddd;
}
.customer-table th {
  background-color: #5bb790;
  color: white;
  font-weight: 600;
}
.customer-table tr:nth-child(even) {
  background-color: #f5f5f5;
}
.customer-table tr:hover {
  background-color: #e0f7fa;
  transition: background-color 0.3s;
}
</style>