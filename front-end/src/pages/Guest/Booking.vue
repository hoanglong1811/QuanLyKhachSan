<template>
  <div class="booking-container">
    <Header />
    <div class="booking-content">
      <div class="booking-header">
        <h1>Đặt Phòng Khách Sạn</h1>
        <p>Vui lòng điền thông tin để đặt phòng</p>
      </div>

      <!-- Bước 1: Chọn thời gian và số khách -->
      <div class="booking-step" v-if="currentStep === 1">
        <h2>Thông tin lưu trú</h2>
        <form @submit.prevent="searchRooms">
          <div class="form-group">
            <label for="checkIn">Ngày nhận phòng</label>
            <input 
              type="date" 
              id="checkIn" 
              v-model="bookingData.checkIn"
              :min="minDate"
              required
            >
          </div>

          <div class="form-group">
            <label for="checkOut">Ngày trả phòng</label>
            <input 
              type="date" 
              id="checkOut" 
              v-model="bookingData.checkOut"
              :min="bookingData.checkIn"
              required
            >
          </div>

          <div class="guests-selection">
            <div class="form-group">
              <label for="adults">Số người lớn</label>
              <div class="number-input">
                <button type="button" @click="decreaseGuests('adults')" :disabled="bookingData.adults <= 1">-</button>
                <input 
                  type="number" 
                  id="adults" 
                  v-model="bookingData.adults"
                  min="1"
                  max="4"
                  readonly
                >
                <button type="button" @click="increaseGuests('adults')" :disabled="bookingData.adults >= 4">+</button>
              </div>
            </div>

            <div class="form-group">
              <label for="children">Số trẻ em</label>
              <div class="number-input">
                <button type="button" @click="decreaseGuests('children')" :disabled="bookingData.children <= 0">-</button>
                <input 
                  type="number" 
                  id="children" 
                  v-model="bookingData.children"
                  min="0"
                  max="4"
                  readonly
                >
                <button type="button" @click="increaseGuests('children')" :disabled="bookingData.children >= 4">+</button>
              </div>
            </div>
          </div>

          <button type="submit" class="next-btn">Tìm phòng</button>
        </form>
      </div>

      <!-- Bước 2: Chọn phòng -->
      <div class="booking-step" v-if="currentStep === 2">
        <h2>Chọn phòng</h2>
        <div v-for="roomType in availableRooms" :key="roomType.type" class="room-type-block">
          <div class="room-type-header">
            <img :src="roomType.image" :alt="roomType.name" class="room-type-img" />
            <div>
              <h3>{{ roomType.name }}</h3>
              <div class="room-rating">
                <i v-for="n in Math.floor(roomType.rating)" :key="n" class="fas fa-star"></i>
                <i v-if="roomType.rating % 1 >= 0.5" class="fas fa-star-half-alt"></i>
                <span>({{ roomType.rating }}/5)</span>
              </div>
              <p class="room-price">Từ {{ formatPrice(roomType.price) }} VND/đêm</p>
              <p class="room-desc">{{ roomType.description }}</p>
              <ul class="amenities-list">
                <li v-for="amenity in roomType.amenities" :key="amenity">{{ amenity }}</li>
              </ul>
            </div>
          </div>
          <div class="room-list-grid">
            <div v-for="room in roomType.rooms" :key="room.id" class="room-item-detail">
              <span>Phòng: <b>{{ room.number }}</b></span>
              <span :class="room.status === 'available' ? 'available' : 'booked'">
                {{ room.status === 'available' ? 'Còn trống' : 'Đã đặt' }}
              </span>
              <button
                class="book-btn"
                :disabled="room.status !== 'available'"
                @click="selectRoom({ ...roomType, ...room })"
              >
                Chọn phòng này
              </button>
            </div>
          </div>
        </div>
      </div>

      <!-- Bước 3: Thông tin đặt phòng -->
      <div class="booking-step" v-if="currentStep === 3">
        <h2>Thông tin đặt phòng</h2>
        <form @submit.prevent="handleSubmit">
          <div class="form-group">
            <label for="name">Họ và tên</label>
            <input 
              type="text" 
              id="name" 
              v-model="bookingData.name"
              required
            >
          </div>

          <div class="form-group">
            <label for="email">Email</label>
            <input 
              type="email" 
              id="email" 
              v-model="bookingData.email"
              required
            >
          </div>

          <div class="form-group">
            <label for="phone">Số điện thoại</label>
            <input 
              type="tel" 
              id="phone" 
              v-model="bookingData.phone"
              required
            >
          </div>

          <div class="form-group">
            <label for="cccd">CCCD</label>
            <input 
              type="text" 
              id="cccd" 
              v-model="bookingData.cccd"
              required
            >
          </div>

          <div class="form-group">
            <label for="specialRequests">Yêu cầu</label>
            <textarea 
              id="specialRequests" 
              v-model="bookingData.specialRequests"
              rows="4"
            ></textarea>
          </div>

          <div class="booking-summary">
            <h3>Tổng quan đặt phòng</h3>
            <div class="summary-item">
              <span>Phòng:</span>
              <span>{{ selectedRoom?.name }} - {{ selectedRoom?.number }}</span>
            </div>
            <div class="summary-item">
              <span>Ngày nhận phòng:</span>
              <span>{{ formatDate(bookingData.checkIn) }}</span>
            </div>
            <div class="summary-item">
              <span>Ngày trả phòng:</span>
              <span>{{ formatDate(bookingData.checkOut) }}</span>
            </div>
            <div class="summary-item">
              <span>Số người lớn:</span>
              <span>{{ bookingData.adults }}</span>
            </div>
            <div class="summary-item">
              <span>Số trẻ em:</span>
              <span>{{ bookingData.children }}</span>
            </div>
            <div class="summary-item total">
              <span>Tổng tiền:</span>
              <span>{{ formatPrice(calculateTotalPrice()) }} VND</span>
            </div>
          </div>

          <div class="form-actions">
            <button type="button" @click="currentStep = 2" class="back-btn">Quay lại</button>
            <button type="submit" class="submit-btn" :disabled="loading">Xác nhận đặt phòng</button>
          </div>
        </form>
      </div>
    </div>
    <Footer />
  </div>
</template>

<script>
import Header from '@/components/Header.vue';
import Footer from '@/components/Footer.vue';
import { roomService } from '@/services/roomService';
import { bookingService } from '@/services/bookingService';
import { userService } from '@/services/userService';

export default {
  name: 'GuestBooking',
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      currentStep: 1,
      bookingData: {
        checkIn: '',
        checkOut: '',
        adults: 1,
        children: 0,
        name: '',
        email: '',
        phone: '',
        cccd: '',
        specialRequests: ''
      },
      selectedRoom: null,
      availableRooms: [],
      roomTypesMap: {},
      loading: false,
      error: '',
      MANUAL_ROOM_DATA: {
        standard: {
          image: 'https://static03-cdn.oneinventory.com/images/2025/04/4986bbf14ff54c4eae67f7f35b6d3d6f.jpg',
          price: 100000
        },
        deluxe: {
          image: 'https://static03-cdn.oneinventory.com/images/2024/07/145fe1acd6be4305b1082625865629c7.jpg',
          price: 200000
        },
        superior: {
          image: 'https://static03-cdn.oneinventory.com/images/2025/04/38dcc78100bd46e5a6e9d7e3af2aefbc.jpg',
          price: 150000
        },
        suite: {
          image: 'https://static03-cdn.oneinventory.com/images/2025/05/1aac1f9a1d074b2293aa1498e837cb47.jpg',
          price: 500000
        }
      }
    }
  },
  computed: {
    minDate() {
      const today = new Date()
      return today.toISOString().split('T')[0]
    }
  },
  methods: {
    increaseGuests(type) {
      if (this.bookingData[type] < 4) {
        this.bookingData[type]++
      }
    },
    decreaseGuests(type) {
      if (this.bookingData[type] > (type === 'adults' ? 1 : 0)) {
        this.bookingData[type]--
      }
    },
    async buildAvailableRooms(totalGuests) {
      try {
        const [rooms, roomTypes] = await Promise.all([
          roomService.getAllRooms(),
          roomService.getRoomTypes()
        ]);
        this.roomTypesMap = Object.fromEntries(roomTypes.map(rt => [rt.idLoaiPhong, rt]));
        const filtered = rooms.filter(r => r.trangThai.toLowerCase() === 'trống' && r.sucChua >= totalGuests);
        // group by idLoaiPhong
        const groups = {};
        filtered.forEach(r => {
          if (!groups[r.idLoaiPhong]) groups[r.idLoaiPhong] = [];
          groups[r.idLoaiPhong].push(r);
        });
        this.availableRooms = Object.entries(groups).map(([idLoaiPhong, list]) => {
          const rt = this.roomTypesMap[idLoaiPhong] || {};
          const key = this.normalizeKey(rt.tenLoaiPhong);
          const manual = this.MANUAL_ROOM_DATA[key] || {};
          const price = manual.price ?? rt.giaPhong ?? 0;
          const image = manual.image ?? rt.hinhAnh ?? 'https://via.placeholder.com/180x120';
          return {
            name: rt.tenLoaiPhong || `Loại phòng ${idLoaiPhong}`,
            type: idLoaiPhong,
            image,
            price,
            rating: 4.5,
            description: rt.moTa || '',
            amenities: [],
            rooms: list.map(r => ({ id: r.idPhong, number: r.soPhong, status: 'available', price }))
          };
        });
      } catch (err) {
        console.error('Error fetching rooms:', err);
        alert('Không thể tải danh sách phòng, vui lòng thử lại sau.');
      }
    },
    searchRooms() {
      // Validate dates
      if (!this.bookingData.checkIn || !this.bookingData.checkOut) {
        alert('Vui lòng chọn ngày nhận phòng và trả phòng');
        return;
      }

      const checkIn = new Date(this.bookingData.checkIn);
      const checkOut = new Date(this.bookingData.checkOut);
      if (checkOut <= checkIn) {
        alert('Ngày trả phòng phải sau ngày nhận phòng');
        return;
      }

      const totalGuests = this.bookingData.adults + this.bookingData.children;
      if (totalGuests > 4) {
        alert('Tổng số khách không được vượt quá 4 người');
        return;
      }

      // Fetch real rooms
      this.buildAvailableRooms(totalGuests).then(() => {
        if (this.availableRooms.length === 0) {
          alert('Không còn phòng trống phù hợp.');
          return;
        }
        this.currentStep = 2;
      });
    },
    selectRoom(room) {
      this.selectedRoom = room;
      this.currentStep = 3;
    },
    formatPrice(price) {
      return new Intl.NumberFormat('vi-VN').format(price)
    },
    formatDate(date) {
      return new Date(date).toLocaleDateString('vi-VN')
    },
    calculateTotalPrice() {
      if (!this.selectedRoom || !this.bookingData.checkIn || !this.bookingData.checkOut) return 0
      const nights = Math.ceil((new Date(this.bookingData.checkOut) - new Date(this.bookingData.checkIn)) / (1000 * 60 * 60 * 24))
      let pricePerNight = this.selectedRoom?.price;
      if (!pricePerNight) {
        const key = this.normalizeKey(this.roomTypesMap[this.selectedRoom?.type]?.tenLoaiPhong);
        pricePerNight = this.MANUAL_ROOM_DATA[key]?.price ?? this.roomTypesMap[this.selectedRoom?.type]?.giaPhong ?? 0;
      }
      return pricePerNight * nights;
    },
    async handleSubmit() {
      if (!this.selectedRoom) {
        alert('Vui lòng chọn phòng');
        return;
      }
      this.loading = true;
      try {
        // B1: tìm hoặc tạo khách hàng
        let customers = await userService.searchCustomersByPhone(this.bookingData.phone);
        let customerId = null;
        if (customers && customers.length) {
          customerId = customers[0].idKhachHang || customers[0].IdKhachHang;
        } else {
          const newCust = await userService.createCustomer({
            hoTen: this.bookingData.name,
            dienThoai: parseInt(this.bookingData.phone, 10),
            cccd: this.bookingData.cccd
          });
          customerId = newCust.idKhachHang || newCust.IdKhachHang;
        }

        // B2: tạo DatPhong
        const booking = await bookingService.createBooking({ idKhachHang: customerId });
        const bookingId = booking.idDatPhong || booking.IdDatPhong;

        // B3: tạo ChiTietDatPhong
        const totalGuests = this.bookingData.adults + this.bookingData.children;
        await bookingService.createBookingDetail({
          idPhong: this.selectedRoom.id,
          idDatPhong: bookingId,
          idKhachHang: customerId,
          ngayDatPhong: this.bookingData.checkIn,
          ngayTraPhong: this.bookingData.checkOut,
          soLuongNguoi: totalGuests,
          phuongThucThanhToan: JSON.stringify({ note: this.bookingData.specialRequests, adults: this.bookingData.adults, children: this.bookingData.children }),
          thanhTien: this.calculateTotalPrice()
        });

        // B4: cập nhật trạng thái phòng
        await roomService.updateRoom(this.selectedRoom.id, {
          trangThai: 'Đã đặt',
          sucChua: totalGuests,
          soPhong: this.selectedRoom.number,
          idLoaiPhong: this.selectedRoom.type
        });

        alert('Đặt phòng thành công!');
        this.$router.push('/');
      } catch (err) {
        console.error('Booking error:', err);
        alert('Đặt phòng thất bại, vui lòng thử lại sau.');
      } finally {
        this.loading = false;
      }
    },
    normalizeKey(str) {
      return str?.toString().trim().toLowerCase() || '';
    }
  }
}
</script>

<style scoped>
.booking-container {
  width: 100%;
  background-color: #f5f1e9;
  font-family: 'Roboto', sans-serif;
  color: #1e3a5f;
}

.booking-content {
  max-width: 1200px;
  margin: 0 auto;
  padding: 40px 20px;
}

.booking-header {
  text-align: center;
  margin-bottom: 2rem;
}

.booking-header h1 {
  font-family: 'Playfair Display', serif;
  font-size: 2.5rem;
  margin-bottom: 0.5rem;
}

.booking-header p {
  color: #4b5d67;
}

.booking-step {
  background: #fff;
  border-radius: 15px;
  padding: 30px;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  margin-bottom: 2rem;
}

.booking-step h2 {
  font-family: 'Playfair Display', serif;
  font-size: 1.8rem;
  margin-bottom: 1.5rem;
  color: #1e3a5f;
}

.form-group {
  margin-bottom: 1.5rem;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  color: #1e3a5f;
  font-weight: 500;
}

input,
select,
textarea {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 8px;
  font-size: 1rem;
  color: #1e3a5f;
}

input:focus,
select:focus,
textarea:focus {
  outline: none;
  border-color: #c9a66b;
  box-shadow: 0 0 0 2px rgba(201, 166, 107, 0.2);
}

.guests-selection {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1rem;
}

.number-input {
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.number-input button {
  width: 40px;
  height: 40px;
  border: 1px solid #ddd;
  background: #f5f1e9;
  border-radius: 8px;
  cursor: pointer;
  color: #1e3a5f;
  font-size: 1.2rem;
  transition: all 0.3s ease;
}

.number-input button:hover:not(:disabled) {
  background: #c9a66b;
  color: #fff;
}

.number-input button:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.number-input input {
  width: 60px;
  text-align: center;
}

.room-type-block {
  margin-bottom: 2.5rem;
  background: #fff;
  border-radius: 15px;
  box-shadow: 0 4px 15px rgba(0,0,0,0.07);
  padding: 1.5rem;
}
.room-type-header {
  display: flex;
  gap: 2rem;
  align-items: center;
  margin-bottom: 1rem;
}
.room-type-img {
  width: 180px;
  height: 120px;
  object-fit: cover;
  border-radius: 10px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.08);
}
.room-list-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
  gap: 1rem;
}
.room-item-detail {
  background: #f5f1e9;
  border-radius: 8px;
  padding: 1rem;
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  gap: 0.5rem;
  box-shadow: 0 2px 6px rgba(0,0,0,0.04);
}
.room-item-detail .available {
  color: #2ecc71;
  font-weight: 600;
}
.room-item-detail .booked {
  color: #e74c3c;
  font-weight: 600;
}
.room-item-detail .book-btn {
  margin-top: 0.5rem;
  width: 100%;
  padding: 0.5rem 0;
}

.book-btn,
.next-btn,
.submit-btn {
  width: 100%;
  padding: 1rem;
  background-color: #c9a66b;
  color: white;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.book-btn:hover,
.next-btn:hover,
.submit-btn:hover {
  background-color: #b38d4f;
}

.back-btn {
  width: 100%;
  padding: 1rem;
  background-color: #f5f1e9;
  color: #1e3a5f;
  border: 1px solid #c9a66b;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
}

.back-btn:hover {
  background-color: #e8e0d0;
}

.booking-summary {
  background-color: #f5f1e9;
  padding: 1.5rem;
  border-radius: 8px;
  margin: 2rem 0;
}

.booking-summary h3 {
  font-family: 'Playfair Display', serif;
  font-size: 1.4rem;
  margin-bottom: 1rem;
  color: #1e3a5f;
}

.summary-item {
  display: flex;
  justify-content: space-between;
  margin-bottom: 0.5rem;
  color: #4b5d67;
}

.summary-item.total {
  margin-top: 1rem;
  padding-top: 1rem;
  border-top: 1px solid #ddd;
  font-weight: 600;
  color: #1e3a5f;
}

.form-actions {
  display: flex;
  gap: 1rem;
  margin-top: 2rem;
}

@media (max-width: 768px) {
  .booking-content {
    padding: 20px 10px;
  }

  .booking-step {
    padding: 20px;
  }

  .guests-selection {
    grid-template-columns: 1fr;
  }

  .room-list {
    grid-template-columns: 1fr;
  }

  .room-item {
    flex-direction: column;
  }

  .room-image {
    height: 200px;
  }

  .form-actions {
    flex-direction: column;
  }

  .back-btn,
  .next-btn,
  .submit-btn {
    width: 100%;
  }
}
</style> 