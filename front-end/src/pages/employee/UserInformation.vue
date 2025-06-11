<template>
  <div class="user-info-container">
    <!-- Thanh điều hướng -->
    <Navbar />
    <!-- Nút đăng xuất ở góc trái bên dưới -->
    <button class="logout-btn" @click="logout">Đăng xuất</button>
    <!-- Nội dung chính -->
    <div class="content-section">
      <!-- Loading state -->
      <div v-if="loading" class="loading-overlay">
        <div class="spinner"></div>
        <p class="loading-text">{{ loadingText }}</p>
      </div>

      <!-- Error message -->
      <div v-if="error" class="error-message">
        {{ error }}
        <button class="close-error" @click="error = ''">×</button>
      </div>

      <!-- Success message -->
      <div v-if="successMessage" class="success-message">
        {{ successMessage }}
        <button class="close-success" @click="successMessage = ''">×</button>
      </div>

      <div class="info-card" v-if="employeeInfo">
        <div class="avatar-section">
          <div class="avatar" />
          <h2 class="user-name">{{ employeeInfo.name }}</h2>
          <span class="role-badge">{{ employeeInfo.role }}</span>
        </div>
        
        <!-- Normal view mode -->
        <div class="info-details" v-if="!isEditing">
          <div class="info-item">
            <span class="label">Email:</span>
            <span class="value">{{ employeeInfo.email }}</span>
          </div>
          <div class="info-item">
            <span class="label">Giới tính:</span>
            <span class="value">{{ employeeInfo.gender || 'Chưa cập nhật' }}</span>
          </div>
          <div class="info-item">
            <span class="label">Số điện thoại:</span>
            <span class="value">{{ employeeInfo.phone || 'Chưa cập nhật' }}</span>
          </div>
          <div class="info-item">
            <span class="label">Địa chỉ:</span>
            <span class="value">{{ employeeInfo.address || 'Chưa cập nhật' }}</span>
          </div>
          <button class="edit-btn" @click="startEdit">
            <i class="fas fa-edit"></i> Chỉnh sửa thông tin
          </button>
        </div>

        <!-- Edit mode -->
        <div class="info-details edit-mode" v-else>
          <div class="form-group">
            <label>Họ tên: <span class="required">*</span></label>
            <input 
              type="text" 
              v-model="editForm.name"
              :class="{ 'error': validationErrors.name }"
            />
            <span class="error-text" v-if="validationErrors.name">
              {{ validationErrors.name }}
            </span>
          </div>
          <div class="form-group">
            <label>Email:</label>
            <input type="email" v-model="editForm.email" readonly class="readonly-input" />
          </div>
          <div class="form-group">
            <label>Giới tính:</label>
            <select v-model="editForm.gender">
              <option value="">Chọn giới tính</option>
              <option value="Nam">Nam</option>
              <option value="Nữ">Nữ</option>
              <option value="Khác">Khác</option>
            </select>
          </div>
          <div class="form-group">
            <label>Số điện thoại: <span class="required">*</span></label>
            <input 
              type="tel" 
              v-model="editForm.phone"
              :class="{ 'error': validationErrors.phone }"
            />
            <span class="error-text" v-if="validationErrors.phone">
              {{ validationErrors.phone }}
            </span>
          </div>
          <div class="form-group">
            <label>Địa chỉ:</label>
            <input type="text" v-model="editForm.address" />
          </div>
          <div class="button-group">
            <button class="cancel-btn" @click="cancelEdit">
              <i class="fas fa-times"></i> Hủy
            </button>
            <button class="save-btn" @click="saveChanges" :disabled="loading">
              <i class="fas fa-save"></i> {{ loading ? 'Đang lưu...' : 'Lưu thay đổi' }}
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Confirm logout modal -->
    <div v-if="showLogoutConfirm" class="modal-overlay" @click.self="showLogoutConfirm = false">
      <div class="modal-content">
        <h3>Xác nhận đăng xuất</h3>
        <p>Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?</p>
        <div class="button-group">
          <button class="cancel-btn" @click="showLogoutConfirm = false">
            <i class="fas fa-times"></i> Hủy
          </button>
          <button class="confirm-btn" @click="confirmLogout" :disabled="loading">
            <i class="fas fa-sign-out-alt"></i> {{ loading ? 'Đang xử lý...' : 'Xác nhận' }}
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue';
import { userService } from '@/services/userService';
import { authService } from '@/services/authService';

export default {
  components: { Navbar },
  data() {
    return {
      user: null,
      employeeInfo: null,
      loading: false,
      loadingText: '',
      error: '',
      successMessage: '',
      isEditing: false,
      showLogoutConfirm: false,
      editForm: {
        name: '',
        email: '',
        gender: '',
        phone: '',
        address: ''
      },
      validationErrors: {
        name: '',
        phone: ''
      }
    };
  },
  methods: {
    async fetchEmployeeInfo() {
      this.loading = true;
      this.loadingText = 'Đang tải thông tin...';
      this.error = '';
      try {
        const user = authService.getCurrentUser();
        console.log('Current user from localStorage:', user);

        if (!user || !user.id) {
          console.error('Invalid user data:', user);
          this.error = 'Không thể xác thực người dùng';
          this.$router.push('/login');
          return;
        }

        this.user = user;
        console.log('Fetching employee info for account ID:', user.id);
        
        const response = await userService.getEmployeeInfo(user.id);
        console.log('Employee info response:', response);

        if (response) {
          this.employeeInfo = {
            idNhanVien: response.idNhanVien,
            name: response.hoTen || '',
            email: response.email || user.email || '',
            role: response.vaiTro || user.role || '',
            gender: response.gioiTinh || '',
            phone: response.dienThoai?.toString() || '',
            address: response.diaChi || ''
          };
          console.log('Processed employee info:', this.employeeInfo);
        } else {
          throw new Error('Không tìm thấy thông tin nhân viên');
        }
      } catch (err) {
        console.error('Error fetching employee info:', {
          message: err.message,
          response: err.response?.data,
          status: err.response?.status,
          user: this.user
        });
        this.error = 'Không thể tải thông tin nhân viên: ' + (err.response?.data?.message || err.message);
        
        if (err.response?.status === 401) {
          authService.clearAuth();
          this.$router.push('/login');
        }
      } finally {
        this.loading = false;
        this.loadingText = '';
      }
    },

    validateForm() {
      let isValid = true;
      this.validationErrors = {
        name: '',
        phone: ''
      };

      if (!this.editForm.name.trim()) {
        this.validationErrors.name = 'Họ tên không được để trống';
        isValid = false;
      }

      if (this.editForm.phone.trim()) {
        if (!/^\d{10}$/.test(this.editForm.phone.trim())) {
          this.validationErrors.phone = 'Số điện thoại phải có 10 chữ số';
          isValid = false;
        }
      }

      return isValid;
    },

    startEdit() {
      this.editForm = {
        name: this.employeeInfo.name,
        email: this.employeeInfo.email,
        gender: this.employeeInfo.gender,
        phone: this.employeeInfo.phone,
        address: this.employeeInfo.address
      };
      this.isEditing = true;
    },

    cancelEdit() {
      this.isEditing = false;
      this.editForm = {
        name: '',
        email: '',
        gender: '',
        phone: '',
        address: ''
      };
      this.validationErrors = {
        name: '',
        phone: ''
      };
    },

    async saveChanges() {
      if (!this.validateForm()) {
        return;
      }

      this.loading = true;
      this.loadingText = 'Đang lưu thay đổi...';
      this.error = '';
      try {
        const updateData = {
          hoTen: this.editForm.name.trim(),
          gioiTinh: this.editForm.gender || null,
          diaChi: this.editForm.address.trim() || null,
          dienThoai: this.editForm.phone.trim() ? parseInt(this.editForm.phone.trim()) : null,
          isActive: true
        };

        console.log('Sending update data:', {
          employeeId: this.employeeInfo.idNhanVien,
          updateData
        });

        await userService.updateEmployeeInfo(this.employeeInfo.idNhanVien, updateData);
        
        await this.fetchEmployeeInfo();
        this.isEditing = false;
        this.successMessage = 'Cập nhật thông tin thành công!';
        setTimeout(() => {
          this.successMessage = '';
        }, 3000);
      } catch (err) {
        console.error('Error updating employee info:', {
          error: err,
          response: err.response?.data,
          status: err.response?.status
        });
        this.error = 'Không thể cập nhật thông tin: ' + (err.response?.data?.message || err.message);
      } finally {
        this.loading = false;
        this.loadingText = '';
      }
    },

    logout() {
      this.showLogoutConfirm = true;
    },

    async confirmLogout() {
      this.loading = true;
      this.loadingText = 'Đang đăng xuất...';
      try {
        authService.clearAuth();
        this.$router.push('/login');
      } catch (err) {
        console.error('Lỗi đăng xuất:', err);
        this.error = 'Không thể đăng xuất: ' + err.message;
      } finally {
        this.loading = false;
        this.loadingText = '';
        this.showLogoutConfirm = false;
      }
    }
  },
  created() {
    this.fetchEmployeeInfo();
  }
};
</script>

<style scoped>
.user-info-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background: linear-gradient(135deg, #f5f7fa, #ffffff);
}

.content-section {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 2rem;
  margin-top: 60px;
  background-color: #f8f9fa;
  overflow-y: auto;
}

.info-card {
  background: white;
  border-radius: 1rem;
  box-shadow: 0 4px 20px rgba(44, 62, 80, 0.1);
  width: 100%;
  max-width: 600px;
  margin-top: 1rem;
  padding: 2.5rem;
  border: 1px solid rgba(52, 152, 219, 0.1);
}

.avatar-section {
  text-align: center;
  padding-bottom: 2rem;
  margin-bottom: 2rem;
  border-bottom: 2px solid #e9ecef;
  position: relative;
}

.avatar-section::after {
  content: '';
  position: absolute;
  bottom: -2px;
  left: 25%;
  right: 25%;
  height: 2px;
  background: linear-gradient(to right, transparent, #3498db, transparent);
}

.user-name {
  font-size: 2rem;
  font-weight: 700;
  color: #2c3e50;
  margin: 0 0 1rem 0;
  letter-spacing: -0.5px;
}

.role-badge {
  display: inline-block;
  background: linear-gradient(135deg, #3498db, #2980b9);
  color: white;
  padding: 0.5rem 1.5rem;
  border-radius: 2rem;
  font-size: 0.875rem;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 0.5px;
  box-shadow: 0 2px 8px rgba(52, 152, 219, 0.2);
}

/* Form Edit Mode */
.info-details.edit-mode {
  background: #f8f9fa;
  padding: 2rem;
  border-radius: 1rem;
  box-shadow: inset 0 2px 4px rgba(44, 62, 80, 0.05);
  max-width: 500px;
  margin: 0 auto;
}

.form-group {
  margin-bottom: 2rem;
  position: relative;
  max-width: 100%;
}

.form-group:last-child {
  margin-bottom: 0;
}

.form-group label {
  display: inline-block;
  margin-bottom: 0.75rem;
  color: #2c3e50;
  font-weight: 600px;
  font-size: 0.95rem;
  padding-left: 0.75rem;
  position: relative;
}

.form-group label::before {
  content: '';
  position: absolute;
  left: 0;
  top: 50%;
  transform: translateY(-50%);
  width: 0px;
  height: 1rem;
  background: #3498db;
  border-radius: 3px;
}

.required {
  color: #e74c3c;
  margin-left: 0.25rem;
}

.form-group input,
.form-group select {
  width: 90%;
  max-width: 100%;
  padding: 1rem 1.25rem;
  border: 2px solid #e9ecef;
  border-radius: 0.75rem;
  font-size: 1rem;
  transition: all 0.3s ease;
  background: white;
  color: #2c3e50;
  -webkit-appearance: none;
  -moz-appearance: none;
  appearance: none;
}

.form-group select {
  background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none' stroke='%232c3e50' stroke-width='2' stroke-linecap='round' stroke-linejoin='round'%3E%3Cpolyline points='6 9 12 15 18 9'%3E%3C/polyline%3E%3C/svg%3E");
  background-repeat: no-repeat;
  background-position: right 1rem center;
  background-size: 1.25rem;
  padding-right: 3rem;
}

.form-group input:hover,
.form-group select:hover {
  border-color: #3498db;
}

.form-group input:focus,
.form-group select:focus {
  outline: none;
  border-color: #3498db;
  box-shadow: 0 0 0 4px rgba(52, 152, 219, 0.1);
}

.form-group input.error {
  border-color: #e74c3c;
  background-color: #fff5f5;
}

.error-text {
  position: absolute;
  left: 0;
  top: 100%;
  margin-top: 0.5rem;
  color: #e74c3c;
  font-size: 0.875rem;
  font-weight: 500;
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.error-text::before {
  content: "⚠";
  font-size: 1rem;
}

.readonly-input {
  background-color: #f8f9fa !important;
  cursor: not-allowed;
  color: #7f8c8d;
  border-style: dashed !important;
}

/* View Mode */
.info-item {
  display: flex;
  align-items: center;
  padding: 1.25rem;
  background: #f8f9fa;
  border-radius: 0.75rem;
  transition: all 0.3s ease;
  border: 1px solid #e9ecef;
  position: relative;
  overflow: hidden;
  margin-bottom: 1rem;
}

.info-item::before {
  content: '';
  position: absolute;
  left: 0;
  top: 0;
  bottom: 0;
  width: 4px;
  background: linear-gradient(to bottom, #3498db, #2980b9);
  opacity: 0;
  transition: opacity 0.3s ease;
}

.info-item:hover {
  background: white;
  transform: translateX(5px);
  border-color: #3498db;
  box-shadow: 0 4px 12px rgba(52, 152, 219, 0.1);
}

.info-item:hover::before {
  opacity: 1;
}

.label {
  font-weight: 600;
  color: #2c3e50;
  min-width: 140px;
}

.value {
  color: #2c3e50;
  flex: 1;
  font-weight: 500;
}

/* Buttons */
.button-group {
  display: flex;
  gap: 1rem;
  margin-top: 2.5rem;
  padding-top: 2rem;
  border-top: 2px solid #e9ecef;
}

.edit-btn,
.save-btn,
.cancel-btn,
.confirm-btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 0.75rem;
  padding: 1rem 2rem;
  border: none;
  border-radius: 0.75rem;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
}

.edit-btn,
.save-btn {
  background: linear-gradient(135deg, #3498db, #2980b9);
  color: white;
  border: none;
}

.edit-btn {
  width: 100%;
}

.save-btn {
  flex: 1;
}

.cancel-btn {
  background: #f8f9fa;
  color: #2c3e50;
  border: 2px solid #e9ecef;
  flex: 1;
}

.confirm-btn {
  background: linear-gradient(135deg, #e74c3c, #c0392b);
  color: white;
  flex: 1;
}

.edit-btn:hover,
.save-btn:hover {
  background: linear-gradient(135deg, #2980b9, #2472a4);
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(52, 152, 219, 0.2);
}

.cancel-btn:hover {
  background: #e9ecef;
  transform: translateY(-2px);
  border-color: #cbd5e0;
}

.confirm-btn:hover {
  background: linear-gradient(135deg, #c0392b, #a93226);
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(231, 76, 60, 0.2);
}

.logout-btn {
  position: fixed;
  bottom: 2rem;
  left: 2rem;
  display: inline-flex;
  align-items: center;
  gap: 0.75rem;
  padding: 1rem 2rem;
  background: linear-gradient(135deg, #e74c3c, #c0392b);
  color: white;
  border: none;
  border-radius: 0.75rem;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  z-index: 100;
}

.logout-btn:hover {
  background: linear-gradient(135deg, #c0392b, #a93226);
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(231, 76, 60, 0.2);
}

/* Messages */
.error-message,
.success-message {
  width: 100%;
  max-width: 600px;
  margin: 0 auto 1.5rem auto;
  padding: 1rem 1.5rem;
  border-radius: 0.75rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-weight: 500;
}

.error-message {
  background-color: #fdf2f2;
  color: #c0392b;
  border: 1px solid #fbd5d5;
}

.success-message {
  background-color: #ebf8ff;
  color: #2980b9;
  border: 1px solid #bee3f8;
}

/* Modal */
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(44, 62, 80, 0.7);
  backdrop-filter: blur(4px);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal-content {
  background: white;
  padding: 2.5rem;
  border-radius: 1rem;
  width: 90%;
  max-width: 400px;
  text-align: center;
  box-shadow: 0 4px 20px rgba(44, 62, 80, 0.15);
}

.modal-content h3 {
  margin: 0 0 1rem 0;
  color: #2c3e50;
  font-size: 1.5rem;
  font-weight: 700;
}

.modal-content p {
  margin-bottom: 2rem;
  color: #34495e;
  font-size: 1.1rem;
  line-height: 1.5;
}

/* Responsive */
@media (max-width: 768px) {
  .content-section {
    padding: 1rem;
  }

  .info-card {
    padding: 1.5rem;
  }

  .button-group {
    flex-direction: column;
    margin-top: 2rem;
    padding-top: 1.5rem;
  }

  .edit-btn,
  .save-btn,
  .cancel-btn,
  .confirm-btn {
    width: 100%;
    padding: 1rem;
  }

  .logout-btn {
    left: 1rem;
    bottom: 1rem;
    width: calc(100% - 2rem);
  }

  .info-item {
    flex-direction: column;
    align-items: flex-start;
    gap: 0.5rem;
  }

  .label {
    min-width: auto;
    margin-bottom: 0.25rem;
  }

  .value {
    padding-left: 1.5rem;
  }

  .avatar-section::after {
    left: 10%;
    right: 10%;
  }

  .info-details.edit-mode {
    padding: 1.5rem;
  }

  .form-group {
    margin-bottom: 1.75rem;
  }
}

.loading-overlay {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(255, 255, 255, 0.9);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 1rem;
  z-index: 1000;
}

.spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #f3f3f3;
  border-top: 4px solid #4caf50;
  border-radius: 50%;
  animation: spin 1s linear infinite;
}

.loading-text {
  color: #666;
  font-size: 1rem;
}

.close-error,
.close-success {
  background: none;
  border: none;
  font-size: 1.25rem;
  cursor: pointer;
  padding: 0;
  margin-left: 1rem;
  opacity: 0.7;
  transition: opacity 0.3s ease;
}

.close-error:hover,
.close-success:hover {
  opacity: 1;
}
</style>