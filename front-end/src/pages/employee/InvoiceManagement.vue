<!-- File: InvoiceManagement.vue -->
<template>
  <div class="page-container">
    <NavBar />
    <div class="content-wrapper">
      <div class="content-container">
        <!-- Header Section -->
        <div class="header-section">
          <div class="header-left">
            <h1 class="page-title">Quản lý hóa đơn</h1>
            <p class="subtitle">Xem và quản lý tất cả hóa đơn</p>
          </div>
          <button class="back-button" @click="goBack">
            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7"></path>
            </svg>
            <span>Quay lại</span>
          </button>
        </div>

        <!-- Table Section -->
        <div class="table-container">
          <div class="table-wrapper">
            <table class="invoice-table">
              <thead>
                <tr>
                  <th>Mã hóa đơn</th>
                  <th>Thông tin khách hàng</th>
                  <th>Trạng thái thanh toán</th>
                  <th>Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(invoice, index) in invoices" :key="index" class="invoice-row">
                  <td class="invoice-id">{{ invoice.invoiceId }}</td>
                  <td class="customer-info">{{ invoice.customerInfo }}</td>
                  <td>
                    <span :class="getStatusClass(invoice.status)" class="status-badge">
                      {{ invoice.status }}
                    </span>
                  </td>
                  <td>
                    <button class="view-button" @click="viewDetails(invoice)">
                      <svg class="w-5 h-5 mr-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                      </svg>
                      Xem chi tiết
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
          <p v-if="!invoices.length" class="empty-message">
            <svg class="w-16 h-16 mb-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
            </svg>
            Chưa có hóa đơn nào.
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import NavBar from '@/components/navbar.vue';

export default {
  name: 'InvoiceManagement',
  components: {
    NavBar
  },
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
      this.$router ? this.$router.go(-1) : window.history.back();
    },
    viewDetails(invoice) {
      this.$router.push(`/employee/invoice-detail/${invoice.invoiceId}`);
    },
    getStatusClass(status) {
      return status === 'ĐÃ THANH TOÁN' 
        ? 'status-paid' 
        : 'status-unpaid';
    }
  },
};
</script>

<style scoped>
.page-container {
  min-height: 100vh;
  background-color: #f3f4f6;
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

.table-container {
  background-color: white;
  border-radius: 0.75rem;
  overflow: hidden;
}

.table-wrapper {
  overflow-x: auto;
  margin: 0 -1rem;
}

.invoice-table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
  min-width: 800px;
}

.invoice-table th {
  background-color: #f9fafb;
  color: #374151;
  font-weight: 600;
  padding: 1rem 1.5rem;
  text-align: left;
  border-bottom: 1px solid #e5e7eb;
  white-space: nowrap;
}

.invoice-table td {
  padding: 1rem 1.5rem;
  color: #4b5563;
  border-bottom: 1px solid #e5e7eb;
}

.invoice-row {
  transition: background-color 0.2s;
}

.invoice-row:hover {
  background-color: #f9fafb;
}

.invoice-id {
  font-family: monospace;
  font-weight: 600;
  color: #2563eb;
}

.customer-info {
  font-weight: 500;
}

.status-badge {
  display: inline-flex;
  align-items: center;
  padding: 0.25rem 0.75rem;
  border-radius: 9999px;
  font-size: 0.875rem;
  font-weight: 500;
}

.status-paid {
  background-color: #dcfce7;
  color: #15803d;
}

.status-unpaid {
  background-color: #fee2e2;
  color: #b91c1c;
}

.view-button {
  display: inline-flex;
  align-items: center;
  padding: 0.375rem 0.75rem;
  background-color: #f3f4f6;
  color: #3b82f6;
  border: 1px solid #e5e7eb;
  border-radius: 0.375rem;
  font-size: 0.875rem;
  font-weight: 500;
  transition: all 0.2s;
}

.view-button:hover {
  background-color: #3b82f6;
  color: white;
  border-color: #3b82f6;
}

.view-button svg {
  width: 1rem;
  height: 1rem;
  margin-right: 0.375rem;
}

.empty-message {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 4rem 2rem;
  color: #6b7280;
  text-align: center;
  font-size: 1rem;
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
    border-radius: 0.5rem;
  }

  .header-section {
    flex-direction: column;
    align-items: flex-start;
    gap: 1rem;
    margin-bottom: 1.5rem;
  }

  .back-button {
    width: 100%;
    justify-content: center;
  }

  .table-wrapper {
    margin: 0;
    border-radius: 0.5rem;
    border: 1px solid #e5e7eb;
  }

  .invoice-table th,
  .invoice-table td {
    padding: 0.75rem 1rem;
  }
}

/* Print styles */
@media print {
  .page-container {
    background-color: white;
    padding-top: 0;
  }

  .content-wrapper {
    padding: 0;
  }

  .content-container {
    box-shadow: none;
    padding: 0;
  }

  .back-button,
  .view-button svg {
    display: none;
  }

  .header-section {
    border-bottom: none;
  }

  .invoice-table {
    border: 1px solid #e5e7eb;
  }

  .status-badge {
    border: 1px solid currentColor;
  }
}
</style>