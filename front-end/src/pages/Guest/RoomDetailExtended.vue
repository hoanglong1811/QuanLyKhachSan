<template>
  <div class="room-detail">
    <div class="container">
      <button class="back-btn" @click="goBack">← Quay Lại</button>
      <div class="detail-content">
        <div class="detail-info">
          <h2>{{ room.name }} - Phòng {{ room.number }}</h2>
          <p class="description">"{{ room.description }}"</p>
          <div class="room-intro">
            <h3>Giới Thiệu Phòng</h3>
            <p class="intro-text">
              Trải nghiệm sự sang trọng và thoải mái tại {{ room.name }}. Với thiết kế tinh tế và tiện nghi hiện đại, căn phòng này mang đến không gian lý tưởng cho kỳ nghỉ của bạn. 
              <strong>Điểm đánh giá:</strong> {{ room.rating }} <span class="star-icon">★</span> | 
              <strong>Giá:</strong> {{ room.price }} VNĐ/đêm
            </p>
          </div>
          <h3>Thông Tin</h3>
          <div class="info-list">
            <p><span class="icon">📏</span> Diện tích: {{ room.area }} m²</p>
            <p><span class="icon">👥</span> Sức chứa: {{ room.maxGuests }} người</p>
            <p><span class="icon">🛏️</span> Loại giường: {{ room.bedType }}</p>
            <p><span class="icon">🌳</span> Hướng nhìn: {{ room.view }}</p>
          </div>
          <div class="main-images">
            <div class="carousel">
              <img
                v-if="room.images && room.images[currentImageIndex]"
                :src="room.images[currentImageIndex]"
                :alt="`${room.name} - Hình ${currentImageIndex + 1}`"
              />
              <div v-else class="no-image">Không có hình ảnh</div>
              <button class="carousel-btn prev" @click="prevImage">❮</button>
              <button class="carousel-btn next" @click="nextImage">❯</button>
            </div>
            <div class="carousel-dots">
              <span
                v-for="(image, index) in room.images"
                :key="index"
                :class="{ active: index === currentImageIndex }"
                @click="setImage(index)"
              ></span>
            </div>
          </div>
          <div class="sub-images">
            <div class="sub-image" v-for="(image, index) in room.images" :key="index">
              <img :src="image" :alt="`${room.name} - Hình ${index + 1}`" />
            </div>
          </div>
          <div class="tabs">
            <button
              :class="{ active: activeTab === 'services' }"
              @click="activeTab = 'services'"
            >
              Dịch Vụ
            </button>
            <button
              :class="{ active: activeTab === 'regulations' }"
              @click="activeTab = 'regulations'"
            >
              Quy Định
            </button>
          </div>
          <div class="tab-content" v-if="activeTab === 'services'">
            <div class="amenities">
              <div class="amenity" v-for="(amenity, index) in room.amenities" :key="index">
                <span class="amenity-icon">{{ getAmenityIcon(amenity) }}</span>
                {{ amenity }}
              </div>
            </div>
          </div>
          <div class="tab-content" v-if="activeTab === 'regulations'">
            <ul class="policy-list">
              <li v-for="(rule, index) in room.policy" :key="index">{{ rule }}</li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <Header />
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
      activeTab: 'services',
      currentImageIndex: 0,
      roomData: {
        deluxe: {
          name: 'Phòng Deluxe',
          rating: 4.5,
          price: '2,500,000',
          description: 'Thiết kế hiện đại, view đẹp, lý tưởng cho cặp đôi.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Mini bar', 'Máy pha cà phê', 'Két an toàn'],
          policy: [
            'Hủy miễn phí trước 48 giờ, không hoàn tiền nếu hủy muộn.',
            'Thời gian nhận phòng: 14:00, trả phòng: 12:00.',
            'Không hút thuốc trong phòng.',
            'Phụ thu cho thú cưng: 500,000 VNĐ/đêm (phải báo trước).',
            'Không chịu trách nhiệm về mất mát tài sản cá nhân.',
          ],
          rooms: Array.from({ length: 18 }, (_, index) => ({
            id: `deluxe-D${101 + index}`,
            number: `D${101 + index}`,
            name: 'Phòng Deluxe',
            images: [
              'https://palacelonghairesort.vn/wp-content/uploads/2024/08/DSC07689_2-small.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2025/05/DSC05174.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2025/05/DSC05159.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2023/04/IMG_2015_2-1024x683-1.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2024/08/STANDARD-GARDEN-FAMILY_22-small.jpg',
            ],
            status: 'available',
            area: 35,
            maxGuests: 2,
            bedType: '1 giường đôi',
            view: 'Hướng vườn',
            rating: 4.5,
            price: '2,500,000',
            description: 'Thiết kế hiện đại, view đẹp, lý tưởng cho cặp đôi.',
            amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Mini bar', 'Máy pha cà phê', 'Két an toàn'],
            policy: [
              'Hủy miễn phí trước 48 giờ, không hoàn tiền nếu hủy muộn.',
              'Thời gian nhận phòng: 14:00, trả phòng: 12:00.',
              'Không hút thuốc trong phòng.',
              'Phụ thu cho thú cưng: 500,000 VNĐ/đêm (phải báo trước).',
              'Không chịu trách nhiệm về mất mát tài sản cá nhân.',
            ],
          })),
        },
        suite: {
          name: 'Phòng Suite',
          rating: 4.8,
          price: '3,500,000',
          description: 'Rộng rãi, view biển, tiện nghi cao cấp.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Mini bar', 'Máy pha cà phê', 'Két an toàn', 'Ban công riêng'],
          policy: [
            'Hủy miễn phí trước 48 giờ, không hoàn tiền nếu hủy muộn.',
            'Thời gian nhận phòng: 14:00, trả phòng: 12:00.',
            'Không hút thuốc trong phòng.',
            'Phụ thu cho thú cưng: 500,000 VNĐ/đêm (phải báo trước).',
            'Không chịu trách nhiệm về mất mát tài sản cá nhân.',
          ],
          rooms: Array.from({ length: 18 }, (_, index) => ({
            id: `suite-S${201 + index}`,
            number: `S${201 + index}`,
            name: 'Phòng Suite',
            images: [
              'https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC01469-small-1.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC01457-small.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC01455-small.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2024/08/STANDARD-GARDEN-FAMILY_04-small.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2024/08/STANDARD-GARDEN-FAMILY_02-small.jpg',
            ],
            status: 'available',
            area: 50,
            maxGuests: 3,
            bedType: '1 giường đôi lớn',
            view: 'Hướng biển một phần',
            rating: 4.8,
            price: '3,500,000',
            description: 'Rộng rãi, view biển, tiện nghi cao cấp.',
            amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Mini bar', 'Máy pha cà phê', 'Két an toàn', 'Ban công riêng'],
            policy: [
              'Hủy miễn phí trước 48 giờ, không hoàn tiền nếu hủy muộn.',
              'Thời gian nhận phòng: 14:00, trả phòng: 12:00.',
              'Không hút thuốc trong phòng.',
              'Phụ thu cho thú cưng: 500,000 VNĐ/đêm (phải báo trước).',
              'Không chịu trách nhiệm về mất mát tài sản cá nhân.',
            ],
          })),
        },
        villa: {
          name: 'Beach Villa',
          rating: 5.0,
          price: '5,500,000',
          description: 'Hồ bơi riêng, view biển tuyệt đẹp.',
          amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Hồ bơi riêng', 'Mini bar', 'Máy pha cà phê', 'Két an toàn', 'Ban công riêng', 'Khu vực ăn uống'],
          policy: [
            'Hủy miễn phí trước 48 giờ, không hoàn tiền nếu hủy muộn.',
            'Thời gian nhận phòng: 14:00, trả phòng: 12:00.',
            'Không hút thuốc trong phòng.',
            'Phụ thu cho thú cưng: 500,000 VNĐ/đêm (phải báo trước).',
            'Không chịu trách nhiệm về mất mát tài sản cá nhân.',
          ],
          rooms: Array.from({ length: 18 }, (_, index) => ({
            id: `villa-V${301 + index}`,
            number: `V${301 + index}`,
            name: 'Beach Villa',
            images: [
              'https://palacelonghairesort.vn/wp-content/uploads/2024/08/DSC07187_2-small.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2025/05/DSC05166.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2025/05/DSC05127.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2025/05/DSC05103.jpg',
              'https://palacelonghairesort.vn/wp-content/uploads/2025/05/DSC05379.jpg',
            ],
            status: 'available',
            area: 80,
            maxGuests: 4,
            bedType: '2 giường đôi',
            view: 'Hướng biển toàn cảnh',
            rating: 5.0,
            price: '5,500,000',
            description: 'Hồ bơi riêng, view biển tuyệt đẹp.',
            amenities: ['Wifi miễn phí', 'Điều hòa', 'Smart TV', 'Bồn tắm', 'Hồ bơi riêng', 'Mini bar', 'Máy pha cà phê', 'Két an toàn', 'Ban công riêng', 'Khu vực ăn uống'],
            policy: [
              'Hủy miễn phí trước 48 giờ, không hoàn tiền nếu hủy muộn.',
              'Thời gian nhận phòng: 14:00, trả phòng: 12:00.',
              'Không hút thuốc trong phòng.',
              'Phụ thu cho thú cưng: 500,000 VNĐ/đêm (phải báo trước).',
              'Không chịu trách nhiệm về mất mát tài sản cá nhân.',
            ],
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
    getAmenityIcon(amenity) {
      const icons = {
        'Wifi miễn phí': '📶',
        'Điều hòa': '❄️',
        'Smart TV': '📺',
        'Mini bar': '🍹',
        'Máy pha cà phê': '☕',
        'Két an toàn': '🔒',
        'Bồn tắm': '🛁',
        'Ban công riêng': '🌅',
        'Hồ bơi riêng': '🏊',
        'Khu vực ăn uống': '🍽️',
      };
      return icons[amenity] || '⚙️';
    },
    prevImage() {
      if (this.room.images && this.room.images.length > 0) {
        this.currentImageIndex =
          (this.currentImageIndex - 1 + this.room.images.length) % this.room.images.length;
      }
    },
    nextImage() {
      if (this.room.images && this.room.images.length > 0) {
        this.currentImageIndex = (this.currentImageIndex + 1) % this.room.images.length;
      }
    },
    setImage(index) {
      this.currentImageIndex = index;
    },
  },
};
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Playfair+Display:wght@400;700&display=swap');

.room-detail {
  padding: 60px 0;
  background-color: #f8f5f0;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
}

.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 20px;
}

.back-btn {
  background: linear-gradient(90deg, #d4b68f, #c0a77a);
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  font-family: 'Playfair Display', serif;
  font-size: 1rem;
  cursor: pointer;
  margin-bottom: 20px;
  transition: all 0.3s ease;
}

.back-btn:hover {
  background: linear-gradient(90deg, #c0a77a, #a88f5f);
  transform: translateY(-2px);
}

.detail-content {
  display: flex;
  flex-direction: column;
}

.detail-info {
  background: white;
  padding: 30px;
  border-radius: 15px;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.05);
}

.detail-info h2 {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  color: #d4b68f;
  margin-bottom: 20px;
  text-transform: uppercase;
  letter-spacing: 1px;
}

.description {
  font-family: 'Playfair Display', serif;
  font-size: 1.2rem;
  color: #666;
  line-height: 1.8;
  margin-bottom: 20px;
  font-style: italic;
}

.room-intro {
  background: #f9f9f9;
  padding: 20px;
  border-radius: 10px;
  margin-bottom: 30px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.05);
}

.room-intro h3 {
  font-family: 'Playfair Display', serif;
  font-size: 1.5rem;
  color: #d4b68f;
  margin-bottom: 10px;
  text-transform: uppercase;
  border-bottom: 1px solid #d4b68f;
  padding-bottom: 5px;
}

.intro-text {
  font-family: 'Playfair Display', serif;
  font-size: 1.1rem;
  color: #666;
  line-height: 1.8;
}

.star-icon {
  color: #d4a017;
  font-size: 1.2rem;
}

.detail-info h3 {
  font-family: 'Playfair Display', serif;
  font-size: 1.5rem;
  color: #d4b68f;
  margin-bottom: 15px;
  text-transform: uppercase;
  border-bottom: 1px solid #d4b68f;
  padding-bottom: 5px;
}

.info-list {
  margin-bottom: 30px;
}

.info-list p {
  font-family: 'Playfair Display', serif;
  font-size: 1.1rem;
  color: #666;
  line-height: 1.8;
  margin-bottom: 10px;
  display: flex;
  align-items: center;
  gap: 10px;
}

.info-list .icon {
  font-size: 1.2rem;
}

.main-images {
  margin-bottom: 30px;
  position: relative;
}

.carousel {
  position: relative;
}

.carousel img {
  width: 100%;
  height: 500px;
  object-fit: cover;
  border-radius: 10px;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
}

.no-image {
  width: 100%;
  height: 500px;
  background-color: #e0e0e0;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #666;
  font-size: 1.2rem;
  font-style: italic;
  border-radius: 10px;
}

.carousel-btn {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background: linear-gradient(90deg, rgba(212, 182, 143, 0.8), rgba(212, 182, 143, 0.5));
  color: white;
  border: none;
  padding: 15px;
  cursor: pointer;
  font-size: 1.8rem;
  border-radius: 50%;
  width: 40px;
  height: 40px;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: background 0.3s ease;
}

.carousel-btn:hover {
  background: rgba(212, 182, 143, 1);
}

.carousel-btn.prev {
  left: 20px;
}

.carousel-btn.next {
  right: 20px;
}

.carousel-dots {
  position: absolute;
  bottom: 20px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  gap: 12px;
}

.carousel-dots span {
  width: 12px;
  height: 12px;
  background-color: #ccc;
  border-radius: 50%;
  display: inline-block;
  cursor: pointer;
  transition: background 0.3s ease;
}

.carousel-dots span.active {
  background-color: #d4b68f;
}

.carousel-dots span:hover {
  background-color: #c0a77a;
}

.sub-images {
  display: flex;
  gap: 20px;
  margin-bottom: 30px;
  overflow-x: auto;
}

.sub-image {
  flex: 0 0 auto;
  width: 300px;
}

.sub-image img {
  width: 100%;
  height: 200px;
  object-fit: cover;
  border-radius: 10px;
  box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
}

.tabs {
  display: flex;
  gap: 20px;
  margin-bottom: 20px;
}

.tabs button {
  background: #d4b68f;
  color: white;
  border: none;
  padding: 10px 20px;
  border-radius: 5px;
  font-family: 'Playfair Display', serif;
  font-size: 1.1rem;
  text-transform: uppercase;
  cursor: pointer;
  transition: all 0.3s ease;
}

.tabs button.active {
  background: linear-gradient(90deg, #c0a77a, #a88f5f);
}

.tabs button:hover {
  background: linear-gradient(90deg, #c0a77a, #a88f5f);
}

.tab-content {
  padding: 20px 0;
}

.amenities {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 20px;
}

.amenity {
  display: flex;
  align-items: center;
  gap: 10px;
  font-family: 'Playfair Display', serif;
  font-size: 1rem;
  color: #666;
}

.amenity-icon {
  font-size: 1.2rem;
}

.policy-list {
  list-style: none;
  padding: 0;
}

.policy-list li {
  font-family: 'Playfair Display', serif;
  font-size: 1.1rem;
  color: #666;
  line-height: 1.8;
  margin-bottom: 10px;
}
</style>