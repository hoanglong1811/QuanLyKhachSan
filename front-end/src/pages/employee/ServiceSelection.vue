<!-- File: ServiceSelection.vue -->
<template>
  <div>
    <Navbar />
    <div class="page-container">
      <div class="content-wrapper">
        <div class="content-container">
          <!-- Header -->
          <div class="header-section">
            <div class="header-left">
              <h1 class="page-title">Quản lý dịch vụ</h1>
              <p class="subtitle">Thêm, sửa và xóa dịch vụ</p>
            </div>
            <div class="header-actions">
              <button class="add-service-button" @click="openAddModal">
                <i class="fas fa-plus"></i>
                Thêm dịch vụ mới
              </button>
              <button class="add-service-to-room-button" @click="openAddServiceToRoomModal">
                <i class="fas fa-concierge-bell"></i>
                Thêm dịch vụ cho phòng
              </button>
            </div>
          </div>

          <!-- Services Table -->
          <div class="services-table-container">
            <div class="table-responsive">
              <table class="services-table">
                <thead>
                  <tr>
                    <th>Tên dịch vụ</th>
                    <th>Mô tả</th>
                    <th>Giá (VND)</th>
                    <th>Đơn vị tính</th>
                    <th>Thao tác</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="service in services" :key="service.id">
                    <td>{{ service.name }}</td>
                    <td>{{ service.description }}</td>
                    <td>{{ formatPrice(service.price) }}</td>
                    <td>{{ service.unit }}</td>
                    <td class="actions-cell">
                      <button class="edit-button" @click="openEditModal(service)">
                        <i class="fas fa-edit"></i>
                        Sửa
                      </button>
                      <button class="delete-button" @click="confirmDelete(service)">
                        <i class="fas fa-trash"></i>
                        Xóa
                      </button>
                    </td>
                  </tr>
                  <tr v-if="services.length === 0">
                    <td colspan="6" class="no-data">
                      <i class="fas fa-box-open"></i>
                      <p>Chưa có dịch vụ nào</p>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>

          <!-- Add/Edit Service Modal -->
          <div v-if="showModal" class="modal-overlay">
            <div class="modal-content">
              <div class="modal-header">
                <h2 class="modal-title">
                  <i class="fas" :class="isEditing ? 'fa-edit' : 'fa-plus'"></i>
                  {{ isEditing ? 'Sửa dịch vụ' : 'Thêm dịch vụ mới' }}
                </h2>
                <button @click="closeModal" class="close-button">
                  <i class="fas fa-times"></i>
                </button>
              </div>

              <div class="modal-body">
                <form @submit.prevent="handleSubmit" class="service-form">
                  <div class="form-group">
                    <label for="name">Tên dịch vụ</label>
                    <input
                      type="text"
                      id="name"
                      v-model="formData.name"
                      required
                      placeholder="Nhập tên dịch vụ"
                    />
                  </div>

                  <div class="form-group">
                    <label for="description">Mô tả</label>
                    <textarea
                      id="description"
                      v-model="formData.description"
                      required
                      placeholder="Nhập mô tả dịch vụ"
                      rows="3"
                    ></textarea>
                  </div>

                  <div class="form-group">
                    <label for="price">Giá (VND)</label>
                    <input
                      type="number"
                      id="price"
                      v-model.number="formData.price"
                      required
                      min="0"
                      placeholder="Nhập giá dịch vụ"
                    />
                  </div>

                  <div class="form-group">
                    <label for="unit">Đơn vị tính</label>
                    <input
                      type="text"
                      id="unit"
                      v-model="formData.unit"
                      required
                      placeholder="Nhập đơn vị tính"
                    />
                  </div>

                  <div class="form-actions">
                    <button type="button" class="cancel-button" @click="closeModal">
                      Hủy
                    </button>
                    <button type="submit" class="submit-button">
                      {{ isEditing ? 'Cập nhật' : 'Thêm mới' }}
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>

          <!-- Add Service to Room Modal -->
          <div v-if="showAddServiceToRoomModal" class="modal-overlay">
            <div class="modal-content">
              <div class="modal-header">
                <h2 class="modal-title">
                  <i class="fas fa-concierge-bell"></i>
                  Thêm dịch vụ cho phòng
                </h2>
                <button @click="closeAddServiceToRoomModal" class="close-button">
                  <i class="fas fa-times"></i>
                </button>
              </div>

              <div class="modal-body">
                <form @submit.prevent="handleAddServiceToRoom" class="service-form">
                  <div class="form-group">
                    <label for="roomNumber">Chọn phòng</label>
                    <select 
                      id="roomNumber" 
                      v-model="serviceToRoomForm.roomId"
                      required
                      @change="handleRoomSelect"
                    >
                      <option value="">Chọn phòng</option>
                      <option 
                        v-for="room in bookedRooms" 
                        :key="room.idPhong" 
                        :value="room.idPhong"
                      >
                        Phòng {{ room.soPhong }} - {{ room.bookingInfo?.tenKhachHang }}
                      </option>
                    </select>
                  </div>

                  <div class="form-group">
                    <label for="service">Chọn dịch vụ</label>
                    <select 
                      id="service" 
                      v-model="serviceToRoomForm.serviceId"
                      required
                      @change="handleServiceSelect"
                    >
                      <option value="">Chọn dịch vụ</option>
                      <option 
                        v-for="service in services" 
                        :key="service.id" 
                        :value="service.id"
                      >
                        {{ service.name }} - {{ formatPrice(service.price) }}
                      </option>
                    </select>
                  </div>

                  <div class="form-group">
                    <label for="quantity">Số lượng</label>
                    <input 
                      type="number" 
                      id="quantity"
                      v-model.number="serviceToRoomForm.quantity"
                      required
                      min="1"
                      :max="selectedService?.maxQuantity || 999"
                    />
                  </div>

                  <div class="form-group">
                    <label for="note">Ghi chú</label>
                    <textarea
                      id="note"
                      v-model="serviceToRoomForm.note"
                      rows="2"
                      placeholder="Ghi chú (tuỳ chọn)"
                    ></textarea>
                  </div>

                  <div class="total-price" v-if="serviceToRoomForm.serviceId && serviceToRoomForm.quantity">
                    <span>Tổng tiền:</span>
                    <span class="price">{{ formatPrice(calculateTotalPrice()) }}</span>
                  </div>

                  <div class="form-actions">
                    <button type="button" class="cancel-button" @click="closeAddServiceToRoomModal">
                      Hủy
                    </button>
                    <button type="submit" class="submit-button" :disabled="loading">
                      {{ loading ? 'Đang thêm...' : 'Thêm dịch vụ' }}
                    </button>
                  </div>
                </form>
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
  name: 'ServiceSelection',
  components: {
    Navbar
  },
  data() {
    return {
      services: [],
      showModal: false,
      isEditing: false,
      formData: {
        id: null,
        name: '',
        description: '',
        price: 0,
        unit: ''
      },
      showAddServiceToRoomModal: false,
      bookedRooms: [],
      serviceToRoomForm: {
        roomId: '',
        serviceId: '',
        quantity: 1,
        note: ''
      },
      loading: false
    };
  },
  computed: {
    selectedService() {
      return this.services.find(s => s.id === this.serviceToRoomForm.serviceId);
    }
  },
  created() {
    this.fetchServices();
  },
  methods: {
    async fetchServices() {
      try {
        const response = await axios.get('http://localhost:5012/api/DichVu', {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });
        this.services = response.data.map(service => ({
          id: service.idDichVu,
          name: service.tenDichVu,
          description: service.moTa,
          price: service.gia,
          unit: service.donViTinh
        }));
      } catch (error) {
        console.error('Error fetching services:', error);
        alert('Không thể tải danh sách dịch vụ. Vui lòng thử lại sau.');
      }
    },

    openAddModal() {
      this.isEditing = false;
      this.formData = {
        id: null,
        name: '',
        description: '',
        price: 0,
        unit: ''
      };
      this.showModal = true;
    },

    openEditModal(service) {
      this.isEditing = true;
      this.formData = {
        id: service.id,
        name: service.name,
        description: service.description,
        price: service.price,
        unit: service.unit
      };
      this.showModal = true;
    },

    closeModal() {
      if (this.isEditing && this.hasUnsavedChanges()) {
        if (!confirm('Bạn có chưa lưu thay đổi. Bạn có chắc chắn muốn đóng?')) {
          return;
        }
      }
      this.showModal = false;
      this.isEditing = false;
      this.formData = {
        id: null,
        name: '',
        description: '',
        price: 0,
        unit: ''
      };
    },

    hasUnsavedChanges() {
      if (!this.isEditing) return false;
      const originalService = this.services.find(s => s.id === this.formData.id);
      if (!originalService) return false;

      return (
        originalService.name !== this.formData.name ||
        originalService.description !== this.formData.description ||
        originalService.price !== this.formData.price ||
        originalService.unit !== this.formData.unit
      );
    },

    async handleSubmit() {
      try {
        // Validate form data
        if (!this.formData.name.trim()) {
          alert('Vui lòng nhập tên dịch vụ');
          return;
        }
        if (!this.formData.description.trim()) {
          alert('Vui lòng nhập mô tả dịch vụ');
          return;
        }
        if (this.formData.price <= 0) {
          alert('Giá dịch vụ phải lớn hơn 0');
          return;
        }
        if (!this.formData.unit.trim()) {
          alert('Vui lòng nhập đơn vị tính');
          return;
        }

        const serviceData = {
          idDichVu: this.formData.id,
          tenDichVu: this.formData.name.trim(),
          moTa: this.formData.description.trim(),
          gia: this.formData.price,
          donViTinh: this.formData.unit.trim()
        };

        if (this.isEditing) {
          await axios.put(`http://localhost:5012/api/DichVu/${this.formData.id}`, serviceData, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('token')}`
            }
          });
          alert('Cập nhật dịch vụ thành công!');
        } else {
          await axios.post('http://localhost:5012/api/DichVu', serviceData, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('token')}`
            }
          });
          alert('Thêm dịch vụ mới thành công!');
        }

        this.closeModal();
        this.fetchServices();
      } catch (error) {
        console.error('Error saving service:', error);
        if (error.response) {
          alert(error.response.data || 'Có lỗi xảy ra. Vui lòng thử lại sau.');
        } else {
          alert('Có lỗi xảy ra. Vui lòng thử lại sau.');
        }
      }
    },

    async confirmDelete(service) {
      if (confirm(`Bạn có chắc chắn muốn xóa dịch vụ "${service.name}" không?`)) {
        try {
          await axios.delete(`http://localhost:5012/api/DichVu/${service.id}`, {
            headers: {
              Authorization: `Bearer ${localStorage.getItem('token')}`
            }
          });
          alert('Xóa dịch vụ thành công!');
          this.fetchServices();
        } catch (error) {
          console.error('Error deleting service:', error);
          if (error.response) {
            alert(error.response.data || 'Không thể xóa dịch vụ. Vui lòng thử lại sau.');
          } else {
            alert('Không thể xóa dịch vụ. Vui lòng thử lại sau.');
          }
        }
      }
    },

    formatPrice(price) {
      return price.toLocaleString('vi-VN') + ' VND';
    },

    async fetchBookedRooms() {
      try {
        const response = await axios.get('http://localhost:5012/api/ChiTietDatPhong', {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });
        
        // Lọc các phòng đã đặt và đang thuê
        this.bookedRooms = response.data.filter(booking => 
          booking.trangThaiDatPhong === 'Đã xác nhận' || 
          booking.trangThaiDatPhong === 'Đang thuê'
        ).map(booking => ({
          idPhong: booking.idPhong,
          soPhong: booking.soPhong,
          bookingInfo: {
            tenKhachHang: booking.tenKhachHang,
            ngayDatPhong: booking.ngayDatPhong,
            ngayTraPhong: booking.ngayTraPhong,
            trangThaiDatPhong: booking.trangThaiDatPhong
          }
        }));
      } catch (error) {
        console.error('Error fetching booked rooms:', error);
        alert('Không thể tải danh sách phòng đã đặt. Vui lòng thử lại sau.');
      }
    },

    openAddServiceToRoomModal() {
      // Chuyển về trang Dashboard
      this.$router.push('/dashboard');
    },

    closeAddServiceToRoomModal() {
      this.showAddServiceToRoomModal = false;
      this.serviceToRoomForm = {
        roomId: '',
        serviceId: '',
        quantity: 1,
        note: ''
      };
    },

    handleRoomSelect() {
      // Reset service selection when room changes
      this.serviceToRoomForm.serviceId = '';
      this.serviceToRoomForm.quantity = 1;
    },

    handleServiceSelect() {
      // Reset quantity when service changes
      this.serviceToRoomForm.quantity = 1;
    },

    calculateTotalPrice() {
      if (!this.selectedService) return 0;
      return this.selectedService.price * this.serviceToRoomForm.quantity;
    },

    async handleAddServiceToRoom() {
      if (!this.serviceToRoomForm.roomId || !this.serviceToRoomForm.serviceId || !this.serviceToRoomForm.quantity) {
        alert('Vui lòng điền đầy đủ thông tin');
        return;
      }

      this.loading = true;
      try {
        // 1. Lấy thông tin đặt phòng từ ChiTietDatPhongController
        const datPhongResponse = await axios.get(`http://localhost:5012/api/ChiTietDatPhong/room/${this.serviceToRoomForm.roomId}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        // 2. Tạo chi tiết dịch vụ
        const chiTietDichVu = await axios.post('http://localhost:5012/api/ChiTietDichVu', {
          idDatPhong: datPhongResponse.data.idDatPhong,
          idDichVu: this.serviceToRoomForm.serviceId,
          soLuong: this.serviceToRoomForm.quantity,
          donGia: this.selectedService.price,
          thanhTien: this.calculateTotalPrice(),
          ghiChu: this.serviceToRoomForm.note,
          ngaySuDung: new Date().toISOString(),
          trangThai: 'Chưa thanh toán'
        }, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        // 3. Tạo chi tiết hóa đơn
        await axios.post('http://localhost:5012/api/ChiTietHoaDon', {
          idDatPhong: datPhongResponse.data.idDatPhong,
          idChiTietDichVu: chiTietDichVu.data.idChiTietDichVu,
          thanhTien: this.calculateTotalPrice(),
          ghiChu: this.serviceToRoomForm.note
        }, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        alert('Thêm dịch vụ thành công!');
        this.closeAddServiceToRoomModal();
      } catch (error) {
        console.error('Error adding service to room:', error);
        alert('Không thể thêm dịch vụ. Vui lòng thử lại sau.');
      } finally {
        this.loading = false;
      }
    }
  }
};
</script>

<style scoped>
.page-container {
  min-height: 100vh;
  background-color: #f7f9fc;
  padding-top: 64px;
}

.content-wrapper {
  max-width: 1200px;
  margin: 0 auto;
  padding: 2rem;
}

.content-container {
  background-color: #ffffff;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
  padding: 2.5rem;
}

.header-section {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2.5rem;
  padding-bottom: 1.5rem;
  border-bottom: 1px solid #e0e6ed;
}

.header-left .page-title {
  font-size: 2rem;
  font-weight: bold;
  color: #2c3e50;
  margin-bottom: 0.5rem;
}

.header-left .subtitle {
  font-size: 1rem;
  color: #7f8c8d;
}

.header-actions {
  display: flex;
  gap: 1rem;
}

.add-service-button {
  background-color: #2ecc71;
  color: white;
  padding: 0.75rem 1.5rem;
  border-radius: 8px;
  font-weight: 600;
  display: flex;
  align-items: center;
  gap: 0.5rem;
  border: none;
  cursor: pointer;
  transition: all 0.3s ease;
}

.add-service-button:hover {
  background-color: #27ae60;
}

.add-service-to-room-button {
  background-color: #3498db;
  color: white;
  padding: 0.75rem 1.5rem;
  border-radius: 8px;
  font-weight: 600;
  display: flex;
  align-items: center;
  gap: 0.5rem;
  border: none;
  cursor: pointer;
  transition: all 0.3s ease;
}

.add-service-to-room-button:hover {
  background-color: #2980b9;
}

.services-table-container {
  background-color: #fbfdff;
  border: 1px solid #e0e6ed;
  border-radius: 10px;
  overflow: hidden;
}

.table-responsive {
  overflow-x: auto;
}

.services-table {
  width: 100%;
  border-collapse: collapse;
  min-width: 800px;
}

.services-table th,
.services-table td {
  padding: 1rem 1.25rem;
  border-bottom: 1px solid #e0e6ed;
  text-align: left;
}

.services-table th {
  background-color: #f5f8fa;
  font-weight: 600;
  color: #5d6d7e;
  text-transform: uppercase;
  font-size: 0.85rem;
}

.services-table tbody tr:last-child td {
  border-bottom: none;
}

.actions-cell {
  display: flex;
  gap: 0.5rem;
}

.edit-button,
.delete-button {
  padding: 0.5rem 1rem;
  border-radius: 6px;
  font-weight: 500;
  display: flex;
  align-items: center;
  gap: 0.5rem;
  border: none;
  cursor: pointer;
  transition: all 0.2s ease;
}

.edit-button {
  background-color: #3498db;
  color: white;
}

.edit-button:hover {
  background-color: #2980b9;
}

.delete-button {
  background-color: #e74c3c;
  color: white;
}

.delete-button:hover {
  background-color: #c0392b;
}

.no-data {
  text-align: center;
  padding: 3rem;
  color: #95a5a6;
}

.no-data i {
  font-size: 3rem;
  margin-bottom: 1rem;
}

.modal-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
  backdrop-filter: blur(4px);
}

.modal-content {
  background: white;
  border-radius: 16px;
  width: 90%;
  max-width: 600px;
  max-height: 90vh;
  display: flex;
  flex-direction: column;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.2);
}

.modal-header {
  padding: 1.5rem;
  border-bottom: 1px solid #e9ecef;
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.modal-title {
  font-size: 1.5rem;
  font-weight: 600;
  color: #2c3e50;
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.close-button {
  background: none;
  border: none;
  font-size: 1.25rem;
  color: #6c757d;
  cursor: pointer;
  padding: 0.5rem;
  border-radius: 50%;
  transition: all 0.2s ease;
}

.close-button:hover {
  background: #f8f9fa;
  color: #343a40;
}

.modal-body {
  padding: 1.5rem;
  overflow-y: auto;
}

.service-form {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
}

.form-group {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.form-group label {
  font-weight: 500;
  color: #2c3e50;
}

.form-group input,
.form-group textarea,
.form-group select {
  padding: 0.75rem;
  border: 1px solid #ced4da;
  border-radius: 8px;
  font-size: 1rem;
  transition: all 0.2s ease;
}

.form-group input:focus,
.form-group textarea:focus,
.form-group select:focus {
  outline: none;
  border-color: #3498db;
  box-shadow: 0 0 0 3px rgba(52, 152, 219, 0.2);
}

.form-actions {
  display: flex;
  justify-content: flex-end;
  gap: 1rem;
  margin-top: 1rem;
}

.cancel-button,
.submit-button {
  padding: 0.75rem 1.5rem;
  border-radius: 8px;
  font-weight: 600;
  border: none;
  cursor: pointer;
  transition: all 0.2s ease;
}

.cancel-button {
  background-color: #ecf0f1;
  color: #34495e;
}

.cancel-button:hover {
  background-color: #dfe6e9;
}

.submit-button {
  background-color: #3498db;
  color: white;
}

.submit-button:hover {
  background-color: #2980b9;
}

.total-price {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  background-color: #f8f9fa;
  border-radius: 8px;
  margin: 1rem 0;
  font-weight: 600;
}

.total-price .price {
  color: #2ecc71;
  font-size: 1.2rem;
}

@media (max-width: 768px) {
  .content-container {
    padding: 1.5rem;
  }

  .header-section {
    flex-direction: column;
    align-items: flex-start;
    gap: 1rem;
  }

  .header-actions {
    flex-direction: column;
    width: 100%;
  }

  .add-service-button,
  .add-service-to-room-button {
    width: 100%;
    justify-content: center;
  }

  .services-table th,
  .services-table td {
    padding: 0.75rem;
    font-size: 0.9rem;
  }

  .actions-cell {
    flex-direction: column;
  }

  .edit-button,
  .delete-button {
    width: 100%;
    justify-content: center;
  }

  .modal-content {
    margin: 1rem;
    width: calc(100% - 2rem);
  }

  .form-actions {
    flex-direction: column;
  }

  .cancel-button,
  .submit-button {
    width: 100%;
  }
}
</style>