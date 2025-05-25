<template>
  <div>
    <Header />
    <div class="room-types-container">
      <!-- Banner Section with Parallax -->
      <div class="banner parallax">
        <img src="https://i.pinimg.com/736x/c3/c9/cf/c3c9cf000c4bbe4e887f108d950c5179.jpg" alt="Room Types Banner">
        <div class="banner-overlay"></div>
        <div class="banner-content">
          <h1>Các Loại Phòng</h1>
          <p>Khám phá không gian nghỉ dưỡng tuyệt vời tại Palace Long Hai Resort</p>
        </div>
      </div>

      <!-- Introduction Section -->
      <div class="intro-section">
        <div class="intro-content">
          <h2>Trải Nghiệm Đẳng Cấp</h2>
          <p>Tận hưởng kỳ nghỉ của bạn trong không gian sang trọng và đẳng cấp tại Palace Long Hai Resort. Chúng tôi mang đến cho bạn ba lựa chọn phòng độc đáo, mỗi loại đều được thiết kế tỉ mỉ để đáp ứng nhu cầu của những vị khách khó tính nhất.</p>
        </div>
      </div>

      <!-- Room Types Section -->
      <div class="room-types-section">
        <!-- Deluxe Room -->
        <div class="room-card" @mouseover="activeRoom = 'deluxe'" @mouseleave="activeRoom = null">
          <div class="room-image">
            <img src="https://i.pinimg.com/736x/38/27/b4/3827b4f58756dff744206adcdc6bb118.jpg" alt="Deluxe Room">
            <div class="image-overlay"></div>
            <div class="room-price" :class="{ 'price-active': activeRoom === 'deluxe' }">
              <span>Từ</span>
              <h3>2,500,000 VND</h3>
              <span>/đêm</span>
            </div>
          </div>
          <div class="room-info">
            <div class="room-header">
              <h2>Phòng Deluxe</h2>
              <div class="rating">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <span>(4.5/5)</span>
              </div>
            </div>
            <div class="room-features">
              <div class="feature">
                <i class="fas fa-bed"></i>
                <span>1 Giường đôi</span>
              </div>
              <div class="feature">
                <i class="fas fa-user-friends"></i>
                <span>2 Người</span>
              </div>
              <div class="feature">
                <i class="fas fa-vector-square"></i>
                <span>35m²</span>
              </div>
            </div>
            <p class="room-description">
              Phòng Deluxe với thiết kế hiện đại, view đẹp, đầy đủ tiện nghi cao cấp, phù hợp cho cặp đôi hoặc gia đình nhỏ.
            </p>
            <div class="room-amenities">
              <span><i class="fas fa-wifi"></i> Wifi miễn phí</span>
              <span><i class="fas fa-snowflake"></i> Điều hòa</span>
              <span><i class="fas fa-tv"></i> TV màn hình phẳng</span>
              <span><i class="fas fa-coffee"></i> Mini bar</span>
            </div>
            <div class="action-buttons">
              <button class="view-details-btn" @click="viewDetails('deluxe')">Xem Chi Tiết</button>
              <button class="book-now-btn" @click="bookRoom('deluxe')">Đặt Ngay</button>
            </div>
          </div>
        </div>

        <!-- Suite Room -->
        <div class="room-card" @mouseover="activeRoom = 'suite'" @mouseleave="activeRoom = null">
          <div class="room-image">
            <img src="https://i.pinimg.com/736x/2b/0e/12/2b0e123b86c4b2448a4c52b6111cc5a4.jpg" alt="Suite Room">
            <div class="image-overlay"></div>
            <div class="room-price" :class="{ 'price-active': activeRoom === 'suite' }">
              <span>Từ</span>
              <h3>3,500,000 VND</h3>
              <span>/đêm</span>
            </div>
            <div class="room-badge">BEST SELLER</div>
          </div>
          <div class="room-info">
            <div class="room-header">
              <h2>Phòng Suite</h2>
              <div class="rating">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <span>(4.8/5)</span>
              </div>
            </div>
            <div class="room-features">
              <div class="feature">
                <i class="fas fa-bed"></i>
                <span>1 Giường đôi + 1 Giường đơn</span>
              </div>
              <div class="feature">
                <i class="fas fa-user-friends"></i>
                <span>3 Người</span>
              </div>
              <div class="feature">
                <i class="fas fa-vector-square"></i>
                <span>50m²</span>
              </div>
            </div>
            <p class="room-description">
              Phòng Suite rộng rãi với phòng khách riêng biệt, ban công view biển, thiết kế sang trọng và đầy đủ tiện nghi cao cấp.
            </p>
            <div class="room-amenities">
              <span><i class="fas fa-wifi"></i> Wifi miễn phí</span>
              <span><i class="fas fa-snowflake"></i> Điều hòa</span>
              <span><i class="fas fa-tv"></i> TV màn hình phẳng</span>
              <span><i class="fas fa-coffee"></i> Mini bar</span>
              <span><i class="fas fa-hot-tub"></i> Bồn tắm</span>
            </div>
            <div class="action-buttons">
              <button class="view-details-btn" @click="viewDetails('suite')">Xem Chi Tiết</button>
              <button class="book-now-btn" @click="bookRoom('suite')">Đặt Ngay</button>
            </div>
          </div>
        </div>

        <!-- Villa -->
        <div class="room-card" @mouseover="activeRoom = 'villa'" @mouseleave="activeRoom = null">
          <div class="room-image">
            <img src="https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg" alt="Villa">
            <div class="image-overlay"></div>
            <div class="room-price" :class="{ 'price-active': activeRoom === 'villa' }">
              <span>Từ</span>
              <h3>5,500,000 VND</h3>
              <span>/đêm</span>
            </div>
            <div class="room-badge luxury">LUXURY</div>
          </div>
          <div class="room-info">
            <div class="room-header">
              <h2>Beach Villa</h2>
              <div class="rating">
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <i class="fas fa-star"></i>
                <span>(5.0/5)</span>
              </div>
            </div>
            <div class="room-features">
              <div class="feature">
                <i class="fas fa-bed"></i>
                <span>2 Giường đôi</span>
              </div>
              <div class="feature">
                <i class="fas fa-user-friends"></i>
                <span>4 Người</span>
              </div>
              <div class="feature">
                <i class="fas fa-vector-square"></i>
                <span>80m²</span>
              </div>
            </div>
            <p class="room-description">
              Villa sang trọng với hồ bơi riêng, view biển tuyệt đẹp, thiết kế độc đáo và đầy đủ tiện nghi cao cấp nhất.
            </p>
            <div class="room-amenities">
              <span><i class="fas fa-wifi"></i> Wifi miễn phí</span>
              <span><i class="fas fa-snowflake"></i> Điều hòa</span>
              <span><i class="fas fa-tv"></i> Smart TV</span>
              <span><i class="fas fa-coffee"></i> Mini bar</span>
              <span><i class="fas fa-hot-tub"></i> Bồn tắm</span>
              <span><i class="fas fa-swimming-pool"></i> Hồ bơi riêng</span>
            </div>
            <div class="action-buttons">
              <button class="view-details-btn" @click="viewDetails('villa')">Xem Chi Tiết</button>
              <button class="book-now-btn" @click="bookRoom('villa')">Đặt Ngay</button>
            </div>
          </div>
        </div>
      </div>

      <!-- Compare Section -->
      <div class="compare-section">
        <h2>So Sánh Các Loại Phòng</h2>
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
                <td>Số người tối đa</td>
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
    bookRoom(roomType) {
      this.$router.push({
        path: '/booking',
        query: { type: roomType }
      });
    },
    viewDetails(roomType) {
      this.$router.push({
        path: `/room-types/${roomType}`,
        query: { type: roomType }
      });
    }
  }
};
</script>

<style scoped>
/* Main Container */
.room-types-container {
  padding-top: 80px; /* Height of the header */
  width: 100%;
  min-height: calc(100vh - 80px); /* Subtract header height */
  background-color: #f8f9fa;
  position: relative;
  z-index: 1;
}

/* Banner Styles */
.banner {
  position: relative;
  height: 500px;
  overflow: hidden;
  margin-top: -80px; /* Offset the header padding */
}

.parallax {
  background-attachment: fixed;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}

.banner img {
  width: 100%;
  height: calc(100% + 80px); /* Add extra height to account for offset */
  object-fit: cover;
  margin-top: -80px; /* Pull image up to fill gap */
}

.banner-overlay {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.4);
}

.banner-content {
  position: absolute;
  top: 55%; /* Adjusted to account for header */
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
  color: white;
  z-index: 2;
}

.banner-content h1 {
  font-size: 4em;
  font-weight: 700;
  margin-bottom: 0.5em;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);
}

.banner-content p {
  font-size: 1.5em;
  text-shadow: 1px 1px 2px rgba(0, 0, 0, 0.5);
}

/* Introduction Section */
.intro-section {
  background: white;
  padding: 60px 20px;
  text-align: center;
  position: relative;
  z-index: 2;
}

.intro-content {
  max-width: 800px;
  margin: 0 auto;
}

.intro-content h2 {
  color: #333;
  font-size: 2.5em;
  margin-bottom: 20px;
}

.intro-content p {
  color: #666;
  font-size: 1.2em;
  line-height: 1.6;
}

/* Room Types Section */
.room-types-section {
  max-width: 1200px;
  margin: 50px auto;
  padding: 0 20px;
}

.room-card {
  background: white;
  border-radius: 20px;
  overflow: hidden;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  display: flex;
  margin-bottom: 40px;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.room-card:hover {
  transform: translateY(-10px);
  box-shadow: 0 15px 40px rgba(0, 0, 0, 0.2);
}

.room-image {
  flex: 1;
  position: relative;
  min-height: 450px;
}

.image-overlay {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: linear-gradient(to bottom, rgba(0,0,0,0) 0%, rgba(0,0,0,0.6) 100%);
  opacity: 0;
  transition: opacity 0.3s ease;
}

.room-card:hover .image-overlay {
  opacity: 1;
}

.room-badge {
  position: absolute;
  top: 20px;
  right: 20px;
  background: #ff6b6b;
  color: white;
  padding: 8px 15px;
  border-radius: 20px;
  font-weight: bold;
  font-size: 0.9em;
  z-index: 2;
}

.room-badge.luxury {
  background: #ffd700;
  color: #333;
}

.room-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}

.rating {
  color: #ffd700;
  font-size: 0.9em;
}

.rating span {
  color: #666;
  margin-left: 5px;
}

.room-features {
  display: flex;
  gap: 30px;
  margin-bottom: 25px;
  flex-wrap: wrap;
}

.feature {
  display: flex;
  align-items: center;
  gap: 10px;
  color: #666;
}

.feature i {
  color: #CDB79E;
  font-size: 1.2em;
}

.room-description {
  color: #666;
  line-height: 1.8;
  margin-bottom: 25px;
  font-size: 1.1em;
}

.room-amenities {
  display: flex;
  flex-wrap: wrap;
  gap: 15px;
  margin-bottom: 25px;
}

.room-amenities span {
  background: #f8f9fa;
  padding: 10px 20px;
  border-radius: 25px;
  font-size: 0.95em;
  color: #666;
  display: flex;
  align-items: center;
  gap: 10px;
  transition: background 0.3s ease;
}

.room-amenities span:hover {
  background: #CDB79E;
  color: white;
}

.room-amenities span:hover i {
  color: white;
}

.room-amenities i {
  color: #CDB79E;
  transition: color 0.3s ease;
}

.action-buttons {
  display: flex;
  gap: 15px;
}

.view-details-btn, .book-now-btn {
  flex: 1;
  padding: 12px 25px;
  border-radius: 25px;
  font-size: 1.1em;
  cursor: pointer;
  transition: all 0.3s ease;
  border: none;
  font-weight: 600;
}

.view-details-btn {
  background: transparent;
  border: 2px solid #CDB79E;
  color: #CDB79E;
}

.view-details-btn:hover {
  background: #CDB79E;
  color: white;
}

.book-now-btn {
  background: #CDB79E;
  color: white;
}

.book-now-btn:hover {
  background: #8B7D6B;
  transform: scale(1.05);
}

/* Compare Section */
.compare-section {
  background: white;
  padding: 60px 20px;
  margin-top: 50px;
  margin-bottom: 50px; /* Add space before footer */
}

.compare-section h2 {
  text-align: center;
  color: #333;
  font-size: 2.5em;
  margin-bottom: 40px;
}

.compare-table {
  max-width: 1000px;
  margin: 0 auto;
  overflow-x: auto;
}

table {
  width: 100%;
  border-collapse: collapse;
  background: white;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
  border-radius: 10px;
  overflow: hidden;
}

th, td {
  padding: 20px;
  text-align: center;
  border-bottom: 1px solid #eee;
}

th {
  background: #CDB79E;
  color: white;
  font-weight: 600;
}

td {
  color: #666;
}

tr:hover {
  background: #f8f9fa;
}

.fa-check {
  color: #2ecc71;
}

.fa-times {
  color: #e74c3c;
}

/* Responsive Design */
@media (max-width: 992px) {
  .room-types-container {
    padding-top: 60px; /* Smaller header height on mobile */
  }

  .room-card {
    flex-direction: column;
  }

  .room-image {
    min-height: 300px;
  }

  .room-features {
    flex-direction: column;
    gap: 15px;
  }

  .action-buttons {
    flex-direction: column;
  }

  .banner {
    height: 400px;
    margin-top: -60px;
  }

  .banner img {
    height: calc(100% + 60px);
    margin-top: -60px;
  }

  .banner-content {
    top: 60%;
  }

  .banner-content h1 {
    font-size: 3em;
  }

  .banner-content p {
    font-size: 1.2em;
  }
}

@media (max-width: 768px) {
  .banner-content h1 {
    font-size: 2.5em;
  }

  .compare-table {
    font-size: 0.9em;
  }

  th, td {
    padding: 15px 10px;
  }
}
</style>
