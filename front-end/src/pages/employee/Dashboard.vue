<template>
  <div class="dashboard-container">
    <!-- Thanh điều hướng -->
    <Navbar/>
    <!-- Nội dung chính -->
    <div class="content-section">
      <div class="status-header">
        <div class="filter-section">
          <span>Loại phòng:</span>
          <select v-model="selectedRoomType" @change="filterRooms">
            <option value="all">Tất cả</option>
            <option value="Phòng đơn">Phòng đơn</option>
            <option value="Phòng đôi">Phòng đôi</option>
            <option value="Phòng VIP">Phòng VIP</option>
          </select>
        </div>
      </div>
      <div class="room-grid">
        <div class="room-card" v-for="room in filteredRooms" :key="room.id">
          <div class="room-top">
            <div class="room-info">
              <span class="room-id">{{ room.id }}</span>
              <span class="room-type">{{ room.type }}</span>
            </div>
            <div class="status-container">
              <span class="icon check">{{ room.statusIcon }}</span>
              <span class="room-status">{{ room.status }}</span>
            </div>
          </div>
          <div class="room-bottom">
            <span class="icon">⏰ {{ room.time }}</span>
            <span :class="['icon', room.cleanStatus === 'đã dọn dẹp' ? 'check' : 'cross']">{{ room.cleanStatusIcon }} {{ room.cleanStatus }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '../../components/navbar.vue';
import apiClient from '@/services/api';

export default {
  components: {
    Navbar,
  },
  data() {
    return {
      selectedRoomType: 'all',
      rooms: [],
      loading: false,
      error: '',
    };
  },
  computed: {
    filteredRooms() {
      if (this.selectedRoomType === 'all') {
        return this.rooms;
      }
      return this.rooms.filter(room => room.type === this.selectedRoomType);
    },
  },
  methods: {
    async fetchRooms() {
      this.loading = true;
      this.error = '';
      try {
        const response = await apiClient.get('/api/Phong'); // Đổi endpoint phù hợp backend
        // Giả sử response.data là mảng phòng, bạn có thể cần map lại dữ liệu cho đúng định dạng
        this.rooms = response.data.map(item => ({
          id: item.idPhong || item.id,
          type: item.loaiPhong || item.type,
          status: item.trangThai || item.status,
          statusIcon: item.trangThai === 'Phòng trống' ? '✓' : '✗',
          time: item.thoiGian || '0 giờ',
          cleanStatus: item.tinhTrangDonDep || 'đã dọn dẹp',
          cleanStatusIcon: item.tinhTrangDonDep === 'đã dọn dẹp' ? '✓' : '✗',
        }));
      } catch (err) {
        this.error = 'Không thể tải danh sách phòng';
        console.error(err);
      } finally {
        this.loading = false;
      }
    },
    filterRooms() {
      // Hàm này để trigger computed filteredRooms
    },
  },
  mounted() {
    this.fetchRooms();
  },
};
</script>

<style>
.dashboard-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background-color: #fff;
}



.status-header {
  display: flex;
  justify-content: flex-end;
  font-size: 1rem;
  color: #333;
  font-weight: 500;
  margin-bottom: 1rem;
}
.filter-section {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}
.filter-section select {
  padding: 0.25rem;
  border: 1px solid #ccc;
  border-radius: 0.25rem;
  font-size: 0.875rem;
  color: #333;
  background-color: #fff;
  cursor: pointer;
  transition: border-color 0.3s;
}
.filter-section select:hover {
  border-color: #4caf50;
}
.room-grid {
  display: grid;
  grid-template-columns: repeat(6, 1fr);
  gap: 0.75rem;
}
.room-card {
  border-radius: 0.5rem;
  display: flex;
  flex-direction: column;
  min-height: 130px;
  background: linear-gradient(145deg, #e0f2e9, #d1e7dd);
  box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.1), -5px -5px 10px rgba(255, 255, 255, 0.7);
  transition: transform 0.2s, box-shadow 0.3s;
}
.room-card:hover {
  transform: scale(1.02);
  box-shadow: 6px 6px 12px rgba(0, 0, 0, 0.15), -6px -6px 12px rgba(255, 255, 255, 0.9);
}
.room-top {
  padding: 0.5rem;
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
  flex: 1;
}
.room-info {
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.room-id {
  font-size: 1rem;
  font-weight: 600;
  color: #2e7d32;
}
.room-type {
  font-size: 0.75rem;
  color: #4a4a4a;
  font-style: italic;
}
.status-container {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 0.25rem;
}
.room-status {
  font-size: 0.875rem;
  color: #333;
  font-weight: 500;
}
.room-bottom {
  background: linear-gradient(145deg, #d3d3d3, #e0e0e0);
  padding: 0.25rem 0.5rem;
  display: flex;
  justify-content: space-between;
  font-size: 0.75rem;
  border-top: 1px solid rgba(0, 0, 0, 0.1);
}
.icon {
  display: flex;
  align-items: center;
  color: #333;
}
.icon.check {
  color: #4caf50;
}
.icon.cross {
  color: #ff4444;
}
</style>