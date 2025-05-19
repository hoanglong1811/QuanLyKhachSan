<template>
  <footer>
    <div class="footer-container">
      <div class="footer-column">
        <h4>Palace Long Hai Resort</h4>
        <p>Palace Long Hai Resort là khu nghỉ dưỡng 4 sao sang trọng tọa lạc tại trung tâm thị trấn Long Hải, mang đến sự kết hợp hoàn hảo giữa sự riêng tư và những trải nghiệm sôi động.</p>
      </div>
      <div class="footer-column">
        <h4>Liên kết nhanh</h4>
        <router-link to="/">Trang chủ</router-link>
        <router-link to="/about">Giới thiệu</router-link>
        <router-link to="/ser">Các loại phòng</router-link>
        <router-link to="/ser">Dịch vụ</router-link>
        <router-link to="/contact">Liên hệ</router-link>
      </div>
      <div class="footer-column">
        <h4>Liên hệ với chúng tôi</h4>
        <p>Địa chỉ: Long Hai Town, Ba Ria - Vung Tau, Vietnam</p>
        <p>Số điện thoại: 0938 156 069</p>
        <p>Email: info@palacelonghairesort.vn</p>
      </div>
    </div>
  </footer>
</template>

<script>
export default {
  name: "Footer",
};
</script>

<style scoped>
footer {
  background-color: #8B7D6B;
  color: white;
  padding: 50px 20px;
}

.footer-container {
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
  gap: 30px;
  max-width: 1200px;
  margin: 0 auto;
}

.footer-column {
  flex: 1;
  min-width: 200px;
}

.footer-column h4 {
  font-size: 18px;
  font-weight: 600;
  margin-bottom: 20px;
  color: #fff;
}

.footer-column p,
.footer-column a,
.footer-column router-link {
  font-size: 14px;
  color: #d1d1d1;
  text-decoration: none;
  margin-bottom: 4px;
  display: block;
  line-height: 1.6;
  font-weight: 300;
}

.footer-column a:hover,
.footer-column router-link:hover {
  color: #fff;
}

.footer-bottom {
  text-align: center;
  padding-top: 30px;
  border-top: 1px solid #5a7a7c;
  margin-top: 30px;
}

.footer-bottom p {
  font-size: 14px;
  color: #d1d1d1;
  font-weight: 300;
}

@media (max-width: 768px) {
  .footer-container {
    flex-direction: column;
    align-items: center;
    text-align: center;
  }

  .footer-column {
    margin-bottom: 20px;
  }
}
</style>