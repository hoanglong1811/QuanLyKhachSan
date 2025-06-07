<template>
  <div class="about-us">
    <!-- Main Image with Header -->
    <div class="main-image">
      <img src="https://i.pinimg.com/736x/5f/43/4a/5f434a75f3d03ac0ce3778603a55c907.jpg" alt="About Us Image">
      <div class="hero-overlay"></div>
      <div class="image-text">
        <span class="subtitle">Palace Long Hai Resort</span>
        <h1>Dịch vụ</h1>
        <p>Sự hài lòng của bạn là hạnh phúc của chúng tôi</p>
        <div class="scroll-indicator">
          <div class="mouse">
            <div class="wheel"></div>
          </div>
          <div class="arrows">
            <span></span>
            <span></span>
            <span></span>
          </div>
        </div>
      </div>
    </div>

    <!-- Sử dụng Header component -->
    <Header />

    <!-- Intro Section -->
    <section class="intro-section">   
      <div class="container">
        <div class="intro-content">
          <div class="intro-header">
            <span class="section-tag">Dịch vụ đẳng cấp</span>
            <h1 class="main-title">Trải nghiệm hoàn hảo</h1>
            <div class="title-underline"></div>
          </div>
          <p class="intro-text">
            Palace Long Hai Resort tự hào mang đến những trải nghiệm nghỉ dưỡng và tổ chức sự kiện đẳng cấp 4 sao. 
            Với đội ngũ chuyên nghiệp và cơ sở vật chất hiện đại, chúng tôi cam kết mang đến những khoảnh khắc đáng nhớ cho mọi du khách.
          </p>
          <div class="service-stats">
            <div class="stat-item">
              <span class="stat-number">700+</span>
              <span class="stat-label">Khách/Sự kiện</span>
            </div>
            <div class="stat-item">
              <span class="stat-number">50+</span>
              <span class="stat-label">Nhân viên</span>
            </div>
            <div class="stat-item">
              <span class="stat-number">100%</span>
              <span class="stat-label">Hài lòng</span>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- New Section: Sunset Section 1 - Tổ chức sự kiện -->
    <section class="sunset-section">
      <div class="content-column">
        <h1>Tổ chức sự kiện</h1>
        <h2>Nơi tạo nên những khoảnh khắc đáng nhớ</h2>
        <p>Palace Long Hai Resort là điểm đến hoàn hảo cho mọi sự kiện từ quy mô nhỏ đến lớn:</p>
        <ul class="feature-list">
          <li>Không gian rộng rãi sát biển</li>
          <li>Sức chứa lên đến 700 khách</li>
          <li>Đội ngũ tổ chức chuyên nghiệp</li>
          <li>Trang thiết bị hiện đại</li>
        </ul>
      </div>
      <div class="image-column">
        <img :src="eventImages[currentImageIndices[0]]" alt="Event Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(0)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(0)"></button>
        <div class="pagination">
          <span 
            v-for="(image, index) in eventImages" 
            :key="index" 
            :class="{ 'active': index === currentImageIndices[0] }"
            @click="goToImage(0, index)"
          >
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
    </section>

    <!-- New Section: Sunset Section 2 - Tiệc cưới -->
    <section class="sunset-section">
      <div class="image-column">
        <img :src="weddingImages[currentImageIndices[1]]" alt="Wedding Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(1)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(1)"></button>
        <div class="pagination">
          <span 
            v-for="(image, index) in weddingImages" 
            :key="index" 
            :class="{ 'active': index === currentImageIndices[1] }"
            @click="goToImage(1, index)"
          >
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
      <div class="content-column">
        <h1>Tiệc cưới</h1>
        <h2>Nơi ghi dấu hạnh phúc trọn vẹn</h2>
        <p>Không gian cưới đẳng cấp tại Palace Long Hai Resort:</p>
        <ul class="feature-list">
          <li>Sảnh tiệc sang trọng sức chứa 700 khách</li>
          <li>Bãi biển lãng mạn cho tiệc cưới ngoài trời</li>
          <li>Dịch vụ trang trí tiệc cưới theo yêu cầu</li>
          <li>Đội ngũ đầu bếp chuyên nghiệp</li>
        </ul>
      </div>
    </section>

    <!-- New Section: Sunset Section 3 - Team Building -->
    <section class="sunset-section">
      <div class="content-column">
        <h1>Team Building</h1>
        <h2>Nơi kết nối - Nơi thành công</h2>
        <p>Địa điểm lý tưởng cho các hoạt động team building:</p>
        <ul class="feature-list">
          <li>Bãi biển riêng tư rộng rãi</li>
          <li>Khu vực tổ chức trò chơi đa dạng</li>
          <li>Trang thiết bị hoạt động ngoài trời</li>
          <li>Đội ngũ hỗ trợ chuyên nghiệp</li>
        </ul>
      </div>
      <div class="image-column">
        <img :src="teamBuildingImages[currentImageIndices[2]]" alt="Team Building Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(2)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(2)"></button>
        <div class="pagination">
          <span 
            v-for="(image, index) in teamBuildingImages" 
            :key="index" 
            :class="{ 'active': index === currentImageIndices[2] }"
            @click="goToImage(2, index)"
          >
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
    </section>

    <!-- New Section: Sunset Section 4 - Điểm tham quan lân cận -->
    <section class="sunset-section">
      <div class="image-column">
        <img :src="nearbyImages[currentImageIndices[3]]" alt="Nearby Attraction Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(3)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(3)"></button>
        <div class="pagination">
          <span 
            v-for="(image, index) in nearbyImages" 
            :key="index" 
            :class="{ 'active': index === currentImageIndices[3] }"
            @click="goToImage(3, index)"
          >
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
      <div class="content-column">
        <h1>Điểm tham quan</h1>
        <h2>Khám phá vẻ đẹp Long Hải</h2>
        <p>Những địa điểm không thể bỏ qua khi đến Long Hải:</p>
        <ul class="feature-list highlight">
          <li>Bãi biển Long Hải</li>
          <li>Khu di tích Minh Đạm</li>
          <li>Đèo Nước Ngọt</li>
          <li>Đền Dinh Cô</li>
          <li>Thiền viện Trúc Lâm</li>
          <li>Làng chài Long Hải</li>
        </ul>
      </div>
    </section>

    <!-- Sử dụng Footer component -->
    <Footer />
  </div>
</template>

<script>
import Header from '../../components/Header.vue';
import Footer from '../../components/Footer.vue';

export default {
  name: "Services",
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      isScrolled: false,
      descriptions: [
        { show: false },
        { show: false },
        { show: false },
        { show: false },
      ],
      currentImageIndices: [0, 0, 0, 0], // Mảng chứa chỉ số hình ảnh cho từng section
      eventImages: [ // Ảnh cho section Tổ chức sự kiện
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-8.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-7.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-6.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-1.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/10/TRANG-SU-KIEN21-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/10/TRANG-SU-KIEN12-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-10.jpg"
      ],
      weddingImages: [ // Ảnh cho section Tiệc cưới
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC03082_2-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC03121_2-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/LTO04760-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/LTO04744-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/LTO05494-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC03093_2-small.jpg"
      ],
      teamBuildingImages: [ // Ảnh cho section Team Building
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/450259574_10226728122884949_8373272424702179827_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/453011581_1009774047816718_1794423109283007495_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/452965493_1009774174483372_2700943104046581161_n-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/450332275_8204059062960326_8003284075842702402_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/450327326_8204059372960295_5250398034549012779_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/453008963_1009774081150048_70538483209812672_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/449918219_10226728123084954_7888605806022048818_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/452947259_1009774057816717_6355652659540582983_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/DSC05285-small.jpeg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/DSC05309-small.jpeg",
      ],
      nearbyImages: [ // Ảnh cho section Điểm tham quan lân cận
        "https://i.pinimg.com/736x/5b/26/51/5b2651bc08050b9af23bb838973f8879.jpg",
        "https://i.pinimg.com/736x/9e/1e/9c/9e1e9cde43714cbf93717c0bbcedf6ce.jpg",
        "https://i.pinimg.com/736x/3e/17/56/3e17562dc1b1e844a9daa4f4172eb024.jpg",
        "https://i.pinimg.com/736x/a0/6e/1a/a06e1a16854372b3a4fe6b03b4bcf48b.jpg",
        "https://i.pinimg.com/736x/97/ea/22/97ea228cda929b6c0bc6b3ba438fff41.jpg",
        "https://i.pinimg.com/736x/0f/37/11/0f371119e630e4dea2bf3b4dcf196047.jpg"
      ]
    };
  },
  methods: {
    handleScroll() {
      this.isScrolled = window.scrollY > 0;
    },
    showDescription(index) {
      this.descriptions[index].show = true;
    },
    hideDescription(index) {
      this.descriptions[index].show = false;
    },
    prevImage(sectionIndex) {
      const imageArrays = [this.eventImages, this.weddingImages, this.teamBuildingImages, this.nearbyImages];
      this.currentImageIndices[sectionIndex] = (this.currentImageIndices[sectionIndex] > 0) ? this.currentImageIndices[sectionIndex] - 1 : imageArrays[sectionIndex].length - 1;
    },
    nextImage(sectionIndex) {
      const imageArrays = [this.eventImages, this.weddingImages, this.teamBuildingImages, this.nearbyImages];
      this.currentImageIndices[sectionIndex] = (this.currentImageIndices[sectionIndex] < imageArrays[sectionIndex].length - 1) ? this.currentImageIndices[sectionIndex] + 1 : 0;
    },
    goToImage(sectionIndex, imageIndex) {
      this.currentImageIndices[sectionIndex] = imageIndex;
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
/* Giữ lại các style liên quan đến nội dung .about-us và .main-content */
.about-us {
  background-color: #b9b9b9;
  min-height: 100vh;
}

/* Main Image Styles */
.main-image {
  width: 100%;
  height: 100vh;
  overflow: hidden;
  position: relative;
  z-index: 1;
}

.main-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transform: scale(1.1);
  transition: transform 0.3s ease-out;
}

.hero-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(
    to bottom,
    rgba(0, 0, 0, 0.4) 0%,
    rgba(0, 0, 0, 0.6) 100%
  );
}

.image-text {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
  color: white;
  width: 90%;
  max-width: 1200px;
}

.image-text .subtitle {
  display: block;
  font-size: 1.2rem;
  text-transform: uppercase;
  letter-spacing: 4px;
  margin-bottom: 1rem;
  opacity: 0.9;
}

.image-text h1 {
  font-size: 4.5rem;
  font-weight: 700;
  margin: 0;
  letter-spacing: 2px;
  text-transform: uppercase;
  animation: fadeInUp 1s ease-out;
}

.image-text p {
  font-size: 1.5rem;
  margin-top: 1.5rem;
  opacity: 0.9;
  font-weight: 300;
  animation: fadeInUp 1s ease-out 0.2s;
}

/* Scroll Indicator */
.scroll-indicator {
  position: absolute;
  bottom: 40px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 1rem;
}

.mouse {
  width: 26px;
  height: 42px;
  border: 2px solid #fff;
  border-radius: 15px;
  position: relative;
}

.wheel {
  width: 4px;
  height: 8px;
  background: #fff;
  position: absolute;
  top: 7px;
  left: 50%;
  transform: translateX(-50%);
  border-radius: 2px;
  animation: scroll 2s infinite;
}

.arrows {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 5px;
}

.arrows span {
  display: block;
  width: 10px;
  height: 10px;
  border-right: 2px solid #fff;
  border-bottom: 2px solid #fff;
  transform: rotate(45deg);
  animation: arrows 2s infinite;
}

.arrows span:nth-child(2) {
  animation-delay: 0.2s;
}

.arrows span:nth-child(3) {
  animation-delay: 0.4s;
}

/* Intro Section Styles */
.intro-section {
  padding: 120px 0;
  background-color: #fff;
  position: relative;
}

.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 20px;
}

.intro-content {
  text-align: center;
  max-width: 900px;
  margin: 0 auto;
}

.intro-header {
  margin-bottom: 40px;
}

.section-tag {
  display: inline-block;
  padding: 12px 24px;
  background: rgba(212, 160, 23, 0.1);
  color: #d4a017;
  border-radius: 30px;
  font-size: 1.2rem;
  text-transform: uppercase;
  letter-spacing: 2px;
  margin-bottom: 1.5rem;
  font-weight: 500;
}

.main-title {
  font-size: 3.5rem;
  color: #333;
  margin-bottom: 1rem;
  font-weight: 700;
  text-transform: uppercase;
  letter-spacing: 1px;
}

.title-underline {
  width: 100px;
  height: 4px;
  background: #d4a017;
  margin: 0 auto;
  margin-top: 1rem;
}

.intro-text {
  font-size: 1.4rem;
  color: #666;
  line-height: 1.8;
  margin-bottom: 4rem;
  max-width: 800px;
  margin-left: auto;
  margin-right: auto;
}

.service-stats {
  display: flex;
  justify-content: space-between;
  gap: 2rem;
  margin-top: 4rem;
}

.stat-item {
  flex: 1;
  text-align: center;
  padding: 2.5rem;
  background: #fff;
  border-radius: 15px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
  border: 1px solid rgba(212, 160, 23, 0.1);
}

.stat-item:hover {
  transform: translateY(-10px);
  box-shadow: 0 15px 40px rgba(212, 160, 23, 0.15);
  border-color: #d4a017;
}

.stat-number {
  display: block;
  font-size: 3.5rem;
  font-weight: 700;
  color: #d4a017;
  margin-bottom: 0.8rem;
  line-height: 1;
}

.stat-label {
  font-size: 1.2rem;
  color: #666;
  text-transform: uppercase;
  letter-spacing: 1px;
  font-weight: 500;
}

@keyframes scroll {
  0% { opacity: 1; transform: translateX(-50%) translateY(0); }
  50% { opacity: 0; transform: translateX(-50%) translateY(8px); }
  100% { opacity: 1; transform: translateX(-50%) translateY(0); }
}

@keyframes arrows {
  0% { opacity: 0; transform: rotate(45deg) translate(-5px, -5px); }
  50% { opacity: 1; }
  100% { opacity: 0; transform: rotate(45deg) translate(5px, 5px); }
}

@keyframes fadeInUp {
  from {
    opacity: 0;
    transform: translateY(20px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

/* Sunset Section Styles */
.sunset-section {
  display: flex;
  justify-content: space-between;
  padding: 40px 20px;
  background-color: #f5f5f5;
  /* Xóa height: 500px để chiều cao tự động */
}

.content-column {
  flex: 1;
  padding: 40px;
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.content-column h1 {
  font-size: 3.2rem;
  color: #d4a017;
  text-transform: uppercase;
  margin-bottom: 1rem;
  font-weight: 700;
  text-align: left;
}

.content-column h2 {
  font-size: 1.8rem;
  color: #333;
  margin-bottom: 2rem;
  font-weight: 500;
  text-align: left;
}

.content-column p {
  font-size: 1.4rem;
  color: #555;
  margin-bottom: 1.5rem;
  line-height: 1.6;
}

.feature-list {
  list-style: none;
  padding: 0;
  margin: 0;
}

.feature-list li {
  font-size: 1.3rem;
  color: #666;
  margin-bottom: 1rem;
  padding-left: 2rem;
  position: relative;
  line-height: 1.4;
}

.feature-list li::before {
  content: "•";
  color: #d4a017;
  font-size: 1.5rem;
  position: absolute;
  left: 0;
  top: -2px;
}

.feature-list.highlight li {
  font-size: 1.4rem;
  font-weight: 500;
  color: #555;
}

.image-column {
  flex: 1;
  position: relative;
}

.sunset-image {
  width: 100%;
  height: 450px; /* Chiều cao mặc định */
  object-fit: cover;
}

.arrow-btn {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  border: none;
  font-size: 20px;
  cursor: pointer;
  padding: 10px;
}

.prev-btn {
  left: 10px;
}

.next-btn {
  right: 10px;
}

.pagination {
  text-align: center;
  margin-top: 15px;
  display: flex;
  justify-content: center;
  gap: 10px;
}

.pagination span {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 35px;
  height: 35px;
  background-color: rgba(255, 255, 255, 0.9);
  margin: 0 2px;
  cursor: pointer;
  border-radius: 50%;
  font-size: 0.9rem;
  font-weight: 500;
  color: #666;
  transition: all 0.3s ease;
  border: 2px solid transparent;
}

.pagination span:hover {
  background-color: rgba(212, 160, 23, 0.1);
  color: #d4a017;
  border-color: #d4a017;
  transform: translateY(-2px);
}

.pagination span.active {
  background-color: #d4a017;
  color: white;
  border-color: #d4a017;
}

/* Split Section Styles */
.split-section {
  display: flex;
  width: 100%;
  height: 50vh;
}

.text-content {
  flex: 1;
  background-color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: center;
}

.stars {
  display: flex;
  gap: 5px;
  margin-bottom: 10px;
  justify-content: center;
}

.stars i {
  color: #d4a017;
  font-size: 16px;
}

.text-content h3 {
  font-size: 24px;
  color: #d4a017;
  margin-bottom: 15px;
  font-weight: bold;
}

.text-content p {
  font-size: 16px;
  color: #666;
  line-height: 1.6;
}

.image-content {
  flex: 1;
}

.image-content img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

/* Service Highlights Styles */
.main-content {
  display: flex;
  justify-content: center;
  gap: 20px;
  padding: 50px 20px;
  flex-wrap: wrap;
  background: #f1f0f0;
}

.main-content h2 {
  font-size: 32px;
  color: #3b7097;
  text-align: center;
  margin-bottom: 30px;
  width: 100%;
}

.service-item {
  position: relative;
  width: 30%;
  min-width: 300px;
  overflow: hidden;
}

.service-item img {
  width: 100%;
  height: auto;
  display: block;
}

.service-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.7);
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  padding: 20px;
  opacity: 0;
  transform: translateY(10px);
  transition: opacity 0.3s ease, transform 0.3s ease;
}

.service-item:hover .service-overlay {
  opacity: 1;
  transform: translateY(0);
}

/* Responsive Design */
@media (max-width: 768px) {
  .main-image {
    height: 80vh;
  }

  .image-text h1 {
    font-size: 3rem;
  }

  .image-text p {
    font-size: 1.2rem;
  }

  .intro-section {
    padding: 80px 0;
  }

  .section-tag {
    font-size: 1rem;
    padding: 8px 16px;
  }

  .main-title {
    font-size: 2.5rem;
  }

  .intro-text {
    font-size: 1.2rem;
    padding: 0 20px;
  }

  .service-stats {
    flex-direction: column;
    gap: 1.5rem;
    padding: 0 20px;
  }

  .stat-item {
    padding: 2rem;
  }

  .stat-number {
    font-size: 3rem;
  }

  .stat-label {
    font-size: 1.1rem;
  }

  .sunset-section {
    flex-direction: column;
    height: auto; /* Để chiều cao tự động trên thiết bị di động */
  }

  .content-column, .image-column {
    width: 100%;
  }

  .sunset-image {
    height: 300px; /* Giảm chiều cao hình ảnh trên thiết bị di động */
  }

  .split-section {
    flex-direction: column;
    height: auto;
  }

  .text-content {
    padding: 20px;
  }

  .text-content h3 {
    font-size: 20px;
  }

  .text-content p {
    font-size: 14px;
  }

  .image-content img {
    height: 300px;
  }

  .main-content {
    flex-direction: column;
    padding: 20px;
  }

  .main-content h2 {
    font-size: 24px;
    margin-bottom: 20px;
  }

  .service-item {
    width: 100%;
    min-width: 0;
  }

  .content-column {
    padding: 30px 20px;
  }

  .content-column h1 {
    font-size: 2.5rem;
  }

  .content-column h2 {
    font-size: 1.5rem;
  }

  .content-column p {
    font-size: 1.2rem;
  }

  .feature-list li {
    font-size: 1.1rem;
  }

  .feature-list.highlight li {
    font-size: 1.2rem;
  }
}
</style>