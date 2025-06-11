<template>
  <div class="user-manager-container">
    <!-- Thanh điều hướng -->
    <Navbar />
    <!-- Nội dung chính -->
    <div class="content-section">
      <div class="header-section">
        <h2>Quản Lý Khách Hàng</h2>
        <div class="search-header">
          <div class="search-group">
            <label for="searchPhone">Tìm kiếm theo số điện thoại:</label>
            <input
              type="text"
              id="searchPhone"
              v-model="searchPhone"
              placeholder="Nhập số điện thoại..."
              class="search-input"
              @input="handleSearch"
            />
          </div>
        </div>
      </div>

      <!-- Loading spinner -->
      <div v-if="loading" class="loading-container">
        <div class="spinner"></div>
        <p>Đang tải dữ liệu...</p>
      </div>

      <!-- Error message -->
      <div v-if="error" class="error-message">
        {{ error }}
      </div>

      <!-- Customer table -->
      <div v-if="!loading" class="table-container">
        <table class="customer-table">
          <thead>
            <tr>
              <th>Họ và tên</th>
              <th>Số điện thoại</th>
              <th>CCCD</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="customer in filteredCustomers" :key="customer.idKhachHang">
              <td>{{ customer.hoTen || 'Chưa cập nhật' }}</td>
              <td>{{ customer.dienThoai || 'Chưa cập nhật' }}</td>
              <td>{{ customer.cccd || 'Chưa cập nhật' }}</td>
            </tr>
            <tr v-if="filteredCustomers.length === 0">
              <td colspan="3" class="no-data">Không tìm thấy khách hàng nào</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/navbar.vue';
import { userService } from '@/services/userService';
import { authService } from '@/services/authService';
import { ref, computed, onMounted } from 'vue';
import { useRouter } from 'vue-router';

export default {
  name: 'UserManager',
  components: { Navbar },
  setup() {
    const router = useRouter();
    const customers = ref([]);
    const searchPhone = ref('');
    const loading = ref(false);
    const error = ref('');

    // Kiểm tra quyền admin
    const checkAdminAccess = () => {
      if (!authService.isAdmin()) {
        console.log('Access denied: User is not admin');
        router.push('/dashboard');
        return false;
      }
      return true;
    };

    // Lọc khách hàng theo số điện thoại
    const filteredCustomers = computed(() => {
      if (!searchPhone.value) return customers.value;
      const searchTerm = searchPhone.value.toLowerCase();
      return customers.value.filter(customer => 
        customer.dienThoai?.toString().includes(searchTerm)
      );
    });

    // Lấy danh sách khách hàng
    const fetchCustomers = async () => {
      if (!checkAdminAccess()) return;
      
      loading.value = true;
      error.value = '';
      try {
        console.log('Starting to fetch customers...');
        const response = await userService.getAllCustomers();
        console.log('Response received:', response);
        
        if (!response || !Array.isArray(response)) {
          throw new Error('Dữ liệu không hợp lệ');
        }

        customers.value = response.map(customer => ({
          idKhachHang: customer.idKhachHang,
          hoTen: customer.hoTen || customer.tenKhachHang || 'Chưa cập nhật',
          dienThoai: customer.dienThoai || customer.soDienThoai || 'Chưa cập nhật',
          cccd: customer.cccd || 'Chưa cập nhật'
        }));

        console.log('Processed customers:', customers.value);
      } catch (err) {
        console.error('Error in fetchCustomers:', err);
        error.value = err.message || 'Không thể tải danh sách khách hàng';
        if (err.message.includes('đăng nhập lại')) {
          authService.clearAuth();
          router.push('/login');
        }
      } finally {
        loading.value = false;
      }
    };

    // Xử lý tìm kiếm
    const handleSearch = () => {
      if (searchPhone.value.trim() === '') {
        fetchCustomers();
        return;
      }

      const searchTerm = searchPhone.value.trim();
      const filtered = customers.value.filter(customer => 
        customer.dienThoai?.toString().includes(searchTerm)
      );
      
      if (filtered.length === 0) {
        error.value = 'Không tìm thấy khách hàng nào';
      } else {
        error.value = '';
      }
    };

    // Mounted hook
    onMounted(() => {
      fetchCustomers();
    });

    return {
      customers,
      searchPhone,
      loading,
      error,
      filteredCustomers,
      handleSearch
    };
  }
};
</script>

<style scoped>
.user-manager-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background-color: #f5f7fa;
}

.content-section {
  flex: 1;
  padding: 2rem;
  overflow-y: auto;
}

.header-section {
  margin-bottom: 2rem;
}

.header-section h2 {
  color: #2c3e50;
  margin-bottom: 1rem;
}

.search-header {
  display: flex;
  align-items: center;
  gap: 1rem;
  margin-bottom: 1.5rem;
}

.search-group {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.search-group label {
  color: #2c3e50;
  font-weight: 500;
}

.search-input {
  padding: 0.5rem 1rem;
  border: 1px solid #dcdfe6;
  border-radius: 4px;
  font-size: 0.9rem;
  width: 250px;
  transition: all 0.3s;
}

.search-input:focus {
  outline: none;
  border-color: #409eff;
  box-shadow: 0 0 0 2px rgba(64, 158, 255, 0.2);
}

.table-container {
  background-color: white;
  border-radius: 8px;
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
}

.customer-table {
  width: 100%;
  border-collapse: collapse;
}

.customer-table th,
.customer-table td {
  padding: 1rem;
  text-align: left;
  border-bottom: 1px solid #ebeef5;
}

.customer-table th {
  background-color: #f5f7fa;
  color: #606266;
  font-weight: 500;
}

.customer-table tr:hover {
  background-color: #f5f7fa;
}

.no-data {
  text-align: center;
  color: #909399;
  padding: 2rem;
}

.loading-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 2rem;
}

.spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #409eff;
  border-radius: 50%;
  animation: spin 1s linear infinite;
}

.error-message {
  background-color: #fef0f0;
  color: #f56c6c;
  padding: 1rem;
  border-radius: 4px;
  margin-bottom: 1rem;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}
</style>