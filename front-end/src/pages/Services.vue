<template>
  <div class="about-us">
    <!-- Main Image with Header -->
    <div class="main-image">
      <img src="https://i.pinimg.com/736x/5f/43/4a/5f434a75f3d03ac0ce3778603a55c907.jpg" alt="About Us Image">
      <div class="image-text">
        <h1>Dịch vụ</h1>
        <p>Sự hài lòng của bạn là hạnh phúc của chúng tôi</p>
      </div>
    </div>

    <!-- Sử dụng Header component -->
    <Header />

    <!-- Intro Section -->
    <section class="intro-section">   
      <div>
        <h1 class="underlined-title">Trải nghiệm đẳng cấp mỗi ngày</h1>
        <p>Long Hai Resort mang đến cho bạn một loạt các dịch vụ đẳng cấp, đáp ứng mọi nhu cầu từ nghỉ dưỡng đến tổ chức sự kiện</p>
      </div>
    </section>

    <!-- New Section: Sunset Section 1 - Tổ chức sự kiện -->
    <section class="sunset-section">
      <div class="content-column">
        <h1>Tổ chức sự kiện</h1>
        <h2>Nơi mỗi sự kiện đều mang một dấu ấn khác biệt và đáng nhớ trong lòng du khách</h2>
        <p>Sở hữu không gian rộng rãi sát biển, Palace Long Hai Resort còn là điểm đến vô cùng ấn tượng dành cho những sự kiện như sinh nhật, tiệc công ty, sự kiện âm nhạc hay các cuộc thi thời trang, thi hoa hậu… Với các sự kiện nhỏ mang tính ấm cúng như tiệc sum họp gia đình, sinh nhật, lễ kỷ niệm của vợ chồng hay các cặp đôi, họp mặt nhóm bạn… thì không gian của Nhà hàng Đại Dương chính là một lựa chọn cực kỳ phù hợp.</p>
        <p>Trong khi đó, Palace Long Hai Resort cũng hứa hẹn gây bùng nổ với các sự kiện âm nhạc, biểu diễn nghệ thuật hoành tráng hay các sự kiện công ty quy mô lớn tại khu vực hồ bơi với sức chứa lên đến 700 chỗ. Bãi cát dài và bằng phẳng ngay sát biển với không gian rộng thoáng sẽ là địa điểm lý tưởng cho các chương trình lễ hội, hội chợ, triển lãm…</p>
        <p>Đội ngũ tổ chức sự kiện trẻ trung, năng động, nhiều ý tưởng sáng tạo với tác phong chuyên nghiệp của Palace Long Hai Resort luôn sẵn sàng hỗ trợ các đơn vị đối tác hoặc các đoàn khách làm nên những big-event đầy ấn tượng</p>
      </div>
      <div class="image-column">
        <img :src="eventImages[currentImageIndices[0]]" alt="Event Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(0)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(0)"></button>
        <div class="pagination">
          <span v-for="(image, index) in eventImages" :key="index" :class="{ 'active': index === currentImageIndices[0] }">
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
    </section>

    <!-- New Section: Sunset Section 2 - Tiệc cưới -->
    <section class="sunset-section">
      <div class="image-column">
        <img :src="weddingImages[currentImageIndices[1]]" alt="Wedding Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(1)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(1)"></button>
        <div class="pagination">
          <span v-for="(image, index) in weddingImages" :key="index" :class="{ 'active': index === currentImageIndices[1] }">
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
      <div class="content-column">
        <h1>Tiệc cưới</h1>
        <h2>Nơi lưu dấu những khoảnh khắc đáng nhớ của hạnh phúc lứa đôi</h2>
        <p>Có sức chứa lên đến 700 chỗ vô cùng lãng mạn xung quanh hồ bơi sát biển sẽ là lựa chọn hoàn hảo để những cặp đôi trao lời hẹn ước trăm năm. Hoặc không gian bãi cát dọc bờ biển cũng rất thích hợp để tổ chức các lễ cưới theo phong cách địa trung hải vô cùng ấn tượng và đặc sắc. Đội ngũ giàu kinh nghiệm của Palace Long Hai Resort sẽ hỗ trợ tổ chức tiệc cho các cặp đôi với những concept mới lạ, độc đáo và chuyên nghiệp.</p>
        <p>Thực đơn được chế biến công phu từ những đầu bếp chuyên nghiệp của Nhà hàng Đại Dương sẽ khiến lễ cưới của các cặp đôi thêm đậm đà hương vị.</p>
        <p>Không chỉ gây ấn tượng với không gian tổ chức tiệc cưới, Palace Long Hai Resort còn là nơi lý tưởng để chụp ảnh cưới với cảnh sắc thiên nhiên tươi đẹp đầy sức sống, bãi biển nên thơ với hàng triệu con sóng cùng hòa chung giai điệu của tình yêu đôi lứa hay những góc check-in cực xịn sò lưu dấu kỷ niệm đáng nhớ của những đôi tình nhân. Một bộ ảnh cưới lung linh chắc chắn sẽ khiến cho ngày vui của cặp đôi thêm trọn vẹn ý nghĩa.</p>
      </div>
    </section>

    <!-- New Section: Sunset Section 3 - Team Building -->
    <section class="sunset-section">
      <div class="content-column">
        <h1>Team Building</h1>
        <h2>Palace Long Hai Resort tiếp lửa hành trình sẻ chia, kết nối và mở lối thành công</h2>
        <p>Đã nhắc đến du lịch MICE thì không thể bỏ qua các hoạt động teambuilding gắn kết đội ngũ đầy vui nhộn. Sở hữu bãi biển cát trắng chạy dài thoai thoải, Palace Long Hai Resort rất phù hợp cho các hoạt động team building, cắm trại, đốt lửa trại của khách đoàn.</p>
        <p>Tham gia teambuilding, các thành viên không chỉ có những phút giây thư giãn giải trí, bung xõa năng lượng mà còn được gắn kết hơn nhờ các hoạt động trải nghiệm, những môn thể thao đồng đội hay có thêm thời gian bên nhau để cùng khám phá thiên nhiên, tham quan các điểm du lịch nổi tiếng hay quay quần cùng nhau và chia sẻ những câu chuyện bên lửa trại… Có thể nói, đây chính là cơ hội để các thành viên phát huy tinh thần làm việc nhóm, sự gắn kết và chia sẻ.</p>
      </div>
      <div class="image-column">
        <img :src="teamBuildingImages[currentImageIndices[2]]" alt="Team Building Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(2)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(2)"></button>
        <div class="pagination">
          <span v-for="(image, index) in teamBuildingImages" :key="index" :class="{ 'active': index === currentImageIndices[2] }">
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
    </section>

    <!-- New Section: Sunset Section 4 - Điểm tham quan lân cận -->
    <section class="sunset-section">
      <div class="image-column">
        <img :src="nearbyImages[currentImageIndices[3]]" alt="Nearby Attraction Image" class="sunset-image">
        <button class="arrow-btn prev-btn" @click="prevImage(3)"></button>
        <button class="arrow-btn next-btn" @click="nextImage(3)"></button>
        <div class="pagination">
          <span v-for="(image, index) in nearbyImages" :key="index" :class="{ 'active': index === currentImageIndices[3] }">
            {{ (index + 1).toString().padStart(2, '0') }}
          </span>
        </div>
      </div>
      <div class="content-column">
        <h1>Điểm tham quan lân cận</h1>
        <h2>Những địa điểm tham quan mà bạn nên ghé đến khi tới Long Hải</h2>
        <p>Những ai đến du lịch Long Hải sẽ không khỏi ngạc nhiên bởi cảnh biển đẹp một cách tự nhiên. Nước biển sạch và mát mẻ, cùng với đồi núi xanh thơ mộng.</p>
        <ul class="attraction-list">
          <li>Bãi biển du lịch Long Hải</li>
          <li>Khu di tích Minh Đạm</li>
          <li>Đèo Nước Ngọt</li>
          <li>Đền Dinh Cô, Mộ Cô</li>
          <li>Thiền viện trúc lâm chân nguyên</li>
          <li>Làng chài Long Hải</li>
        </ul>
      </div>
    </section>

    <!-- Sử dụng Footer component -->
    <Footer />
  </div>
</template>

<script>
import Header from '../components/Header.vue';
import Footer from '../components/Footer.vue';

export default {
  name: "Services",
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
        { show: false },
      ],
      currentImageIndices: [0, 0, 0, 0], // Mảng chứa chỉ số hình ảnh cho từng section
      eventImages: [ // Ảnh cho section Tổ chức sự kiện
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-8.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-7.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-6.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-1.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/10/TRANG-SU-KIEN21-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/10/TRANG-SU-KIEN12-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-10.jpg"
      ],
      weddingImages: [ // Ảnh cho section Tiệc cưới
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC03082_2-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC03121_2-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/LTO04760-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/LTO04744-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/LTO05494-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/12/DSC03093_2-small.jpg"
      ],
      teamBuildingImages: [ // Ảnh cho section Team Building
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/450259574_10226728122884949_8373272424702179827_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/453011581_1009774047816718_1794423109283007495_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/452965493_1009774174483372_2700943104046581161_n-small.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/450332275_8204059062960326_8003284075842702402_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/450327326_8204059372960295_5250398034549012779_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/453008963_1009774081150048_70538483209812672_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/449918219_10226728123084954_7888605806022048818_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/452947259_1009774057816717_6355652659540582983_n.jpg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/DSC05285-small.jpeg",
        "https://palacelonghairesort.vn/wp-content/uploads/2024/08/DSC05309-small.jpeg",
      ],
      nearbyImages: [ // Ảnh cho section Điểm tham quan lân cận
        "https://i.pinimg.com/736x/5b/26/51/5b2651bc08050b9af23bb838973f8879.jpg",
        "https://i.pinimg.com/736x/9e/1e/9c/9e1e9cde43714cbf93717c0bbcedf6ce.jpg",
        "https://i.pinimg.com/736x/3e/17/56/3e17562dc1b1e844a9daa4f4172eb024.jpg",
        "https://i.pinimg.com/736x/a0/6e/1a/a06e1a16854372b3a4fe6b03b4bcf48b.jpg",
        "https://i.pinimg.com/736x/97/ea/22/97ea228cda929b6c0bc6b3ba438fff41.jpg",
        "https://i.pinimg.com/736x/0f/37/11/0f371119e630e4dea2bf3b4dcf196047.jpg"
      ]
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
    prevImage(sectionIndex) {
      const imageArrays = [this.eventImages, this.weddingImages, this.teamBuildingImages, this.nearbyImages];
      this.currentImageIndices[sectionIndex] = (this.currentImageIndices[sectionIndex] > 0) ? this.currentImageIndices[sectionIndex] - 1 : imageArrays[sectionIndex].length - 1;
    },
    nextImage(sectionIndex) {
      const imageArrays = [this.eventImages, this.weddingImages, this.teamBuildingImages, this.nearbyImages];
      this.currentImageIndices[sectionIndex] = (this.currentImageIndices[sectionIndex] < imageArrays[sectionIndex].length - 1) ? this.currentImageIndices[sectionIndex] + 1 : 0;
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

/* Intro Section Styles */
.intro-section {
  padding: 40px 20px;
  background-color: #f5f0e1;
  text-align: center; /* Căn giữa nội dung */
}

.intro-section h1 {
  font-size: 32px;
  color: #d4a017;
  margin-bottom: 15px;
  text-transform: uppercase;
  position: relative;
  display: inline-block; /* Để gạch chân chỉ áp dụng cho độ dài của tiêu đề */
}

.underlined-title::after {
  content: '';
  position: absolute;
  left: 50%;
  transform: translateX(-50%);
  bottom: -5px;
  width: 100%; /* Độ dài gạch chân */
  height: 2px; /* Độ dày gạch chân */
  background-color: #d4a017; /* Màu gạch chân */
}

.intro-section p {
  font-size: 16px;
  color: #666;
  margin: 0 auto;
  max-width: 800px; /* Giới hạn chiều rộng đoạn văn để dễ đọc */
}

/* Sunset Section Styles */
.sunset-section {
  display: flex;
  justify-content: space-between;
  padding: 40px 20px;
  background-color: #f5f5f5;
  /* Xóa height: 500px để chiều cao tự động */
}

.content-column {
  flex: 1;
  padding-right: 20px;
  padding-left: 20px;
  display: flex;
  flex-direction: column;
  justify-content: center; /* Căn giữa nội dung theo chiều dọc */
}

.content-column h1 {
  font-size: 28px;
  color: #d4a017;
  text-transform: uppercase;
  text-align: center;
}

.content-column h2 {
  font-size: 18px;
  color: #d4a017;
  margin-bottom: 15px;
  text-align: center;
  text-transform: uppercase;
}

.content-column p {
  font-size: 16px;
  color: #666;
  margin-bottom: 0px;
}

.attraction-list {
  list-style-type: none;
  padding: 0;
}

.attraction-list li {
  font-size: 16px;
  color: #666;
  margin: 5px 0;
}

.image-column {
  flex: 1;
  position: relative;
}

.sunset-image {
  width: 100%;
  height: 450px; /* Chiều cao mặc định */
  object-fit: cover;
}

.arrow-btn {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  border: none;
  font-size: 20px;
  cursor: pointer;
  padding: 10px;
}

.prev-btn {
  left: 10px;
}

.next-btn {
  right: 10px;
}

.pagination {
  text-align: center;
  margin-top: 10px;
}

.pagination span {
  display: inline-block;
  width: 30px;
  height: 30px;
  line-height: 30px;
  background-color: #ddd;
  margin: 0 5px;
  cursor: pointer;
  border-radius: 50%;
}

.pagination span.active {
  background-color: #d4a017;
  color: white;
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

  .intro-section h1 {
    font-size: 24px;
  }

  .intro-section p {
    font-size: 14px;
  }

  .sunset-section {
    flex-direction: column;
    height: auto; /* Để chiều cao tự động trên thiết bị di động */
  }

  .content-column, .image-column {
    width: 100%;
  }

  .sunset-image {
    height: 300px; /* Giảm chiều cao hình ảnh trên thiết bị di động */
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