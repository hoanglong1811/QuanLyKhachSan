<template>
  <div class="auth-container">
    <div class="form-section">
      <h2>Enter OTP</h2>
      <div class="form-group">
        <label for="otp" class="input-label">OTP Code</label>
        <input id="otp" v-model="otp" type="text" placeholder="Enter your OTP" />
      </div>
      <button @click="handleVerifyOTP">Verify OTP</button>
      <p>
        Back to
        <router-link to="/forgot-password">Forgot Password</router-link>
      </p>
    </div>
    <div class="image-section">
      <img src="https://i.pinimg.com/736x/41/52/1a/41521a5841f178c2a0cc33e956f47f01.jpg" alt="OTP Image" />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      otp: '',
    };
  },
  methods: {
    handleVerifyOTP() {
      if (!this.otp) {
        alert('Please enter the OTP code');
        return;
      }
      alert('OTP verified! (Simulated)');
      this.$router.push('/reset-password');
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
.form-section input[type="text"] {
  padding: 0.75rem;
  border: 1px solid #d1d5db;
  border-radius: 0.5rem;
  font-size: 1rem;
  width: 100%;
  box-sizing: border-box;
  text-align: center;
}
.form-section input::placeholder {
  color: #a0aec0;
  text-align: center;
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