<!-- File: ServiceSelection.vue -->
<template>
  <div class="min-h-screen bg-gray-100 flex items-center justify-center p-6">
    <div class="bg-white rounded-lg shadow-lg w-full max-w-4xl p-8">
      <!-- Header -->
      <div class="flex justify-between items-center mb-6">
        <h1 class="text-2xl font-bold text-gray-800">Quản lý dịch vụ</h1>
        <button class="text-gray-500 hover:text-gray-700">
          <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path>
          </svg>
        </button>
      </div>

      <!-- Service List with Expandable Tables -->
      <div class="space-y-6 mb-8">
        <!-- Giặt ủi -->
        <div>
          <button class="flex justify-between items-center w-full p-3 border rounded-md" @click="toggleSection('laundry')">
            <span class="text-base font-medium text-gray-700">Giặt ủi</span>
            <svg class="w-5 h-5 text-gray-500 transform transition-transform" :class="{ 'rotate-180': expandedSections.laundry }" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
            </svg>
          </button>
          <div v-if="expandedSections.laundry" class="mt-3">
            <table class="w-full border-collapse">
              <thead>
                <tr class="bg-gray-100">
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Tên dịch vụ</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Giá (VND)</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Số lượng</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in laundryServices" :key="index">
                  <td class="border p-3">{{ item.name }}</td>
                  <td class="border p-3">{{ item.price }}</td>
                  <td class="border p-3">
                    <input v-model.number="laundryServices[index].quantity" type="number" min="0" class="w-full p-2 border rounded-md focus:outline-none" placeholder="0" />
                  </td>
                  <td class="border p-3">
                    <button class="bg-green-500 text-white px-3 py-2 rounded-md hover:bg-green-600" @click="addService({ ...laundryServices[index] }, 'laundry', index, 'laundry')">Thêm</button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <!-- Ăn uống -->
        <div>
          <button class="flex justify-between items-center w-full p-3 border rounded-md" @click="toggleSection('food')">
            <span class="text-base font-medium text-gray-700">Ăn uống</span>
            <svg class="w-5 h-5 text-gray-500 transform transition-transform" :class="{ 'rotate-180': expandedSections.food }" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
            </svg>
          </button>
          <div v-if="expandedSections.food" class="mt-3">
            <table class="w-full border-collapse">
              <thead>
                <tr class="bg-gray-100">
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Tên dịch vụ</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Giá (VND)</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Số lượng</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in foodServices" :key="index">
                  <td class="border p-3">{{ item.name }}</td>
                  <td class="border p-3">{{ item.price }}</td>
                  <td class="border p-3">
                    <input v-model.number="foodServices[index].quantity" type="number" min="0" class="w-full p-2 border rounded-md focus:outline-none" placeholder="0" />
                  </td>
                  <td class="border p-3">
                    <button class="bg-green-500 text-white px-3 py-2 rounded-md hover:bg-green-600" @click="addService({ ...foodServices[index] }, 'food', index, 'food')">Thêm</button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <!-- Spa -->
        <div>
          <button class="flex justify-between items-center w-full p-3 border rounded-md" @click="toggleSection('spa')">
            <span class="text-base font-medium text-gray-700">Spa</span>
            <svg class="w-5 h-5 text-gray-500 transform transition-transform" :class="{ 'rotate-180': expandedSections.spa }" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7"></path>
            </svg>
          </button>
          <div v-if="expandedSections.spa" class="mt-3">
            <table class="w-full border-collapse">
              <thead>
                <tr class="bg-gray-100">
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Tên dịch vụ</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Giá (VND)</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Số lượng</th>
                  <th class="border p-3 text-left text-sm font-medium text-gray-700">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(item, index) in spaServices" :key="index">
                  <td class="border p-3">{{ item.name }}</td>
                  <td class="border p-3">{{ item.price }}</td>
                  <td class="border p-3">
                    <input v-model.number="spaServices[index].quantity" type="number" min="0" class="w-full p-2 border rounded-md focus:outline-none" placeholder="0" />
                  </td>
                  <td class="border p-3">
                    <button class="bg-green-500 text-white px-3 py-2 rounded-md hover:bg-green-600" @click="addService({ ...spaServices[index] }, 'spa', index, 'spa')">Thêm</button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>

      <!-- Selected Services Section -->
      <div class="mb-8">
        <h2 class="text-base font-medium text-gray-700 mb-3">Dịch vụ đã chọn</h2>
        <table v-if="selectedServices.length" class="w-full border-collapse">
          <thead>
            <tr class="bg-gray-100">
              <th class="border p-3 text-left text-sm font-medium text-gray-700">Tên dịch vụ</th>
              <th class="border p-3 text-left text-sm font-medium text-gray-700">Giá (VND)</th>
              <th class="border p-3 text-left text-sm font-medium text-gray-700">Số lượng</th>
              <th class="border p-3 text-left text-sm font-medium text-gray-700">Thành tiền (VND)</th>
              <th class="border p-3 text-left text-sm font-medium text-gray-700">Thao tác</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(service, index) in selectedServices" :key="index">
              <td class="border p-3">{{ service.name }}</td>
              <td class="border p-3">{{ service.price }}</td>
              <td class="border p-3">{{ service.quantity }}</td>
              <td class="border p-3">{{ (parseInt(service.price.replace(/[^0-9]/g, '')) * service.quantity).toLocaleString() }}</td>
              <td class="border p-3">
                <button class="bg-red-500 text-white px-3 py-2 rounded-md hover:bg-red-600" @click="removeService(index)">Xóa</button>
              </td>
            </tr>
          </tbody>
        </table>
        <p v-if="!selectedServices.length" class="text-sm text-gray-500">Chưa có dịch vụ nào được chọn.</p>
      </div>

      <!-- Total and Button -->
      <div class="flex justify-between items-center">
        <p class="text-base font-medium text-gray-700">Tổng tiền dự kiến: <span class="font-bold">{{ totalPrice }} VND</span></p>
        <button class="bg-green-500 text-white px-6 py-3 rounded-md hover:bg-green-600">Xuất hóa đơn</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ServiceSelection',
  data() {
    return {
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
    };
  },
  computed: {
    totalPrice() {
      let total = 0;
      this.selectedServices.forEach(service => {
        const pricePerUnit = parseInt(service.price.replace(/[^0-9]/g, ''));
        total += pricePerUnit * service.quantity;
      });
      return total.toLocaleString();
    },
  },
  methods: {
    toggleSection(section) {
      this.expandedSections[section] = !this.expandedSections[section];
    },
    addService(item, section, index, serviceType) {
      if (item.quantity <= 0) {
        alert('Chưa nhập số lượng');
        return;
      }
      const existingService = this.selectedServices.find(s => s.name === item.name);
      if (existingService) {
        existingService.quantity = item.quantity;
      } else {
        this.selectedServices.push({ ...item });
      }
      // Reset quantity after adding
      if (serviceType === 'laundry') this.laundryServices[index].quantity = 0;
      if (serviceType === 'food') this.foodServices[index].quantity = 0;
      if (serviceType === 'spa') this.spaServices[index].quantity = 0;
    },
    removeService(index) {
      this.selectedServices.splice(index, 1);
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

.max-w-4xl {
  max-width: 64rem; /* Tăng kích thước tối đa lên 64rem (1024px) */
}

.p-6 {
  padding: 1.5rem;
}

.p-8 {
  padding: 2rem;
}

.mb-6 {
  margin-bottom: 1.5rem;
}

.mb-8 {
  margin-bottom: 2rem;
}

.mb-3 {
  margin-bottom: 0.75rem;
}

.text-2xl {
  font-size: 1.5rem;
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

.space-y-6 > * + * {
  margin-top: 1.5rem;
}

.block {
  display: block;
}

.text-sm {
  font-size: 0.875rem;
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

.p-3 {
  padding: 0.75rem;
}

.p-2 {
  padding: 0.5rem;
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

.bg-green-500 {
  background-color: #48bb78;
}

.bg-red-500 {
  background-color: #e53e3e;
}

.text-white {
  color: #ffffff;
}

.px-6 {
  padding-left: 1.5rem;
  padding-right: 1.5rem;
}

.py-3 {
  padding-top: 0.75rem;
  padding-bottom: 0.75rem;
}

.px-3 {
  padding-left: 0.75rem;
  padding-right: 0.75rem;
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

.w-6 {
  width: 1.5rem;
}

.h-6 {
  height: 1.5rem;
}

.w-5 {
  width: 1.25rem;
}

.h-5 {
  height: 1.25rem;
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
</style>