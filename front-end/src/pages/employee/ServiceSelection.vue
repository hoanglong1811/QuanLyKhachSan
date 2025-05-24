<!-- File: ServiceSelection.vue -->
<template>
  <div class="min-h-screen bg-gray-100 flex items-center justify-center p-8">
    <div class="bg-white rounded-lg shadow-lg w-full max-w-6xl mx-auto p-10">
      <!-- Header -->
      <div class="flex justify-between items-center mb-8">
        <h1 class="text-3xl font-bold text-gray-800">Quản lý dịch vụ</h1>
        <button class="text-gray-500 hover:text-gray-700" @click="goBack">
          <svg class="w-7 h-7" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path>
          </svg>
        </button>
      </div>

      <!-- Customer Selection Section -->
      <div class="mb-8">
        <div class="flex justify-between items-center mb-4">
          <h2 class="text-xl font-semibold text-gray-800">Thông tin khách hàng</h2>
          <button
            v-if="!selectedCustomer"
            @click="showCustomerModal = true"
            class="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700 transition-colors"
          >
            Chọn khách hàng
          </button>
        </div>

        <!-- Selected Customer Info -->
        <div v-if="selectedCustomer" class="bg-gray-50 p-6 rounded-lg">
          <div class="flex justify-between items-start">
            <div>
              <h3 class="text-lg font-medium text-gray-900">{{ selectedCustomer.name }}</h3>
              <p class="text-gray-600">SĐT: {{ selectedCustomer.phone }}</p>
              <p class="text-gray-600">CCCD: {{ selectedCustomer.idNumber }}</p>
            </div>
            <button
              @click="clearSelectedCustomer"
              class="text-gray-500 hover:text-gray-700"
            >
              <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
              </svg>
            </button>
          </div>
        </div>

        <!-- No Customer Selected Message -->
        <div v-else class="bg-gray-50 p-6 rounded-lg text-center">
          <p class="text-gray-500">Vui lòng chọn khách hàng để thêm dịch vụ</p>
        </div>
      </div>

      <!-- Service List with Expandable Tables -->
      <div v-if="selectedCustomer" class="space-y-8 mb-10">
        <!-- Giặt ủi -->
        <div>
          <button class="flex justify-between items-center w-full p-4 border rounded-md" @click="toggleSection('laundry')">
            <span class="text-lg font-medium text-gray-700">Giặt ủi</span>
            <svg class="w-6 h-6 text-gray-500 transform transition-transform" :class="{ 'rotate-180': expandedSections.laundry }" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
            </svg>
          </button>
          <div v-if="expandedSections.laundry" class="mt-4">
            <table class="w-full border-collapse">
              <thead>
                <tr class="bg-gray-100">
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Tên dịch vụ</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Giá (VND)</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Số lượng</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in laundryServices" :key="index">
                  <td class="border p-4">{{ item.name }}</td>
                  <td class="border p-4">{{ item.price }}</td>
                  <td class="border p-4">
                    <input v-model.number="laundryServices[index].quantity" type="number" min="0" class="w-full p-3 border rounded-md focus:outline-none focus:ring-2 focus:ring-green-500" placeholder="0" />
                  </td>
                  <td class="border p-4">
                    <button class="bg-green-500 text-white px-4 py-2 rounded-md hover:bg-green-600" @click="addService({ ...laundryServices[index] }, 'laundry', index)">Thêm</button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <!-- Ăn uống -->
        <div>
          <button class="flex justify-between items-center w-full p-4 border rounded-md" @click="toggleSection('food')">
            <span class="text-lg font-medium text-gray-700">Ăn uống</span>
            <svg class="w-6 h-6 text-gray-500 transform transition-transform" :class="{ 'rotate-180': expandedSections.food }" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
            </svg>
          </button>
          <div v-if="expandedSections.food" class="mt-4">
            <table class="w-full border-collapse">
              <thead>
                <tr class="bg-gray-100">
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Tên dịch vụ</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Giá (VND)</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Số lượng</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in foodServices" :key="index">
                  <td class="border p-4">{{ item.name }}</td>
                  <td class="border p-4">{{ item.price }}</td>
                  <td class="border p-4">
                    <input v-model.number="foodServices[index].quantity" type="number" min="0" class="w-full p-3 border rounded-md focus:outline-none focus:ring-2 focus:ring-green-500" placeholder="0" />
                  </td>
                  <td class="border p-4">
                    <button class="bg-green-500 text-white px-4 py-2 rounded-md hover:bg-green-600" @click="addService({ ...foodServices[index] }, 'food', index)">Thêm</button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <!-- Spa -->
        <div>
          <button class="flex justify-between items-center w-full p-4 border rounded-md" @click="toggleSection('spa')">
            <span class="text-lg font-medium text-gray-700">Spa</span>
            <svg class="w-6 h-6 text-gray-500 transform transition-transform" :class="{ 'rotate-180': expandedSections.spa }" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
            </svg>
          </button>
          <div v-if="expandedSections.spa" class="mt-4">
            <table class="w-full border-collapse">
              <thead>
                <tr class="bg-gray-100">
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Tên dịch vụ</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Giá (VND)</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Số lượng</th>
                  <th class="border p-4 text-left text-base font-medium text-gray-700">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in spaServices" :key="index">
                  <td class="border p-4">{{ item.name }}</td>
                  <td class="border p-4">{{ item.price }}</td>
                  <td class="border p-4">
                    <input v-model.number="spaServices[index].quantity" type="number" min="0" class="w-full p-3 border rounded-md focus:outline-none focus:ring-2 focus:ring-green-500" placeholder="0" />
                  </td>
                  <td class="border p-4">
                    <button class="bg-green-500 text-white px-4 py-2 rounded-md hover:bg-green-600" @click="addService({ ...spaServices[index] }, 'spa', index)">Thêm</button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <!-- Selected Services Section -->
      <div v-if="selectedCustomer" class="mb-10">
        <h2 class="text-lg font-medium text-gray-700 mb-4">Dịch vụ đã chọn</h2>
        <table v-if="selectedServices.length" class="w-full border-collapse">
          <thead>
            <tr class="bg-gray-100">
              <th class="border p-4 text-left text-base font-medium text-gray-700">Tên dịch vụ</th>
              <th class="border p-4 text-left text-base font-medium text-gray-700">Giá (VND)</th>
              <th class="border p-4 text-left text-base font-medium text-gray-700">Số lượng</th>
              <th class="border p-4 text-left text-base font-medium text-gray-700">Thành tiền (VND)</th>
              <th class="border p-4 text-left text-base font-medium text-gray-700">Thao tác</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(service, index) in selectedServices" :key="index">
              <td class="border p-4">{{ service.name }}</td>
              <td class="border p-4">{{ service.price }}</td>
              <td class="border p-4">{{ service.quantity }}</td>
              <td class="border p-4">{{ (parseInt(service.price.replace(/[^0-9]/g, '')) * service.quantity).toLocaleString() }}</td>
              <td class="border p-4">
                <button class="bg-red-500 text-white px-4 py-2 rounded-md hover:bg-red-600" @click="removeService(service, index)">Xóa</button>
              </td>
            </tr>
          </tbody>
        </table>
        <p v-if="!selectedServices.length" class="text-base text-gray-500">Chưa có dịch vụ nào được chọn.</p>
      </div>

      <!-- Total and Button -->
      <div v-if="selectedCustomer" class="flex justify-between items-center">
        <p class="text-lg font-medium text-gray-700">Tổng tiền dự kiến: <span class="font-bold">{{ totalPrice }} VND</span></p>
        <button class="bg-green-500 text-white px-8 py-3 rounded-md hover:bg-green-600">Xác nhận</button>
      </div>

      <!-- Customer Selection Modal -->
      <div v-if="showCustomerModal" class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
        <div class="bg-white rounded-xl p-8 w-full max-w-2xl">
          <div class="flex justify-between items-center mb-6">
            <h2 class="text-2xl font-bold text-gray-900">Chọn khách hàng</h2>
            <button @click="closeCustomerModal" class="text-gray-500 hover:text-gray-700">
              <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
              </svg>
            </button>
          </div>

          <!-- Search Input -->
          <div class="mb-6">
            <input
              type="text"
              v-model="searchQuery"
              placeholder="Tìm kiếm khách hàng..."
              class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
          </div>

          <!-- Customer List -->
          <div class="max-h-96 overflow-y-auto">
            <div
              v-for="customer in filteredCustomers"
              :key="customer.id"
              @click="selectCustomer(customer)"
              class="p-4 border-b border-gray-200 hover:bg-gray-50 cursor-pointer"
            >
              <div class="flex justify-between items-center">
                <div>
                  <h3 class="font-medium text-gray-900">{{ customer.name }}</h3>
                  <p class="text-sm text-gray-500">{{ customer.phone }}</p>
                </div>
                <div class="text-sm text-gray-500">
                  CCCD: {{ customer.idNumber }}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Delete Confirmation Modal -->
      <div v-if="showDeleteModal" class="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
        <div class="bg-white rounded-xl p-6 w-full max-w-md">
          <div class="text-center mb-6">
            <svg class="mx-auto h-12 w-12 text-red-500" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z" />
            </svg>
            <h3 class="text-lg font-medium text-gray-900 mt-4">Xác nhận xóa dịch vụ</h3>
            <p class="text-gray-500 mt-2">
              Bạn có chắc chắn muốn xóa dịch vụ "{{ serviceToDelete?.name }}" không?
            </p>
          </div>
          <div class="flex justify-end gap-4">
            <button
              @click="cancelDelete"
              class="px-4 py-2 border border-gray-300 rounded-lg text-gray-700 hover:bg-gray-50"
            >
              Hủy
            </button>
            <button
              @click="confirmDelete"
              class="px-4 py-2 bg-red-600 text-white rounded-lg hover:bg-red-700"
            >
              Xóa
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ServiceSelection',
  data() {
    return {
      // Customer selection
      showCustomerModal: false,
      searchQuery: '',
      selectedCustomer: null,
      customers: [
        { id: 1, name: 'Nguyễn Văn A', phone: '0123456789', idNumber: '001234567890' },
        { id: 2, name: 'Trần Thị B', phone: '0987654321', idNumber: '098765432100' },
        { id: 3, name: 'Lê Văn C', phone: '0369852147', idNumber: '036985214700' },
      ],

      // Existing data
      expandedSections: {
        laundry: false,
        food: false,
        spa: false,
      },
      laundryServices: [
        { name: 'Giặt sấy dưới 5kg', price: '10,000/kg', quantity: 0 },
        { name: 'Giặt trên 7kg', price: '8,000/kg', quantity: 0 },
        { name: 'Ủi quần - áo', price: '10,000/cái', quantity: 0 },
      ],
      foodServices: [
        { name: 'Phở bò', price: '80,000/suất', quantity: 0 },
        { name: 'Cơm tấm sườn nướng', price: '70,000/suất', quantity: 0 },
        { name: 'Nước ép', price: '45,000/ly', quantity: 0 },
      ],
      spaServices: [
        { name: 'Massage toàn thân', price: '300,000/lần', quantity: 0 },
        { name: 'Gội đầu dưỡng sinh', price: '100,000/lần', quantity: 0 },
        { name: 'Xông hơi', price: '150,000/lần', quantity: 0 },
      ],
      selectedServices: [],

      // Delete confirmation
      showDeleteModal: false,
      serviceToDelete: null,
      serviceIndexToDelete: -1,
    };
  },
  computed: {
    filteredCustomers() {
      const query = this.searchQuery.toLowerCase();
      return this.customers.filter(customer => 
        customer.name.toLowerCase().includes(query) ||
        customer.phone.includes(query) ||
        customer.idNumber.includes(query)
      );
    },
    totalPrice() {
      let total = 0;
      this.selectedServices.forEach(service => {
        const pricePerUnit = parseInt(service.price.replace(/[^0-9]/g, '')) || 0;
        total += pricePerUnit * (service.quantity || 0);
      });
      return total.toLocaleString();
    },
  },
  methods: {
    goBack() {
      this.$router ? this.$router.go(-1) : window.history.back();
    },
    // Customer selection methods
    closeCustomerModal() {
      this.showCustomerModal = false;
      this.searchQuery = '';
    },
    selectCustomer(customer) {
      this.selectedCustomer = customer;
      this.closeCustomerModal();
    },
    clearSelectedCustomer() {
      this.selectedCustomer = null;
      this.selectedServices = [];
      this.expandedSections = {
        laundry: false,
        food: false,
        spa: false,
      };
    },

    // Existing methods
    toggleSection(section) {
      this.expandedSections[section] = !this.expandedSections[section];
    },
    addService(item, section, index) {
      if (!item.quantity || item.quantity <= 0) {
        alert('Chưa nhập số lượng');
        return;
      }
      const existingService = this.selectedServices.find(s => s.name === item.name);
      if (existingService) {
        existingService.quantity = Number(item.quantity);
      } else {
        this.selectedServices.push({ ...item, quantity: Number(item.quantity) });
      }
      if (section === 'laundry') this.laundryServices[index].quantity = 0;
      if (section === 'food') this.foodServices[index].quantity = 0;
      if (section === 'spa') this.spaServices[index].quantity = 0;
    },
    removeService(service, index) {
      this.serviceToDelete = service;
      this.serviceIndexToDelete = index;
      this.showDeleteModal = true;
    },

    // Add new methods for delete confirmation
    cancelDelete() {
      this.showDeleteModal = false;
      this.serviceToDelete = null;
      this.serviceIndexToDelete = -1;
    },

    confirmDelete() {
      if (this.serviceIndexToDelete > -1) {
        this.selectedServices.splice(this.serviceIndexToDelete, 1);
        this.showDeleteModal = false;
        this.serviceToDelete = null;
        this.serviceIndexToDelete = -1;
      }
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

.shadow-lg {
  box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -2px rgba(0, 0, 0, 0.05);
}

.rounded-lg {
  border-radius: 0.5rem;
}

.w-full {
  width: 100%;
}

.max-w-6xl {
  max-width: 80rem; /* Chiều rộng tối đa 1280px */
}

.mx-auto {
  margin-left: auto;
  margin-right: auto;
}

.p-8 {
  padding: 2rem;
}

.p-10 {
  padding: 2.5rem;
}

.mb-8 {
  margin-bottom: 2rem;
}

.mb-10 {
  margin-bottom: 2.5rem;
}

.mb-4 {
  margin-bottom: 1rem;
}

.text-3xl {
  font-size: 1.875rem;
}

.text-lg {
  font-size: 1.125rem;
}

.text-base {
  font-size: 1rem;
}

.font-bold {
  font-weight: 700;
}

.text-gray-800 {
  color: #2d3748;
}

.text-gray-500 {
  color: #a0aec0;
}

.text-gray-700 {
  color: #4a5568;
}

.hover\:text-gray-700:hover {
  color: #4a5568;
}

.hover\:text-gray-600:hover {
  color: #718096;
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

.space-y-8 > * + * {
  margin-top: 2rem;
}

.block {
  display: block;
}

.font-medium {
  font-weight: 500;
}

.border {
  border-width: 1px;
}

.border-collapse {
  border-collapse: collapse;
}

.rounded-md {
  border-radius: 0.375rem;
}

.p-4 {
  padding: 1rem;
}

.p-3 {
  padding: 0.75rem;
}

.text-left {
  text-align: left;
}

.bg-gray-100 {
  background-color: #edf2f7;
}

.focus\:outline-none:focus {
  outline: none;
}

.focus\:ring-2:focus {
  box-shadow: 0 0 0 2px #48bb78;
}

.focus\:ring-green-500:focus {
  box-shadow: 0 0 0 2px #48bb78;
}

.bg-green-500 {
  background-color: #48bb78;
}

.bg-red-500 {
  background-color: #e53e3e;
}

.text-white {
  color: #ffffff;
}

.px-8 {
  padding-left: 2rem;
  padding-right: 2rem;
}

.py-3 {
  padding-top: 0.75rem;
  padding-bottom: 0.75rem;
}

.px-4 {
  padding-left: 1rem;
  padding-right: 1rem;
}

.py-2 {
  padding-top: 0.5rem;
  padding-bottom: 0.5rem;
}

.hover\:bg-green-600:hover {
  background-color: #38a169;
}

.hover\:bg-red-600:hover {
  background-color: #c53030;
}

.w-7 {
  width: 1.75rem;
}

.h-7 {
  height: 1.75rem;
}

.w-6 {
  width: 1.5rem;
}

.h-6 {
  height: 1.5rem;
}

.transform {
  transform: rotate(0deg);
}

.transition-transform {
  transition: transform 0.2s ease-in-out;
}

.rotate-180 {
  transform: rotate(180deg);
}

table th,
table td {
  border-color: #e2e8f0;
}

input[type="number"] {
  appearance: textfield;
}

input[type="number"]::-webkit-inner-spin-button,
input[type="number"]::-webkit-outer-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* New styles for customer selection */
.bg-blue-600 {
  background-color: #2563eb;
}

.hover\:bg-blue-700:hover {
  background-color: #1d4ed8;
}

.bg-opacity-50 {
  background-color: rgba(0, 0, 0, 0.5);
}

.max-h-96 {
  max-height: 24rem;
}

.overflow-y-auto {
  overflow-y: auto;
}

/* Add new styles for delete confirmation modal */
.text-red-500 {
  color: #ef4444;
}

.text-red-600 {
  color: #dc2626;
}

.hover\:bg-red-700:hover {
  background-color: #b91c1c;
}

.bg-red-600 {
  background-color: #dc2626;
}
</style>