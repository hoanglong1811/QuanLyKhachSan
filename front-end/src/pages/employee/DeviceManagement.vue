<template>
  <div class="device-management">
    <!-- Add/Edit Device Modal -->
    <div v-if="showAddModal || showEditModal" class="modal-overlay" @click="closeModal">
      <div class="modal-content" @click.stop>
        <div class="modal-header">
          <div class="modal-title">
            <i class="fas" :class="showEditModal ? 'fa-edit' : 'fa-plus-circle'"></i>
            <h3>{{ showEditModal ? 'Sửa thiết bị' : 'Thêm thiết bị mới' }}</h3>
          </div>
          <button @click="closeModal" class="close-btn">
            <i class="fas fa-times"></i>
          </button>
        </div>
        <form @submit.prevent="submitDevice" class="modal-form">
          <div class="form-grid">
            <div class="form-group">
              <label>
                <i class="fas fa-tag"></i>
                Tên thiết bị
              </label>
              <input
                v-model="deviceForm.tenThietBi"
                type="text"
                class="form-input"
                required
                placeholder="Nhập tên thiết bị"
              >
            </div>
            <div class="form-group">
              <label>
                <i class="fas fa-list"></i>
                Loại thiết bị
              </label>
              <input
                v-model="deviceForm.loaiThietBi"
                type="text"
                class="form-input"
                required
                placeholder="Nhập loại thiết bị"
              >
            </div>
            <div class="form-group">
              <label>
                <i class="fas fa-info-circle"></i>
                Tình trạng
              </label>
              <select
                v-model="deviceForm.tinhTrang"
                class="form-input"
                required
              >
                <option value="Mới">Mới</option>
                <option value="Tốt">Tốt</option>
                <option value="Cần bảo trì">Cần bảo trì</option>
                <option value="Hỏng">Hỏng</option>
              </select>
            </div>
            <div class="form-group">
              <label>
                <i class="fas fa-cubes"></i>
                Số lượng
              </label>
              <input
                v-model.number="deviceForm.soLuong"
                type="number"
                min="1"
                class="form-input"
                required
                placeholder="Nhập số lượng"
              >
            </div>
            <div class="form-group">
              <label>
                <i class="fas fa-money-bill-wave"></i>
                Giá
              </label>
              <div class="price-input-wrapper">
                <input
                  v-model.number="deviceForm.gia"
                  type="number"
                  min="0"
                  class="form-input"
                  required
                  placeholder="Nhập giá"
                >
                <span class="currency">VNĐ</span>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              @click="closeModal"
              class="cancel-btn"
            >
              Hủy
            </button>
            <button
              type="submit"
              class="submit-btn"
              :disabled="isSubmitting"
            >
              <span v-if="isSubmitting" class="spinner"></span>
              {{ isSubmitting ? 'Đang lưu...' : 'Lưu' }}
            </button>
          </div>
        </form>
      </div>
    </div>

    <Navbar />
    <div class="content-wrapper">
      <div class="header-section">
        <h2 class="page-title">Quản lý thiết bị</h2>
        <div class="header-actions">
          <div class="filter-section">
            <select v-model="selectedRoom" class="filter-select" @change="filterDevices">
              <option value="">Tất cả phòng</option>
              <option v-for="room in rooms" :key="room.idPhong" :value="room.idPhong">
                Phòng {{ room.soPhong }}
              </option>
            </select>
          </div>
          <button
            @click="showAddModal = true"
            class="add-device-btn"
            :disabled="isLoading"
          >
            <i class="fas fa-plus mr-2"></i>
            Thêm thiết bị mới
          </button>
        </div>
      </div>

      <!-- Loading State -->
      <div v-if="isLoading" class="loading-state">
        <div class="loading-spinner"></div>
        <p>Đang tải dữ liệu...</p>
      </div>

      <!-- Device List -->
      <div v-if="!isLoading && filteredDevices.length" class="table-container">
        <div class="table-responsive">
          <table class="device-table">
            <thead>
              <tr>
                <th>Tên thiết bị</th>
                <th>Loại thiết bị</th>
                <th>Tình trạng</th>
                <th>Số lượng</th>
                <th>Giá</th>
                <th>Thao tác</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="device in filteredDevices" :key="device.idThietBi" class="device-row">
                <td>{{ device.tenThietBi }}</td>
                <td>{{ device.loaiThietBi }}</td>
                <td>
                  <span :class="getStatusClass(device.tinhTrang)" class="status-badge">
                    {{ device.tinhTrang }}
                  </span>
                </td>
                <td>{{ device.soLuong }}</td>
                <td>{{ formatPrice(device.gia) }}</td>
                <td class="action-buttons">
                  <button @click="editDevice(device)" class="action-btn edit-btn" title="Sửa">
                    <i class="fas fa-edit"></i>
                  </button>
                  <button @click="deleteDevice(device.idThietBi)" class="action-btn delete-btn" title="Xóa">
                    <i class="fas fa-trash"></i>
                  </button>
                  <button @click="createMaintenance(device)" class="action-btn maintenance-btn" title="Bảo trì">
                    <i class="fas fa-tools"></i>
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <!-- Empty State -->
      <div v-if="!isLoading && !filteredDevices.length" class="empty-state">
        <i class="fas fa-box-open empty-icon"></i>
        <p>Không có thiết bị nào để hiển thị.</p>
        <button @click="showAddModal = true" class="add-first-device-btn">
          Thêm thiết bị đầu tiên
        </button>
      </div>

      <!-- Maintenance Modal -->
      <div v-if="showMaintenanceModal" class="modal-overlay" @click="closeMaintenanceModal">
        <div class="modal-content" @click.stop>
          <div class="modal-header">
            <h3>Tạo phiếu bảo trì</h3>
            <button @click="closeMaintenanceModal" class="close-btn">
              <i class="fas fa-times"></i>
            </button>
          </div>
          <form @submit.prevent="submitMaintenance" class="modal-form">
            <div class="form-group">
              <label>Mô tả vấn đề</label>
              <textarea
                v-model="maintenanceForm.moTa"
                class="form-input"
                required
                placeholder="Nhập mô tả vấn đề cần bảo trì"
                rows="4"
              ></textarea>
            </div>
            <div class="form-group">
              <label>Ngày bắt đầu</label>
              <input
                v-model="maintenanceForm.ngayBatDau"
                type="date"
                class="form-input"
                required
              >
            </div>
            <div class="form-group">
              <label>Ngày kết thúc dự kiến</label>
              <input
                v-model="maintenanceForm.ngayKetThucDuKien"
                type="date"
                class="form-input"
                required
              >
            </div>
            <div class="modal-footer">
              <button
                type="button"
                @click="closeMaintenanceModal"
                class="cancel-btn"
              >
                Hủy
              </button>
              <button
                type="submit"
                class="submit-btn"
                :disabled="isSubmitting"
              >
                <span v-if="isSubmitting" class="spinner"></span>
                {{ isSubmitting ? 'Đang tạo...' : 'Tạo phiếu' }}
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import Navbar from '@/components/navbar.vue';

export default {
  name: 'DeviceManagement',
  components: {
    Navbar
  },
  data() {
    return {
      devices: [],
      rooms: [],
      selectedRoom: '',
      filteredDevices: [],
      showAddModal: false,
      showEditModal: false,
      showMaintenanceModal: false,
      isLoading: false,
      isSubmitting: false,
      deviceForm: {
        tenThietBi: '',
        loaiThietBi: '',
        tinhTrang: 'Mới',
        soLuong: 1,
        gia: 0
      },
      maintenanceForm: {
        moTa: '',
        ngayBatDau: '',
        ngayKetThucDuKien: '',
        idThietBi: null
      },
      editingDeviceId: null,
      baseUrl: 'http://localhost:5012/api'
    };
  },
  async created() {
    await Promise.all([
      this.fetchDevices(),
      this.fetchRooms()
    ]);
  },
  methods: {
    async fetchRooms() {
      try {
        const response = await axios.get(`${this.baseUrl}/Phong`, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        if (response.data) {
          this.rooms = response.data;
        }
      } catch (error) {
        console.error('Lỗi khi tải danh sách phòng:', error);
        alert('Không thể tải danh sách phòng');
      }
    },
    filterDevices() {
      if (!this.selectedRoom) {
        this.filteredDevices = this.devices;
      } else {
        this.filteredDevices = this.devices.filter(device => 
          device.idPhong === this.selectedRoom
        );
      }
    },
    async fetchDevices() {
      this.isLoading = true;
      try {
        const response = await axios.get(`${this.baseUrl}/ThietBi`, {
          headers: {
            'Content-Type': 'application/json'
          },
          timeout: 10000
        });

        if (response.data && response.data.data) {
          this.devices = response.data.data.map(device => ({
            idThietBi: device.idThietBi,
            tenThietBi: device.tenThietBi,
            loaiThietBi: device.loaiThietBi,
            tinhTrang: device.tinhTrang,
            soLuong: device.soLuong,
            gia: device.gia,
            idPhong: device.idPhong
          }));
          this.filteredDevices = this.devices;
        } else {
          throw new Error('Dữ liệu trả về không đúng định dạng');
        }
      } catch (error) {
        console.error('Lỗi khi tải danh sách thiết bị:', error);
        let errorMessage = 'Không thể tải danh sách thiết bị';
        if (error.response) {
          errorMessage = error.response.data.message || `Lỗi máy chủ: ${error.response.status}`;
        } else if (error.request) {
          errorMessage = 'Không nhận được phản hồi từ máy chủ';
        } else {
          errorMessage = error.message;
        }
        alert(errorMessage);
        this.devices = [];
        this.filteredDevices = [];
      } finally {
        this.isLoading = false;
      }
    },
    getStatusClass(status) {
      const classes = {
        'Mới': 'bg-green-100 text-green-800',
        'Tốt': 'bg-blue-100 text-blue-800',
        'Cần bảo trì': 'bg-yellow-100 text-yellow-800',
        'Hỏng': 'bg-red-100 text-red-800'
      };
      return `px-2 py-1 rounded-full text-xs font-semibold ${classes[status] || 'bg-gray-100 text-gray-800'}`;
    },
    formatPrice(price) {
      return new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND'
      }).format(price || 0);
    },
    editDevice(device) {
      this.editingDeviceId = device.idThietBi;
      this.deviceForm = { ...device };
      this.showEditModal = true;
    },
    async deleteDevice(id) {
      if (!confirm('Bạn có chắc chắn muốn xóa thiết bị này?')) return;

      this.isLoading = true;
      try {
        const response = await axios.delete(`${this.baseUrl}/ThietBi/${id}`, {
          headers: {
            'Content-Type': 'application/json'
          }
        });

        if (response.data && response.data.message) {
          await this.fetchDevices();
          alert(response.data.message);
        } else {
          throw new Error('Phản hồi không hợp lệ từ máy chủ');
        }
      } catch (error) {
        console.error('Lỗi khi xóa thiết bị:', error);
        let errorMessage = 'Không thể xóa thiết bị';
        if (error.response) {
          errorMessage = error.response.data.message || `Lỗi máy chủ: ${error.response.status}`;
        } else if (error.request) {
          errorMessage = 'Không nhận được phản hồi từ máy chủ';
        } else {
          errorMessage = error.message;
        }
        alert(errorMessage);
      } finally {
        this.isLoading = false;
      }
    },
    createMaintenance(device) {
      this.maintenanceForm = {
        moTa: '',
        ngayBatDau: new Date().toISOString().split('T')[0],
        ngayKetThucDuKien: '',
        idThietBi: device.idThietBi
      };
      this.showMaintenanceModal = true;
    },
    async submitDevice() {
      this.isSubmitting = true;
      try {
        const payload = { ...this.deviceForm };
        let response;

        if (this.showEditModal) {
          response = await axios.put(`${this.baseUrl}/ThietBi/${this.editingDeviceId}`, payload, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
        } else {
          response = await axios.post(`${this.baseUrl}/ThietBi`, payload, {
            headers: {
              'Content-Type': 'application/json'
            }
          });
        }

        if (response.data && response.data.message) {
          await this.fetchDevices();
          this.closeModal();
          alert(response.data.message);
        } else {
          throw new Error('Phản hồi không hợp lệ từ máy chủ');
        }
      } catch (error) {
        console.error('Lỗi khi lưu thiết bị:', error);
        let errorMessage = 'Không thể lưu thiết bị';
        if (error.response) {
          errorMessage = error.response.data.message || `Lỗi máy chủ: ${error.response.status}`;
        } else if (error.request) {
          errorMessage = 'Không nhận được phản hồi từ máy chủ';
        } else {
          errorMessage = error.message;
        }
        alert(errorMessage);
      } finally {
        this.isSubmitting = false;
      }
    },
    async submitMaintenance() {
      this.isSubmitting = true;
      try {
        const response = await axios.post(`${this.baseUrl}/PhieuBaoTri`, this.maintenanceForm, {
          headers: {
            'Content-Type': 'application/json'
          }
        });

        if (response.data && response.data.message) {
          this.closeMaintenanceModal();
          await this.fetchDevices();
          alert(response.data.message);
        } else {
          throw new Error('Phản hồi không hợp lệ từ máy chủ');
        }
      } catch (error) {
        console.error('Lỗi khi tạo phiếu bảo trì:', error);
        let errorMessage = 'Không thể tạo phiếu bảo trì';
        if (error.response) {
          errorMessage = error.response.data.message || `Lỗi máy chủ: ${error.response.status}`;
        } else if (error.request) {
          errorMessage = 'Không nhận được phản hồi từ máy chủ';
        } else {
          errorMessage = error.message;
        }
        alert(errorMessage);
      } finally {
        this.isSubmitting = false;
      }
    },
    closeModal() {
      this.showAddModal = false;
      this.showEditModal = false;
      this.deviceForm = {
        tenThietBi: '',
        loaiThietBi: '',
        tinhTrang: 'Mới',
        soLuong: 1,
        gia: 0
      };
      this.editingDeviceId = null;
    },
    closeMaintenanceModal() {
      this.showMaintenanceModal = false;
      this.maintenanceForm = {
        moTa: '',
        ngayBatDau: '',
        ngayKetThucDuKien: '',
        idThietBi: null
      };
    },
    async fetchRoomForDevice(deviceId) {
      try {
        const response = await axios.get(`http://localhost:5012/api/ThietBi/phong/${deviceId}`, {
          headers: {
            'Content-Type': 'application/json'
          }
        });
        console.log('Room data for device:', response.data);
        return response.data;
      } catch (error) {
        console.error('Error fetching room for device:', error);
        return null;
      }
    }
  }
};
</script>

<style scoped>
.device-management {
  min-height: 100vh;
  background-color: #f8fafc;
}

.content-wrapper {
  padding: 2rem;
  margin-top: 4rem;
  max-width: 1400px;
  margin-left: auto;
  margin-right: auto;
}

.header-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}

.page-title {
  font-size: 1.875rem;
  font-weight: 700;
  color: #1e293b;
}

.header-actions {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.filter-section {
  position: relative;
}

.filter-select {
  padding: 0.75rem 2.5rem 0.75rem 1rem;
  border: 1px solid #e2e8f0;
  border-radius: 0.5rem;
  background-color: white;
  color: #1e293b;
  font-size: 0.875rem;
  min-width: 200px;
  appearance: none;
  background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='%236b7280'%3E%3Cpath stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='M19 9l-7 7-7-7'%3E%3C/path%3E%3C/svg%3E");
  background-repeat: no-repeat;
  background-position: right 0.75rem center;
  background-size: 1rem;
  transition: all 0.2s ease;
}

.filter-select:focus {
  outline: none;
  border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.1);
}

.add-device-btn {
  background-color: #3b82f6;
  color: white;
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  font-weight: 500;
  display: flex;
  align-items: center;
  transition: all 0.2s;
  box-shadow: 0 2px 4px rgba(59, 130, 246, 0.1);
}

.add-device-btn:hover {
  background-color: #2563eb;
  transform: translateY(-1px);
  box-shadow: 0 4px 6px rgba(59, 130, 246, 0.2);
}

.add-device-btn:disabled {
  opacity: 0.7;
  cursor: not-allowed;
}

/* Loading State */
.loading-state {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 4rem;
  color: #64748b;
}

.loading-spinner {
  width: 40px;
  height: 40px;
  border: 4px solid #e2e8f0;
  border-top-color: #3b82f6;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin-bottom: 1rem;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}

/* Table Styles */
.table-container {
  background-color: white;
  border-radius: 0.75rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.table-responsive {
  overflow-x: auto;
}

.device-table {
  width: 100%;
  border-collapse: collapse;
}

.device-table th {
  background-color: #f8fafc;
  padding: 1rem;
  text-align: left;
  font-weight: 600;
  color: #475569;
  border-bottom: 2px solid #e2e8f0;
}

.device-table td {
  padding: 1rem;
  border-bottom: 1px solid #e2e8f0;
  color: #1e293b;
}

.device-row:hover {
  background-color: #f8fafc;
}

/* Status Badge */
.status-badge {
  padding: 0.375rem 0.75rem;
  border-radius: 9999px;
  font-size: 0.875rem;
  font-weight: 500;
  display: inline-block;
}

/* Action Buttons */
.action-buttons {
  display: flex;
  gap: 0.5rem;
}

.action-btn {
  padding: 0.5rem;
  border-radius: 0.375rem;
  transition: all 0.2s;
  color: white;
}

.action-btn:hover {
  transform: translateY(-1px);
}

.edit-btn {
  background-color: #3b82f6;
}

.edit-btn:hover {
  background-color: #2563eb;
}

.delete-btn {
  background-color: #ef4444;
}

.delete-btn:hover {
  background-color: #dc2626;
}

.maintenance-btn {
  background-color: #10b981;
}

.maintenance-btn:hover {
  background-color: #059669;
}

/* Empty State */
.empty-state {
  text-align: center;
  padding: 4rem;
  background-color: white;
  border-radius: 0.75rem;
  box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
}

.empty-icon {
  font-size: 3rem;
  color: #94a3b8;
  margin-bottom: 1rem;
}

.add-first-device-btn {
  margin-top: 1rem;
  background-color: #3b82f6;
  color: white;
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  font-weight: 500;
  transition: all 0.2s;
}

.add-first-device-btn:hover {
  background-color: #2563eb;
  transform: translateY(-1px);
}

/* Modal Styles */
.modal-overlay {
  position: fixed;
  inset: 0;
  background-color: rgba(0, 0, 0, 0.6);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 10000;
  backdrop-filter: blur(6px);
  transition: opacity 0.3s ease;
}

.modal-content {
  background-color: #ffffff;
  border-radius: 1rem;
  width: 100%;
  max-width: 36rem;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
  animation: modalFadeIn 0.3s ease-out;
  overflow: hidden;
  margin: 1rem;
}

@keyframes modalFadeIn {
  from {
    opacity: 0;
    transform: scale(0.95);
  }
  to {
    opacity: 1;
    transform: scale(1);
  }
}

.modal-header {
  padding: 1.5rem 2rem;
  border-bottom: 1px solid #e5e7eb;
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: #f9fafb;
}

.modal-title {
  display: flex;
  align-items: center;
  gap: 0.75rem;
}

.modal-title i {
  color: #3b82f6;
  font-size: 1.25rem;
}

.modal-header h3 {
  font-size: 1.5rem;
  font-weight: 600;
  color: #1e293b;
  margin: 0;
}

.close-btn {
  color: #6b7280;
  padding: 0.5rem;
  border-radius: 0.5rem;
  background: none;
  border: none;
  transition: all 0.2s ease;
  cursor: pointer;
}

.close-btn:hover {
  background-color: #f1f5f9;
  color: #1e293b;
  transform: scale(1.1);
}

.close-btn i {
  font-size: 1.25rem;
}

.modal-form {
  padding: 2rem;
}

.form-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 1.5rem;
}

.form-group {
  margin-bottom: 1.5rem;
}

.form-group label {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  font-weight: 500;
  color: #374151;
  margin-bottom: 0.5rem;
  font-size: 0.875rem;
}

.form-group label i {
  color: #6b7280;
}

.form-input {
  width: 100%;
  padding: 0.875rem;
  border: 1px solid #d1d5db;
  border-radius: 0.5rem;
  transition: all 0.2s ease;
  color: #1e293b;
  font-size: 0.875rem;
  background-color: #f9fafb;
}

.form-input:focus {
  outline: none;
  border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.15);
  background-color: #ffffff;
}

.form-input::placeholder {
  color: #9ca3af;
}

.price-input-wrapper {
  position: relative;
  display: flex;
  align-items: center;
}

.price-input-wrapper .form-input {
  padding-right: 3.5rem;
}

.currency {
  position: absolute;
  right: 1rem;
  color: #6b7280;
  font-size: 0.875rem;
  font-weight: 500;
}

.modal-footer {
  display: flex;
  justify-content: flex-end;
  gap: 1rem;
  padding: 1.5rem 2rem;
  border-top: 1px solid #e5e7eb;
  background-color: #f9fafb;
}

.cancel-btn {
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  font-weight: 500;
  color: #374151;
  background-color: #e5e7eb;
  transition: all 0.2s ease;
  border: none;
  cursor: pointer;
}

.cancel-btn:hover {
  background-color: #d1d5db;
  transform: translateY(-1px);
}

.submit-btn {
  padding: 0.75rem 1.5rem;
  border-radius: 0.5rem;
  font-weight: 500;
  color: white;
  background-color: #3b82f6;
  transition: all 0.2s ease;
  border: none;
  cursor: pointer;
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.submit-btn:hover {
  background-color: #2563eb;
  transform: translateY(-1px);
  box-shadow: 0 2px 8px rgba(59, 130, 246, 0.2);
}

.submit-btn:disabled {
  opacity: 0.6;
  cursor: not-allowed;
  transform: none;
}

.spinner {
  width: 1rem;
  height: 1rem;
  border: 2px solid #ffffff;
  border-top-color: transparent;
  border-radius: 50%;
  animation: spin 1s linear infinite;
}

/* Responsive Design */
@media (max-width: 768px) {
  .content-wrapper {
    padding: 1rem;
  }

  .header-section {
    flex-direction: column;
    gap: 1rem;
    align-items: stretch;
  }

  .header-actions {
    flex-direction: column;
    width: 100%;
  }

  .filter-select {
    width: 100%;
  }

  .add-device-btn {
    width: 100%;
    justify-content: center;
  }

  .device-table th,
  .device-table td {
    padding: 0.75rem;
  }

  .action-buttons {
    flex-direction: column;
  }

  .modal-content {
    margin: 1rem;
    max-width: 95%;
  }

  .form-grid {
    grid-template-columns: 1fr;
  }
}

@media (max-width: 480px) {
  .modal-header {
    padding: 1rem 1.5rem;
  }

  .modal-form {
    padding: 1.5rem;
  }

  .modal-footer {
    padding: 1rem 1.5rem;
    flex-direction: column;
    gap: 0.75rem;
  }

  .cancel-btn,
  .submit-btn {
    width: 100%;
    text-align: center;
  }
}
</style>