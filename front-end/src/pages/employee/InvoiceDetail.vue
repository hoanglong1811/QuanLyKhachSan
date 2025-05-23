<!-- File: InvoiceDetail.vue -->
<template>
  <div class="min-h-screen bg-gray-100 flex items-center justify-center p-10">
    <div class="bg-white rounded-xl shadow-xl w-full max-w-7xl mx-auto p-12">
      <!-- Header Section -->
      <div class="flex justify-between items-start mb-10">
        <div>
          <h1 class="text-4xl font-extrabold text-gray-900 mb-6">Chi tiết hóa đơn</h1>
          <div class="space-y-3">
            <p class="text-lg text-gray-700"><span class="font-semibold">Mã hóa đơn:</span> {{ invoice.invoiceId }}</p>
            <p class="text-lg text-gray-700"><span class="font-semibold">Tên khách hàng:</span> {{ invoice.customerInfo }}</p>
            <p class="text-lg text-gray-700">
              <span class="font-semibold">Trạng thái:</span>
              <span :class="invoice.status === 'ĐÃ THANH TOÁN' ? 'text-green-600 font-semibold' : 'text-red-600 font-semibold'">
                {{ invoice.status }}
              </span>
            </p>
          </div>
        </div>
        <div class="text-right">
          <p class="text-lg text-gray-700"><span class="font-semibold">Ngày lập:</span> {{ invoice.date }}</p>
          <p class="text-lg text-gray-700"><span class="font-semibold">Giờ lập:</span> {{ invoice.time }}</p>
        </div>
      </div>

      <!-- Service/Room Table -->
      <div class="mb-12">
        <table class="w-full border-collapse bg-white rounded-lg shadow-md">
          <thead>
            <tr class="bg-gray-200 text-gray-800">
              <th class="border-b p-5 text-left text-lg font-semibold">Tên dịch vụ/phòng</th>
              <th class="border-b p-5 text-left text-lg font-semibold">Giá (VND)</th>
              <th class="border-b p-5 text-left text-lg font-semibold">Số lượng</th>
              <th class="border-b p-5 text-left text-lg font-semibold">Thành tiền (VND)</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in invoice.items" :key="index" class="hover:bg-gray-50 transition-colors duration-150">
              <td class="border-b p-5 text-gray-700 text-lg">{{ item.name }}</td>
              <td class="border-b p-5 text-gray-700 text-lg">{{ item.price.toLocaleString() }}</td>
              <td class="border-b p-5 text-gray-700 text-lg">{{ item.quantity }}</td>
              <td class="border-b p-5 text-gray-700 text-lg">{{ (item.price * item.quantity).toLocaleString() }}</td>
            </tr>
          </tbody>
        </table>
        <p v-if="!invoice.items.length" class="text-lg text-gray-500 mt-6 text-center">Chưa có dịch vụ/phòng nào.</p>
      </div>

      <!-- Total Section -->
      <div class="flex justify-end">
        <div class="bg-green-500 text-white rounded-lg shadow-md p-4 w-full max-w-xs">
          <p class="text-xl font-semibold">Tổng tiền:</p>
          <p class="text-3xl font-extrabold">{{ totalAmount.toLocaleString() }} VND</p>
        </div>
      </div>

      <!-- Back Button -->
      <div class="mt-10">
        <button class="bg-gray-600 text-white px-8 py-3 rounded-lg hover:bg-gray-700 transition-colors duration-200" @click="goBack">
          Quay lại
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'InvoiceDetail',
  data() {
    return {
      invoice: {
        invoiceId: 'HD001',
        customerInfo: 'Nguyễn Văn A',
        status: 'ĐÃ THANH TOÁN',
        date: '23/05/2025',
        time: '11:24 AM',
        items: [
          { name: 'Giặt sấy dưới 5kg', price: 10000, quantity: 2 },
          { name: 'Phở bò', price: 80000, quantity: 1 },
          { name: 'Massage toàn thân', price: 300000, quantity: 1 },
        ],
      },
    };
  },
  computed: {
    totalAmount() {
      return this.invoice.items.reduce((total, item) => total + item.price * item.quantity, 0);
    },
  },
  methods: {
    goBack() {
      // Logic để quay lại trang trước, có thể dùng router nếu bạn dùng Vue Router
      this.$router ? this.$router.go(-1) : window.history.back();
    },
  },
};
</script>

<style scoped>
.min-h-screen {
  min-height: 100vh;
}

.bg-gray-100 {
  background-color: #f7fafc;
}

.bg-white {
  background-color: #ffffff;
}

.shadow-xl {
  box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04);
}

.shadow-md {
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
}

.rounded-xl {
  border-radius: 0.75rem;
}

.rounded-lg {
  border-radius: 0.5rem;
}

.w-full {
  width: 100%;
}

.max-w-7xl {
  max-width: 96rem; /* Chiều rộng tối đa 1536px */
}

.max-w-xs {
  max-width: 20rem; /* Giảm kích thước hộp tổng tiền */
}

.mx-auto {
  margin-left: auto;
  margin-right: auto;
}

.p-10 {
  padding: 2.5rem;
}

.p-12 {
  padding: 3rem;
}

.p-4 {
  padding: 1rem;
}

.mb-6 {
  margin-bottom: 1.5rem;
}

.mb-10 {
  margin-bottom: 2.5rem;
}

.mb-12 {
  margin-bottom: 3rem;
}

.mt-6 {
  margin-top: 1.5rem;
}

.mt-10 {
  margin-bottom: 2.5rem;
}

.space-y-3 > * + * {
  margin-top: 0.75rem;
}

.text-4xl {
  font-size: 2.25rem;
}

.text-3xl {
  font-size: 1.875rem;
}

.text-xl {
  font-size: 1.25rem;
}

.text-lg {
  font-size: 1.125rem;
}

.font-extrabold {
  font-weight: 800;
}

.font-bold {
  font-weight: 700;
}

.font-semibold {
  font-weight: 600;
}

.text-gray-900 {
  color: #1f2937;
}

.text-gray-500 {
  color: #a0aec0;
}

.text-gray-700 {
  color: #4a5568;
}

.text-gray-800 {
  color: #2d3748;
}

.text-green-600 {
  color: #16a34a;
}

.text-red-600 {
  color: #dc2626;
}

.text-white {
  color: #ffffff;
}

.bg-green-500 {
  background-color: #22c55e;
}

.flex {
  display: flex;
}

.justify-between {
  justify-content: space-between;
}

.justify-end {
  justify-content: flex-end;
}

.items-start {
  align-items: flex-start;
}

.text-right {
  text-align: right;
}

.text-center {
  text-align: center;
}

.border-b {
  border-bottom-width: 1px;
}

.border-collapse {
  border-collapse: collapse;
}

.p-5 {
  padding: 1.25rem;
}

.text-left {
  text-align: left;
}

.bg-gray-200 {
  background-color: #e5e7eb;
}

.bg-gray-50 {
  background-color: #fafafa;
}

.bg-gray-600 {
  background-color: #4b5563;
}

.transition-colors {
  transition: color 0.2s ease-in-out, background-color 0.2s ease-in-out;
}

.duration-150 {
  transition-duration: 150ms;
}

.duration-200 {
  transition-duration: 200ms;
}

.hover\:bg-gray-50:hover {
  background-color: #fafafa;
}

.hover\:bg-gray-700:hover {
  background-color: #374151;
}

table th,
table td {
  border-color: #e2e8f0;
}

.px-8 {
  padding-left: 2rem;
  padding-right: 2rem;
}

.py-3 {
  padding-top: 0.75rem;
  padding-bottom: 0.75rem;
}
</style>