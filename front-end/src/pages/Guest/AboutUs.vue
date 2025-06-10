<template>
  <div class="about-us">
    <!-- Main Image with Header -->
    <div class="main-image">
      <img src="https://i.pinimg.com/736x/83/ff/cf/83ffcf75c3156cffd5bad60e9925a788.jpg" alt="About Us Image">
      <div class="image-text">
        <h1>Chào mừng đến với</h1>
        <h1>Place Long Hai</h1>
        <p>Sự hài lòng của bạn là hạnh phúc của chúng tôi</p>
      </div>
    </div>

    <!-- Sử dụng Header component -->
    <Header />

    <!-- Section 1: Image and Text Split -->
    <div class="split-section">
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>CHẤT LƯỢNG DỊCH VỤ 4 SAO</h3>
        <p>Bằng sự chuyên nghiệp và tận tâm của đội ngũ nhân viên cùng nhiều lợi thế nổi bật, Palace Long Hai Resort nhanh chóng trở thành điểm đến nghỉ dưỡng yêu thích của đông đảo du khách.</p>
      </div>
      <div class="image-content">
        <img src="https://i.pinimg.com/736x/43/17/9f/43179f8785c5c0deed6605f71389f301.jpg" alt="Service Quality Image">
      </div>
    </div>

    <!-- Section 3: Image and Text Split -->
    <div class="split-section">
      <div class="image-content">
        <img src="https://cf.bstatic.com/xdata/images/hotel/max1024x768/498977541.jpg?k=39564d6c4a0c2f5b49d512f4ba0b94b258448dcef50c0772f009bc33c683c2c7&o=&hp=1" alt="Service Quality Image">
      </div>
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>62 Bungalow với 75 phòng</h3>
        <p>Được thiết kế độc đáo và riêng tư, đa dạng hạng phòng diện tích 30m2 - 150m2. Đặc biệt, tất cả các phòng ngủ đều sở hữu view hướng biển hoặc hướng vườn xanh mướt.</p>
      </div>
      
    </div>


     <div class="split-section">
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>Giải thưởng "Sản phẩm – Dịch vụ chất lượng ASEAN 2024"</h3>
        <p>tại ASEAN Strong Brands Award 2024 (Singapore) là bảo chứng cho chất lượng vượt trội của Palace Long Hai Resort, xứng đáng là lựa chọn hàng đầu của du khách.</p>
      </div>
      <div class="image-content">
        <img src="https://apnews.vn/wp-content/uploads/2025/04/top-5-thuong-hieu-manh-asean-1366x910.jpg" alt="Service Quality Image">
      </div>
    </div>    
  
    <div class="split-section">
      <div class="image-content">
        <img src="https://i.pinimg.com/736x/fa/13/fe/fa13fe9f3b125e63c072aed58164c544.jpg" alt="Service Quality Image">
      </div>
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>Vừa riêng tư, vừa sôi động</h3>
        <p>Không gian nghỉ dưỡng với các bungalow tách biệt đảm bảo tính riêng tư nhưng cũng không kém phần sôi động với nhiều dịch vụ giải trí hấp dẫn</p>
      </div>
    </div>

    <div class="split-section">
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>An ninh đảm bảo</h3>
        <p>Không chỉ được bảo vệ 24/24, Palace Long Hai Resort còn có bãi biển riêng với các nhân viên cứu hộ chuyên nghiệp và dày dặn kinh nghiệm.</p>
      </div>
      <div class="image-content">
        <img src="https://i.pinimg.com/736x/5d/a3/e0/5da3e013774ae1bbad33f3930ea69971.jpg" alt="Service Quality Image">
      </div>
    </div> 
    
    <div class="split-section">
      <div class="image-content">
        <img src="https://i.pinimg.com/736x/9f/a2/da/9fa2da95208b9a8fe5037608455b478c.jpg" alt="Service Quality Image">
      </div>
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>Nhiều khuyến mãi hấp dẫn</h3>
        <p>Thường xuyên có các chương trình ưu đãi cho nhóm gia đình, khách lẻ, khách hàng thân thiết, khách trải nghiệm trong ngày và hội nghị, tiệc cưới…</p>
      </div>
    </div>

    <!-- New Section: Service Highlights -->
    <div class="main-content">
      <h2>Các điểm nổi bật của chúng tôi</h2>
      <div class="service-grid">
        <div class="service-item">
          <img src="https://i.pinimg.com/736x/08/9d/94/089d94bf9610318138e58402f01e4c5c.jpg" alt="Green Place">
          <div class="service-overlay">
            <h3>Không gian xanh</h3>
            <p>Môi trường thanh bình với cây xanh và không khí trong lành</p>
          </div>
        </div>
        <div class="service-item">
          <img src="https://i.pinimg.com/736x/49/b7/f2/49b7f2e9745a66cef581c4d03c4d7e88.jpg" alt="Service Heart">
          <div class="service-overlay">
            <h3>Dịch vụ tận tâm</h3>
            <p>Đội ngũ nhân viên chuyên nghiệp, sẵn sàng phục vụ 24/7</p>
          </div>
        </div>
        <div class="service-item">
          <img src="https://i.pinimg.com/736x/94/5b/93/945b93d607c108c5849738363a068faf.jpg" alt="International Friendly">
          <div class="service-overlay">
            <h3>Đa văn hóa</h3>
            <p>Môi trường quốc tế với dịch vụ đa ngôn ngữ</p>
          </div>
        </div>
      </div>
    </div>

    <!-- Sử dụng Footer component -->
    <Footer />
  </div>
</template>

<script>
import Header from '../../components/Header.vue';
import Footer from '../../components/Footer.vue';

export default {
  name: "AboutUs",
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      isScrolled: false
    };
  },
  methods: {
    handleScroll() {
      this.isScrolled = window.scrollY > 0;
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
  height: 66.67vh;
  overflow: hidden;
  position: relative;
  z-index: 1;
}

.main-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.image-text {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
  color: white;
  text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.image-text h1 {
  font-size: 56px;
  margin: 5px 0;
  font-weight: bold;
}

.image-text p {
  font-size: 32px;
  margin-top: 10px;
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
  font-size: 28px;
}

.text-content h3 {
  font-size: 38px;
  color: #d4a017;
  margin-bottom: 20px;
  font-weight: bold;
}

.text-content p {
  font-size: 26px;
  color: #666;
  line-height: 1.6;
  padding: 30px 60px;
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
  padding: 80px 20px;
  background-color: #f5f5f5;
}

.main-content h2 {
  text-align: center;
  font-size: 36px;
  color: #333;
  margin-bottom: 50px;
  font-weight: 700;
  position: relative;
}

.main-content h2:after {
  content: '';
  display: block;
  width: 80px;
  height: 3px;
  background: #c4a35a;
  margin: 15px auto;
}

.service-grid {
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 20px;
  padding: 20px;
}

.service-item {
  position: relative;
  overflow: hidden;
  border-radius: 8px;
  aspect-ratio: 1;
}

.service-item img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  transition: transform 0.3s ease;
}

.service-item:hover img {
  transform: scale(1.05);
}

.service-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.7);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  padding: 20px;
  opacity: 0;
  transition: opacity 0.3s ease;
  text-align: center;
}

.service-item:hover .service-overlay {
  opacity: 1;
}

.service-overlay h3 {
  color: #FFD700;
  margin-bottom: 15px;
  text-align: center;
  font-size: 32px;
  font-weight: 700;
  font-family: 'Playfair Display', serif;
  text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);
  letter-spacing: 1px;
  text-transform: uppercase;
  padding: 10px 20px;
  border-bottom: 2px solid rgba(255, 215, 0, 0.3);
}

.service-overlay p {
  color: #fff;
  text-align: center;
  font-size: 20px;
  line-height: 1.5;
  max-width: 80%;
  margin: 0 auto;
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.5);
  font-family: 'Montserrat', sans-serif;
}

/* New Styles for Read More Button and Modal */
.read-more-btn {
  background-color: #c4a35a;
  color: white;
  border: none;
  padding: 8px 15px;
  border-radius: 8px;
  cursor: pointer;
  font-size: 14px;
  margin-top: 15px;
  transition: background-color 0.3s ease;
}

.read-more-btn:hover {
  background-color: #a68c4d;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.7);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal-content {
  background: #fff;
  padding: 40px;
  border-radius: 12px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
  width: 90%;
  max-width: 600px;
  text-align: center;
  position: relative;
  animation: fadeIn 0.3s ease-out;
}

.modal-content h3 {
  font-size: 28px;
  color: #333;
  margin-bottom: 20px;
  font-weight: 700;
}

.modal-content p {
  font-size: 16px;
  color: #666;
  line-height: 1.6;
  margin-bottom: 30px;
}

.close-modal-btn {
  background-color: #c4a35a;
  color: white;
  border: none;
  padding: 10px 25px;
  border-radius: 8px;
  cursor: pointer;
  font-size: 16px;
  transition: background-color 0.3s ease;
}

.close-modal-btn:hover {
  background-color: #a68c4d;
}

@keyframes fadeIn {
  from { opacity: 0; transform: translateY(-20px); }
  to { opacity: 1; transform: translateY(0); }
}

@media (max-width: 768px) {
  .modal-content {
    padding: 30px;
  }

  .modal-content h3 {
    font-size: 24px;
  }

  .modal-content p {
    font-size: 14px;
  }

  .close-modal-btn {
    font-size: 14px;
    padding: 8px 20px;
  }
}

@media (max-width: 768px) {
  .main-image {
    height: 50vh;
  }

  .image-text h1 {
    font-size: 36px;
  }

  .image-text p {
    font-size: 24px;
  }

  .split-section {
    flex-direction: column;
    height: auto;
  }

  .text-content {
    padding: 20px;
  }

  .text-content h3 {
    font-size: 30px;
  }

  .text-content p {
    font-size: 22px;
    padding: 20px 30px;
  }

  .image-content img {
    height: 300px;
  }

  .main-content {
    flex-direction: column;
    padding: 20px;
  }

  .main-content h2 {
    font-size: 28px;
    margin-bottom: 30px;
  }

  .service-grid {
    grid-template-columns: 1fr;
    gap: 20px;
  }

  .service-overlay h3 {
    font-size: 16px;
  }

  .service-overlay p {
    font-size: 12px;
  }
}
</style>