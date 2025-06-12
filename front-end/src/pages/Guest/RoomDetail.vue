<template>
  <div class="room-detail-container">
    <Header />
    <div class="room-detail-content">
      <h1 class="room-title">Chi Tiết Phòng {{ roomName }}</h1>
      
      <!-- Danh sách các phòng -->
      <div class="room-list">
        <div v-for="room in rooms" :key="room.id" class="room-item">
          <div class="room-image">
            <img :src="room.image" :alt="room.name" />
          </div>
          <div class="room-details">
            <h3>{{ room.name }} - Phòng {{ room.number }}</h3>
            <div class="room-rating">
              <i v-for="n in ratingStars" :key="n" class="fas fa-star"></i>
              <span>({{ rating }}/5)</span>
            </div>
            <p class="room-price">Từ {{ price }} VND/đêm</p>
            <p class="room-status" :class="room.status === 'available' ? 'available' : 'booked'">
              Trạng thái: {{ room.status === 'available' ? 'Còn trống' : 'Đã đặt' }}
            </p>
            <p class="room-desc">{{ description }}</p>
            <h4>Tiện Nghi</h4>
            <ul class="amenities-list">
              <li v-for="amenity in amenities" :key="amenity">{{ amenity }}</li>
            </ul>
            <div class="button-group">
              <button
                class="book-btn"
                @click="bookRoom(room)"
                :disabled="room.status !== 'available'"
              >
                Đặt Phòng Ngay
              </button>
              <button
                class="detail-btn"
                @click="viewExtendedDetails(room)"
              >
                Xem Chi Tiết
              </button>
            </div>
          </div>
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
  name: 'RoomDetail',
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      roomData: {
        standard: {
          name: 'Phòng Standard',
          rating: 4.5,
          price: '100000',
          description: 'Phòng tiêu chuẩn.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Mini bar'],
          rooms: Array.from({ length: 5 }, (_, index) => ({
            id: `standard-D${101 + index}`,
            number: `D${101 + index}`,
            name: 'phòng standard',
            image: 'https://i.pinimg.com/736x/38/27/b4/3827b4f58756dff744206adcdc6bb118.jpg',
            status: 'available',
          })),
        },
        superior: {
          name: 'Phòng Superior',
          rating: 4.8,
          price: '150000',
          description: 'Phòng nâng cao.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Mini bar'],
          rooms: Array.from({ length: 5 }, (_, index) => ({
            id: `superior-S${201 + index}`,
            number: `S${201 + index}`,
            name: 'phòng superior',
            image: 'https://i.pinimg.com/736x/2b/0e/12/2b0e123b86c4b2448a4c52b6111cc5a4.jpg',
            status: 'available',
          })),
        },
        deluxe: {
          name: 'Phòng Deluxe',
          rating: 5.0,
          price: '200000',
          description: 'Phòng sang trọng.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Hồ bơi riêng', 'Mini bar'],
          rooms: Array.from({ length: 5 }, (_, index) => ({
            id: `deluxe-D${301 + index}`,
            number: `D${301 + index}`,
            name: 'phòng deluxe',
            image: 'https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg',
            status: 'available',
          })),
        },
        suite: {
          name: 'Phòng Suite',
          rating: 5.0,
          price: '500000',
          description: 'Phòng thượng hạng.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Hồ bơi riêng', 'Mini bar'],
          rooms: Array.from({ length: 5 }, (_, index) => ({
            id: `suite-S${401 + index}`,
            number: `S${401 + index}`,
            name: 'phòng suite',
            image: 'https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg',
            status: 'available',
          })),
        },
      },
    };
  },
  computed: {
    roomType() {
      // Ưu tiên lấy đúng key, nếu không thì trả về 'standard' mặc định
      const type = this.$route.query.type;
      if (type && this.roomData[type]) return type;
      return 'standard';
    },
    roomName() {
      return this.roomData[this.roomType]?.name || 'Không xác định';
    },
    rating() {
      return this.roomData[this.roomType]?.rating || 0;
    },
    ratingStars() {
      return Math.floor(this.rating); // Số sao hiển thị
    },
    price() {
      return this.roomData[this.roomType]?.price || '0';
    },
    description() {
      return this.roomData[this.roomType]?.description || 'Không có mô tả.';
    },
    amenities() {
      return this.roomData[this.roomType]?.amenities || [];
    },
    rooms() {
      return this.roomData[this.roomType]?.rooms || [];
    },
  },
  methods: {
    bookRoom(room) {
      if (room.status === 'available') {
        // Điều hướng đến trang đặt phòng với thông tin phòng
        this.$router.push({
          path: '/booking',
          query: { roomId: room.id, type: this.roomType },
        });
      }
    },
    viewExtendedDetails(room) {
      this.$router.push({
        path: `/room-types/${this.roomType}/extended/${room.id}`,
        query: { roomId: room.id, type: this.roomType },
      });
    },
  },
};
</script>

<style scoped>
.room-detail-container {
  width: 100%;
  background-color: #f5f1e9;
  font-family: 'Roboto', sans-serif;
  color: #1e3a5f;
}

.room-detail-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 40px 20px;
}

.room-title {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  text-align: center;
  margin-bottom: 2rem;
}

.room-list {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(500px, 1fr));
  gap: 25px; /* Giảm khoảng cách giữa các phòng */
}

.room-item {
  display: flex;
  background: #fff;
  border-radius: 15px;
  padding: 15px; /* Giảm padding để giao diện gọn hơn */
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

.room-image {
  flex: 1;
  height: 220px; /* Giảm chiều cao ảnh để cân đối */
  overflow: hidden;
  border-radius: 10px;
}

.room-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.room-details {
  flex: 1;
  padding: 15px; /* Giảm padding để giao diện gọn hơn */
}

.room-details h3 {
  font-family: 'Playfair Display', serif;
  font-size: 1.4rem; /* Giảm font-size để cân đối */
  margin-bottom: 0.4rem;
}

.room-rating {
  color: #c9a66b;
  font-size: 0.9rem; /* Giảm font-size */
  margin-bottom: 0.4rem;
}

.room-rating span {
  color: #4b5d67;
  margin-left: 5px;
}

.room-price {
  font-size: 1.1rem; /* Giảm font-size */
  margin-bottom: 0.4rem;
}

.room-status {
  font-size: 0.9rem; /* Giảm font-size */
  margin-bottom: 0.4rem;
}

.room-status.available {
  color: #2ecc71;
}

.room-status.booked {
  color: #e74c3c;
}

.room-desc {
  font-size: 0.9rem; /* Giảm font-size */
  color: #4b5d67;
  margin-bottom: 0.8rem;
}

.room-details h4 {
  font-size: 1.1rem; /* Giảm font-size */
  margin-bottom: 0.4rem;
}

.amenities-list {
  list-style: none;
  margin-bottom: 0.8rem;
}

.amenities-list li {
  font-size: 0.9rem; /* Giảm font-size */
  color: #4b5d67;
  margin-bottom: 0.4rem;
  display: flex;
  align-items: center;
  gap: 8px;
}

.amenities-list li::before {
  content: '✔';
  color: #2ecc71;
}

.button-group {
  display: flex;
  gap: 10px; /* Giảm khoảng cách giữa các nút */
  margin-top: 0.8rem;
}

.book-btn, .detail-btn {
  background-color: #c9a66b;
  color: #fff;
  padding: 8px 18px; /* Giảm padding để nút nhỏ hơn */
  border: none;
  border-radius: 20px; /* Giảm border-radius để phù hợp với kích thước nhỏ hơn */
  font-size: 0.9rem; /* Giảm font-size */
  cursor: pointer;
  transition: background-color 0.3s ease;
  flex: 1; /* Đảm bảo các nút chia đều không gian */
  text-align: center;
}

.book-btn:hover, .detail-btn:hover {
  background-color: #a87c3a;
}

.book-btn:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}

@media (max-width: 768px) {
  .room-list {
    grid-template-columns: 1fr;
  }

  .room-item {
    flex-direction: column;
  }

  .room-image {
    height: 180px; /* Giảm chiều cao ảnh trên màn hình nhỏ */
  }

  .room-title {
    font-size: 2rem;
  }

  .room-details h3 {
    font-size: 1.2rem; /* Giảm font-size */
  }

  .button-group {
    flex-direction: column;
    gap: 8px; /* Giảm khoảng cách giữa các nút */
  }

  .book-btn, .detail-btn {
    width: 100%;
    padding: 8px; /* Đảm bảo padding hợp lý trên màn hình nhỏ */
  }
}
</style>