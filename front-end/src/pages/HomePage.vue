<template>
    <div class="main-image">
        <img src="https://i.pinimg.com/736x/d6/dd/5f/d6dd5fd0c2428fa3200ce69a932eecdd.jpg" alt="Main Image">
    </div>
    <header :class="{ 'sticky': isScrolled }">
        <div class="menu-toggle" @click="toggleMenu">
            <i class="fas fa-bars"></i>
        </div>
        <div class="contact">
            <i class="fas fa-phone-alt"></i>
            <span>0938 156 069</span>
        </div>
        <div class="menu-dropdown" v-if="showMenu">
            <router-link to="/">Home</router-link>
            <router-link to="/about">About Us</router-link>
            <a href="#">Our Room Types</a>
            <a href="#">Services</a>
            <a href="#">Contact Us</a>
        </div>
        <div class="logo">
            <div>
                <span>PLACE</span>
                <span>LONG HAI RESORT</span>
            </div>
        </div>
        <div class="right-section">
            <div class="language">
                <i class="fas fa-globe"></i>
                <span>English</span>
                <i class="fas fa-chevron-down"></i>
            </div>
            <button class="booking-btn">BOOKING NOW</button>
        </div>
    </header>

    <div class="main-content">
        <div class="service-section">
            <div class="service-item" @mouseover="showDescription(0)" @mouseleave="hideDescription(0)">
                <img src="https://i.pinimg.com/736x/68/74/08/687408d95f45c04ed6010235d04bc3d1.jpg" alt="Green Place">
                <div class="service-overlay">A GREEN FRESH PLACE</div>
                <div class="service-description" v-show="descriptions[0].show">
                    Enjoy a serene environment surrounded by lush greenery and fresh air, perfect for relaxation.
                </div>
            </div>
            <div class="service-item" @mouseover="showDescription(1)" @mouseleave="hideDescription(1)">
                <img src="https://i.pinimg.com/736x/0c/6c/3d/0c6c3df6eacfd2c22cf7af112e3f7f51.jpg" alt="Service Heart">
                <div class="service-overlay">SERVICE FROM THE HEART</div>
                <div class="service-description" v-show="descriptions[1].show">
                    Experience heartfelt hospitality with our dedicated staff ensuring your every need is met.
                </div>
            </div>
            <div class="service-item" @mouseover="showDescription(2)" @mouseleave="hideDescription(2)">
                <img src="https://i.pinimg.com/736x/93/90/c2/9390c2e81bb38832bed5b107efc6ee8b.jpg" alt="Private Vibrant">
                <div class="service-overlay">BOTH PRIVATE AND VIBRANT</div>
                <div class="service-description" v-show="descriptions[2].show">
                    Enjoy privacy with vibrant activities and stunning views, ideal for all types of travelers.
                </div>
            </div>
        </div>

        <div class="booking-form">
            <div class="form-item">
                <label>CHECK-IN</label>
                <input type="date">
            </div>
            <div class="form-item">
                <label>CHECK-OUT</label>
                <input type="date">
            </div>
            <div class="form-item">
                <label>ROOMS</label>
                <select>
                    <option>01 Room</option>
                    <option>02 Rooms</option>
                    <option>03 Rooms</option>
                </select>
            </div>
            <div class="form-item">
                <label>ADULTS</label>
                <select>
                    <option>01 Adult</option>
                    <option>02 Adults</option>
                    <option>03 Adults</option>
                </select>
            </div>
            <div class="form-item">
                <label>CHILDREN</label>
                <select>
                    <option>0 Children</option>
                    <option>1 Child</option>
                    <option>2 Children</option>
                </select>
            </div>
            <div class="form-item">
                <button class="check-availability">CHECK AVAILABILITY</button>
            </div>
        </div>

        <footer>
            <div class="footer-container">
                <div class="footer-column">
                    <h4>About Palace Long Hai Resort</h4>
                    <p>Palace Long Hai Resort is a luxurious 4-star resort located in the heart of Long Hai town, offering a perfect blend of privacy and vibrant experiences.</p>
                </div>
                <div class="footer-column">
                    <h4>Quick Links</h4>
                    <a href="#">Home</a>
                    <a href="#">About Us</a>
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
                <div class="footer-column">
                    <h4>Newsletter</h4>
                    <input type="email" placeholder="Enter your email">
                    <button>Subscribe</button>
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
    name: "HomePage",
    data() {
        return {
            showMenu: false,
            descriptions: [
                { show: false },
                { show: false },
                { show: false }
            ],
            isScrolled: false
        };
    },
    methods: {
        toggleMenu() {
            this.showMenu = !this.showMenu;
        },
        showDescription(index) {
            this.descriptions[index].show = true;
        },
        hideDescription(index) {
            this.descriptions[index].show = false;
        },
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
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
    font-family: 'Arial', sans-serif;
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

.menu-toggle {
    font-size: 24px;
    cursor: pointer;
    color: white;
    margin-left: 30px;
}

.contact {
    display: flex;
    align-items: center;
    gap: 8px;
    font-size: 22px;
    color: white;
    margin-right: 1200px;
}

.contact i {
    font-size: 22px;
}

.menu-dropdown {
    position: absolute;
    top: 100%;
    left: 20px;
    background-color: #d4a017;
    color: white;
    padding: 10px;
    border-radius: 5px;
    display: flex;
    flex-direction: column;
    gap: 5px;
    z-index: 1001;
}

.menu-dropdown a,
.menu-dropdown router-link {
    color: white;
    text-decoration: none;
    font-size: 22px;
}

.menu-dropdown a:hover,
.menu-dropdown router-link:hover {
    text-decoration: underline;
}

.logo {
    display: flex;
    align-items: center;
    gap: 10px;
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
    color: white;
    text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.logo i {
    font-size: 16px;
}

.logo div {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.logo span {
    font-size: 20px;
    font-weight: normal;
    margin-top: -2px;
}

.right-section {
    display: flex;
    align-items: center;
    gap: 20px;
}

.language {
    display: flex;
    align-items: center;
    gap: 6px;
    font-size: 20px;
    cursor: pointer;
    color: white;
    text-shadow: 1px 1px 5px rgba(0, 0, 0, 0.7);
}

.language i {
    font-size: 22px;
}

.booking-btn {
    background-color: transparent;
    background: white;
    color: #d4a017;
    border: 2px solid #d4a017;
    padding: 8px 15px;
    font-size: 20px;
    font-weight: bold;
    text-transform: uppercase;
    cursor: pointer;
    transition: none;
}

/* Main Image Styles */
.main-image {
    width: 100%;
    height: 100vh;
    overflow: hidden;
    position: relative;
    z-index: 1;
}

.main-image img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}

/* Main Content Styles */
.main-content {
    position: relative;
    z-index: 2;
}

/* Service Section Styles */
.service-section {
    display: flex;
    justify-content: center;
    gap: 30px;
    padding: 50px 20px;
    max-width: 1200px;
    margin: 0 auto;
}

.service-item {
    position: relative;
    width: 33.33%;
    text-align: center;
    transition: transform 0.3s ease;
}

.service-item:hover {
    transform: scale(1.1);
}

.service-item img {
    width: 100%;
    height: 400px;
    object-fit: cover;
    border-radius: 10px;
}

.service-overlay {
    position: absolute;
    bottom: 20px;
    left: 0;
    right: 0;
    background: rgba(0, 0, 0, 0.5);
    color: white;
    padding: 10px;
    font-size: 20px;
    font-weight: bold;
    text-align: center;
}

.service-description {
    position: absolute;
    top: 50%;
    left: 0;
    right: 0;
    background: rgba(0, 0, 0, 0.7);
    color: white;
    padding: 20px;
    font-size: 16px;
    text-align: center;
    transform: translateY(-50%);
    display: none;
}

.service-item:hover .service-description {
    display: block;
}

/* Booking Form Styles */
.booking-form {
    background-color: #d4a017;
    padding: 15px 20px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    margin: 0;
    height: 150px; /* Chiều cao cố định 150px */
}

.form-item {
    flex: 1;
    text-align: center;
    margin: 0 5px;
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.form-item label {
    display: block;
    color: white;
    font-size: 12px;
    margin-bottom: 8px;
    text-transform: uppercase;
}

/* Đẩy label của Rooms, Adults, Children sang bên phải */
.form-item:nth-child(3) label,
.form-item:nth-child(4) label,
.form-item:nth-child(1) label,
.form-item:nth-child(2) label,
.form-item:nth-child(5) label {
    text-align: left;
}

.form-item input,
.form-item select {
    padding: 8px;
    border: none;
    border-radius: 4px;
    font-size: 14px;
    background-color: white;
    width: 100%;
    text-align: left;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

/* Tùy chỉnh input type="date" để hiển thị lịch */
.form-item input[type="date"] {
    appearance: none;
    -webkit-appearance: none;
    -moz-appearance: none;
    padding-right: 10px;
}

/* Tùy chỉnh mũi tên của select */
.form-item select {
    appearance: none;
    -webkit-appearance: none;
    -moz-appearance: none;
    background: url('data:image/svg+xml;utf8,<svg fill="black" height="24" viewBox="0 0 24 24" width="24" xmlns="http://www.w3.org/2000/svg"><path d="M7 10l5 5 5-5z"/></svg>') no-repeat;
    background-position: right 10px center;
    background-size: 12px;
    padding-right: 30px;
}

.check-availability {
    background-color: white;
    color: #d4a017;
    border: 2px solid #d4a017;
    padding: 8px 16px;
    border-radius: 50%;
    font-size: 12px;
    font-weight: 700;
    cursor: pointer;
    width: 100px;
    height: 100px;
    display: flex;
    align-items: center;
    justify-content: center;
    text-transform: uppercase;
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
.footer-column a {
    font-size: 14px;
    color: #d1d1d1;
    text-decoration: none;
    margin-bottom: 12px;
    display: block;
    line-height: 1.6;
    font-weight: 300;
}

.footer-column a:hover {
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

    .menu-toggle {
        font-size: 18px;
    }

    .contact {
        font-size: 12px;
    }

    .contact i {
        font-size: 12px;
    }

    .logo {
        font-size: 20px;
    }

    .logo span {
        font-size: 10px;
    }

    .language, .booking-btn {
        font-size: 12px;
    }

    .language i {
        font-size: 12px;
    }

    .booking-btn {
        padding: 5px 10px;
    }

    .main-image {
        height: 50vh;
    }

    .service-section {
        flex-direction: column;
        padding: 30px 15px;
    }

    .service-item {
        width: 100%;
        margin-bottom: 20px;
    }

    .service-item img {
        height: 300px;
    }

    .booking-form {
        flex-direction: column;
        gap: 10px;
        padding: 15px;
        height: auto; /* Để chiều cao tự động trên mobile */
        align-items: center;
    }

    .form-item {
        width: 100%;
        margin: 0 0 10px 0;
    }

    .form-item input,
    .form-item select {
        width: 100%;
    }

    .check-availability {
        width: 50px;
        height: 50px;
        margin: 0 auto;
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