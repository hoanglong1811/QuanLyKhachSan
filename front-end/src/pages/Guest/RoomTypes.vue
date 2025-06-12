<template>
  <div>
    <Header />
    <div class="room-types-container">
      <!-- Hero Section with Animation -->
      <div class="hero-section">
        <div class="hero-background">
          <img src="https://i.pinimg.com/736x/c3/c9/cf/c3c9cf000c4bbe4e887f108d950c5179.jpg" alt="Hero Background">
          <div class="hero-overlay"></div>
        </div>
        <div class="hero-content">
          <h1 class="hero-title">Khám Phá Các Loại Phòng</h1>
          <p class="hero-subtitle">Nghỉ dưỡng thượng lưu tại Palace Long Hai Resort</p>
          <button class="explore-btn" @click="scrollToRooms">Khám Phá Ngay</button>
        </div>
      </div>

      <!-- Welcome Section -->
      <div class="welcome-section">
        <div class="welcome-content">
          <h2 class="welcome-title">Chào Mừng Đến Với Đẳng Cấp</h2>
          <p class="welcome-text">Palace Long Hai Resort mang đến không gian nghỉ dưỡng tinh tế với các loại phòng được thiết kế riêng biệt, đáp ứng mọi nhu cầu của bạn.</p>
        </div>
      </div>

      <!-- Room Types Section -->
      <div class="room-types-section" ref="roomsSection">
        <div class="room-grid">
          <!-- Standard Room -->
          <div class="room-item" @mouseover="activeRoom = 'standard'" @mouseleave="activeRoom = null">
            <div class="room-image">
              <img src="https://i.pinimg.com/736x/38/27/b4/3827b4f58756dff744206adcdc6bb118.jpg" alt="Standard Room">
              <div class="room-label">Standard</div>
            </div>
            <div class="room-details">
              <h3 class="room-name">Phòng Standard</h3>
              <div class="room-rating">
                <i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><span>(4.5/5)</span>
              </div>
              <p class="room-price">Từ 100,000 VND/đêm</p>
              <p class="room-desc">Phòng tiêu chuẩn.</p>
              <button class="room-btn" @click="viewDetails('standard')">Xem Thêm</button>
            </div>
          </div>
          <!-- Superior Room -->
          <div class="room-item" @mouseover="activeRoom = 'superior'" @mouseleave="activeRoom = null">
            <div class="room-image">
              <img src="https://i.pinimg.com/736x/2b/0e/12/2b0e123b86c4b2448a4c52b6111cc5a4.jpg" alt="Superior Room">
              <div class="room-label">Superior</div>
            </div>
            <div class="room-details">
              <h3 class="room-name">Phòng Superior</h3>
              <div class="room-rating">
                <i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><span>(4.8/5)</span>
              </div>
              <p class="room-price">Từ 150,000 VND/đêm</p>
              <p class="room-desc">Phòng nâng cao.</p>
              <button class="room-btn" @click="viewDetails('superior')">Xem Thêm</button>
            </div>
          </div>
          <!-- Deluxe Room -->
          <div class="room-item" @mouseover="activeRoom = 'deluxe'" @mouseleave="activeRoom = null">
            <div class="room-image">
              <img src="https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg" alt="Deluxe Room">
              <div class="room-label">Deluxe</div>
            </div>
            <div class="room-details">
              <h3 class="room-name">Phòng Deluxe</h3>
              <div class="room-rating">
                <i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><span>(5.0/5)</span>
              </div>
              <p class="room-price">Từ 200,000 VND/đêm</p>
              <p class="room-desc">Phòng sang trọng.</p>
              <button class="room-btn" @click="viewDetails('deluxe')">Xem Thêm</button>
            </div>
          </div>
          <!-- Suite Room -->
          <div class="room-item" @mouseover="activeRoom = 'suite'" @mouseleave="activeRoom = null">
            <div class="room-image">
              <img src="https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg" alt="Suite Room">
              <div class="room-label">Suite</div>
            </div>
            <div class="room-details">
              <h3 class="room-name">Phòng Suite</h3>
              <div class="room-rating">
                <i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><span>(5.0/5)</span>
              </div>
              <p class="room-price">Từ 500,000 VND/đêm</p>
              <p class="room-desc">Phòng thượng hạng.</p>
              <button class="room-btn" @click="viewDetails('suite')">Xem Thêm</button>
            </div>
          </div>
        </div>
      </div>

      <!-- Amenities Section -->
      <div class="amenities-section">
        <h2 class="amenities-title">Tiện Nghi Nổi Bật</h2>
        <div class="amenities-grid">
          <div class="amenity-item"><i class="fas fa-wifi"></i> Wifi miễn phí</div>
          <div class="amenity-item"><i class="fas fa-snowflake"></i> Điều hòa</div>
          <div class="amenity-item"><i class="fas fa-tv"></i> Smart TV</div>
          <div class="amenity-item"><i class="fas fa-hot-tub"></i> Bồn tắm</div>
          <div class="amenity-item"><i class="fas fa-swimming-pool"></i> Hồ bơi riêng</div>
          <div class="amenity-item"><i class="fas fa-coffee"></i> Mini bar</div>
        </div>
      </div>

      <!-- Compare Section -->
      <div class="compare-section">
        <h2 class="compare-title">So Sánh Các Loại Phòng</h2>
        <div class="compare-table">
          <table>
            <thead>
              <tr>
                <th>Tiện Nghi</th>
                <th>Deluxe</th>
                <th>Suite</th>
                <th>Beach Villa</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Diện tích</td>
                <td>35m²</td>
                <td>50m²</td>
                <td>80m²</td>
              </tr>
              <tr>
                <td>Số người</td>
                <td>2</td>
                <td>3</td>
                <td>4</td>
              </tr>
              <tr>
                <td>View</td>
                <td>Thành phố/Vườn</td>
                <td>Biển một phần</td>
                <td>Biển toàn cảnh</td>
              </tr>
              <tr>
                <td>Bồn tắm</td>
                <td><i class="fas fa-times"></i></td>
                <td><i class="fas fa-check"></i></td>
                <td><i class="fas fa-check"></i></td>
              </tr>
              <tr>
                <td>Hồ bơi riêng</td>
                <td><i class="fas fa-times"></i></td>
                <td><i class="fas fa-times"></i></td>
                <td><i class="fas fa-check"></i></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
    <Footer />
  </div>
</template>

<script>
import Header from '@/components/Header.vue';
import Footer from '@/components/Footer.vue';

export default {
  name: 'RoomTypes',
  components: {
    Header,
    Footer
  },
  data() {
    return {
      activeRoom: null
    }
  },
  methods: {
    viewDetails(roomType) {
      this.$router.push({
        path: `/room-types/${roomType}`,
        query: { type: roomType }
      });
    },
    scrollToRooms() {
      this.$refs.roomsSection.scrollIntoView({ behavior: 'smooth' });
    }
  }
};
</script>

<style scoped>
/* Import Google Fonts */
@import url('https://fonts.googleapis.com/css2?family=Playfair+Display:wght@400;700&family=Roboto:wght@300;400;500&display=swap');

/* Global Styles */
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.room-types-container {
  width: 100%;
  background-color: #F5F1E9;
  font-family: 'Roboto', sans-serif;
  color: #1E3A5F;
}

/* Hero Section */
.hero-section {
  position: relative;
  height: 100vh;
  overflow: hidden;
}

.hero-background img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 1;
}

.hero-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(to bottom, rgba(30, 58, 95, 0.4), rgba(30, 58, 95, 0.7));
  z-index: 2;
}

.hero-content {
  position: relative;
  z-index: 3;
  text-align: center;
  padding-top: 20vh;
  color: #fff;
}

.hero-title {
  font-family: 'Playfair Display', serif;
  font-size: 4rem;
  font-weight: 700;
  margin-bottom: 1rem;
}

.hero-subtitle {
  font-size: 1.5rem;
  margin-bottom: 2rem;
}

.explore-btn {
  background-color: #C9A66B;
  color: #fff;
  padding: 12px 30px;
  border: none;
  border-radius: 25px;
  font-size: 1.1rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.explore-btn:hover {
  background-color: #A87C3A;
}

/* Welcome Section */
.welcome-section {
  padding: 60px 20px;
  background-color: #fff;
  text-align: center;
}

.welcome-content {
  max-width: 800px;
  margin: 0 auto;
}

.welcome-title {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  margin-bottom: 1rem;
}

.welcome-text {
  font-size: 1.2rem;
  line-height: 1.6;
  color: #4B5D67;
}

/* Room Types Section */
.room-types-section {
  padding: 60px 20px;
  max-width: 1200px;
  margin: 0 auto;
}

.room-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 30px;
}

.room-item {
  background: #fff;
  border-radius: 15px;
  overflow: hidden;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease;
}

.room-item:hover {
  transform: translateY(-5px);
}

.room-image {
  position: relative;
  height: 300px;
  overflow: hidden;
}

.room-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.3s ease;
}

.room-item:hover .room-image img {
  transform: scale(1.1);
}

.room-label {
  position: absolute;
  top: 15px;
  left: 15px;
  background: #C9A66B;
  color: #fff;
  padding: 8px 15px;
  border-radius: 20px;
  font-size: 0.9rem;
  font-weight: 500;
}

.room-label.luxury {
  background: #1E3A5F;
}

.room-details {
  padding: 20px;
  text-align: center;
}

.room-name {
  font-family: 'Playfair Display', serif;
  font-size: 1.8rem;
  color: #1E3A5F;
  margin-bottom: 0.5rem;
}

.room-rating {
  color: #C9A66B;
  font-size: 0.9rem;
  margin-bottom: 0.5rem;
}

.room-rating span {
  color: #4B5D67;
  margin-left: 5px;
}

.room-price {
  font-size: 1.2rem;
  color: #1E3A5F;
  margin-bottom: 1rem;
}

.room-desc {
  font-size: 1rem;
  color: #4B5D67;
  margin-bottom: 1rem;
}

.room-btn {
  background-color: #C9A66B;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 25px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.room-btn:hover {
  background-color: #A87C3A;
}

/* Amenities Section */
.amenities-section {
  padding: 60px 20px;
  background-color: #fff;
  text-align: center;
}

.amenities-title {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  color: #1E3A5F;
  margin-bottom: 2rem;
}

.amenities-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 20px;
  max-width: 1000px;
  margin: 0 auto;
}

.amenity-item {
  font-size: 1.1rem;
  color: #4B5D67;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
}

.amenity-item i {
  color: #C9A66B;
  font-size: 1.2rem;
}

/* Compare Section */
.compare-section {
  padding: 60px 20px;
  background-color: #F5F1E9;
}

.compare-title {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  color: #1E3A5F;
  text-align: center;
  margin-bottom: 2rem;
}

.compare-table {
  max-width: 1000px;
  margin: 0 auto;
  overflow-x: auto;
}

table {
  width: 100%;
  border-collapse: collapse;
  background: #fff;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
}

th, td {
  padding: 15px;
  text-align: center;
  border-bottom: 1px solid #eee;
}

th {
  background: #1E3A5F;
  color: #fff;
  font-weight: 500;
}

td {
  color: #4B5D67;
}

tr:hover {
  background: #F5F1E9;
}

.fa-check {
  color: #2ECC71;
}

.fa-times {
  color: #E74C3C;
}

/* Responsive Design */
@media (max-width: 768px) {
  .hero-title {
    font-size: 3rem;
  }

  .hero-subtitle {
    font-size: 1.2rem;
  }

  .welcome-title, .amenities-title, .compare-title {
    font-size: 2rem;
  }

  .room-image {
    height: 250px;
  }

  .room-name {
    font-size: 1.5rem;
  }

  .room-price {
    font-size: 1rem;
  }

  .room-btn {
    padding: 8px 16px;
  }

  th, td {
    padding: 10px;
  }
}

@media (max-width: 480px) {
  .hero-title {
    font-size: 2.5rem;
  }

  .hero-content {
    padding-top: 15vh;
  }

  .room-image {
    height: 200px;
  }

  .room-details {
    padding: 15px;
  }

  .amenities-grid {
    grid-template-columns: 1fr;
  }
}
</style>