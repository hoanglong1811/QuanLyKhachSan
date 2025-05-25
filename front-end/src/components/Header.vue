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
        <div class="language-selector" @click="toggleLanguage">
          <i class="fas fa-globe"></i>
          <span>{{ currentLanguage }}</span>
          <div class="language-dropdown" v-if="showLanguageDropdown">
            <div class="language-option" @click="selectLanguage('VI')">Tiếng Việt</div>
            <div class="language-option" @click="selectLanguage('EN')">English</div>
          </div>
        </div>
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
      isMenuOpen: false,
      showLanguageDropdown: false,
      currentLanguage: 'VI'
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
    toggleLanguage() {
      this.showLanguageDropdown = !this.showLanguageDropdown;
    },
    selectLanguage(lang) {
      this.currentLanguage = lang;
      this.showLanguageDropdown = false;
      // Implement language change logic here
    },
    goToBooking() {
      this.$router.push('/booking');
    }
  },
  mounted() {
    window.addEventListener('scroll', this.handleScroll);
    // Close language dropdown when clicking outside
    document.addEventListener('click', (e) => {
      if (!e.target.closest('.language-selector')) {
        this.showLanguageDropdown = false;
      }
    });
  },
  beforeUnmount() {
    window.removeEventListener('scroll', this.handleScroll);
  },
};
</script>

<style scoped>
header {
  background: transparent;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
  transition: all 0.3s ease;
}

header.sticky {
  background-color: rgba(205, 183, 158, 0.95);
  backdrop-filter: blur(10px);
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

.header-container {
  max-width: 1400px;
  margin: 0 auto;
  padding: 15px 30px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

/* Logo Styles */
.logo {
  flex: 0 0 auto;
}

.logo a {
  text-decoration: none;
  color: white;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.3);
}

.logo-text {
  font-size: 28px;
  font-weight: 700;
  letter-spacing: 2px;
}

.logo-subtext {
  font-size: 14px;
  font-weight: 500;
  letter-spacing: 1px;
}

/* Navigation Menu */
.menu {
  display: flex;
  gap: 30px;
  align-items: center;
}

.nav-link {
  color: white;
  text-decoration: none;
  font-size: 16px;
  font-weight: 500;
  padding: 5px 0;
  position: relative;
  transition: all 0.3s ease;
}

.nav-link::after {
  content: '';
  position: absolute;
  bottom: -2px;
  left: 0;
  width: 0;
  height: 2px;
  background-color: white;
  transition: width 0.3s ease;
}

.nav-link:hover::after,
.nav-link.router-link-active::after {
  width: 100%;
}

/* Right Section */
.right-section {
  display: flex;
  align-items: center;
  gap: 20px;
}

.language-selector {
  position: relative;
  display: flex;
  align-items: center;
  gap: 8px;
  color: white;
  cursor: pointer;
  padding: 5px 10px;
  border-radius: 5px;
  transition: all 0.3s ease;
}

.language-selector:hover {
  background: rgba(255, 255, 255, 0.1);
}

.language-dropdown {
  position: absolute;
  top: 100%;
  right: 0;
  background: white;
  border-radius: 5px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  margin-top: 5px;
}

.language-option {
  padding: 10px 20px;
  color: #333;
  transition: all 0.3s ease;
  white-space: nowrap;
}

.language-option:hover {
  background: #f5f5f5;
}

.booking-btn {
  background: white;
  color: #CDB79E;
  border: none;
  padding: 10px 20px;
  border-radius: 25px;
  font-size: 16px;
  font-weight: 600;
  display: flex;
  align-items: center;
  gap: 8px;
  cursor: pointer;
  transition: all 0.3s ease;
}

.booking-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
}

.menu-toggle {
  display: none;
  background: none;
  border: none;
  color: white;
  font-size: 24px;
  cursor: pointer;
  padding: 5px;
}

/* Mobile Styles */
@media (max-width: 992px) {
  .header-container {
    padding: 10px 20px;
  }

  .menu {
    position: fixed;
    top: 0;
    left: -100%;
    width: 80%;
    height: 100vh;
    background: rgba(205, 183, 158, 0.98);
    flex-direction: column;
    justify-content: center;
    padding: 50px 20px;
    transition: all 0.3s ease;
  }

  .menu-active {
    left: 0;
  }

  .nav-link {
    font-size: 20px;
    padding: 15px 0;
  }

  .menu-toggle {
    display: block;
  }

  .language-selector span {
    display: none;
  }

  .booking-btn span {
    display: none;
  }

  .booking-btn {
    padding: 10px;
  }
}

@media (max-width: 576px) {
  .logo-text {
    font-size: 24px;
  }

  .logo-subtext {
    font-size: 12px;
  }

  .header-container {
    padding: 10px 15px;
  }
}
</style>