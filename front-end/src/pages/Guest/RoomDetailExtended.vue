<template>
  <div class="extended-detail-container">
    <Header />
    <div class="extended-detail-content">
      <h1 class="extended-title">Thông Tin Chi Tiết - {{ room.name }} - Phòng {{ room.number }}</h1>
      
      <div class="extended-info">
        <!-- Carousel hiển thị 5 hình ảnh -->
        <div class="image-carousel">
          <button class="carousel-btn prev-btn" @click="scrollCarousel('prev')">&#10094;</button>
          <div class="carousel-container" ref="carousel">
            <div class="carousel-slide" v-for="(image, index) in room.images" :key="index">
              <img :src="image" :alt="`${room.name} - Hình ${index + 1}`" />
            </div>
          </div>
          <button class="carousel-btn next-btn" @click="scrollCarousel('next')">&#10095;</button>
        </div>
        <div class="extended-details">
          <h3>Thông Tin Cơ Bản</h3>
          <ul class="basic-info-list">
            <li><strong>Diện tích:</strong> {{ room.area }} m²</li>
            <li><strong>Số người tối đa:</strong> {{ room.maxGuests }} người</li>
            <li><strong>Loại giường:</strong> {{ room.bedType }}</li>
            <li><strong>Hướng view:</strong> {{ room.view }}</li>
          </ul>

          <h3>Tiện Nghi</h3>
          <ul class="amenities-list">
            <li v-for="amenity in room.amenities" :key="amenity">{{ amenity }}</li>
          </ul>

          <h3>Thông Tin Thêm</h3>
          <ul class="additional-info-list">
            <li><strong>Chính sách hủy phòng:</strong> Miễn phí hủy trước 48 giờ</li>
            <li><strong>Giờ nhận phòng:</strong> Sau 14:00</li>
            <li><strong>Giờ trả phòng:</strong> Trước 12:00</li>
            <li><strong>Dịch vụ bổ sung:</strong> Bữa sáng miễn phí, dịch vụ dọn phòng hàng ngày</li>
          </ul>

          <button class="back-btn" @click="goBack">Quay Lại</button>
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
  name: 'RoomDetailExtended',
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      room: {},
      roomData: {
        deluxe: {
          name: 'Phòng Deluxe',
          rating: 4.5,
          price: '2,500,000',
          description: 'Thiết kế hiện đại, view đẹp, lý tưởng cho cặp đôi.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Mini bar'],
          rooms: Array.from({ length: 18 }, (_, index) => ({
            id: `deluxe-D${101 + index}`,
            number: `D${101 + index}`,
            name: 'Phòng Deluxe',
            images: [
              'https://i.pinimg.com/736x/38/27/b4/3827b4f58756dff744206adcdc6bb118.jpg',
              'https://i.pinimg.com/736x/5d/3e/4a/5d3e4a1a2b3f4c5d6e7f8a9b0c1d2e3.jpg',
              'https://i.pinimg.com/736x/7f/2e/5b/7f2e5b1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/9a/3c/6d/9a3c6d1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/bc/4e/8f/bc4e8f1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
            ],
            status: 'available',
            area: 35,
            maxGuests: 2,
            bedType: '1 giường đôi',
            view: 'Hướng vườn',
            amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Mini bar', 'Máy pha cà phê', 'Két an toàn'],
          })),
        },
        suite: {
          name: 'Phòng Suite',
          rating: 4.8,
          price: '3,500,000',
          description: 'Rộng rãi, view biển, tiện nghi cao cấp.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Mini bar'],
          rooms: Array.from({ length: 18 }, (_, index) => ({
            id: `suite-S${201 + index}`,
            number: `S${201 + index}`,
            name: 'Phòng Suite',
            images: [
              'https://i.pinimg.com/736x/2b/0e/12/2b0e123b86c4b2448a4c52b6111cc5a4.jpg',
              'https://i.pinimg.com/736x/4d/5f/6a/4d5f6a1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/6e/7h/8i/6e7h8i1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/8f/9i/0j/8f9i0j1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/0a/1b/2c/0a1b2c1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
            ],
            status: 'available',
            area: 50,
            maxGuests: 3,
            bedType: '1 giường đôi lớn',
            view: 'Hướng biển một phần',
            amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Mini bar', 'Máy pha cà phê', 'Két an toàn', 'Ban công riêng'],
          })),
        },
        villa: {
          name: 'Beach Villa',
          rating: 5.0,
          price: '5,500,000',
          description: 'Hồ bơi riêng, view biển tuyệt đẹp.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Hồ bơi riêng', 'Mini bar'],
          rooms: Array.from({ length: 18 }, (_, index) => ({
            id: `villa-V${301 + index}`,
            number: `V${301 + index}`,
            name: 'Beach Villa',
            images: [
              'https://i.pinimg.com/736x/f5/46/03/f54603d14ea4377ad3e6c15e1fa3fa24.jpg',
              'https://i.pinimg.com/736x/2c/3d/4e/2c3d4e1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/4f/5g/6h/4f5g6h1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/6i/7j/8k/6i7j8k1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
              'https://i.pinimg.com/736x/8l/9m/0n/8l9m0n1a2b3c4d5e6f7g8h9i0j1k2l3.jpg',
            ],
            status: 'available',
            area: 80,
            maxGuests: 4,
            bedType: '2 giường đôi',
            view: 'Hướng biển toàn cảnh',
            amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Hồ bơi riêng', 'Mini bar', 'Máy pha cà phê', 'Két an toàn', 'Ban công riêng', 'Khu vực ăn uống'],
          })),
        },
      },
    };
  },
  created() {
    const roomId = this.$route.query.roomId;
    const type = this.$route.query.type || 'deluxe';
    this.room = this.roomData[type].rooms.find(r => r.id === roomId) || {};
  },
  methods: {
    goBack() {
      this.$router.go(-1);
    },
    scrollCarousel(direction) {
      const carousel = this.$refs.carousel;
      const scrollAmount = carousel.clientWidth; // Cuộn theo chiều rộng của 1 ảnh
      if (direction === 'prev') {
        carousel.scrollBy({ left: -scrollAmount, behavior: 'smooth' });
      } else {
        carousel.scrollBy({ left: scrollAmount, behavior: 'smooth' });
      }
    },
  },
};
</script>

<style scoped>
.extended-detail-container {
  width: 100%;
  background-color: #f5f1e9;
  font-family: 'Roboto', sans-serif;
  color: #1e3a5f;
}

.extended-detail-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 40px 20px;
}

.extended-title {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  text-align: center;
  margin-bottom: 2rem;
}

.extended-info {
  display: flex;
  gap: 30px;
  background: #fff;
  border-radius: 15px;
  padding: 20px;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

.image-carousel {
  flex: 1;
  height: 300px;
  position: relative;
  border-radius: 10px;
  overflow: hidden;
}

.carousel-container {
  display: flex;
  height: 100%;
  overflow-x: auto;
  scroll-behavior: smooth;
  -webkit-overflow-scrolling: touch;
}

.carousel Misses .carousel-container::-webkit-scrollbar {
  display: none; /* Ẩn thanh cuộn */
}

.carousel-slide {
  flex: 0 0 auto;
  width: 100%;
  height: 100%;
}

.carousel-slide img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  border-radius: 10px;
}

.carousel-btn {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background-color: rgba(0, 0, 0, 0.5);
  color: #fff;
  border: none;
  padding: 10px;
  cursor: pointer;
  font-size: 1.5rem;
  border-radius: 50%;
  transition: background-color 0.3s ease;
}

.carousel-btn:hover {
  background-color: rgba(0, 0, 0, 0.8);
}

.prev-btn {
  left: 10px;
}

.next-btn {
  right: 10px;
}

.extended-details {
  flex: 1;
  padding: 20px;
}

.extended-details h3 {
  font-family: 'Playfair Display', serif;
  font-size: 1.5rem;
  margin-bottom: 0.5rem;
}

.basic-info-list, .amenities-list, .additional-info-list {
  list-style: none;
  margin-bottom: 1rem;
}

.basic-info-list li, .amenities-list li, .additional-info-list li {
  font-size: 1rem;
  color: #4b5d67;
  margin-bottom: 0.5rem;
  display: flex;
  align-items: center;
  gap: 10px;
}

.amenities-list li::before {
  content: '✔';
  color: #2ecc71;
}

.back-btn {
  background-color: #c9a66b;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 25px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.back-btn:hover {
  background-color: #a87c3a;
}

@media (max-width: 768px) {
  .extended-info {
    flex-direction: column;
  }

  .image-carousel {
    height: 200px;
  }

  .extended-title {
    font-size: 2rem;
  }

  .extended-details h3 {
    font-size: 1.3rem;
  }
}
</style>