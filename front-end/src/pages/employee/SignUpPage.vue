<template>
  <div class="auth-container">
    <div class="form-section">
      <h2>Log In</h2>
      <div class="form-group">
        <label for="email" class="input-label">Email address</label>
        <input id="email" v-model="email" type="email" placeholder="Enter your email" />
      </div>
      <div class="form-group">
        <label for="password" class="input-label">Password</label>
        <input id="password" v-model="password" type="password" placeholder="Enter your password" />
      </div>
      <button @click="handleLogin">Log In</button>
      <p>
        Forgot your password?
        <router-link to="/forgot-password">Reset it</router-link>
      </p>
      <p>
        Don't have an account?
        <router-link to="/create-account">Create one</router-link>
      </p>
    </div>
    <div class="image-section">
      <img src="https://i.pinimg.com/736x/41/52/1a/41521a5841f178c2a0cc33e956f47f01.jpg" alt="Login Image" />
    </div>
  </div>
</template>

<script>
import apiClient from '@/services/api';

export default {
  data() {
    return {
      email: '',
      password: '',
    };
  },
  methods: {
    async handleLogin() {
      if (!this.email || !this.password) {
        alert('Please fill in all fields');
        return;
      }
      try {
        const response = await apiClient.post('/api/TaiKhoan/login', {
          tenDangNhap: this.email,
          matKhau: this.password,
        });
         console.log('Login response:', response.data); 
        // Lưu token nếu có
        if (response.data && response.data.token) {
          localStorage.setItem('token', response.data.token);
        }
        alert('Login successful!');
        this.$router.push('/dashboard');
      } catch (error) {
        alert('Login failed: ' + (error.response?.data?.message || error.message));
      }
    },
  },
};
</script>

<style>
.auth-container {
  display: flex;
  height: 100vh;
  width: 100%;
}
.form-section {
  flex: 1;
  padding: 3rem;
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
  background-color: #fff;
  justify-content: center;
}
.form-section h2 {
  font-size: 2rem;
  font-weight: 700;
  color: #000;
}
.form-group {
  display: flex;
  flex-direction: column;
  gap: 0.25rem;
}
.form-section .input-label {
  font-size: 1rem;
  font-weight: 600;
  color: #333;  
}
.form-section input[type="email"],
.form-section input[type="password"] {
  padding: 0.75rem;
  border: 1px solid #d1d5db;
  border-radius: 0.5rem;
  font-size: 1rem;
  width: 100%;
  box-sizing: border-box;
  text-align: left;
}
.form-section input::placeholder {
  color: #a0aec0;
  text-align: left;
}
.form-section button {
  padding: 0.75rem;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 0.5rem;
  font-size: 1rem;
  cursor: pointer;
  width: 100%;
}
.form-section button:hover {
  background-color: #45a049;
}
.form-section p {
  text-align: center;
  font-size: 0.875rem;
  color: #374151;
}
.form-section a {
  color: #2563eb;
  text-decoration: none;
}
.form-section a:hover {
  text-decoration: underline;
}
.image-section {
  flex: 1;
  background-color: #f5f5f5;
}
.image-section img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}
</style>