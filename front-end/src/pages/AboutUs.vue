<template>
    <div class="about-us">
        <!-- Main Image with Header -->
        <div class="main-image">
            <img src="https://i.pinimg.com/736x/fd/f3/7a/fdf37a147474daa3fb326f7652b5db48.jpg" alt="About Us Image">
            <div class="image-text">
                <h1>Welcome to</h1>
                <h1>Place Long Hai</h1>
                <p>Your satisfaction, our happiness</p>
            </div>
        </div>

        <!-- Header -->
        <header :class="{ 'sticky': isScrolled }">
            <div class="logo">
                <div>
                    <span>PLACE</span>
                    <span>LONG HAI RESORT</span>
                </div>
            </div>
            <nav class="menu">
                <router-link to="/">Home</router-link>
                <router-link to="/about">About Us</router-link>
                <a href="#">Our Room Types</a>
                <a href="#">Services</a>
                <a href="#">Contact Us</a>
            </nav>
            <div class="right-section">
                <button class="booking-btn">BOOKING NOW</button>
            </div>
        </header>

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
                <img src="https://i.imgur.com/8qN8e9k.jpeg" alt="Service Quality Image">
            </div>
        </div>

        <!-- Section 2: Image and Text Split -->
        <div class="split-section">
            <div class="image-content">
                <img src="https://i.imgur.com/8qN8e9k.jpeg" alt="Service Quality Image">
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
                <img src="https://i.imgur.com/8qN8e9k.jpeg" alt="Service Quality Image">
            </div>
        </div>

        <!-- Section 4: Image and Text Split -->
        <div class="split-section">
            <div class="image-content">
                <img src="https://i.imgur.com/8qN8e9k.jpeg" alt="Service Quality Image">
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

        <!-- New Section: Satisfaction and Happiness -->
        <div class="satisfaction-section">
            <div class="pool-image">
                <img src="https://i.imgur.com/8qN8e9k.jpeg" alt="Pool Image">
            </div>
            <div class="text-content">
                <h2>Your satisfaction, Our happiness</h2>
                <p>Palace Long Hai Resort was awarded the ranking of ASEAN Quality Products - Services 2024 for its natural advantages as well as investment in numerous services and facilities for sightseeing and leisure, which have been highly embraced by travellers...</p>
            </div>
        </div>

        <!-- Footer -->
        <footer>
            <div class="footer-container">
                <div class="footer-column">
                    <h4>About Palace Long Hai Resort</h4>
                    <p>Palace Long Hai Resort is a luxurious 4-star resort located in the heart of Long Hai town, offering a perfect blend of privacy and vibrant experiences.</p>
                </div>
                <div class="footer-column">
                    <h4>Quick Links</h4>
                    <router-link to="/">Home</router-link>
                    <router-link to="/about">About Us</router-link>
                    <a href="#">Rooms</a>
                    <a href="#">Services</a>
                    <a href="#">Contact</a>
                </div>
                <div class="footer-column">
                    <h4>Contact Us</h4>
                    <p>Address: Long Hai Town, Ba Ria - Vung Tau, Vietnam</p>
                    <p>Phone: 0938 156 069</p>
                    <p>Email: info@palacelonghairesort.vn</p>
                </div>
            </div>
            <div class="footer-bottom">
                <p>© 2023 Palace Long Hai Resort. All rights reserved.</p>
            </div>
        </footer>
    </div>
</template>

<script>
export default {
    name: "AboutUs",
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
    beforeDestroy() {
        window.removeEventListener('scroll', this.handleScroll);
    }
};
</script>

<style scoped>
.about-us {
    background-color: #b9b9b9; /* Nền xanh lam nhạt */
    min-height: 100vh;
}

/* Header Styles */
header {
    background: transparent;
    padding: 10px 20px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    position: fixed;
    top: 0;
    width: 100%;
    height: 80px;
    z-index: 1000;
    transition: background-color 0.3s ease;
}

header.sticky {
    background-color: #d4a017;
}

.logo {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    color: white;
    text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.logo div {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.logo span {
    font-size: 22px; /* Tăng kích thước chữ logo lên 22px */
    font-weight: normal;
    margin-top: -2px;
}

.menu {
    display: flex;
    gap: 20px;
}

.menu a,
.menu router-link {
    color: white;
    text-decoration: none;
    font-size: 20px; /* Tăng kích thước chữ lên 20px */
    text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.menu a:hover,
.menu router-link:hover {
    text-decoration: underline;
}

.right-section {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
}

.booking-btn {
    background: white;
    color: #d4a017;
    border: 1px solid #d4a017;
    padding: 8px 15px;
    font-size: 20px; /* Tăng kích thước chữ lên 20px */
    font-weight: bold;
    text-transform: uppercase;
    cursor: pointer;
    transition: none;
}

/* Main Image Styles */
.main-image {
    width: 100%;
    height: 66.67vh; /* 2/3 chiều cao viewport */
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
    height: 50vh; /* Mỗi phần chiếm 1/2 chiều cao viewport */
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

/* Satisfaction Section Styles */
.satisfaction-section {
    display: flex;
    width: 75%;
    height: 50vh;
    margin: 100px auto; /* Căn giữa với margin: 0 auto và giữ khoảng cách trên/dưới */
    background-color: white;
}

.staff-image, .pool-image, .text-content {
    flex: 1;
    display: flex;
    justify-content: center;
    align-items: center;
}

.staff-image img, .pool-image img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}

.text-content h2 {
    font-size: 32px;
    color: #d4a017;
    font-weight: bold;
    text-align: center;
    margin-bottom: 10px;
}

.text-content p {
    font-size: 16px;
    color: #666;
    text-align: center;
    max-width: 80%;
    margin: 0 auto;
    line-height: 1.6;
}

/* Footer Styles */
footer {
    background-color: #3b5c5e;
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
    margin-bottom: 12px;
    display: block;
    line-height: 1.6;
    font-weight: 300;
}

.footer-column a:hover,
.footer-column router-link:hover {
    color: #fff;
}

.footer-column input {
    padding: 12px;
    border: none;
    border-radius: 5px;
    width: 100%;
    margin-bottom: 10px;
    font-size: 14px;
}

.footer-column button {
    background-color: #d4a017;
    color: white;
    border: none;
    padding: 12px 20px;
    border-radius: 5px;
    cursor: pointer;
    font-size: 14px;
    font-weight: bold;
}

.footer-column button:hover {
    background-color: #b88c14;
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

/* Responsive Styles */
@media (max-width: 768px) {
    header {
        padding: 10px 15px;
        height: 60px;
    }

    .logo span {
        font-size: 18px; /* Giảm kích thước logo trên mobile */
    }

    .menu {
        gap: 10px;
    }

    .menu a,
    .menu router-link {
        font-size: 16px; /* Giảm kích thước chữ trên mobile */
    }

    .booking-btn {
        font-size: 16px; /* Giảm kích thước chữ trên mobile */
        padding: 5px 10px;
    }

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

    .satisfaction-section {
        flex-direction: column;
        height: auto;
        width: 100%; /* Đảm bảo chiếm toàn bộ chiều rộng trên mobile */
        margin: 50px 0; /* Giảm khoảng cách trên mobile */
    }

    .staff-image img, .pool-image img {
        height: 300px;
    }

    .text-content h2 {
        font-size: 24px;
    }

    .text-content p {
        font-size: 14px;
    }

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