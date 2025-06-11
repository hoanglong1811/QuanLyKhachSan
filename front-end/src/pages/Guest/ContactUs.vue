<template>
  <div class="contact-page">
    <Header />
    
    <!-- Hero Section -->
    <div class="hero-section">
      <img src="https://i.pinimg.com/736x/5f/43/4a/5f434a75f3d03ac0ce3778603a55c907.jpg" alt="Contact Banner" class="hero-bg">
      <div class="hero-overlay"></div>
      <div class="hero-content">
        <h1 class="animate-fade-down">Liên Hệ Palace Long Hai</h1>
        <p class="animate-fade-up">Chúng tôi luôn sẵn sàng lắng nghe và phục vụ bạn</p>
      </div>
    </div>

    <!-- Emergency Contact -->
    <div class="emergency-contact">
      <div class="container">
        <div class="emergency-content">
          <div class="emergency-item">
            <div class="icon-wrapper">
              <i class="fas fa-phone-alt"></i>
            </div>
            <div class="emergency-text">
              <span class="label">Hotline 24/7</span>
              <a href="tel:1800 1234" class="contact-number">1800 1234</a>
            </div>
          </div>
          <div class="emergency-divider"></div>
          <div class="emergency-item">
            <div class="icon-wrapper">
              <i class="fas fa-calendar-alt"></i>
            </div>
            <div class="emergency-text">
              <span class="label">Đặt Phòng</span>
              <a href="tel:0254 3789 789" class="contact-number">0254 3789 789</a>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Contact Methods -->
    <section class="contact-methods">
      <div class="container">
        <div class="section-header">
          <h2>Phương Thức Liên Hệ</h2>
          <p>Chọn cách thuận tiện nhất để liên hệ với chúng tôi</p>
        </div>
        <div class="methods-grid">
          <div class="method-card">
            <div class="method-icon">
              <i class="fas fa-map-marker-alt"></i>
            </div>
            <h3>Địa Chỉ</h3>
            <p>Phường Phước Hưng, Thị xã Long Hải,</p>
            <p>Tỉnh Bà Rịa - Vũng Tàu</p>
            <a href="https://goo.gl/maps/yourlink" class="method-link">
              Xem trên bản đồ
              <i class="fas fa-arrow-right"></i>
            </a>
          </div>

          <div class="method-card">
            <div class="method-icon">
              <i class="fas fa-envelope"></i>
            </div>
            <h3>Email</h3>
            <p>info@palacelonghai.com</p>
            <p>booking@palacelonghai.com</p>
            <a href="mailto:info@palacelonghai.com" class="method-link">
              Gửi email ngay
              <i class="fas fa-arrow-right"></i>
            </a>
          </div>

          <div class="method-card">
            <div class="method-icon">
              <i class="fas fa-clock"></i>
            </div>
            <h3>Giờ Làm Việc</h3>
            <p>Check-in: 14:00</p>
            <p>Check-out: 12:00</p>
            <a href="/booking" class="method-link">
              Đặt phòng ngay
              <i class="fas fa-arrow-right"></i>
            </a>
          </div>
        </div>
      </div>
    </section>

    <!-- Contact Form Section -->
    <section class="contact-section">
      <div class="container">
        <div class="contact-wrapper">
          <div class="form-container">
            <div class="form-header">
              <h2>Gửi Thông Tin Liên Hệ</h2>
              <p>Điền thông tin bên dưới, chúng tôi sẽ liên hệ lại trong thời gian sớm nhất</p>
            </div>
            <form @submit.prevent="submitForm" class="contact-form">
              <div class="form-row">
                <div class="form-group">
                  <label for="name">Họ và tên *</label>
                  <input 
                    type="text" 
                    id="name" 
                    v-model="formData.name"
                    required
                    placeholder="Nhập họ và tên của bạn"
                  >
                </div>
                <div class="form-group phone-group">
                  <label for="phone">Số điện thoại *</label>
                  <input 
                    type="tel" 
                    id="phone" 
                    v-model="formData.phone"
                    required
                    placeholder="Nhập số điện thoại của bạn"
                    class="phone-input"
                  >
                </div>
              </div>

              <div class="form-group">
                <label for="email">Email *</label>
                <input 
                  type="email" 
                  id="email" 
                  v-model="formData.email"
                  required
                  placeholder="Nhập địa chỉ email của bạn"
                >
              </div>

              <div class="form-group">
                <label for="subject">Chủ đề</label>
                <select id="subject" v-model="formData.subject">
                  <option value="">Chọn chủ đề</option>
                  <option value="booking">Đặt phòng</option>
                  <option value="service">Dịch vụ</option>
                  <option value="complaint">Khiếu nại</option>
                  <option value="feedback">Góp ý</option>
                  <option value="other">Khác</option>
                </select>
              </div>

              <div class="form-group">
                <label for="message">Nội dung tin nhắn *</label>
                <textarea 
                  id="message" 
                  v-model="formData.message"
                  required
                  rows="5"
                  placeholder="Nhập nội dung tin nhắn của bạn"
                ></textarea>
              </div>

              <button type="submit" class="submit-btn">
                <span>Gửi Tin Nhắn</span>
                <i class="fas fa-paper-plane"></i>
              </button>
            </form>
          </div>

          <div class="map-container">
            <div class="map">
              <iframe 
                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3921.0456317141697!2d107.2392663!3d10.6423583!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31756fd4554f0cf5%3A0xb58ba82c3175e337!2sLong%20Hai%20Beach%20Resort!5e0!3m2!1sen!2s!4v1234567890"
                width="100%" 
                height="100%" 
                style="border:0;" 
                allowfullscreen="" 
                loading="lazy"
              ></iframe>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- FAQ Section -->
    <section class="faq-section">
      <div class="container">
        <div class="section-header">
          <h2>Câu Hỏi Thường Gặp</h2>
          <p>Những thông tin hữu ích dành cho bạn</p>
        </div>
        <div class="faq-grid">
          <div class="faq-item" v-for="(faq, index) in faqs" :key="index" @click="toggleFaq(index)">
            <div class="faq-question">
              <h3>{{ faq.question }}</h3>
              <i :class="['fas', faq.isOpen ? 'fa-minus' : 'fa-plus']"></i>
            </div>
            <div class="faq-answer" :class="{ 'open': faq.isOpen }">
              <p>{{ faq.answer }}</p>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Social Media Section -->
    <section class="social-section">
      <div class="container">
        <div class="section-header">
          <h2>Kết Nối Với Chúng Tôi</h2>
          <p>Theo dõi chúng tôi trên mạng xã hội để cập nhật những thông tin mới nhất</p>
        </div>
        <div class="social-links">
          <a href="#" class="social-link facebook">
            <i class="fab fa-facebook-f"></i>
          </a>
          <a href="#" class="social-link instagram">
            <i class="fab fa-instagram"></i>
          </a>
          <a href="#" class="social-link twitter">
            <i class="fab fa-twitter"></i>
          </a>
          <a href="#" class="social-link youtube">
            <i class="fab fa-youtube"></i>
          </a>
        </div>
      </div>
    </section>

    <Footer />
  </div>
</template>

<script>
import Header from '../../components/Header.vue';
import Footer from '../../components/Footer.vue';

export default {
  name: "ContactUs",
  components: {
    Header,
    Footer,
  },
  data() {
    return {
      formData: {
        name: '',
        email: '',
        phone: '',
        subject: '',
        message: ''
      },
      faqs: [
        {
          question: 'Làm thế nào để đặt phòng?',
          answer: 'Bạn có thể đặt phòng trực tiếp trên website của chúng tôi hoặc gọi số hotline 1800 1234 để được hỗ trợ.',
          isOpen: false
        },
        {
          question: 'Thời gian nhận và trả phòng?',
          answer: 'Thời gian nhận phòng là 14:00 và trả phòng là 12:00 trưa ngày hôm sau.',
          isOpen: false
        },
        {
          question: 'Có dịch vụ đưa đón sân bay không?',
          answer: 'Có, chúng tôi có dịch vụ đưa đón sân bay. Vui lòng liên hệ trước để đặt dịch vụ.',
          isOpen: false
        },
        {
          question: 'Chính sách hủy phòng như thế nào?',
          answer: 'Bạn có thể hủy phòng miễn phí trước 24 giờ. Sau thời gian này sẽ tính phí theo quy định.',
          isOpen: false
        }
      ]
    }
  },
  methods: {
    async submitForm() {
      try {
        console.log('Form submitted:', this.formData);
        this.formData = {
          name: '',
          email: '',
          phone: '',
          subject: '',
          message: ''
        };
        alert('Cảm ơn bạn đã liên hệ. Chúng tôi sẽ phản hồi sớm nhất có thể!');
      } catch (error) {
        console.error('Error submitting form:', error);
        alert('Có lỗi xảy ra. Vui lòng thử lại sau!');
      }
    },
    toggleFaq(index) {
      this.faqs[index].isOpen = !this.faqs[index].isOpen;
    }
  }
};
</script>

<style scoped>
.contact-page {
  background-color: #f8f9fa;
}

/* Hero Section */
.hero-section {
  height: 60vh;
  position: relative;
  overflow: hidden;
}

.hero-bg {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.hero-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.7));
}

.hero-content {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
  color: #ffffff;
  width: 100%;
  z-index: 2;
}

.hero-content h1 {
  font-size: 3.5rem;
  margin-bottom: 1rem;
  font-weight: 700;
}

.hero-content p {
  font-size: 1.5rem;
  opacity: 0.9;
}

/* Emergency Contact */
.emergency-contact {
  background: linear-gradient(135deg, #d4a017 0%, #b88a14 100%);
  padding: 30px 0;
  color: #ffffff;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

.emergency-content {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 60px;
  position: relative;
}

.emergency-item {
  display: flex;
  align-items: center;
  gap: 20px;
  padding: 10px 20px;
  transition: transform 0.3s ease;
}

.emergency-item:hover {
  transform: translateY(-3px);
}

.icon-wrapper {
  width: 60px;
  height: 60px;
  background: rgba(255, 255, 255, 0.15);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  backdrop-filter: blur(5px);
  border: 2px solid rgba(255, 255, 255, 0.2);
  transition: all 0.3s ease;
}

.emergency-item:hover .icon-wrapper {
  background: rgba(255, 255, 255, 0.25);
  transform: rotate(15deg);
}

.emergency-item i {
  font-size: 24px;
  color: #ffffff;
}

.emergency-text {
  display: flex;
  flex-direction: column;
  gap: 5px;
}

.emergency-text .label {
  font-size: 0.95rem;
  text-transform: uppercase;
  letter-spacing: 1px;
  opacity: 0.9;
}

.emergency-text .contact-number {
  font-size: 1.8rem;
  font-weight: 700;
  color: #ffffff;
  text-decoration: none;
  transition: color 0.3s ease;
}

.emergency-text .contact-number:hover {
  color: rgba(255, 255, 255, 0.8);
}

.emergency-divider {
  width: 2px;
  height: 60px;
  background: rgba(255, 255, 255, 0.2);
  border-radius: 1px;
}

/* Container */
.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 20px;
}

/* Section Styles */
section {
  padding: 80px 0;
}

.section-header {
  text-align: center;
  margin-bottom: 50px;
}

.section-header h2 {
  font-size: 2.5rem;
  color: #333;
  margin-bottom: 15px;
}

.section-header p {
  color: #666;
  font-size: 1.1rem;
}

/* Contact Methods */
.methods-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: 30px;
}

.method-card {
  background: #ffffff;
  padding: 40px;
  border-radius: 15px;
  text-align: center;
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
}

.method-card:hover {
  transform: translateY(-10px);
}

.method-icon {
  width: 80px;
  height: 80px;
  background: #d4a017;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 0 auto 25px;
}

.method-icon i {
  font-size: 32px;
  color: #ffffff;
}

.method-card h3 {
  font-size: 1.5rem;
  color: #333;
  margin-bottom: 15px;
}

.method-card p {
  color: #666;
  line-height: 1.6;
  margin-bottom: 5px;
}

.method-link {
  display: inline-flex;
  align-items: center;
  gap: 8px;
  color: #d4a017;
  text-decoration: none;
  margin-top: 20px;
  font-weight: 500;
  transition: all 0.3s ease;
}

.method-link:hover {
  gap: 12px;
  color: #b88a14;
}

/* Contact Form Section */
.contact-wrapper {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 50px;
  align-items: stretch;
}

.form-container {
  background: #ffffff;
  padding: 40px;
  border-radius: 15px;
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
  height: 100%;
}

.form-header {
  text-align: center;
  margin-bottom: 30px;
}

.form-header h2 {
  font-size: 2rem;
  color: #333;
  margin-bottom: 10px;
}

.form-header p {
  color: #666;
}

.form-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
  margin-bottom: 20px;
}

.form-group {
  margin-bottom: 20px;
}

.form-group label {
  display: block;
  margin-bottom: 8px;
  color: #333;
  font-weight: 500;
}

.form-group input,
.form-group select,
.form-group textarea {
  width: 100%;
  padding: 12px 15px;
  border: 2px solid #eee;
  border-radius: 8px;
  font-size: 1rem;
  transition: all 0.3s ease;
}

.form-group input:focus,
.form-group select:focus,
.form-group textarea:focus {
  border-color: #d4a017;
  outline: none;
  box-shadow: 0 0 0 3px rgba(212, 160, 23, 0.1);
}

.submit-btn {
  background: #d4a017;
  color: #ffffff;
  border: none;
  padding: 15px 30px;
  font-size: 1.1rem;
  border-radius: 8px;
  cursor: pointer;
  transition: all 0.3s ease;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
  width: 100%;
}

.submit-btn:hover {
  background: #b88a14;
  transform: translateY(-2px);
}

.map-container {
  position: relative;
  width: 100%;
  height: 100%;
  min-height: 500px;
  border-radius: 15px;
  overflow: hidden;
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.1);
}

.map {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
}

.map iframe {
  width: 100%;
  height: 100%;
  border: none;
}

/* FAQ Section */
.faq-grid {
  max-width: 800px;
  margin: 0 auto;
}

.faq-item {
  background: #ffffff;
  border-radius: 10px;
  margin-bottom: 15px;
  overflow: hidden;
  cursor: pointer;
}

.faq-question {
  padding: 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.faq-question h3 {
  font-size: 1.1rem;
  color: #333;
  margin: 0;
}

.faq-question i {
  color: #d4a017;
  transition: transform 0.3s ease;
}

.faq-answer {
  padding: 0 20px;
  max-height: 0;
  overflow: hidden;
  transition: all 0.3s ease;
}

.faq-answer.open {
  padding: 0 20px 20px;
  max-height: 200px;
}

.faq-answer p {
  color: #666;
  line-height: 1.6;
  margin: 0;
}

/* Social Media Section */
.social-section {
  background: #ffffff;
}

.social-links {
  display: flex;
  justify-content: center;
  gap: 25px;
}

.social-link {
  width: 60px;
  height: 60px;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #ffffff;
  font-size: 1.5rem;
  transition: all 0.3s ease;
}

.social-link:hover {
  transform: translateY(-5px);
}

.social-link.facebook { background: #1877f2; }
.social-link.instagram { background: #e4405f; }
.social-link.twitter { background: #1da1f2; }
.social-link.youtube { background: #ff0000; }

/* Animations */
.animate-fade-down {
  animation: fadeDown 1s ease;
}

.animate-fade-up {
  animation: fadeUp 1s ease 0.3s forwards;
  opacity: 0;
}

@keyframes fadeDown {
  from {
    opacity: 0;
    transform: translateY(-30px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

@keyframes fadeUp {
  from {
    opacity: 0;
    transform: translateY(30px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

/* Responsive Design */
@media (max-width: 992px) {
  .contact-wrapper {
    grid-template-columns: 1fr;
  }

  .hero-section {
    height: 50vh;
  }

  .hero-content h1 {
    font-size: 2.5rem;
  }

  .emergency-content {
    flex-direction: column;
    gap: 30px;
  }

  .emergency-divider {
    width: 80%;
    height: 2px;
  }
}

@media (max-width: 768px) {
  .form-row {
    grid-template-columns: 1fr;
  }

  .method-card {
    padding: 30px 20px;
  }

  .social-link {
    width: 50px;
    height: 50px;
    font-size: 1.2rem;
  }

  .section-header h2 {
    font-size: 2rem;
  }

  .hero-content h1 {
    font-size: 2rem;
  }

  .hero-content p {
    font-size: 1.2rem;
  }
}

@media (max-width: 480px) {
  .hero-content h1 {
    font-size: 1.8rem;
  }

  .hero-content p {
    font-size: 1rem;
  }

  .emergency-item {
    flex-direction: column;
    text-align: center;
    gap: 15px;
  }

  .social-links {
    gap: 15px;
  }

  .method-icon {
    width: 60px;
    height: 60px;
  }

  .method-icon i {
    font-size: 24px;
  }

  .emergency-text .contact-number {
    font-size: 1.5rem;
  }

  .icon-wrapper {
    width: 50px;
    height: 50px;
  }

  .emergency-item i {
    font-size: 20px;
  }
}

.phone-input {
  max-width: 220px;
  margin-left: 0;
}

.phone-group {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin-left: 20px;
}

.phone-group label {
  margin-right: 0;
}
</style>