<template>
  <div class="nav-wrapper">
    <div class="nav-bar">
      <div class="nav-header">
        <div class="logo-section">
          <i class="fas fa-hotel"></i>
          <h1>Hệ thống quản lý khách sạn</h1>
        </div>
        <button @click="toggleMenu" class="menu-button">
          <span class="menu-icon"></span>
        </button>
      </div>
      <div class="nav-content" :class="{ 'show': isMenuOpen }">
        <div class="nav-tabs">
          <div class="nav-group">
            <h3 class="group-title">Quản lý thông tin</h3>
            <div class="group-links">
              <router-link class="nav-tab" to="/employee/personal-info">
                <i class="fas fa-user"></i>
                Thông tin cá nhân
              </router-link>
              <router-link class="nav-tab" to="/employee/user-manager">
                <i class="fas fa-users"></i>
                Quản lý khách hàng
              </router-link>
            </div>
          </div>

          <div class="nav-group">
            <h3 class="group-title">Quản lý phòng</h3>
            <div class="group-links">
              <router-link class="nav-tab" to="/dashboard">
                <i class="fas fa-door-open"></i>
                Quản lý phòng
              </router-link>
              <router-link class="nav-tab" to="/employee/booking">
                <i class="fas fa-calendar-check"></i>
                Đặt phòng
              </router-link>
              <router-link class="nav-tab" to="/employee/device-management">
                <i class="fas fa-tools"></i>
                Quản lý thiết bị
              </router-link>
            </div>
          </div>

          <div class="nav-group">
            <h3 class="group-title">Quản lý dịch vụ</h3>
            <div class="group-links">
              <router-link class="nav-tab" to="/employee/service-selection">
                <i class="fas fa-concierge-bell"></i>
                Dịch vụ
              </router-link>
              <router-link class="nav-tab" to="/employee/invoice-management">
                <i class="fas fa-file-invoice-dollar"></i>
                Hóa đơn
              </router-link>
            </div>
          </div>

          <div class="nav-group">
            <h3 class="group-title">Hệ thống</h3>
            <div class="group-links">
              <router-link class="nav-tab" to="/employee/reports">
                <i class="fas fa-chart-bar"></i>
                Báo cáo
              </router-link>
              <router-link class="nav-tab" to="/employee/account-list">
                <i class="fas fa-user-cog"></i>
                Tài khoản
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="nav-spacer"></div>
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
.nav-wrapper {
  width: 100%;
}

.nav-spacer {
  height: 300px;
}

.nav-bar {
  background: linear-gradient(135deg, #2c3e50, #3498db);
  padding: 1rem 2rem;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

.nav-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  margin-bottom: 1rem;
}

.logo-section {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.logo-section i {
  font-size: 2rem;
  color: #fff;
}

.nav-bar h1 {
  font-size: 1.5rem;
  font-weight: 600;
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

.nav-content {
  max-width: 1400px;
  margin: 0 auto;
}

.nav-tabs {
  display: flex;
  gap: 2rem;
  justify-content: space-between;
  padding: 0 1rem;
}

.nav-group {
  flex: 1;
  min-width: 200px;
  max-width: 300px;
}

.group-title {
  color: #fff;
  font-size: 0.875rem;
  font-weight: 500;
  text-transform: uppercase;
  letter-spacing: 0.05em;
  margin: 0;
  padding: 0.5rem 0;
  border-bottom: 1px solid rgba(255, 255, 255, 0.1);
  text-align: center;
}

.group-links {
  display: flex;
  flex-direction: column;
  gap: 0.75rem;
  padding: 0.5rem 0;
}

.nav-tab {
  padding: 0.75rem 1rem;
  background-color: rgba(255, 255, 255, 0.1);
  border: none;
  border-radius: 0.5rem;
  color: #fff;
  font-size: 0.875rem;
  cursor: pointer;
  transition: all 0.3s;
  text-decoration: none;
  white-space: nowrap;
  display: flex;
  align-items: center;
  gap: 0.75rem;
}

.nav-tab i {
  font-size: 1rem;
  width: 1.5rem;
  text-align: center;
}

.nav-tab:hover {
  background-color: rgba(255, 255, 255, 0.2);
  transform: translateY(-2px);
}

.nav-tab.router-link-active {
  background-color: rgba(255, 255, 255, 0.25);
  font-weight: 500;
}

@media (max-width: 1200px) {
  .nav-tabs {
    gap: 1.5rem;
  }

  .nav-group {
    min-width: 180px;
  }
}

@media (max-width: 992px) {
  .nav-tabs {
    flex-wrap: wrap;
    gap: 1rem;
  }

  .nav-group {
    flex: 1 1 calc(50% - 1rem);
    min-width: 250px;
    max-width: none;
  }
}

@media (max-width: 768px) {
  .nav-spacer {
    height: 550px;
  }

  .nav-header {
    padding: 0.5rem;
    margin-bottom: 0.5rem;
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
    gap: 1rem;
    padding: 0.5rem 0;
  }

  .nav-group {
    flex: 1 1 100%;
    min-width: 100%;
  }

  .nav-tab {
    width: 100%;
    text-align: left;
  }
}

@media (max-width: 480px) {
  .nav-bar {
    padding: 0.75rem;
  }

  .logo-section i {
    font-size: 1.5rem;
  }

  .nav-bar h1 {
    font-size: 1.25rem;
  }

  .nav-spacer {
    height: 500px;
  }
}
</style>