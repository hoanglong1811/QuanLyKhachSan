<template>
  <div class="user-info-container">
    <!-- Thanh điều hướng -->
    <Navbar />
    <!-- Nút đăng xuất ở góc trái bên dưới -->
    <button class="logout-btn" @click="logout">Đăng xuất</button>
    <!-- Nội dung chính -->
    <div class="content-section">
      <div class="info-card">
        <div class="avatar-section">
          <div class="avatar" />
          <h2 class="user-name">Nguyễn Văn A</h2>
        </div>
        <div class="info-details">
          <div class="info-item">
            <span class="label">Email:</span>
            <span class="value">nguyenvana@example.com</span>
          </div>
          <div class="info-item">
            <span class="label">Vai trò:</span>
            <span class="value">Quản lý</span>
          </div>
          <div class="info-item">
            <span class="label">Số điện thoại:</span>
            <span class="value">0901234567</span>
          </div>
          <div class="info-item">
            <span class="label">Ngày tham gia:</span>
            <span class="value">15/03/2023</span>
          </div>
          <div class="info-item">
            <span class="label">Địa chỉ:</span>
            <span class="value">123 Đường ABC, TP. HCM</span>
          </div>
          <button class="edit-btn" @click="editInfo">Chỉnh sửa thông tin</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue';

export default {
  components: { Navbar },
  methods: {
    editInfo() {
      alert('Chức năng chỉnh sửa thông tin (simulated)');
      // Thêm logic chỉnh sửa thực tế nếu cần
    },
    logout() {
      alert('Đăng xuất thành công (simulated)');
      this.$router.push('/login');
      // Thêm logic đăng xuất thực tế nếu cần, ví dụ: this.$router.push('/login')
    },
  },
};
</script>

<style scoped>
.user-info-container {
  display: flex;
  flex-direction: column;
  height: 100vh;
  width: 100%;
  background: linear-gradient(135deg, #f0f4f8, #ffffff);
}
.content-section {
  flex: 1;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 2rem;
  background-color: #f9f9f9;
  overflow-y: auto;
}
.info-card {
  background: white;
  border-radius: 1rem;
  box-shadow: 0 10px 20px rgba(0, 0, 0, 0.1), 0 6px 6px rgba(0, 0, 0, 0.05);
  padding: 2rem;
  width: 100%;
  max-width: 500px;
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
  transition: transform 0.3s, box-shadow 0.3s;
}
.info-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 15px 30px rgba(0, 0, 0, 0.15), 0 8px 8px rgba(0, 0, 0, 0.1);
}
.avatar-section {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 1rem;
}
.avatar {
  width: 120px;
  height: 120px;
  background: linear-gradient(135deg, #5bb790, #4caf50);
  border-radius: 50%;
  border: 4px solid #fff;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
}
.user-name {
  font-size: 1.5rem;
  font-weight: 700;
  color: #2e7d32;
  margin: 0;
}
.info-details {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}
.info-item {
  display: flex;
  justify-content: space-between;
  padding: 0.75rem 1rem;
  background: #f5f5f5;
  border-radius: 0.5rem;
  transition: background 0.3s;
}
.info-item:hover {
  background: #e0f7fa;
}
.label {
  font-weight: 500;
  color: #555;
}
.value {
  font-weight: 400;
  color: #333;
}
.edit-btn {
  padding: 0.75rem 1.5rem;
  background: #5bb790;
  color: white;
  border: none;
  border-radius: 0.5rem;
  font-size: 1rem;
  cursor: pointer;
  transition: background 0.3s, transform 0.2s;
}
.edit-btn:hover {
  background: #4caf50;
  transform: translateY(-2px);
}
.logout-btn {
  position: fixed;
  bottom: 1.5rem;
  left: 1.5rem;
  padding: 0.75rem 1.5rem;
  background: #ff6f61;
  color: white;
  border: none;
  border-radius: 0.5rem;
  font-size: 1rem;
  cursor: pointer;
  transition: background 0.3s, transform 0.2s;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
}
.logout-btn:hover {
  background: #e65100;
  transform: translateY(-2px);
  box-shadow: 0 6px 15px rgba(255, 111, 97, 0.4);
}
</style>