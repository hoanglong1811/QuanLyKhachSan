<template>
  <div class="dashboard-container">
    <!-- Thanh điều hướng -->
    <NavBar />
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
import NavBar from '@/components/navbar.vue';


export default {
    components: {
      NavBar,
    },
  data() {
    return {
      selectedRoomType: 'all',
      rooms: [
        { id: 'P101', type: 'Phòng đơn', status: 'Phòng đặt', statusIcon: '✓', time: '5 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P102', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P103', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✗', time: '0 giờ', cleanStatus: 'chưa dọn dẹp', cleanStatusIcon: '✗' },
        { id: 'P104', type: 'Phòng đôi', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P105', type: 'Phòng đôi', status: 'Nguyễn Văn An', statusIcon: '✓', time: '5 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P106', type: 'Phòng đôi', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P107', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P108', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P109', type: 'Phòng VIP', status: 'Phòng đặt', statusIcon: '✓', time: '3 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P110', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P111', type: 'Phòng đôi', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P112', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P113', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P114', type: 'Phòng đôi', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P115', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P116', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P117', type: 'Phòng đôi', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P118', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P119', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P120', type: 'Phòng VIP', status: 'Phòng đặt', statusIcon: '✓', time: '3 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P121', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P122', type: 'Phòng đôi', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P123', type: 'Phòng VIP', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
        { id: 'P124', type: 'Phòng đơn', status: 'Phòng trống', statusIcon: '✓', time: '0 giờ', cleanStatus: 'đã dọn dẹp', cleanStatusIcon: '✓' },
      ],
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