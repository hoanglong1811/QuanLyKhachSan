<template>
  <div class="auth-container">
    <div class="form-section">
      <h2>Reset Password</h2>
      <div class="form-group">
        <label for="newPassword" class="input-label">New Password</label>
        <input id="newPassword" v-model="newPassword" type="password" placeholder="Enter your new password" />
      </div>
      <div class="form-group">
        <label for="confirmPassword" class="input-label">Confirm Password</label>
        <input id="confirmPassword" v-model="confirmPassword" type="password" placeholder="Confirm your password" />
      </div>
      <button @click="handleResetPassword">Reset Password</button>
      <p>
        Back to
        <router-link to="/login">Log In</router-link>
      </p>
    </div>
    <div class="image-section">
      <img src="https://i.pinimg.com/736x/c0/4f/fe/c04ffe886029e6b3702d9a07eec13a7c.jpg" alt="Reset Password Image" />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newPassword: '',
      confirmPassword: '',
    };
  },
  methods: {
    handleResetPassword() {
      if (!this.newPassword || !this.confirmPassword) {
        alert('Please fill in all fields');
        return;
      }
      if (this.newPassword !== this.confirmPassword) {
        alert('Passwords do not match');
        return;
      }
      alert('Password reset successful! (Simulated)');
      this.$router.push('/login');
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
.form-section input[type="password"] {
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