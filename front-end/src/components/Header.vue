<template>
  <header :class="{ 'sticky': isScrolled }">
    <div class="header-container">
      <!-- Logo Section -->
      <div class="logo">
        <router-link to="/">
          <span class="logo-text">PALACE</span>
          <span class="logo-subtext">LONG HAI RESORT</span>
        </router-link>
      </div>

      <!-- Navigation Menu -->
      <nav class="menu" :class="{ 'menu-active': isMenuOpen }">
        <router-link to="/" class="nav-link" @click="closeMenu">Trang chủ</router-link>
        <router-link to="/about-us" class="nav-link" @click="closeMenu">Giới thiệu</router-link>
        <router-link to="/room-types" class="nav-link" @click="closeMenu">Các loại phòng</router-link>
        <router-link to="/services" class="nav-link" @click="closeMenu">Dịch vụ</router-link>
        <router-link to="/contact-us" class="nav-link" @click="closeMenu">Liên hệ</router-link>
      </nav>

      <!-- Right Section -->
      <div class="right-section">
        <button class="booking-btn" @click="goToBooking">
          <i class="fas fa-calendar-alt"></i>
          Đặt phòng ngay
        </button>
        <!-- Mobile Menu Button -->
        <button class="menu-toggle" @click="toggleMenu">
          <i :class="isMenuOpen ? 'fas fa-times' : 'fas fa-bars'"></i>
        </button>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      isScrolled: false,
      isMenuOpen: false
    };
  },
  methods: {
    handleScroll() {
      this.isScrolled = window.scrollY > 0;
    },
    toggleMenu() {
      this.isMenuOpen = !this.isMenuOpen;
      document.body.style.overflow = this.isMenuOpen ? 'hidden' : '';
    },
    closeMenu() {
      this.isMenuOpen = false;
      document.body.style.overflow = '';
    },
    goToBooking() {
      this.$router.push('/booking');
    }
  },
  mounted() {
    window.addEventListener('scroll', this.handleScroll);
  },
  beforeUnmount() {
    window.removeEventListener('scroll', this.handleScroll);
  },
};
</script>

<style scoped>
header {
  background: linear-gradient(to bottom, rgba(0, 0, 0, 0.3), transparent);
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
  transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
  height: 80px;
  display: flex;
  align-items: center;
}

header.sticky {
  background: rgba(205, 183, 158, 0.92);
  backdrop-filter: blur(8px);
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  height: 70px;
}

.header-container {
  max-width: 1400px;
  margin: 0 auto;
  padding: 0 40px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
}

/* Logo Styles */
.logo {
  flex: 0 0 auto;
  transition: transform 0.3s ease;
}

.logo:hover {
  transform: translateY(-2px);
}

.logo a {
  text-decoration: none;
  color: white;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.2);
}

.logo-text {
  font-size: 32px;
  font-weight: 800;
  letter-spacing: 3px;
  line-height: 1;
  background: linear-gradient(45deg, #ffffff, #f0f0f0);
  -webkit-background-clip: text;
  background-clip: text;
  -webkit-text-fill-color: transparent;
}

.logo-subtext {
  font-size: 14px;
  font-weight: 500;
  letter-spacing: 2px;
  opacity: 0.9;
  margin-top: 2px;
}

/* Navigation Menu */
.menu {
  display: flex;
  gap: 40px;
  align-items: center;
  margin: 0 20px;
}

.nav-link {
  color: white;
  text-decoration: none;
  font-size: 15px;
  font-weight: 600;
  letter-spacing: 0.5px;
  padding: 8px 0;
  position: relative;
  transition: all 0.3s ease;
  text-transform: uppercase;
}

.nav-link::after {
  content: '';
  position: absolute;
  bottom: 0;
  left: 50%;
  width: 0;
  height: 2px;
  background: linear-gradient(90deg, transparent, #ffffff, transparent);
  transition: all 0.3s ease;
  transform: translateX(-50%);
}

.nav-link:hover {
  color: rgba(255, 255, 255, 0.95);
}

.nav-link:hover::after,
.nav-link.router-link-active::after {
  width: 100%;
}

/* Right Section */
.right-section {
  display: flex;
  align-items: center;
  gap: 25px;
}

.booking-btn {
  background: linear-gradient(45deg, #CDB79E, #E6C9A8);
  color: white;
  border: none;
  padding: 12px 28px;
  border-radius: 30px;
  font-size: 15px;
  font-weight: 600;
  display: flex;
  align-items: center;
  gap: 10px;
  cursor: pointer;
  transition: all 0.3s ease;
  text-transform: uppercase;
  letter-spacing: 0.5px;
  box-shadow: 0 4px 15px rgba(205, 183, 158, 0.2);
}

.booking-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 8px 25px rgba(205, 183, 158, 0.3);
  background: linear-gradient(45deg, #E6C9A8, #CDB79E);
}

.booking-btn i {
  font-size: 18px;
}

.menu-toggle {
  display: none;
  background: none;
  border: none;
  color: white;
  font-size: 24px;
  cursor: pointer;
  padding: 8px;
  transition: all 0.3s ease;
}

.menu-toggle:hover {
  transform: scale(1.1);
}

/* Mobile Styles */
@media (max-width: 992px) {
  .header-container {
    padding: 0 20px;
  }

  .menu {
    position: fixed;
    top: 0;
    left: -100%;
    width: 100%;
    height: 100vh;
    background: linear-gradient(135deg, rgba(205, 183, 158, 0.97), rgba(230, 201, 168, 0.97));
    flex-direction: column;
    justify-content: center;
    padding: 50px 20px;
    transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
    backdrop-filter: blur(10px);
  }

  .menu-active {
    left: 0;
  }

  .nav-link {
    font-size: 24px;
    padding: 15px 0;
    text-align: center;
    width: 100%;
  }

  .nav-link::after {
    bottom: 10px;
  }

  .menu-toggle {
    display: block;
    z-index: 1001;
  }

  .booking-btn {
    padding: 12px;
  }

  .booking-btn i {
    font-size: 16px;
  }
}

@media (max-width: 576px) {
  header {
    height: 70px;
  }

  header.sticky {
    height: 60px;
  }

  .header-container {
    padding: 0 15px;
  }

  .logo-text {
    font-size: 26px;
  }

  .logo-subtext {
    font-size: 12px;
    letter-spacing: 1px;
  }

  .right-section {
    gap: 15px;
  }

  .booking-btn {
    padding: 10px;
  }

  .booking-btn i {
    font-size: 16px;
  }
}
</style>