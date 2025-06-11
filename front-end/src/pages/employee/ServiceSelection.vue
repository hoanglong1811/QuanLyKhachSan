<!-- File: ServiceSelection.vue -->
<template>
  <div class="page-container">
    <div class="content-wrapper">
      <div class="content-container">
        <!-- Header -->
        <div class="header-section">
          <div class="header-left">
            <h1 class="page-title">Quản lý dịch vụ</h1>
            <p class="subtitle">Thêm và quản lý dịch vụ cho khách hàng</p>
          </div>
          <button class="back-button" @click="goBack">
            Quay lại
          </button>
        </div>

        <!-- Customer Selection Section -->
        <div class="section-container">
          <div class="section-header">
            <h2 class="section-title">Thông tin khách hàng</h2>
            <button
              v-if="!selectedCustomer"
              @click="showCustomerModal = true"
              class="primary-button"
            >
              Chọn khách hàng
            </button>
          </div>

          <!-- Selected Customer Info -->
          <div v-if="selectedCustomer" class="customer-info-card">
            <div class="customer-info-content">
              <div class="customer-details">
                <h3 class="customer-name">{{ selectedCustomer.name }}</h3>
                <p class="customer-data">SĐT: {{ selectedCustomer.phone }}</p>
                <p class="customer-data">CCCD: {{ selectedCustomer.idNumber }}</p>
              </div>
              <button
                @click="clearSelectedCustomer"
                class="icon-button"
              >
                ✕
              </button>
            </div>
          </div>

          <!-- No Customer Selected Message -->
          <div v-else class="empty-state">
            <p>Vui lòng chọn khách hàng để thêm dịch vụ</p>
          </div>
        </div>

        <!-- Service List with Expandable Tables -->
        <div v-if="selectedCustomer" class="services-container">
          <!-- Giặt ủi -->
          <div class="service-section">
            <button class="service-header" @click="toggleSection('laundry')">
              <span class="service-title">Giặt ủi</span>
              <span class="toggle-indicator" :class="{ 'rotate-180': expandedSections.laundry }">▼</span>
            </button>
            <div v-if="expandedSections.laundry" class="service-content">
              <div class="table-responsive">
                <table class="service-table">
                  <thead>
                    <tr>
                      <th>Tên dịch vụ</th>
                      <th>Giá (VND)</th>
                      <th>Số lượng</th>
                      <th>Thao tác</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="(item, index) in laundryServices" :key="index">
                      <td>{{ item.name }}</td>
                      <td>{{ item.price }}</td>
                      <td>
                        <input 
                          v-model.number="laundryServices[index].quantity" 
                          type="number" 
                          min="0" 
                          class="quantity-input" 
                          placeholder="0" 
                        />
                      </td>
                      <td>
                        <button 
                          class="add-button"
                          @click="addService({ ...laundryServices[index] }, 'laundry', index)"
                        >
                          Thêm
                        </button>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>

          <!-- Ăn uống -->
          <div class="service-section">
            <button class="service-header" @click="toggleSection('food')">
              <span class="service-title">Ăn uống</span>
              <span class="toggle-indicator" :class="{ 'rotate-180': expandedSections.food }">▼</span>
            </button>
            <div v-if="expandedSections.food" class="service-content">
              <div class="table-responsive">
                <table class="service-table">
                  <thead>
                    <tr>
                      <th>Tên dịch vụ</th>
                      <th>Giá (VND)</th>
                      <th>Số lượng</th>
                      <th>Thao tác</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="(item, index) in foodServices" :key="index">
                      <td>{{ item.name }}</td>
                      <td>{{ item.price }}</td>
                      <td>
                        <input 
                          v-model.number="foodServices[index].quantity" 
                          type="number" 
                          min="0" 
                          class="quantity-input" 
                          placeholder="0" 
                        />
                      </td>
                      <td>
                        <button 
                          class="add-button"
                          @click="addService({ ...foodServices[index] }, 'food', index)"
                        >
                          Thêm
                        </button>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>

          <!-- Spa -->
          <div class="service-section">
            <button class="service-header" @click="toggleSection('spa')">
              <span class="service-title">Spa</span>
              <span class="toggle-indicator" :class="{ 'rotate-180': expandedSections.spa }">▼</span>
            </button>
            <div v-if="expandedSections.spa" class="service-content">
              <div class="table-responsive">
                <table class="service-table">
                  <thead>
                    <tr>
                      <th>Tên dịch vụ</th>
                      <th>Giá (VND)</th>
                      <th>Số lượng</th>
                      <th>Thao tác</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="(item, index) in spaServices" :key="index">
                      <td>{{ item.name }}</td>
                      <td>{{ item.price }}</td>
                      <td>
                        <input 
                          v-model.number="spaServices[index].quantity" 
                          type="number" 
                          min="0" 
                          class="quantity-input" 
                          placeholder="0" 
                        />
                      </td>
                      <td>
                        <button 
                          class="add-button"
                          @click="addService({ ...spaServices[index] }, 'spa', index)"
                        >
                          Thêm
                        </button>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>

        <!-- Selected Services Section -->
        <div v-if="selectedCustomer" class="selected-services-section">
          <div class="section-header">
            <h2 class="section-title">Dịch vụ đã chọn</h2>
          </div>
          
          <div v-if="selectedServices.length" class="selected-services-table-container">
            <div class="table-responsive">
              <table class="selected-services-table">
                <thead>
                  <tr>
                    <th>Tên dịch vụ</th>
                    <th>Giá (VND)</th>
                    <th>Số lượng</th>
                    <th>Thành tiền (VND)</th>
                    <th>Thao tác</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(service, index) in selectedServices" :key="index">
                    <td class="service-name">{{ service.name }}</td>
                    <td class="service-price">{{ service.price }}</td>
                    <td class="service-quantity">{{ service.quantity }}</td>
                    <td class="service-total">
                      {{ (parseInt(service.price.replace(/[^0-9]/g, '')) * service.quantity).toLocaleString() }}
                    </td>
                    <td>
                      <button class="delete-button" @click="removeService(service, index)">
                        Xóa
                      </button>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          
          <div v-else class="empty-services">
            <p>Chưa có dịch vụ nào được chọn.</p>
          </div>

          <!-- Total and Confirm Button -->
          <div class="footer-section">
            <div class="total-price">
              <span class="total-label">Tổng tiền dự kiến:</span>
              <span class="total-amount">{{ totalPrice }} VND</span>
            </div>
            <button class="confirm-button" @click="confirmServices">
              Xác nhận
            </button>
          </div>
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
      if (confirm(`Bạn có chắc chắn muốn xóa dịch vụ "${service.name}" không?`)) {
        this.selectedServices.splice(index, 1);
        alert('Dịch vụ đã được xóa khỏi danh sách');
      }
    },
    confirmServices() {
      if (this.selectedServices.length === 0) {
        alert('Vui lòng chọn ít nhất một dịch vụ');
        return;
      }
      alert('Đã thêm dịch vụ thành công');
      this.$router.push('/employee/invoice-management');
    },
  },
};
</script>

<style scoped>
.page-container {
  min-height: 100vh;
  background-color: #f3f4f6;
  padding: 2rem;
}

.content-wrapper {
  max-width: 1400px;
  margin: 0 auto;
}

.content-container {
  background-color: white;
  border-radius: 1rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
  padding: 2rem;
}

.header-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
  padding-bottom: 1.5rem;
  border-bottom: 1px solid #e5e7eb;
}

.header-left {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.page-title {
  font-size: 1.875rem;
  font-weight: 700;
  color: #111827;
  margin: 0;
  line-height: 1.2;
}

.subtitle {
  color: #6b7280;
  font-size: 0.975rem;
}

.back-button {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.5rem 1rem;
  color: #4b5563;
  background-color: #f9fafb;
  border: 1px solid #e5e7eb;
  border-radius: 0.5rem;
  transition: all 0.2s;
}

.back-button:hover {
  background-color: #f3f4f6;
  color: #111827;
  border-color: #d1d5db;
}

.section-container {
  margin-bottom: 2rem;
  background-color: white;
  border-radius: 0.75rem;
}

.section-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 1rem;
}

.section-title {
  font-size: 1.25rem;
  font-weight: 600;
  color: #111827;
  margin: 0;
}

.primary-button {
  display: inline-flex;
  align-items: center;
  padding: 0.5rem 1rem;
  background-color: #3b82f6;
  color: white;
  border-radius: 0.5rem;
  font-weight: 500;
  transition: all 0.2s;
}

.primary-button:hover {
  background-color: #2563eb;
}

.customer-info-card {
  background-color: #f9fafb;
  border: 1px solid #e5e7eb;
  border-radius: 0.75rem;
  padding: 1.5rem;
}

.customer-info-content {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
}

.customer-details {
  flex: 1;
}

.customer-name {
  font-size: 1.125rem;
  font-weight: 600;
  color: #111827;
  margin: 0 0 0.5rem 0;
}

.customer-data {
  color: #6b7280;
  margin: 0.25rem 0;
  font-size: 0.975rem;
}

.icon-button {
  padding: 0.5rem;
  color: #6b7280;
  border-radius: 0.5rem;
  transition: all 0.2s;
  font-size: 1rem;
  line-height: 1;
  font-weight: bold;
}

.empty-state {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 3rem 2rem;
  background-color: #f9fafb;
  border: 1px solid #e5e7eb;
  border-radius: 0.75rem;
  color: #6b7280;
  text-align: center;
}

/* Responsive Design */
@media (max-width: 768px) {
  .page-container {
    padding: 1rem;
  }

  .content-container {
    padding: 1rem;
  }

  .header-section {
    flex-direction: column;
    align-items: flex-start;
    gap: 1rem;
  }

  .back-button {
    width: 100%;
    justify-content: center;
  }

  .section-header {
    flex-direction: column;
    align-items: stretch;
    gap: 1rem;
  }

  .primary-button {
    width: 100%;
    justify-content: center;
  }
}

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

.services-container {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  margin-bottom: 2rem;
}

.service-section {
  background-color: white;
  border: 1px solid #e5e7eb;
  border-radius: 0.75rem;
  overflow: hidden;
}

.service-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 1rem 1.5rem;
  background-color: #f9fafb;
  border-bottom: 1px solid #e5e7eb;
  transition: background-color 0.2s;
}

.service-header:hover {
  background-color: #f3f4f6;
}

.service-title {
  font-size: 1.125rem;
  font-weight: 600;
  color: #111827;
}

.toggle-indicator {
  font-size: 0.875rem;
  color: #6b7280;
  transition: transform 0.2s;
}

.toggle-indicator.rotate-180 {
  transform: rotate(180deg);
  display: inline-block;
}

.service-content {
  padding: 1rem;
}

.table-responsive {
  overflow-x: auto;
  margin: 0 -1rem;
}

.service-table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
  min-width: 600px;
}

.service-table th {
  padding: 0.75rem 1rem;
  background-color: #f9fafb;
  color: #374151;
  font-weight: 600;
  text-align: left;
  border-bottom: 1px solid #e5e7eb;
  white-space: nowrap;
}

.service-table td {
  padding: 0.75rem 1rem;
  border-bottom: 1px solid #e5e7eb;
  color: #4b5563;
}

.service-table tr:last-child td {
  border-bottom: none;
}

.quantity-input {
  width: 100%;
  max-width: 120px;
  padding: 0.5rem;
  border: 1px solid #e5e7eb;
  border-radius: 0.375rem;
  background-color: white;
  color: #111827;
  transition: all 0.2s;
}

.quantity-input:focus {
  outline: none;
  border-color: #3b82f6;
  box-shadow: 0 0 0 2px rgba(59, 130, 246, 0.1);
}

.add-button {
  padding: 0.375rem 0.75rem;
  background-color: #10b981;
  color: white;
  border-radius: 0.375rem;
  font-size: 0.875rem;
  font-weight: 500;
  transition: all 0.2s;
}

.add-button:hover {
  background-color: #059669;
}

/* Responsive adjustments */
@media (max-width: 768px) {
  .service-header {
    padding: 0.75rem 1rem;
  }

  .service-content {
    padding: 0.75rem;
  }

  .table-responsive {
    margin: 0;
    border: 1px solid #e5e7eb;
    border-radius: 0.5rem;
  }

  .service-table th,
  .service-table td {
    padding: 0.625rem 0.75rem;
  }

  .quantity-input {
    max-width: 100%;
  }

  .add-button {
    width: 100%;
  }
}

.selected-services-section {
  margin-top: 2rem;
  background-color: white;
  border: 1px solid #e5e7eb;
  border-radius: 0.75rem;
  overflow: hidden;
}

.selected-services-table-container {
  padding: 1rem;
}

.selected-services-table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
  min-width: 800px;
}

.selected-services-table th {
  padding: 0.75rem 1rem;
  background-color: #f9fafb;
  color: #374151;
  font-weight: 600;
  text-align: left;
  border-bottom: 1px solid #e5e7eb;
  white-space: nowrap;
}

.selected-services-table td {
  padding: 0.75rem 1rem;
  border-bottom: 1px solid #e5e7eb;
  color: #4b5563;
}

.service-name {
  font-weight: 500;
  color: #111827;
}

.service-price,
.service-quantity {
  font-family: monospace;
  color: #4b5563;
}

.service-total {
  font-family: monospace;
  font-weight: 600;
  color: #059669;
}

.delete-button {
  display: inline-flex;
  align-items: center;
  padding: 0.375rem 0.75rem;
  background-color: #fee2e2;
  color: #dc2626;
  border-radius: 0.375rem;
  font-size: 0.875rem;
  font-weight: 500;
  transition: all 0.2s;
}

.delete-button:hover {
  background-color: #fecaca;
}

.empty-services {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 3rem 2rem;
  color: #6b7280;
  text-align: center;
}

.footer-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem;
  background-color: #f9fafb;
  border-top: 1px solid #e5e7eb;
}

.total-price {
  display: flex;
  align-items: baseline;
  gap: 0.5rem;
}

.total-label {
  font-size: 1.125rem;
  color: #374151;
}

.total-amount {
  font-size: 1.5rem;
  font-weight: 600;
  color: #059669;
}

.confirm-button {
  display: inline-flex;
  align-items: center;
  padding: 0.625rem 1.25rem;
  background-color: #059669;
  color: white;
  border-radius: 0.5rem;
  font-weight: 500;
  transition: all 0.2s;
}

.confirm-button:hover {
  background-color: #047857;
}
</style>