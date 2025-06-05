<template>
  <div class="login-container">
    <form @submit.prevent="handleLogin" class="login-form">
      <h2>Đăng nhập</h2>
      <div class="form-group">
        <label for="username">Tên đăng nhập:</label>
        <input
          type="text"
          id="username"
          v-model="credentials.tenDangNhap"
          required
          autocomplete="username"
          :disabled="loading"
        />
      </div>
      <div class="form-group">
        <label for="password">Mật khẩu:</label>
        <div class="password-input">
          <input
            :type="showPassword ? 'text' : 'password'"
            id="password"
            v-model="credentials.matKhau"
            required
            autocomplete="current-password"
            :disabled="loading"
          />
          <button 
            type="button" 
            class="toggle-password"
            @click="togglePassword"
            :disabled="loading"
          >
            {{ showPassword ? '🔒' : '👁️' }}
          </button>
        </div>
      </div>
      <button type="submit" :disabled="loading || !isFormValid">
        {{ loading ? 'Đang đăng nhập...' : 'Đăng nhập' }}
      </button>
      <div v-if="error" class="error-container">
        <p class="error">{{ error }}</p>
        <p class="error-detail" v-if="errorDetail">{{ errorDetail }}</p>
      </div>
    </form>
  </div>
</template>

<script>
import { ref, computed } from 'vue';
import { authService } from '../services/authService';
import { useRouter } from 'vue-router';

export default {
  name: 'LoginComponent',
  setup() {
    const router = useRouter();
    const credentials = ref({
      tenDangNhap: '',
      matKhau: ''
    });
    const loading = ref(false);
    const error = ref('');
    const errorDetail = ref('');
    const showPassword = ref(false);

    const isFormValid = computed(() => {
      return credentials.value.tenDangNhap.length > 0 && 
             credentials.value.matKhau.length > 0;
    });

    const togglePassword = () => {
      showPassword.value = !showPassword.value;
    };

    const clearErrors = () => {
      error.value = '';
      errorDetail.value = '';
    };

    const handleLogin = async () => {
      try {
        clearErrors();
        loading.value = true;

        if (!isFormValid.value) {
          error.value = 'Vui lòng nhập đầy đủ thông tin đăng nhập';
          return;
        }

        const response = await authService.login({
          tenDangNhap: credentials.value.tenDangNhap,
          matKhau: credentials.value.matKhau
        });

        if (response && response.token) {
          // Lưu thông tin user
          localStorage.setItem('user', JSON.stringify(response));
          
          // Chuyển hướng dựa vào role của user (nếu có)
          const redirectPath = response.role === 'admin' ? '/admin/dashboard' : '/dashboard';
          router.push(redirectPath);
        } else {
          error.value = 'Đăng nhập thất bại';
          errorDetail.value = 'Không nhận được token từ server';
        }
      } catch (err) {
        console.error('Login error:', err);
        
        if (!navigator.onLine) {
          error.value = 'Không thể kết nối đến server';
          errorDetail.value = 'Vui lòng kiểm tra kết nối internet của bạn';
        } else if (err.response) {
          switch (err.response.status) {
            case 401:
              error.value = 'Sai tên đăng nhập hoặc mật khẩu';
              break;
            case 403:
              error.value = 'Tài khoản của bạn đã bị khóa';
              break;
            case 404:
              error.value = 'Không tìm thấy tài khoản';
              break;
            case 500:
              error.value = 'Lỗi server';
              errorDetail.value = 'Vui lòng thử lại sau';
              break;
            default:
              error.value = 'Đăng nhập thất bại';
              errorDetail.value = err.response.data?.message || 'Vui lòng thử lại';
          }
        } else if (err.request) {
          error.value = 'Không thể kết nối đến server';
          errorDetail.value = 'Server có thể đang bảo trì, vui lòng thử lại sau';
        } else {
          error.value = 'Có lỗi xảy ra';
          errorDetail.value = err.message;
        }
      } finally {
        loading.value = false;
      }
    };

    return {
      credentials,
      loading,
      error,
      errorDetail,
      handleLogin,
      showPassword,
      togglePassword,
      isFormValid
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

.password-input {
  position: relative;
  display: flex;
  align-items: center;
}

.toggle-password {
  position: absolute;
  right: 10px;
  background: none;
  border: none;
  cursor: pointer;
  padding: 0;
  font-size: 1.2rem;
}

.toggle-password:disabled {
  cursor: not-allowed;
  opacity: 0.6;
}

label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: bold;
  color: #333;
}

input {
  width: 100%;
  padding: 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 1rem;
  transition: border-color 0.3s;
}

input:focus {
  outline: none;
  border-color: #4CAF50;
  box-shadow: 0 0 0 2px rgba(76, 175, 80, 0.2);
}

input:disabled {
  background-color: #f5f5f5;
  cursor: not-allowed;
}

button[type="submit"] {
  width: 100%;
  padding: 0.75rem;
  background-color: #4CAF50;
  color: white;
  border: none;
  border-radius: 4px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s;
}

button[type="submit"]:hover:not(:disabled) {
  background-color: #45a049;
}

button[type="submit"]:disabled {
  background-color: #cccccc;
  cursor: not-allowed;
}

.error-container {
  margin-top: 1rem;
  padding: 1rem;
  border-radius: 4px;
  background-color: #ffebee;
  border: 1px solid #ffcdd2;
}

.error {
  color: #c62828;
  margin: 0;
  font-weight: bold;
}

.error-detail {
  color: #ef5350;
  margin: 0.5rem 0 0;
  font-size: 0.9rem;
}
</style> 