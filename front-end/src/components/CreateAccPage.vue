<template>
  <div class="auth-container">
    <div class="form-section">
      <h2>Get Started Now</h2>
      <input v-model="name" type="text" placeholder="Name" />
      <input v-model="email" type="email" placeholder="Email address" />
      <input v-model="password" type="password" placeholder="Password" />
      <label>
        <input v-model="agreeToTerms" type="checkbox" />
        I agree to the terms & policy
      </label>
      <button @click="handleSignUp">Sign Up</button>
      <p>
        Have an account?
        <router-link to="/login">Sign in</router-link>
      </p>
    </div>
    <div class="image-section">
      <!-- Image placeholder: Add your image here -->
      <img src="https://i.pinimg.com/736x/c0/4f/fe/c04ffe886029e6b3702d9a07eec13a7c.jpg" alt="Sign Up Image" />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: '',
      email: '',
      password: '',
      agreeToTerms: false,
    };
  },
  methods: {
    handleSignUp() {
      if (!this.name || !this.email || !this.password) {
        alert('Please fill in all fields');
        return;
      }
      if (!this.agreeToTerms) {
        alert('You must agree to the terms & policy to sign up');
        return;
      }
      alert('Sign Up successful! (Simulated)');
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
.form-section input[type="text"],
.form-section input[type="email"],
.form-section input[type="password"] {
  padding: 0.75rem;
  border: 1px solid #d1d5db;
  border-radius: 0.5rem;
  font-size: 1rem;
  width: 100%;
  box-sizing: border-box;
}
.form-section label {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  font-size: 0.875rem;
  color: #374151;
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