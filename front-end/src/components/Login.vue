<template>
  <div class="login-container">
    <div class="background-overlay"></div>
    <div class="login-wrapper">
      <div class="login-content">
        <div class="login-header">
          <img src="https://palacelonghairesort.vn/wp-content/uploads/2024/12/logo-palace-long-hai-resort.png" alt="Palace Long Hai Resort" class="logo">
          <h2>Đăng nhập hệ thống</h2>
          <p class="welcome-text">Chào mừng bạn đến với Palace Long Hai Resort</p>
        </div>
        <form @submit.prevent="handleLogin" class="login-form">
          <div class="form-group">
            <label for="username">
              <i class="fas fa-user"></i>
              Tên đăng nhập
            </label>
            <input
              type="text"
              id="username"
              v-model="credentials.tenDangNhap"
              required
              autocomplete="username"
              :disabled="loading"
              placeholder="Nhập tên đăng nhập của bạn"
            />
          </div>
          <div class="form-group">
            <label for="password">
              <i class="fas fa-lock"></i>
              Mật khẩu
            </label>
            <div class="password-input">
              <input
                :type="showPassword ? 'text' : 'password'"
                id="password"
                v-model="credentials.matKhau"
                required
                autocomplete="current-password"
                :disabled="loading"
                placeholder="Nhập mật khẩu của bạn"
              />
              <button 
                type="button" 
                class="toggle-password"
                @click="togglePassword"
                :disabled="loading"
                :title="showPassword ? 'Ẩn mật khẩu' : 'Hiện mật khẩu'"
              >
                <i :class="showPassword ? 'fas fa-eye-slash' : 'fas fa-eye'"></i>
              </button>
            </div>
          </div>
          <div class="form-options">
            <label class="remember-me">
              <input 
                type="checkbox" 
                v-model="rememberMe"
                :disabled="loading"
              >
              <span>Ghi nhớ đăng nhập</span>
            </label>
            <router-link to="/forgot-password" class="forgot-password">
              Quên mật khẩu?
            </router-link>
          </div>
          <button type="submit" class="login-button" :disabled="loading || !isFormValid">
            <span v-if="loading" class="loading-spinner"></span>
            <span v-else>Đăng nhập</span>
          </button>
          <div v-if="error" class="error-container">
            <i class="fas fa-exclamation-circle"></i>
            <p class="error">{{ error }}</p>
            <p class="error-detail" v-if="errorDetail">{{ errorDetail }}</p>
          </div>
        </form>
      </div>
    </div>
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
    const rememberMe = ref(false);

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

    const handleForgotPassword = () => {
      router.push('/forgot-password');
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
          
          // Nếu remember me được chọn, lưu thông tin đăng nhập
          if (rememberMe.value) {
            localStorage.setItem('rememberedUser', JSON.stringify({
              tenDangNhap: credentials.value.tenDangNhap
            }));
          } else {
            localStorage.removeItem('rememberedUser');
          }
          
          // Chuyển hướng dựa vào role của user
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

    // Kiểm tra remembered user khi component được mount
    const checkRememberedUser = () => {
      const rememberedUser = localStorage.getItem('rememberedUser');
      if (rememberedUser) {
        const { tenDangNhap } = JSON.parse(rememberedUser);
        credentials.value.tenDangNhap = tenDangNhap;
        rememberMe.value = true;
      }
    };

    // Gọi hàm kiểm tra khi component được mount
    checkRememberedUser();

    return {
      credentials,
      loading,
      error,
      errorDetail,
      handleLogin,
      showPassword,
      togglePassword,
      isFormValid,
      rememberMe,
      handleForgotPassword
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
  background: url('https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-8.jpg') no-repeat center center;
  background-size: cover;
  position: relative;
  padding: 20px;
}

.background-overlay {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: linear-gradient(135deg, rgba(0, 0, 0, 0.7) 0%, rgba(0, 0, 0, 0.5) 100%);
  backdrop-filter: blur(5px);
}

.login-wrapper {
  width: 100%;
  max-width: 450px;
  background: rgba(255, 255, 255, 0.95);
  border-radius: 20px;
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.2);
  backdrop-filter: blur(10px);
  overflow: hidden;
  animation: slideUp 0.5s ease-out;
  position: relative;
  z-index: 1;
  border: 1px solid rgba(255, 255, 255, 0.2);
}

.login-content {
  padding: 40px;
}

.login-header {
  text-align: center;
  margin-bottom: 40px;
}

.logo {
  width: 200px;
  height: auto;
  margin-bottom: 20px;
  filter: drop-shadow(0 2px 4px rgba(0, 0, 0, 0.1));
}

.login-header h2 {
  color: #333;
  font-size: 28px;
  margin-bottom: 10px;
  font-weight: 600;
  text-shadow: 0 1px 2px rgba(0, 0, 0, 0.1);
}

.welcome-text {
  color: #666;
  font-size: 16px;
  margin-bottom: 30px;
}

.form-group {
  margin-bottom: 25px;
}

.form-group label {
  display: flex;
  align-items: center;
  margin-bottom: 8px;
  color: #555;
  font-weight: 500;
  font-size: 16px;
}

.form-group label i {
  margin-right: 8px;
  color: #d4a017;
}

.password-input {
  position: relative;
}

input {
  width: 100%;
  padding: 12px 15px;
  border: 2px solid #e1e1e1;
  border-radius: 10px;
  font-size: 16px;
  transition: all 0.3s ease;
  background: rgba(255, 255, 255, 0.9);
}

input:focus {
  outline: none;
  border-color: #d4a017;
  box-shadow: 0 0 0 3px rgba(212, 160, 23, 0.1);
  background: #fff;
}

input::placeholder {
  color: #999;
}

.toggle-password {
  position: absolute;
  right: 12px;
  top: 50%;
  transform: translateY(-50%);
  background: none;
  border: none;
  color: #666;
  cursor: pointer;
  padding: 5px;
  transition: color 0.3s ease;
}

.toggle-password:hover {
  color: #d4a017;
}

.login-button {
  width: 100%;
  padding: 14px;
  background: linear-gradient(135deg, #d4a017 0%, #b88a15 100%);
  color: white;
  border: none;
  border-radius: 10px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  position: relative;
  overflow: hidden;
  box-shadow: 0 4px 15px rgba(212, 160, 23, 0.2);
}

.login-button:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(212, 160, 23, 0.3);
  background: linear-gradient(135deg, #b88a15 0%, #d4a017 100%);
}

.login-button:disabled {
  background: #ccc;
  cursor: not-allowed;
  box-shadow: none;
}

.loading-spinner {
  display: inline-block;
  width: 20px;
  height: 20px;
  border: 3px solid rgba(255, 255, 255, 0.3);
  border-radius: 50%;
  border-top-color: #fff;
  animation: spin 1s ease-in-out infinite;
}

.error-container {
  margin-top: 20px;
  padding: 15px;
  border-radius: 10px;
  background-color: rgba(255, 245, 245, 0.9);
  border: 1px solid #fed7d7;
  display: flex;
  align-items: flex-start;
  gap: 10px;
  backdrop-filter: blur(5px);
}

.error-container i {
  color: #e53e3e;
  font-size: 20px;
  margin-top: 2px;
}

.error {
  color: #e53e3e;
  margin: 0;
  font-weight: 600;
  font-size: 15px;
}

.error-detail {
  color: #c53030;
  margin: 5px 0 0;
  font-size: 14px;
}

@keyframes slideUp {
  from {
    opacity: 0;
    transform: translateY(20px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}

@media (max-width: 480px) {
  .login-content {
    padding: 30px 20px;
  }

  .logo {
    width: 150px;
  }

  .login-header h2 {
    font-size: 24px;
  }

  input {
    font-size: 15px;
  }

  .login-button {
    padding: 12px;
  }
}

.form-options {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 25px;
  font-size: 14px;
}

.remember-me {
  display: flex;
  align-items: center;
  gap: 8px;
  color: #666;
  cursor: pointer;
}

.remember-me input[type="checkbox"] {
  width: 16px;
  height: 16px;
  margin: 0;
  cursor: pointer;
  accent-color: #d4a017;
}

.forgot-password {
  color: #d4a017;
  text-decoration: none;
  transition: all 0.3s ease;
  font-weight: 500;
  padding: 5px 10px;
  border-radius: 5px;
}

.forgot-password:hover {
  color: #b88a15;
  background-color: rgba(212, 160, 23, 0.1);
  text-decoration: none;
}
</style> 