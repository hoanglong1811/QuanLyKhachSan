<!-- File: InvoiceDetail.vue -->
<template>
  <div class="page-container">
    <NavBar/>
    <div class="content-wrapper">
      <div class="content-container">
        <!-- Header Section -->
        <div class="header-section">
          <div class="info-section">
            <h1 class="page-title">Chi tiết hóa đơn</h1>
            <div class="info-grid">
              <div class="info-item">
                <span class="info-label">Mã hóa đơn:</span>
                <span class="info-value">{{ invoice.invoiceId }}</span>
              </div>
              <div class="info-item">
                <span class="info-label">Tên khách hàng:</span>
                <span class="info-value">{{ invoice.customerInfo }}</span>
              </div>
              <div class="info-item">
                <span class="info-label">Trạng thái:</span>
                <span :class="['status-badge', invoice.status === 'ĐÃ THANH TOÁN' ? 'status-paid' : 'status-unpaid']">
                  {{ invoice.status }}
                </span>
              </div>
            </div>
          </div>
          <div class="date-info">
            <div class="info-item">
              <span class="info-label">Ngày lập:</span>
              <span class="info-value">{{ invoice.date }}</span>
            </div>
            <div class="info-item">
              <span class="info-label">Giờ lập:</span>
              <span class="info-value">{{ invoice.time }}</span>
            </div>
          </div>
        </div>

        <!-- Service/Room Table -->
        <div class="table-container">
          <table class="invoice-table">
            <thead>
              <tr>
                <th>Tên dịch vụ/phòng</th>
                <th>Giá (VND)</th>
                <th>Số lượng</th>
                <th>Thành tiền (VND)</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in invoice.items" :key="index">
                <td>{{ item.name }}</td>
                <td>{{ item.price.toLocaleString() }}</td>
                <td>{{ item.quantity }}</td>
                <td class="amount-cell">{{ (item.price * item.quantity).toLocaleString() }}</td>
              </tr>
            </tbody>
          </table>
          <p v-if="!invoice.items.length" class="empty-message">
            Chưa có dịch vụ/phòng nào.
          </p>
        </div>

        <!-- Total Section -->
        <div class="total-section">
          <div class="total-card">
            <p class="total-label">Tổng tiền:</p>
            <p class="total-amount">{{ totalAmount.toLocaleString() }} VND</p>
          </div>
        </div>

        <!-- Action Buttons -->
        <div class="action-buttons">
          <button @click="goBack" class="btn btn-back">
            <i class="fas fa-arrow-left"></i>
            Quay lại
          </button>
          <button class="btn btn-print">
            <i class="fas fa-print"></i>
            In hóa đơn
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/navbar.vue';

export default {
  name: 'InvoiceDetail',
  components: {
    NavBar,
  },
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
      this.$router ? this.$router.go(-1) : window.history.back();
    },
  },
};
</script>

<style scoped>
.page-container {
  min-height: 100vh;
  background-color: #f7fafc;
  position: relative;
  padding-top: 64px;
}

.content-wrapper {
  padding: 2rem;
  max-width: 1400px;
  margin: 0 auto;
  position: relative;
  z-index: 1;
}

.content-container {
  background-color: white;
  border-radius: 0.75rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
  padding: 2rem;
}

.header-section {
  display: flex;
  justify-content: space-between;
  margin-bottom: 2rem;
  gap: 2rem;
  flex-wrap: wrap;
}

.info-section {
  flex: 1;
  min-width: 300px;
}

.page-title {
  font-size: 2rem;
  font-weight: 800;
  color: #1a202c;
  margin-bottom: 1.5rem;
}

.info-grid {
  display: grid;
  gap: 1rem;
}

.date-info {
  background-color: #f8fafc;
  padding: 1.5rem;
  border-radius: 0.5rem;
  min-width: 250px;
}

.info-item {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  margin-bottom: 0.5rem;
}

.info-label {
  font-weight: 600;
  color: #4a5568;
  min-width: 120px;
}

.info-value {
  color: #1a202c;
}

.status-badge {
  padding: 0.25rem 1rem;
  border-radius: 9999px;
  font-weight: 600;
}

.status-paid {
  background-color: #def7ec;
  color: #046c4e;
}

.status-unpaid {
  background-color: #fde8e8;
  color: #c81e1e;
}

.table-container {
  margin: 2rem 0;
  border: 1px solid #e2e8f0;
  border-radius: 0.5rem;
  overflow: hidden;
}

.invoice-table {
  width: 100%;
  border-collapse: collapse;
  min-width: 800px;
}

.invoice-table th {
  background-color: #f8fafc;
  padding: 1rem;
  text-align: left;
  font-weight: 600;
  color: #4a5568;
  border-bottom: 2px solid #e2e8f0;
}

.invoice-table td {
  padding: 1rem;
  border-bottom: 1px solid #e2e8f0;
  color: #4a5568;
}

.amount-cell {
  font-weight: 600;
}

.invoice-table tr:hover {
  background-color: #f8fafc;
}

.total-section {
  display: flex;
  justify-content: flex-end;
  margin: 2rem 0;
}

.total-card {
  background: linear-gradient(to right, #3182ce, #2c5282);
  padding: 1.5rem 2rem;
  border-radius: 0.5rem;
  color: white;
  min-width: 300px;
}

.total-label {
  font-size: 1.25rem;
  font-weight: 600;
  margin-bottom: 0.5rem;
}

.total-amount {
  font-size: 2rem;
  font-weight: 800;
}

.action-buttons {
  display: flex;
  justify-content: space-between;
  gap: 1rem;
  margin-top: 2rem;
}

.btn {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  font-weight: 600;
  transition: all 0.2s;
}

.btn i {
  font-size: 1.25rem;
}

.btn-back {
  background-color: #4a5568;
  color: white;
}

.btn-back:hover {
  background-color: #2d3748;
}

.btn-print {
  background-color: #38a169;
  color: white;
}

.btn-print:hover {
  background-color: #2f855a;
}

.empty-message {
  text-align: center;
  color: #718096;
  padding: 2rem;
}

/* Responsive Design */
@media (max-width: 768px) {
  .page-container {
    padding-top: 56px;
  }

  .content-wrapper {
    padding: 1rem;
  }

  .content-container {
    padding: 1rem;
  }

  .header-section {
    flex-direction: column;
  }

  .date-info {
    width: 100%;
  }

  .table-container {
    margin: 1rem -1rem;
    border-radius: 0;
    border-left: none;
    border-right: none;
  }

  .action-buttons {
    flex-direction: column;
  }

  .btn {
    width: 100%;
    justify-content: center;
  }
}

/* Print styles */
@media print {
  .page-container {
    background-color: white;
    padding: 0;
  }

  .content-wrapper {
    padding: 0;
  }

  .content-container {
    box-shadow: none;
    padding: 0;
  }

  .btn-back {
    display: none;
  }
}
</style>