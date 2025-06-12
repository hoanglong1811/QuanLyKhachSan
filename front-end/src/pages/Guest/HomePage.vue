<template>
  <div>
    <div class="main-image">
      <img src="https://i.pinimg.com/736x/c3/c9/cf/c3c9cf000c4bbe4e887f108d950c5179.jpg" alt="Main Image">
    </div>
    <header :class="{ 'sticky': isScrolled }">
      <div class="menu-toggle" @click="toggleMenu">
        <i class="fas fa-bars"></i>
      </div>
      <div class="contact">
        <i class="fas fa-phone-alt"></i>
        <span>0938 156 069</span>
      </div>
      <div class="menu-dropdown" v-if="showMenu">
        <router-link to="/">Trang chủ</router-link>
        <router-link to="/about-us">Giới thiệu</router-link>
        <router-link to="/room-types">Các loại phòng</router-link>
        <router-link to="/services">Dịch vụ</router-link>
        <router-link to="/contact-us">Liên hệ</router-link>
      </div>
      <div class="logo">
        <span>PLACE </span>
        <span> LONG HAI RESORT</span>
      </div>
      <div class="right-section">
        <button class="booking-btn" @click="goToBooking">Đặt phòng ngay</button>
      </div>
    </header>

    <div class="main-content">
      <div class="service-section">
        <div class="service-item" @mouseover="showDescription(0)" @mouseleave="hideDescription(0)">
          <img src="https://i.pinimg.com/736x/38/27/b4/3827b4f58756dff744206adcdc6bb118.jpg" alt="Green Place">
          <div class="service-overlay">Không gian xanh mát</div>
          <div class="service-description" v-show="descriptions[0].show">
            Khu nghỉ dưỡng với các bungalow riêng tư, hòa cùng thiên nhiên xanh mát.
          </div>
        </div>
        <div class="service-item" @mouseover="showDescription(1)" @mouseleave="hideDescription(1)">
          <img src="https://i.pinimg.com/736x/2b/0e/12/2b0e123b86c4b2448a4c52b6111cc5a4.jpg" alt="Service Heart">
          <div class="service-overlay">DỊCH VỤ TỪ TRÁI TIM</div>
          <div class="service-description" v-show="descriptions[1].show">
            Dịch vụ chuẩn 4 sao, đội ngũ tận tâm, chăm chút từng chi tiết.
          </div>
        </div>
        <div class="service-item" @mouseover="showDescription(2)" @mouseleave="hideDescription(2)">
          <img src="https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg" alt="Private Vibrant">
          <div class="service-overlay">VỪA RIÊNG TƯ VỪA SÔI ĐỘNG</div>
          <div class="service-description" v-show="descriptions[2].show">
            Tọa lạc tại trung tâm Long Hải, mang đến kỳ nghỉ riêng tư và thuận tiện.
          </div>
        </div>
      </div>

      

      <!-- Section: THE PLACE TO ENJOY THE MOST BEAUTIFUL SUNSET IN BARIA-VUNG TAU -->
      <section class="sunset-section">
        <div class="content-column">
          <div class="sun-icon">⭐</div>
          <h2>Lắng nghe âm thanh của biển</h2>
          <p>Sở hữu 62 căn bungalow với 75 phòng được thiết kế độc đáo, Palace Long Hai Resort mang đến không gian nghỉ dưỡng tuyệt vời bên bờ biển.</p>
          <button class="view-benefits-btn" @click="goToRooms">Xem các loại phòng</button>
        </div>
        <div class="image-column">
          <img :src="sunsetImages[currentImageIndex]" alt="Sunset Image" class="sunset-image">
          <button class="arrow-btn prev-btn" @click="prevImage">❮</button>
          <button class="arrow-btn next-btn" @click="nextImage">❯</button>
          <div class="pagination">
            <span v-for="(image, index) in sunsetImages" 
                  :key="index" 
                  :class="{ active: index === currentImageIndex }"
                  @click="goToImage(index)">
              {{ String(index + 1).padStart(2, '0') }}
            </span>
          </div>
        </div>
      </section>

      <!-- Section 1: Our Story -->
      <section class="about-section">
        <div class="image-column">
          <img src="https://i.pinimg.com/736x/42/7e/1e/427e1e3bf74a0a28d9d6091832dfcbd7.jpg" alt="Our Story Image" class="about-image">
        </div>
        <div class="content-column">
          <div class="icon">🌞</div>
          <h2>NGẮM HOÀNG HÔN TẠI BÀ RỊA – VŨNG TÀU </h2>
          <p>Nhờ nằm sát bờ biển, Palace Long Hai Resort là nơi ngắm hoàng hôn đẹp nhất tại Bà Rịa – Vũng Tàu.</p>
          <button class="view-benefits-btn" @click="goToServices">Xem các dịch vụ</button>
        </div>
      </section>

      <!-- Section 2: Our Mission -->
      <section class="about-section">
        <div class="content-column">
          <div class="icon">❤️</div>
          <h2>CẢM NHẬN SỰ YÊU THƯƠNG</h2>
          <p>Với dịch vụ đến từ "trái tim", đội ngũ Palace Long Hai Resort mang đến trải nghiệm hoàn hảo cho bạn.</p>
          <button class="view-benefits-btn" @click="goToAbout">Về chúng tôi</button>
        </div>
        <div class="image-column">
          <img src="https://i.pinimg.com/736x/e0/a9/4c/e0a94c2ca4936ec2bffba22e353136e8.jpg" alt="Our Mission Image" class="about-image">
        </div>
      </section>

      <footer>
        <div class="footer-container">
          <div class="footer-column">
            <div class="h4">
              <h4>PLACE Long Hai Resort</h4>
            </div>
            <p>Palace Long Hai Resort là khu nghỉ dưỡng 4 sao sang trọng tại trung tâm Long Hải, kết hợp hoàn hảo giữa sự riêng tư và trải nghiệm sôi động.</p>
          </div>
          <div class="footer-column">
            <h4>Liên kết nhanh</h4>
            <router-link to="/">Trang chủ</router-link>
            <router-link to="/about-us">Giới thiệu</router-link>
            <router-link to="/room-types">Các loại phòng</router-link>
            <router-link to="/services">Dịch vụ</router-link>
            <router-link to="/contact-us">Liên hệ</router-link>
          </div>
          <div class="footer-column">
            <h4>Liên hệ với chúng tôi</h4>
            <p>Địa chỉ: Long Hai Town, Ba Ria - Vung Tau, Vietnam</p>
            <p>Số điện thoại: 0938 156 069</p>
            <p>Email: info@palacelonghairesort.vn</p>
          </div>
        </div>
      </footer>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomePage",
  data() {
    return {
      showMenu: false,
      isScrolled: false,
      currentImageIndex: 0,
      descriptions: [
        { show: false },
        { show: false },
        { show: false }
      ],
      sunsetImages: [
        "https://i.pinimg.com/736x/c2/05/c1/c205c1f5c0a0186abea431e8c8b59cd1.jpg",
        "https://i.pinimg.com/736x/01/86/17/018617ed16deae698f2631ab63f1122f.jpg",
        "https://i.pinimg.com/736x/17/52/ef/1752efb3482e2cabf5f67b8c0c521bf7.jpg",
        "https://i.pinimg.com/736x/e9/70/e3/e970e3114cbcf4f582328a0ef0e8c3ab.jpg",
        "https://i.pinimg.com/736x/d3/3c/54/d33c54da9337a403e5ae2e265df290e7.jpg",
        "https://i.pinimg.com/736x/7e/13/4f/7e134f89974b32ac5eb22c545ce626d6.jpg"
      ]
    };
  },
  methods: {
    toggleMenu() {
      this.showMenu = !this.showMenu;
    },
    showDescription(index) {
      this.descriptions[index].show = true;
    },
    hideDescription(index) {
      this.descriptions[index].show = false;
    },
    handleScroll() {
      this.isScrolled = window.scrollY > 0;
    },
    nextImage() {
      this.currentImageIndex = (this.currentImageIndex + 1) % this.sunsetImages.length;
    },
    prevImage() {
      this.currentImageIndex = (this.currentImageIndex - 1 + this.sunsetImages.length) % this.sunsetImages.length;
    },
    goToHome() {
      this.$router.push('/');
    },
    goToAbout() {
      this.$router.push('/about-us');
    },
    goToRooms() {
      this.$router.push('/room-types');
    },
    goToServices() {
      this.$router.push('/services');
    },
    goToContact() {
      this.$router.push('/contact-us');
    },
    goToBooking() {
      this.$router.push('/booking');
    },
    goToImage(index) {
      this.currentImageIndex = index;
    }
  },
  mounted() {
    window.addEventListener('scroll', this.handleScroll);
  },
  beforeUnmount() {
    window.removeEventListener('scroll', this.handleScroll);
  }
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Arial', sans-serif;
  font-size: 22px;
}

/* Header Styles */
header {
  background: linear-gradient(to bottom, rgba(0, 0, 0, 0.3), transparent);
  padding: 0 40px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  position: fixed;
  top: 0;
  width: 100%;
  height: 80px;
  z-index: 1000;
  transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
  font-size: 24px;
}

header.sticky {
  background: rgba(205, 183, 158, 0.92);
  backdrop-filter: blur(8px);
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  height: 70px;
}

.menu-toggle {
  font-size: 24px;
  cursor: pointer;
  color: white;
  padding: 8px;
  transition: transform 0.3s ease;
  border: 1px solid rgba(255, 255, 255, 0.2);
  border-radius: 8px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.menu-toggle:hover {
  transform: scale(1.1);
  background: rgba(255, 255, 255, 0.1);
}

.contact {
  display: flex;
  align-items: center;
  gap: 12px;
  font-size: 22px;
  color: white;
  font-weight: 500;
  letter-spacing: 0.5px;
  margin-right: auto;
  margin-left: 30px;
  padding: 8px 15px;
  border-radius: 25px;
  background: rgba(255, 255, 255, 0.1);
  backdrop-filter: blur(5px);
  transition: all 0.3s ease;
}

.contact:hover {
  background: rgba(255, 255, 255, 0.2);
}

.contact i {
  font-size: 18px;
  color: #CDB79E;
}

.menu-dropdown {
  position: absolute;
  top: 100%;
  left: 20px;
  background: rgba(205, 183, 158, 0.95);
  backdrop-filter: blur(10px);
  padding: 15px;
  border-radius: 12px;
  display: flex;
  flex-direction: column;
  gap: 10px;
  z-index: 1001;
  min-width: 200px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  transform-origin: top left;
  animation: dropdownFade 0.2s ease;
}

@keyframes dropdownFade {
  from {
    opacity: 0;
    transform: scale(0.95);
  }
  to {
    opacity: 1;
    transform: scale(1);
  }
}

.menu-dropdown a,
.menu-dropdown router-link {
  color: white;
  text-decoration: none;
  font-size: 22px;
  font-weight: 600;
  padding: 10px 15px;
  border-radius: 8px;
  transition: all 0.3s ease;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.menu-dropdown a:hover,
.menu-dropdown router-link:hover {
  background: rgba(255, 255, 255, 0.1);
  transform: translateX(5px);
}

.logo {
  position: absolute;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  flex-direction: column;
  align-items: center;
  transition: transform 0.3s ease;
}

.logo:hover {
  transform: translateX(-50%) translateY(-2px);
}

.logo span {
  font-size: 42px;
  font-weight: 800;
  color: white;
  letter-spacing: 2px;
  line-height: 1.2;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.2);
}

.logo span:last-child {
  font-size: 24px;
  font-weight: 500;
  letter-spacing: 3px;
  opacity: 0.9;
}

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
  font-size: 22px;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 0.5px;
  cursor: pointer;
  transition: all 0.3s ease;
  box-shadow: 0 4px 15px rgba(205, 183, 158, 0.2);
}

.booking-btn:hover {
  transform: translateY(-2px);
  box-shadow: 0 8px 25px rgba(205, 183, 158, 0.3);
  background: linear-gradient(45deg, #E6C9A8, #CDB79E);
}

/* Main Image Styles */
.main-image {
  width: 100%; /* Full width */
  height: 100vh; /* Full height */
  overflow: hidden;
  position: relative;
  z-index: 1;
}

.main-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

/* Main Content Styles */
.main-content {
  position: relative;
  z-index: 2;
}

/* Service Section Styles */
.service-section {
  display: flex;
  justify-content: center;
  gap: 30px;
  padding: 50px 20px;
  max-width: 1200px;
  margin: 0 auto;
}

.service-item {
  position: relative;
  width: 33.33%;
  text-align: center;
  transition: transform 0.3s ease;
}

.service-item:hover {
  transform: scale(1.1);
}

.service-item img {
  width: 100%;
  height: 400px;
  object-fit: cover;
  border-radius: 10px;
}

.service-overlay {
  position: absolute;
  bottom: 20px;
  left: 0;
  right: 0;
  background: rgba(0, 0, 0, 0.5);
  color: white;
  padding: 10px;
  font-size: 28px;
  font-weight: bold;
  text-align: center;
}

.service-description {
  position: absolute;
  top: 50%;
  left: 0;
  right: 0;
  background: rgba(0, 0, 0, 0.7);
  color: white;
  padding: 20px;
  font-size: 22px;
  text-align: center;
  transform: translateY(-50%);
  display: none;
}

.service-item:hover .service-description {
  display: block;
}

/* Booking Form Styles */
.booking-form {
  background-color: #CDB79E;
  padding: 15px 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  margin: 0;
  height: 150px;
}

.form-item {
  flex: 1;
  text-align: center;
  margin: 0 5px;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.form-item label {
  display: block;
  color: white;
  font-size: 20px;
  margin-bottom: 8px;
  text-transform: uppercase;
}

.form-item:nth-child(3) label,
.form-item:nth-child(4) label,
.form-item:nth-child(1) label,
.form-item:nth-child(2) label,
.form-item:nth-child(5) label {
  text-align: left;
}

.form-item input,
.form-item select {
  padding: 8px;
  border: none;
  border-radius: 4px;
  font-size: 20px;
  background-color: white;
  width: 100%;
  text-align: left;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

.form-item input[type="date"] {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  padding-right: 10px;
}

.form-item select {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
  background: url('data:image/svg+xml;utf8,<svg fill="black" height="24" viewBox="0 0 24 24" width="24" xmlns="http://www.w3.org/2000/svg"><path d="M7 10l5 5 5-5z"/></svg>') no-repeat;
  background-position: right 10px center;
  background-size: 12px;
  padding-right: 30px;
  background: white;
}

.check-availability {
  background-color: white;
  color: #CDB79E;
  border: 2px solid #CDB79E;
  padding: 8px 16px;
  border-radius: 50%;
  font-size: 20px;
  font-weight: 700;
  cursor: pointer;
  width: 100px;
  height: 100px;
  display: flex;
  align-items: center;
  justify-content: center;
  text-transform: uppercase;
}

/* Style cho section: Sunset */
.sunset-section {
  display: flex;
  justify-content: space-between;
  padding: 50px 20px;
  width: 100%;
  background-color: #f5f1e9;
}

.content-column {
  flex: 1;
  padding: 20px;
  color: #d4a017;
  background-color: #f5f1e9;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.content-column h2 {
  font-size: 48px;
  font-weight: bold;
  margin-bottom: 20px;
  text-transform: uppercase;
}

.content-column p {
  font-size: 22px;
  color: #666;
  line-height: 1.6;
  margin-bottom: 20px;
  text-align: center;
}

.sun-icon, .icon {
  font-size: 24px;
  color: #d4a017;
  text-align: center;
  margin-bottom: 20px;
}

.view-benefits-btn {
  background-color: #a67b5b;
  color: white;
  border: none;
  padding: 10px 20px;
  font-size: 22px;
  border-radius: 5px;
  cursor: pointer;
  text-transform: uppercase;
  width: fit-content;
}

.image-column {
  flex: 1;
  padding: 10px;
  position: relative;
}

.sunset-image, .about-image {
  width: 100%;
  height: 400px;
  object-fit: cover;
}

.arrow-btn {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  border: none;
  padding: 10px;
  font-size: 24px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.arrow-btn:hover {
  background-color: rgba(0, 0, 0, 0.8);
}

.prev-btn {
  left: 10px;
}

.next-btn {
  right: 10px;
}

.pagination {
  color: #d4a017;
  font-size: 22px;
  text-align: center;
  margin-top: 10px;
}

.pagination span {
  margin: 0 5px;
  cursor: pointer;
  padding: 5px 10px;
  border-radius: 4px;
  transition: all 0.3s ease;
}

.pagination span:hover {
  background-color: rgba(212, 160, 23, 0.1);
}

.pagination .active {
  font-weight: bold;
  text-decoration: underline;
  background-color: rgba(212, 160, 23, 0.2);
}

/* Style cho section: About Sections */
.about-section {
  display: flex;
  justify-content: space-between;
  padding: 50px 20px;
  width: 100%;
  background-color: #e8e4d9; /* Màu nền khác biệt */
}

.content-column {
  flex: 1;
  padding: 20px;
  color: #d4a017;
  background-color: transparent;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.content-column h2 {
  font-size: 48px;
  font-weight: bold;
  margin-bottom: 20px;
  text-transform: uppercase;
}

.content-column p {
  font-size: 22px;
  color: #666;
  line-height: 1.6;
  margin-bottom: 20px;
}

/* Footer Styles */
footer {
  background-color: #8B7D6B;
  color: white;
  padding: 30px 20px;
}

.footer-container {
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  gap: 30px;
  max-width: 1200px;
  margin: 0 auto;
}

.footer-column {
  flex: 1;
  min-width: 200px;
}

.footer-column h4 {
  font-size: 28px;
  font-weight: 600;
  margin-bottom: 20px;
  color: #fff;
}

.footer-column p,
.footer-column a {
  font-size: 20px;
  color: #d1d1d1;
  text-decoration: none;
  margin-bottom: 4px;
  display: block;
  line-height: 1.6;
  font-weight: 300;
}

.footer-column a:hover {
  color: #fff;
}

.footer-column input {
  padding: 12px;
  border: none;
  border-radius: 5px;
  width: 100%;
  margin-bottom: 10px;
  font-size: 14px;
}

.footer-column button {
  background-color: #CDB79E;
  color: white;
  border: none;
  padding: 12px 20px;
  border-radius: 5px;
  cursor: pointer;
  font-size: 14px;
  font-weight: bold;
}

.footer-bottom {
  text-align: center;
  padding-top: 30px;
  border-top: 1px solid #5a7a7c;
  margin-top: 30px;
}

.footer-bottom p {
  font-size: 20px;
  color: #d1d1d1;
  font-weight: 300;
}

/* Responsive Styles */
@media (max-width: 768px) {
  header {
    padding: 10px 15px;
    height: 60px;
    font-size: 20px;
  }

  .menu-toggle {
    font-size: 18px;
  }

  .contact {
    font-size: 16px;
  }

  .contact i {
    font-size: 12px;
  }

  .logo span {
    font-size: 24px;
  }

  .logo span:last-child {
    font-size: 16px;
  }

  .booking-btn {
    font-size: 16px;
  }

  .main-image {
    height: 50vh;
  }

  .service-section {
    flex-direction: column;
    padding: 30px 15px;
  }

  .service-item {
    width: 100%;
    margin-bottom: 20px;
  }

  .service-item img {
    height: 300px;
  }

  .booking-form {
    flex-direction: column;
    gap: 10px;
    padding: 15px;
    height: auto;
    align-items: center;
  }

  .form-item {
    width: 100%;
    margin: 0 0 10px 0;
  }

  .form-item input,
  .form-item select {
    width: 100%;
  }

  .check-availability {
    width: 50px;
    height: 50px;
    margin: 0 auto;
  }

  .sunset-section,
  .about-section {
    flex-direction: column;
    padding: 20px;
  }

  .content-column, .image-column {
    flex: none;
    width: 100%;
  }

  .sunset-image,
  .about-image {
    height: 300px;
  }

  .arrow-btn {
    font-size: 18px;
    padding: 8px;
  }

  .prev-btn {
    left: 5px;
  }

  .next-btn {
    right: 5px;
  }

  .footer-container {
    flex-direction: column;
    align-items: center;
    text-align: center;
  }

  .footer-column {
    margin-bottom: 20px;
  }

  * {
    font-size: 18px;
  }

  .menu-dropdown a,
  .menu-dropdown router-link {
    font-size: 18px;
  }

  .service-overlay {
    font-size: 20px;
  }

  .service-description {
    font-size: 16px;
  }

  .form-item label {
    font-size: 16px;
  }

  .form-item input,
  .form-item select {
    font-size: 16px;
  }

  .check-availability {
    font-size: 16px;
  }

  .content-column h2 {
    font-size: 28px;
  }

  .content-column p {
    font-size: 16px;
  }

  .view-benefits-btn {
    font-size: 16px;
  }

  .pagination {
    font-size: 16px;
  }

  .footer-column h4 {
    font-size: 20px;
  }

  .footer-column p,
  .footer-column a {
    font-size: 16px;
  }

  .footer-bottom p {
    font-size: 16px;
  }
}
</style>