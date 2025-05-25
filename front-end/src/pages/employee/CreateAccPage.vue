<template>
  <div class="auth-container">
    <div class="form-section">
      <h2>Get Started Now</h2>
      <div class="form-group">
        <label for="name" class="input-label">Name</label>
        <input id="name" v-model="name" type="text" placeholder="Enter your name" />
      </div>
      <div class="form-group">
        <label for="email" class="input-label">Email address</label>
        <input id="email" v-model="email" type="email" placeholder="Enter your email" />
      </div>
      <div class="form-group">
        <label for="password" class="input-label">Password</label>
        <input id="password" v-model="password" type="password" placeholder="Enter your password" />
      </div>
      <label class="checkbox-label">
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
      <img src="https://i.pinimg.com/736x/41/52/1a/41521a5841f178c2a0cc33e956f47f01.jpg" alt="Sign Up Image" />
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
.form-section .checkbox-label {
  display: flex;
  align-items: center;
  gap: 0.5rem;
  font-size: 0.875rem;
  color: #374151;
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
  text-align: left;
}
.form-section input::placeholder {
  color: #a0aec0;
   /* Changed from center to right */
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