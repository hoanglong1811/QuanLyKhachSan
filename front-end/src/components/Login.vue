<template>
  <div class="login-container">
    <form @submit.prevent="handleLogin" class="login-form">
      <h2>Đăng nhập</h2>
      <div class="form-group">
        <label for="username">Tên đăng nhập:</label>
        <input
          type="text"
          id="username"
          v-model="credentials.username"
          required
        />
      </div>
      <div class="form-group">
        <label for="password">Mật khẩu:</label>
        <input
          type="password"
          id="password"
          v-model="credentials.password"
          required
        />
      </div>
      <button type="submit" :disabled="loading">
        {{ loading ? 'Đang đăng nhập...' : 'Đăng nhập' }}
      </button>
      <p v-if="error" class="error">{{ error }}</p>
    </form>
  </div>
</template>

<script>
import { ref } from 'vue';
import { authService } from '../services/authService';
import { useRouter } from 'vue-router';

export default {
  name: 'LoginComponent',
  setup() {
    const router = useRouter();
    const credentials = ref({
      username: '',
      password: ''
    });
    const loading = ref(false);
    const error = ref('');

    const handleLogin = async () => {
      try {
        loading.value = true;
        error.value = '';
        const response = await authService.login({
          tenDangNhap: credentials.value.username,
          matKhau: credentials.value.password
        });
        
        // Lưu thông tin người dùng vào localStorage nếu cần
        localStorage.setItem('user', JSON.stringify(response));
        
        // Chuyển hướng đến trang dashboard sau khi đăng nhập thành công
        router.push('/dashboard');
      } catch (err) {
        error.value = err.response?.data?.message || 'Có lỗi xảy ra khi đăng nhập';
        console.error('Login error:', err);
      } finally {
        loading.value = false;
      }
    };

    return {
      credentials,
      loading,
      error,
      handleLogin
    };
  }
};
</script>

<style scoped>
.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f5f5f5;
}

.login-form {
  background: white;
  padding: 2rem;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 100%;
  max-width: 400px;
}

.form-group {
  margin-bottom: 1rem;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: bold;
}

input {
  width: 100%;
  padding: 0.5rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
}

button {
  width: 100%;
  padding: 0.75rem;
  background-color: #4CAF50;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 1rem;
  cursor: pointer;
}

button:disabled {
  background-color: #cccccc;
  cursor: not-allowed;
}

.error {
  color: red;
  margin-top: 1rem;
  text-align: center;
}
</style> 