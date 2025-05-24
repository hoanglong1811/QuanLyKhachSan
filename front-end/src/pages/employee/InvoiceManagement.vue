<!-- File: InvoiceManagement.vue -->
<template>
  <div class="min-h-screen bg-gray-100 flex items-center justify-center p-10">
    <div class="bg-white rounded-xl shadow-xl w-full max-w-7xl mx-auto p-12">
      <!-- Header -->
      <div class="flex justify-between items-center mb-10">
        <h1 class="text-4xl font-extrabold text-gray-900">Quản lý hóa đơn</h1>
        <div class="flex gap-4">
          <button 
            @click="openCustomerModal"
            class="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition-colors duration-200"
          >
            Thêm hóa đơn mới
          </button>
          <button class="text-gray-600 hover:text-gray-800 transition-colors duration-200 transform hover:scale-110" @click="goBack">
            <svg class="w-8 h-8" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path>
            </svg>
          </button>
        </div>
      </div>

      <!-- Invoice List Table -->
      <div class="mb-12">
        <table class="w-full border-collapse bg-white rounded-lg shadow-md">
          <thead>
            <tr class="bg-gray-200 text-gray-800">
              <th class="border-b p-5 text-left text-lg font-semibold">Mã hóa đơn</th>
              <th class="border-b p-5 text-left text-lg font-semibold">Thông tin khách hàng</th>
              <th class="border-b p-5 text-left text-lg font-semibold">Trạng thái thanh toán</th>
              <th class="border-b p-5 text-left text-lg font-semibold">Thao tác</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(invoice, index) in invoices" :key="index" class="hover:bg-gray-50 transition-colors duration-150">
              <td class="border-b p-5 text-gray-700 text-lg">{{ invoice.invoiceId }}</td>
              <td class="border-b p-5 text-gray-700 text-lg">{{ invoice.customerInfo }}</td>
              <td class="border-b p-5">
                <span :class="invoice.status === 'ĐÃ THANH TOÁN' ? 'text-green-600 font-semibold' : 'text-red-600 font-semibold'">
                  {{ invoice.status }}
                </span>
              </td>
              <td class="border-b p-5">
                <a href="#" class="text-blue-600 underline font-medium hover:text-blue-800 transition-colors duration-200" @click.prevent="viewDetails(invoice)">Xem chi tiết</a>
              </td>
            </tr>
          </tbody>
        </table>
        <p v-if="!invoices.length" class="text-lg text-gray-500 mt-6 text-center">Chưa có hóa đơn nào.</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'InvoiceManagement',
  data() {
    return {
      invoices: [
        { invoiceId: 'HD001', customerInfo: 'Nguyễn Văn A', status: 'ĐÃ THANH TOÁN' },
        { invoiceId: 'HD002', customerInfo: 'Trần Thị B', status: 'CHƯA THANH TOÁN' },
        { invoiceId: 'HD003', customerInfo: 'Lê Văn C', status: 'ĐÃ THANH TOÁN' },
      ],
    };
  },
  methods: {
    goBack() {
      // Logic để quay lại trang trước, có thể dùng router nếu bạn dùng Vue Router
      this.$router ? this.$router.go(-1) : window.history.back();
    },
    viewDetails(invoice) {
      // Logic để xem chi tiết hóa đơn, hiện tại chỉ hiển thị thông báo
      alert(`Xem chi tiết hóa đơn: ${invoice.invoiceId} - Khách hàng: ${invoice.customerInfo}`);
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

.mb-10 {
  margin-bottom: 2.5rem;
}

.mb-12 {
  margin-bottom: 3rem;
}

.mt-6 {
  margin-top: 1.5rem;
}

.text-4xl {
  font-size: 2.25rem;
}

.text-lg {
  font-size: 1.125rem;
}

.font-extrabold {
  font-weight: 800;
}

.font-semibold {
  font-weight: 600;
}

.font-medium {
  font-weight: 500;
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

.text-blue-600 {
  color: #2563eb;
}

.text-blue-800 {
  color: #1d4ed8;
}

.hover\:text-gray-800:hover {
  color: #2d3748;
}

.hover\:text-blue-800:hover {
  color: #1d4ed8;
}

.flex {
  display: flex;
}

.justify-between {
  justify-content: space-between;
}

.items-center {
  align-items: center;
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

.underline {
  text-decoration: underline;
}

.transition-colors {
  transition: color 0.2s ease-in-out;
}

.duration-150 {
  transition-duration: 150ms;
}

.duration-200 {
  transition-duration: 200ms;
}

.hover\:scale-110:hover {
  transform: scale(1.1);
}

table th,
table td {
  border-color: #e2e8f0;
}

.w-8 {
  width: 2rem;
}

.h-8 {
  height: 2rem;
}
</style>