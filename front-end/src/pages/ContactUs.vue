
<template>
  <div class="about-us">
    <!-- Main Image with Header -->
    <div class="main-image">
      <img src="https://i.pinimg.com/736x/5f/43/4a/5f434a75f3d03ac0ce3778603a55c907.jpg" alt="About Us Image">
      <div class="image-text">
        <h1>Welcome to</h1>
        <h1>Place Long Hai</h1>
        <p>Your satisfaction, our happiness</p>
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
        </div>
        <h3>4-STAR SERVICE QUALITY</h3>
        <p>Palace Long Hai Resort quickly became a favourite resort location for many travellers due to the staff's expertise and attention, as well as its numerous wonderful amenities.</p>
      </div>
      <div class="image-content">
        <img src="https://imgs.search.brave.com/zL3OrbDFviWM9rGKHcqEeE5MdvIo-5EpOnol1pfLsx8/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9jZG4u/cGl4YWJheS5jb20v/cGhvdG8vMjAxNi8x/MS8xOC8xNy8yMC9s/aXZpbmctcm9vbS0x/ODM1OTIzXzY0MC5q/cGc" alt="Service Quality Image">
      </div>
    </div>

    <!-- Section 2: Image and Text Split -->
    <div class="split-section">
      <div class="image-content">
        <img src="https://cf.bstatic.com/xdata/images/hotel/max1024x768/502053834.jpg?k=d897aecabccf65b90c22c65f9c752c5960935f9228bcfebbbfcf6e34f5a1fe43&o=&hp=1" alt="Service Quality Image">
      </div>
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>4-STAR SERVICE QUALITY</h3>
        <p>Palace Long Hai Resort quickly became a favourite resort location for many travellers due to the staff's expertise and attention, as well as its numerous wonderful amenities.</p>
      </div>
    </div>

    <!-- Section 3: Image and Text Split -->
    <div class="split-section">
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>4-STAR SERVICE QUALITY</h3>
        <p>Palace Long Hai Resort quickly became a favourite resort location for many travellers due to the staff's expertise and attention, as well as its numerous wonderful amenities.</p>
      </div>
      <div class="image-content">
        <img src="https://cf.bstatic.com/xdata/images/hotel/max1024x768/498977541.jpg?k=39564d6c4a0c2f5b49d512f4ba0b94b258448dcef50c0772f009bc33c683c2c7&o=&hp=1" alt="Service Quality Image">
      </div>
    </div>

    <!-- Section 4: Image and Text Split -->
    <div class="split-section">
      <div class="image-content">
        <img src="https://vielimousine.com/wp-content/uploads/2023/07/13-bien-long-hai.jpg" alt="Service Quality Image">
      </div>
      <div class="text-content">
        <div class="stars">
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
          <i class="fas fa-star"></i>
        </div>
        <h3>4-STAR SERVICE QUALITY</h3>
        <p>Palace Long Hai Resort quickly became a favourite resort location for many travellers due to the staff's expertise and attention, as well as its numerous wonderful amenities.</p>
      </div>
    </div>

    <!-- New Section: Service Highlights -->
    <div class="main-content">
      <h2>Our Highlights</h2>
      <div class="service-item" @mouseover="showDescription(0)" @mouseleave="hideDescription(0)">
        <img src="https://lanrung.com.vn/wp-content/uploads/2020/11/Lan-Rung-Resort-scaled.jpg" alt="Green Place">
        <div class="service-overlay" v-show="descriptions[0].show">
          Enjoy a serene environment surrounded by lush greenery and fresh air, perfect for relaxation.
        </div>
      </div>
      <div class="service-item" @mouseover="showDescription(1)" @mouseleave="hideDescription(1)">
        <img src="https://lanrung.com.vn/wp-content/uploads/2020/11/Lan-Rung-Resort-scaled.jpg" alt="Service Heart">
        <div class="service-overlay" v-show="descriptions[1].show">
          Experience heartfelt hospitality with our dedicated staff ensuring your every need is met.
        </div>
      </div>
    
      <div class="service-item" @mouseover="showDescription(3)" @mouseleave="hideDescription(3)">
        <img src="https://vielimousine.com/wp-content/uploads/2023/07/26-bien-long-hai.webp" alt="International Friendly">
        <div class="service-overlay" v-show="descriptions[3].show">
          Welcoming international travelers with English-speaking staff and tailored experiences for guests from the UK and beyond.
        </div>
      </div>
    </div>

    <!-- Sử dụng Footer component -->
    <Footer />
  </div>
</template>

<script>
import Header from '../components/Header.vue';
import Footer from '../components/Footer.vue';

export default {
  name: "Contact",
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
  font-size: 36px;
  margin: 5px 0;
}

.image-text p {
  font-size: 20px;
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

@media (max-width: 768px) {
  .main-image {
    height: 50vh;
  }

  .image-text h1 {
    font-size: 24px;
  }

  .image-text p {
    font-size: 16px;
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
}
</style>