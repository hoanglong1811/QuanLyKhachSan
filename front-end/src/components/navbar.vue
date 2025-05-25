<template>
  <div class="nav-bar">
    <div class="nav-header">
      <h1>Hệ thống quản lý khách sạn</h1>
      <button @click="toggleMenu" class="menu-button">
        <span class="menu-icon"></span>
      </button>
    </div>
    <div class="nav-content" :class="{ 'show': isMenuOpen }">
      <div class="nav-tabs">
        <router-link class="nav-tab" to="/employee/personal-info">Thông tin cá nhân</router-link>
        <router-link class="nav-tab" to="/dashboard">Quản lý phòng</router-link>
        <router-link class="nav-tab" to="/employee/user-manager">Quản lý khách hàng</router-link>
        <router-link class="nav-tab" to="/employee/booking">Đặt phòng</router-link>
        <router-link class="nav-tab" to="/employee/service-selection">Quản lý dịch vụ</router-link>
      </div>
      <div class="nav-tabs second-row">
        <router-link class="nav-tab" to="/employee/invoice-management">Quản lý hóa đơn</router-link>
        <router-link class="nav-tab" to="/employee/reports">Báo cáo</router-link>
        <router-link class="nav-tab" to="/employee/account-management">Quản lý tài khoản</router-link>
        <router-link class="nav-tab" to="/employee/room-layout-management">Quản lý bố trí phòng</router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isMenuOpen: false
    }
  },
  methods: {
    toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen;
    }
  }
};
</script>

<style scoped>
.nav-bar {
  background-color: #5bb790;
  padding: 1rem;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
}

.nav-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
}

.nav-bar h1 {
  font-size: 1.5rem;
  font-weight: 700;
  color: #fff;
  margin: 0;
}

.menu-button {
  display: none;
  background: none;
  border: none;
  cursor: pointer;
  padding: 0.5rem;
}

.menu-icon {
  display: block;
  width: 25px;
  height: 3px;
  background-color: white;
  position: relative;
  transition: background-color 0.3s;
}

.menu-icon::before,
.menu-icon::after {
  content: '';
  position: absolute;
  width: 25px;
  height: 3px;
  background-color: white;
  transition: transform 0.3s;
}

.menu-icon::before {
  top: -8px;
}

.menu-icon::after {
  bottom: -8px;
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
  transition: all 0.3s;
  text-decoration: none;
  white-space: nowrap;
}

.nav-tab:hover {
  background-color: #81c784;
  transform: translateY(-2px);
}

.nav-tab.router-link-active {
  background-color: #4caf50;
  color: white;
}

.second-row .nav-tab {
  background-color: #d1e7dd;
  color: #333;
}

.second-row .nav-tab:hover {
  background-color: #c8e6c9;
}

@media (max-width: 768px) {
  .nav-header {
    padding: 0.5rem;
  }

  .menu-button {
    display: block;
  }

  .nav-content {
    display: none;
    width: 100%;
  }

  .nav-content.show {
    display: block;
  }

  .nav-tabs {
    flex-direction: column;
    gap: 0.5rem;
    padding: 1rem 0;
  }

  .nav-tab {
    width: 100%;
    text-align: center;
  }

  .second-row {
    margin-top: 0;
  }
}
</style>