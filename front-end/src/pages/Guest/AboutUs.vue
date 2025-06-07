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
      <div class="service-item" @mouseover="showDescription(0)" @mouseleave="hideDescription(0)">
        <img src="https://i.pinimg.com/736x/08/9d/94/089d94bf9610318138e58402f01e4c5c.jpg" alt="Green Place">
        <div class="service-overlay" v-show="descriptions[0].show">
          Bạn có thể tận hưởng môi trường thanh bình được bao quanh bởi cây xanh tươi tốt và không khí trong lành, lý tưởng để thư giãn.
        </div>
      </div>
      <div class="service-item" @mouseover="showDescription(1)" @mouseleave="hideDescription(1)">
        <img src="https://i.pinimg.com/736x/49/b7/f2/49b7f2e9745a66cef581c4d03c4d7e88.jpg" alt="Service Heart">
        <div class="service-overlay" v-show="descriptions[1].show">
          Trải nghiệm lòng hiếu khách chân thành với đội ngũ nhân viên tận tụy của chúng tôi, đảm bảo đáp ứng mọi nhu cầu của bạn.
        </div>
      </div>
    
      <div class="service-item" @mouseover="showDescription(3)" @mouseleave="hideDescription(3)">
        <img src="https://i.pinimg.com/736x/94/5b/93/945b93d607c108c5849738363a068faf.jpg" alt="International Friendly">
        <div class="service-overlay" v-show="descriptions[3].show">
          Chào đón du khách quốc tế với đội ngũ nhân viên nói tiếng Anh và những trải nghiệm được thiết kế riêng cho du khách từ Vương quốc Anh và nhiều nơi khác.
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
      isScrolled: false,
      descriptions: [
        { show: false },
        { show: false },
        { show: false },
        { show: false }, // Thêm cho phần mới
      ],
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
  display: flex;
  justify-content: center;
  gap: 20px;
  padding: 50px 20px;
  flex-wrap: wrap;
  background: #f1f0f0;
}

.main-content h2 {
  font-size: 48px;
  color: #3b7097;
  text-align: center;
  margin-bottom: 40px;
  width: 100%;
  font-weight: bold;
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
  padding: 30px;
  opacity: 0;
  transform: translateY(10px);
  transition: opacity 0.3s ease, transform 0.3s ease;
  font-size: 26px;
}

.service-item:hover .service-overlay {
  opacity: 1;
  transform: translateY(0);
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
    font-size: 36px;
    margin-bottom: 30px;
  }

  .service-item {
    width: 100%;
    min-width: 0;
  }

  .service-overlay {
    font-size: 22px;
    padding: 20px;
  }
}
</style>