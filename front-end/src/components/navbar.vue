<template>
  <div class="nav-bar">
    <h1>Hệ thống quản lý khách sạn</h1>
    <div class="nav-tabs">
      <router-link class="nav-tab" to="/personal-info">Thông tin cá nhân</router-link>
      <router-link class="nav-tab" to="/dashboard">Quản lý phòng</router-link>
      <router-link class="nav-tab" to="/user-manager">Quản lý khách hàng</router-link>
      <router-link class="nav-tab" to="/booking">Đặt phòng</router-link>
      <router-link class="nav-tab" to="/service-management">Quản lý dịch vụ</router-link>
    </div>
    <div class="nav-tabs second-row">
      <router-link class="nav-tab" to="/invoice-management">Quản lý hóa đơn</router-link>
      <router-link class="nav-tab" to="/reports">Báo cáo</router-link>
      <router-link class="nav-tab" to="/account-management">Quản lý tài khoản</router-link>
      <router-link class="nav-tab" to="/room-layout-management">Quản lý bố trí phòng</router-link>
    </div>
  </div>
</template>

<script>
export default {
  // Không cần logic thêm vì chỉ thay button bằng router-link
};
</script>

<style scoped>
.nav-bar {
  background-color: #5bb790;
  padding: 1rem;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.nav-bar h1 {
  font-size: 1.5rem;
  font-weight: 700;
  color: #fff;
  margin-bottom: 0.5rem;
}
.nav-tabs {
  display: flex;
  gap: 0.5rem;
  margin-bottom: 0.5rem;
  flex-wrap: wrap;
  justify-content: center;
}
.nav-tab {
  padding: 0.5rem 0.75rem;
  background-color: #d1e7dd;
  border: none;
  border-radius: 0.25rem;
  color: #333;
  font-size: 0.875rem;
  cursor: pointer;
  transition: background-color 0.3s;
  text-decoration: none;
}
.nav-tab:hover {
  background-color: #81c784;
}
.nav-tab.active {
  background-color: #4caf50;
}
.second-row .nav-tab {
  background-color: #d1e7dd;
  color: #333;
}
.second-row .nav-tab:hover {
  background-color: #c8e6c9;
}
</style>