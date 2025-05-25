<template>
  <header :class="{ 'sticky': isScrolled }">
    <div class="logo">
      <div>
        <span>PLACE</span>
        <span>LONG HAI RESORT</span>
      </div>
    </div>
    <nav class="menu">
      <router-link to="/">Trang chủ</router-link>
        <router-link to="/about-us">Giới thiệu</router-link>
        <router-link to="/room-types">Các loại phòng</router-link>
        <router-link to="/services">Dịch vụ</router-link>
        <router-link to="/contact-us">Liên hệ</router-link>
    </nav>
    <div class="right-section">
      <button class="booking-btn">Đặt phòng ngay</button>
    </div>
  </header>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      isScrolled: false,
    };
  },
  methods: {
    handleScroll() {
      this.isScrolled = window.scrollY > 0;
    },
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
  background: transparent;
  padding: 10px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  position: fixed;
  top: 0;
  width: 100%;
  height: 80px;
  z-index: 1000;
  transition: background-color 0.3s ease;
}

header.sticky {
  background-color: #CDB79E;
}

.logo {
  position: absolute;
  left: 15%;
  top: 50%;
  transform: translate(-50%, -50%);
  display: flex;
  justify-content: center;
  align-items: center;
  color: white;
  text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.logo div {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.logo span {
  font-size: 22px;
  font-weight: normal;
  margin-top: -2px;
}

.menu {
  display: flex;
  gap: 20px;
  position: absolute;
  left: 33%;
  top: 45%;
}

.menu a,
.menu router-link {
  color: white;
  text-decoration: none;
  font-size: 25px;
  text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.menu a:hover,
.menu router-link:hover {
  text-decoration: underline;
}

.right-section {
  display: flex;
  justify-content: center;
  align-items: center;
  position: absolute;
  left: 85%;
  top: 35%;
  
  
}

.booking-btn {
  background: white;
  color: #CDB79E;
  border: 1px solid #CDB79E;
  padding: 8px 15px;
  font-size: 20px;
  font-weight: bold;
  text-transform: uppercase;
  cursor: pointer;
  transition: none;
}

@media (max-width: 768px) {
  header {
    padding: 10px 15px;
    height: 50px;
  }

  .logo {
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
  }

  .logo span {
    font-size: 18px;
  }

  .menu {
    gap: 10px;
  }

  .menu a,
  .menu router-link {
    font-size: 16px;
  }

  .right-section {
    margin-right: 10px;
  }

  .booking-btn {
    font-size: 16px;
    padding: 5px 10px;
  }
}
</style>