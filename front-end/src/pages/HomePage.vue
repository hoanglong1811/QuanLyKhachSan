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
        <router-link to="/about">Giới thiệu</router-link>
        <router-link to="/ser">Các loại phòng</router-link>
        <router-link to="/ser">Dịch vụ</router-link>
        <router-link to="/contact">Liên hệ</router-link>
      </div>
      <div class="logo">
        <span>PLACE </span>
        <span> LONG HAI RESORT</span>
      </div>
      <div class="right-section">
        <div class="language" @click="toggleLanguageDropdown">
          <i class="fas fa-globe"></i>
          <span>{{ currentLanguage }}</span>
          <i class="fas fa-chevron-down"></i>
          <div class="language-dropdown" v-if="showLanguageDropdown">
            <span @click.stop="selectLanguage('Tiếng Việt')">Tiếng Việt</span>
            <span @click.stop="selectLanguage('English')">English</span>
            <!-- Thêm các ngôn ngữ khác nếu cần -->
            <span @click.stop="selectLanguage('日本語')">日本語</span>
            <span @click.stop="selectLanguage('Français')">Français</span>
          </div>
        </div>
        <button class="booking-btn" @click="goToBooking">Đặt phòng ngay</button>
      </div>
    </header>

    <div class="main-content">
      <div class="service-section">
        <div class="service-item" @mouseover="showDescription(0)" @mouseleave="hideDescription(0)">
          <img src="https://i.pinimg.com/736x/38/27/b4/3827b4f58756dff744206adcdc6bb118.jpg" alt="Green Place">
          <div class="service-overlay">Không gian xanh mát</div>
          <div class="service-description" v-show="descriptions[0].show">
            Khu nghỉ dưỡng sở hữu các bungalow riêng tư yên bình, ẩn mình dưới những hàng dương xanh, những cây phượng vĩ rợp bóng mát, ven các lối đi ngập tràn sắc hoa, hòa chung sắc xanh của đại dương sẽ giúp du khách thư giãn và hòa mình trọn vẹn với thiên nhiên.
          </div>
        </div>
        <div class="service-item" @mouseover="showDescription(1)" @mouseleave="hideDescription(1)">
          <img src="https://i.pinimg.com/736x/2b/0e/12/2b0e123b86c4b2448a4c52b6111cc5a4.jpg" alt="Service Heart">
          <div class="service-overlay">DỊCH VỤ TỪ TRÁI TIM</div>
          <div class="service-description" v-show="descriptions[1].show">
            Bên cạnh sự chuyên nghiệp cùng chất lượng dịch vụ chuẩn 4 sao, Chúng tôi mang đến những hoạt động trải nghiệm phong phú cùng sự tận tâm và chu đáo của đội ngũ nhân viên, chăm chút tỉ mỉ từng chi tiết nhỏ để đảm bảo bạn có một trải nghiệm trọn vẹn.
          </div>
        </div>
        <div class="service-item" @mouseover="showDescription(2)" @mouseleave="hideDescription(2)">
          <img src="https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg" alt="Private Vibrant">
          <div class="service-overlay">VỪA RIÊNG TƯ VỪA SÔI ĐỘNG</div>
          <div class="service-description" v-show="descriptions[2].show">
            Nhờ vị trí đắc địa ngay trung tâm thị trấn Long Hải, Palace Long Hai Resort không chỉ giúp khách hàng tận hưởng một kỳ nghỉ riêng tư, an yên bên người thân yêu mà còn dễ dàng kết nối với bên ngoài, khám phá những điểm đến hấp dẫn và trải nghiệm nhịp sống sôi động Long Hải.
          </div>
        </div>
      </div>

      <div class="booking-form">
        <div class="form-item">
          <label>Nhận phòng</label>
          <input type="date">
        </div>
        <div class="form-item">
          <label>Trả phòng</label>
          <input type="date">
        </div>
        <div class="form-item">
          <label>Phòng</label>
          <select>
            <option>01 Phòng</option>
            <option>02 Phòng</option>
            <option>03 Phòng</option>
          </select>
        </div>
        <div class="form-item">
          <label>Người lớn</label>
          <select>
            <option>01 Người lớn</option>
            <option>02 Người lớn</option>
            <option>03 Người lớn</option>
          </select>
        </div>
        <div class="form-item">
          <label>Trẻ em</label>
          <select>
            <option>0 Trẻ em</option>
            <option>1 Trẻ em</option>
            <option>2 Trẻ em</option>
          </select>
        </div>
        <div class="form-item">
          <button class="check-availability" @click="goToBooking">Kiểm tra phòng</button>
        </div>
      </div>

      <!-- Section: THE PLACE TO ENJOY THE MOST BEAUTIFUL SUNSET IN BARIA-VUNG TAU -->
      <section class="sunset-section">
        <div class="content-column">
          <div class="sun-icon">⭐</div>
          <h2>Lắng nghe âm thanh của biển</h2>
          <p>Sở hữu 62 căn bungalow với 75 phòng được thiết kế độc đáo và riêng tư nép mình dưới những hàng dương xanh mát ngay sát bờ biển, Palace Long Hai Resort sẽ ru hồn du khách bằng những khúc hát dịu êm của sóng biển hòa cùng tiếng rì rào trong gió của những hàng dương đệm thêm cho bản hòa ca thiên nhiên thêm bất tận</p>
          <button class="view-benefits-btn" @click="goToRooms">Xem các loại phòng</button>
        </div>
        <div class="image-column">
          <img :src="sunsetImages[currentImageIndex]" alt="Sunset Image" class="sunset-image">
          <button class="arrow-btn prev-btn" @click="prevImage">❮</button>
          <button class="arrow-btn next-btn" @click="nextImage">❯</button>
          <div class="pagination">
            <span v-for="(image, index) in sunsetImages" :key="index" :class="{ active: index === currentImageIndex }">
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
          <p>Nhờ nằm sát bờ biển, Palace Long Hai Resort sẵn sàng làm nức lòng du khách bởi khung cảnh hoàng hôn đầy lãng mạn. Đây cũng chính là nơi ngắm hoàng hôn đẹp nhất tại Bà Rịa – Vũng Tàu. Không những thế, đến đây, du khách còn được thỏa sức chiêm ngắm những khung cảnh thiên nhiên thanh bình và nhiều điểm check-in độc đáo.</p>
          <button class="view-benefits-btn" @click="goToServices">Xem các dịch vụ</button>
        </div>
      </section>

      <!-- Section 2: Our Mission -->
      <section class="about-section">
        <div class="content-column">
          <div class="icon">❤️</div>
          <h2>CẢM NHẬN SỰ YÊU THƯƠNG</h2>
          <p>Với những dịch vụ đến từ “trái tim”, đội ngũ Palace Long Hai Resort không chỉ níu chân du khách bằng sự chuyên nghiệp, tỉ mỉ trong công việc mà còn giúp du khách cảm nhận được sự quan tâm, chăm sóc, yêu thương như trở về với chính ngôi nhà của mình. Chúng tôi luôn nỗ lực để mang đến những trải nghiệm hoàn hảo cho bạn.</p>
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
            <p>Palace Long Hai Resort là khu nghỉ dưỡng 4 sao sang trọng tọa lạc tại trung tâm thị trấn Long Hải, mang đến sự kết hợp hoàn hảo giữa sự riêng tư và những trải nghiệm sôi động.</p>
          </div>
          <div class="footer-column">
            <h4>Liên kết nhanh</h4>
            <a href="#" @click.prevent="goToHome">Trang chủ</a>
            <a href="#" @click.prevent="goToAbout">Giới thiệu</a>
            <a href="#" @click.prevent="goToRooms">Các loại phòng</a>
            <a href="#" @click.prevent="goToServices">Dịch vụ</a>
            <a href="#" @click.prevent="goToContact">Liên hệ</a>
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
      showLanguageDropdown: false, // Trạng thái hiển thị dropdown ngôn ngữ
      currentLanguage: 'Tiếng Việt', // Ngôn ngữ hiện tại
      descriptions: [
        { show: false },
        { show: false },
        { show: false }
      ],
      isScrolled: false,
      sunsetImages: [
        "https://i.pinimg.com/736x/c2/05/c1/c205c1f5c0a0186abea431e8c8b59cd1.jpg",
        "https://i.pinimg.com/736x/01/86/17/018617ed16deae698f2631ab63f1122f.jpg",
        "https://i.pinimg.com/736x/17/52/ef/1752efb3482e2cabf5f67b8c0c521bf7.jpg",
        "https://i.pinimg.com/736x/e9/70/e3/e970e3114cbcf4f582328a0ef0e8c3ab.jpg",
        "https://i.pinimg.com/736x/d3/3c/54/d33c54da9337a403e5ae2e265df290e7.jpg",
        "https://i.pinimg.com/736x/7e/13/4f/7e134f89974b32ac5eb22c545ce626d6.jpg"
      ],
      currentImageIndex: 0
    };
  },
  methods: {
    toggleMenu() {
      this.showMenu = !this.showMenu;
    },
    toggleLanguageDropdown() {
      this.showLanguageDropdown = !this.showLanguageDropdown;
    },
    selectLanguage(language) {
      this.currentLanguage = language;
      this.showLanguageDropdown = false; // Ẩn dropdown sau khi chọn
      // Ở đây bạn có thể thêm logic để thay đổi ngôn ngữ giao diện nếu cần
      console.log(`Ngôn ngữ đã chọn: ${language}`);
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
      this.$router.push('/about');
    },
    goToRooms() {
      this.$router.push('/room');
    },
    goToServices() {
      this.$router.push('/ser');
    },
    goToContact() {
      this.$router.push('/contact');
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
  }
};
</script>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: 'Arial', sans-serif;
}

/* Header Styles */
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

.menu-toggle {
  font-size: 24px;
  cursor: pointer;
  color: white;
  margin-left: 30px;
}

.contact {
  display: flex;
  align-items: center;
  gap: 8px;
  font-size: 22px;
  color: white;
  margin-right: 1200px;
}

.contact i {
  font-size: 22px;
}

.menu-dropdown {
  position: absolute;
  top: 100%;
  left: 20px;
  background-color: #CDB79E;
  color: white;
  padding: 10px;
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  gap: 5px;
  z-index: 1001;
}

.menu-dropdown a,
.menu-dropdown router-link {
  color: white;
  text-decoration: none;
  font-size: 18px;
  font-weight: bold;
}

.menu-dropdown a:hover,
.menu-dropdown router-link:hover {
  text-decoration: underline;
}

.logo {
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}

.logo span {
  font-size: 22px;
  font-weight: normal;
  margin-top: -2px;
  color: white;
}

.right-section {
  display: flex;
  align-items: center;
  gap: 20px;
}

.language {
  position: relative;
  display: flex;
  align-items: center;
  gap: 6px;
  font-size: 20px;
  cursor: pointer;
  color: white;
  text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.language i {
  font-size: 22px;
}

.language-dropdown {
  position: absolute;
  top: 100%;
  right: 0;
  background-color: #CDB79E;
  color: white;
  padding: 10px;
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  gap: 5px;
  z-index: 1001;
  min-width: 120px;
}

.language-dropdown span {
  font-size: 16px;
  cursor: pointer;
}

.language-dropdown span:hover {
  background-color: rgba(255, 255, 255, 0.2);
  border-radius: 3px;
}

.booking-btn {
  background-color: transparent;
  background: white;
  color: #CDB79E;
  border: 2px solid #CDB79E;
  padding: 8px 15px;
  font-size: 20px;
  font-weight: bold;
  text-transform: uppercase;
  cursor: pointer;
  transition: none;
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
  font-size: 20px;
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
  font-size: 16px;
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
  font-size: 12px;
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
  font-size: 14px;
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
  font-size: 12px;
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
  font-size: 36px;
  font-weight: bold;
  margin-bottom: 20px;
  text-transform: uppercase;
}

.content-column p {
  font-size: 16px;
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
  font-size: 16px;
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
  font-size: 16px;
  text-align: center;
  margin-top: 10px;
}

.pagination span {
  margin: 0 5px;
  cursor: pointer;
}

.pagination .active {
  font-weight: bold;
  text-decoration: underline;
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
  font-size: 36px;
  font-weight: bold;
  margin-bottom: 20px;
  text-transform: uppercase;
}

.content-column p {
  font-size: 16px;
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
  font-size: 18px;
  font-weight: 600;
  margin-bottom: 20px;
  color: #fff;
}

.footer-column p,
.footer-column a {
  font-size: 14px;
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
  font-size: 14px;
  color: #d1d1d1;
  font-weight: 300;
}

/* Responsive Styles */
@media (max-width: 768px) {
  header {
    padding: 10px 15px;
    height: 60px;
  }

  .menu-toggle {
    font-size: 18px;
  }

  .contact {
    font-size: 12px;
  }

  .contact i {
    font-size: 12px;
  }

  .logo span {
    font-size: 18px;
  }

  .language,
  .booking-btn {
    font-size: 12px;
  }

  .language i {
    font-size: 12px;
  }

  .language-dropdown {
    min-width: 100px;
  }

  .booking-btn {
    padding: 5px 10px;
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
}
</style>