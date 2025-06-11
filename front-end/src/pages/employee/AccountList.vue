<!-- File: AccountList.vue -->
<template>
  <div>
    <Navbar />
    <div class="page-container">
      <div class="content-wrapper">
        <div class="content-container">
          <!-- Header Section -->
          <div class="header-section">
            <div class="header-left">
              <h1 class="page-title">Quản lý tài khoản</h1>
              <p class="subtitle">Danh sách và quản lý tài khoản nhân viên</p>
            </div>
            <div class="header-right">
              <button class="add-button" @click="openAddModal">
                <i class="fas fa-plus"></i>
                Thêm tài khoản
              </button>
            </div>
          </div>

          <!-- Search and Filter Section -->
          <div class="search-section">
            <div class="search-box">
              <i class="fas fa-search"></i>
              <input 
                type="text" 
                v-model="searchQuery" 
                placeholder="Tìm kiếm theo tên, email hoặc vị trí..."
                @input="handleSearch"
              >
            </div>
            <div class="filter-box">
              <select v-model="roleFilter" @change="handleFilter">
                <option value="">Tất cả vai trò</option>
                <option value="admin">Quản trị viên</option>
                <option value="employee">Nhân viên</option>
              </select>
            </div>
          </div>

          <!-- Accounts Table -->
          <div class="table-container">
            <table class="accounts-table">
              <thead>
                <tr>
                  <th>Họ và tên</th>
                  <th>Email</th>
                  <th>Số điện thoại</th>
                  <th>Vị trí</th>
                  <th>Vai trò</th>
                  <th>Trạng thái</th>
                  <th>Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="account in filteredAccounts" :key="account.id">
                  <td>{{ account.fullName }}</td>
                  <td>{{ account.email }}</td>
                  <td>{{ account.phone }}</td>
                  <td>{{ account.position }}</td>
                  <td>
                    <span class="role-badge" :class="account.role">
                      {{ account.role === 'admin' ? 'Quản trị viên' : 'Nhân viên' }}
                    </span>
                  </td>
                  <td>
                    <span class="status-badge" :class="account.status">
                      {{ account.status === 'active' ? 'Hoạt động' : 'Không hoạt động' }}
                    </span>
                  </td>
                  <td>
                    <div class="action-buttons">
                      <button class="action-button edit" @click="openEditModal(account)">
                        <i class="fas fa-edit"></i>
                      </button>
                      <button class="action-button delete" @click="confirmDelete(account)">
                        <i class="fas fa-trash"></i>
                      </button>
                    </div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>

          <!-- Add/Edit Account Modal -->
          <div class="modal" v-if="showModal">
            <div class="modal-content">
              <div class="modal-header">
                <h2>{{ isEditing ? 'Chỉnh sửa tài khoản' : 'Thêm tài khoản mới' }}</h2>
                <button class="close-button" @click="closeModal">
                  <i class="fas fa-times"></i>
                </button>
              </div>
              <div class="modal-body">
                <form @submit.prevent="handleSubmit">
                  <div class="form-group">
                    <label>Họ và tên</label>
                    <input type="text" v-model="formData.fullName" required>
                  </div>
                  <div class="form-group">
                    <label>Email</label>
                    <input type="email" v-model="formData.email" required>
                  </div>
                  <div class="form-group">
                    <label>Số điện thoại</label>
                    <input type="tel" v-model="formData.phone" required>
                  </div>
                  <div class="form-group">
                    <label>Vị trí</label>
                    <input type="text" v-model="formData.position" required>
                  </div>
                  <div class="form-group">
                    <label>Vai trò</label>
                    <select v-model="formData.role" required>
                      <option value="employee">Nhân viên</option>
                      <option value="admin">Quản trị viên</option>
                    </select>
                  </div>
                  <div class="form-group" v-if="!isEditing">
                    <label>Mật khẩu</label>
                    <input type="password" v-model="formData.password" required>
                  </div>
                  <div class="form-group">
                    <label>Trạng thái</label>
                    <select v-model="formData.status" required>
                      <option value="active">Hoạt động</option>
                      <option value="inactive">Không hoạt động</option>
                    </select>
                  </div>
                  <div class="modal-footer">
                    <button type="button" class="cancel-button" @click="closeModal">Hủy</button>
                    <button type="submit" class="submit-button">
                      {{ isEditing ? 'Cập nhật' : 'Thêm mới' }}
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>

          <!-- Delete Confirmation Modal -->
          <div class="modal" v-if="showDeleteModal">
            <div class="modal-content delete-modal">
              <div class="modal-header">
                <h2>Xác nhận xóa</h2>
                <button class="close-button" @click="closeDeleteModal">
                  <i class="fas fa-times"></i>
                </button>
              </div>
              <div class="modal-body">
                <p>Bạn có chắc chắn muốn xóa tài khoản này?</p>
                <p class="account-info">{{ accountToDelete?.fullName }} ({{ accountToDelete?.email }})</p>
                <div class="modal-footer">
                  <button class="cancel-button" @click="closeDeleteModal">Hủy</button>
                  <button class="delete-button" @click="handleDelete">Xóa</button>
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
import Navbar from '@/components/navbar.vue';
import axios from 'axios';

export default {
  name: 'AccountList',
  components: {
    Navbar
  },
  data() {
    return {
      accounts: [],
      searchQuery: '',
      roleFilter: '',
      showModal: false,
      showDeleteModal: false,
      isEditing: false,
      accountToDelete: null,
      formData: {
        fullName: '',
        email: '',
        phone: '',
        position: '',
        role: 'employee',
        status: 'active',
        password: ''
      }
    };
  },
  computed: {
    filteredAccounts() {
      let filtered = this.accounts;
      
      // Filter by search query
      if (this.searchQuery) {
        const query = this.searchQuery.toLowerCase();
        filtered = filtered.filter(account => 
          account.fullName.toLowerCase().includes(query) ||
          account.email.toLowerCase().includes(query) ||
          account.position.toLowerCase().includes(query)
        );
      }
      
      // Filter by role
      if (this.roleFilter) {
        filtered = filtered.filter(account => account.role === this.roleFilter);
      }
      
      return filtered;
    }
  },
  created() {
    this.fetchAccounts();
  },
  methods: {
    async fetchAccounts() {
      try {
        const response = await axios.get('http://localhost:5012/api/TaiKhoan', {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });
        // Transform the data to match our component's structure
        this.accounts = response.data.map(account => ({
          id: account.idTaiKhoan,
          fullName: account.tenDangNhap,
          email: account.email,
          phone: account.soDienThoai || '',
          position: account.viTri || '',
          role: account.idVaiTro === 1 ? 'admin' : 'employee',
          status: account.trangThai || 'active'
        }));
      } catch (error) {
        console.error('Error fetching accounts:', error);
        alert('Không thể tải danh sách tài khoản. Vui lòng thử lại sau.');
      }
    },
    openAddModal() {
      this.isEditing = false;
      this.formData = {
        fullName: '',
        email: '',
        phone: '',
        position: '',
        role: 'employee',
        status: 'active',
        password: ''
      };
      this.showModal = true;
    },
    openEditModal(account) {
      this.isEditing = true;
      this.formData = { ...account };
      this.showModal = true;
    },
    closeModal() {
      this.showModal = false;
      this.formData = {
        fullName: '',
        email: '',
        phone: '',
        position: '',
        role: 'employee',
        status: 'active',
        password: ''
      };
    },
    async handleSubmit() {
      try {
        if (this.isEditing) {
          await axios.put(`http://localhost:3000/api/accounts/${this.formData.id}`, this.formData, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('token')}`
            }
          });
          alert('Cập nhật tài khoản thành công!');
        } else {
          await axios.post('http://localhost:3000/api/accounts', this.formData, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('token')}`
            }
          });
          alert('Thêm tài khoản mới thành công!');
        }
        this.closeModal();
        this.fetchAccounts();
      } catch (error) {
        console.error('Error saving account:', error);
        alert('Không thể lưu tài khoản. Vui lòng thử lại sau.');
      }
    },
    confirmDelete(account) {
      this.accountToDelete = account;
      this.showDeleteModal = true;
    },
    closeDeleteModal() {
      this.showDeleteModal = false;
      this.accountToDelete = null;
    },
    async handleDelete() {
      try {
        await axios.delete(`http://localhost:3000/api/accounts/${this.accountToDelete.id}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });
        alert('Xóa tài khoản thành công!');
        this.closeDeleteModal();
        this.fetchAccounts();
      } catch (error) {
        console.error('Error deleting account:', error);
        alert('Không thể xóa tài khoản. Vui lòng thử lại sau.');
      }
    },
    handleSearch() {
      // Search is handled by computed property
    },
    handleFilter() {
      // Filter is handled by computed property
    }
  }
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
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
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
}

.subtitle {
  color: #6b7280;
  font-size: 0.975rem;
}

.add-button {
  padding: 0.75rem 1.5rem;
  background-color: #10b981;
  color: white;
  border: none;
  border-radius: 0.5rem;
  font-size: 0.875rem;
  cursor: pointer;
  display: flex;
  align-items: center;
  gap: 0.5rem;
  transition: background-color 0.3s;
}

.add-button:hover {
  background-color: #059669;
}

.search-section {
  display: flex;
  gap: 1rem;
  margin-bottom: 1.5rem;
}

.search-box {
  flex: 1;
  position: relative;
}

.search-box i {
  position: absolute;
  left: 1rem;
  top: 50%;
  transform: translateY(-50%);
  color: #6b7280;
}

.search-box input {
  width: 100%;
  padding: 0.75rem 1rem 0.75rem 2.5rem;
  border: 1px solid #e5e7eb;
  border-radius: 0.5rem;
  font-size: 0.875rem;
}

.search-box input:focus {
  outline: none;
  border-color: #3b82f6;
  box-shadow: 0 0 0 2px rgba(59, 130, 246, 0.1);
}

.filter-box select {
  padding: 0.75rem 1rem;
  border: 1px solid #e5e7eb;
  border-radius: 0.5rem;
  font-size: 0.875rem;
  min-width: 150px;
}

.table-container {
  overflow-x: auto;
}

.accounts-table {
  width: 100%;
  border-collapse: collapse;
}

.accounts-table th,
.accounts-table td {
  padding: 1rem;
  text-align: left;
  border-bottom: 1px solid #e5e7eb;
}

.accounts-table th {
  font-weight: 600;
  color: #374151;
  background-color: #f9fafb;
}

.role-badge {
  padding: 0.25rem 0.75rem;
  border-radius: 9999px;
  font-size: 0.75rem;
  font-weight: 500;
}

.role-badge.admin {
  background-color: #fee2e2;
  color: #ef4444;
}

.role-badge.employee {
  background-color: #dbeafe;
  color: #3b82f6;
}

.status-badge {
  padding: 0.25rem 0.75rem;
  border-radius: 9999px;
  font-size: 0.75rem;
  font-weight: 500;
}

.status-badge.active {
  background-color: #dcfce7;
  color: #10b981;
}

.status-badge.inactive {
  background-color: #f3f4f6;
  color: #6b7280;
}

.action-buttons {
  display: flex;
  gap: 0.5rem;
}

.action-button {
  padding: 0.5rem;
  border: none;
  border-radius: 0.375rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.action-button.edit {
  background-color: #dbeafe;
  color: #3b82f6;
}

.action-button.edit:hover {
  background-color: #bfdbfe;
}

.action-button.delete {
  background-color: #fee2e2;
  color: #ef4444;
}

.action-button.delete:hover {
  background-color: #fecaca;
}

.modal {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
}

.modal-content {
  background-color: white;
  border-radius: 1rem;
  width: 100%;
  max-width: 600px;
  max-height: 90vh;
  overflow-y: auto;
}

.modal-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem;
  border-bottom: 1px solid #e5e7eb;
}

.modal-header h2 {
  font-size: 1.25rem;
  font-weight: 600;
  color: #111827;
  margin: 0;
}

.close-button {
  background: none;
  border: none;
  color: #6b7280;
  cursor: pointer;
  padding: 0.5rem;
}

.modal-body {
  padding: 1.5rem;
}

.form-group {
  margin-bottom: 1.5rem;
}

.form-group label {
  display: block;
  font-size: 0.875rem;
  font-weight: 500;
  color: #374151;
  margin-bottom: 0.5rem;
}

.form-group input,
.form-group select {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #e5e7eb;
  border-radius: 0.5rem;
  font-size: 0.875rem;
}

.form-group input:focus,
.form-group select:focus {
  outline: none;
  border-color: #3b82f6;
  box-shadow: 0 0 0 2px rgba(59, 130, 246, 0.1);
}

.modal-footer {
  display: flex;
  justify-content: flex-end;
  gap: 1rem;
  margin-top: 2rem;
}

.cancel-button {
  padding: 0.75rem 1.5rem;
  background-color: #f3f4f6;
  color: #374151;
  border: none;
  border-radius: 0.5rem;
  font-size: 0.875rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.cancel-button:hover {
  background-color: #e5e7eb;
}

.submit-button {
  padding: 0.75rem 1.5rem;
  background-color: #3b82f6;
  color: white;
  border: none;
  border-radius: 0.5rem;
  font-size: 0.875rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.submit-button:hover {
  background-color: #2563eb;
}

.delete-modal .modal-content {
  max-width: 400px;
}

.delete-modal .account-info {
  margin: 1rem 0;
  padding: 1rem;
  background-color: #f9fafb;
  border-radius: 0.5rem;
  font-size: 0.875rem;
  color: #374151;
}

.delete-button {
  padding: 0.75rem 1.5rem;
  background-color: #ef4444;
  color: white;
  border: none;
  border-radius: 0.5rem;
  font-size: 0.875rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

.delete-button:hover {
  background-color: #dc2626;
}

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

  .search-section {
    flex-direction: column;
  }

  .filter-box select {
    width: 100%;
  }
}
</style> 