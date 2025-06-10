<template>
  <div class="login-container">
    <div class="background-overlay"></div>
    <div class="login-wrapper">
      <div class="login-content">
        <div class="login-header">
          <h2>Đăng Nhập</h2>
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
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600;700&family=Inter:wght@400;500;600&display=swap');

.login-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: url('https://palacelonghairesort.vn/wp-content/uploads/2024/12/palace-long-hai-resort-to-chuc-su-kien-8.jpg') no-repeat center center;
  background-size: cover;
  position: relative;
  padding: 20px;
  font-family: 'Inter', sans-serif;
}

.background-overlay {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: linear-gradient(135deg, rgba(0, 0, 0, 0.8) 0%, rgba(0, 0, 0, 0.6) 100%);
  backdrop-filter: blur(8px);
}

.login-wrapper {
  width: 100%;
  max-width: 480px;
  background: rgba(255, 255, 255, 0.95);
  border-radius: 24px;
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.3);
  backdrop-filter: blur(10px);
  overflow: hidden;
  animation: slideUp 0.6s ease-out;
  position: relative;
  z-index: 1;
  border: 1px solid rgba(255, 255, 255, 0.3);
}

.login-content {
  padding: 50px 40px;
}

.login-header {
  text-align: center;
  margin-bottom: 35px;
}

.login-header h2 {
  color: #1a1a1a;
  font-size: 32px;
  margin-bottom: 12px;
  font-weight: 700;
  letter-spacing: 0.5px;
  text-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  font-family: 'Montserrat', sans-serif;
}

.welcome-text {
  color: #666;
  font-size: 16px;
  margin-bottom: 25px;
  font-weight: 500;
  letter-spacing: 0.3px;
}

.form-group {
  margin-bottom: 25px;
  position: relative;
}

.form-group label {
  display: flex;
  align-items: center;
  margin-bottom: 12px;
  color: #333;
  font-weight: 600;
  font-size: 15px;
  letter-spacing: 0.3px;
  font-family: 'Montserrat', sans-serif;
}

.form-group label i {
  margin-right: 10px;
  color: #c4a35a;
  font-size: 16px;
  width: 20px;
  text-align: center;
}

.password-input {
  position: relative;
  width: 100%;
}

input[type="text"],
input[type="password"] {
  width: 100%;
  height: 50px;
  padding: 0 20px;
  border: 2px solid #e0e0e0;
  border-radius: 12px;
  font-size: 15px;
  transition: all 0.3s ease;
  background: #fff;
  color: #333;
  letter-spacing: 0.3px;
  box-sizing: border-box;
  font-family: 'Inter', sans-serif;
}

input[type="text"]:focus,
input[type="password"]:focus {
  border-color: #c4a35a;
  box-shadow: 0 0 0 3px rgba(196, 163, 90, 0.1);
  outline: none;
}

input[type="text"]::placeholder,
input[type="password"]::placeholder {
  color: #999;
  font-weight: 400;
  font-size: 14px;
  font-family: 'Inter', sans-serif;
}

.toggle-password {
  position: absolute;
  right: 15px;
  top: 50%;
  transform: translateY(-50%);
  background: none;
  border: none;
  color: #666;
  cursor: pointer;
  padding: 8px;
  transition: color 0.3s ease;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 40px;
  border-radius: 8px;
}

.toggle-password:hover {
  color: #c4a35a;
  background: rgba(196, 163, 90, 0.1);
}

.toggle-password i {
  font-size: 16px;
}

.form-options {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 30px 0;
  font-size: 14px;
  font-family: 'Inter', sans-serif;
}

.remember-me {
  display: flex;
  align-items: center;
  gap: 10px;
  color: #555;
  cursor: pointer;
  font-family: 'Inter', sans-serif;
}

.remember-me input[type="checkbox"] {
  width: 18px;
  height: 18px;
  accent-color: #c4a35a;
  cursor: pointer;
  margin: 0;
}

.forgot-password {
  color: #c4a35a;
  text-decoration: none;
  transition: all 0.3s ease;
  font-weight: 500;
  padding: 5px 10px;
  border-radius: 6px;
  font-family: 'Inter', sans-serif;
}

.forgot-password:hover {
  color: #a88a4a;
  background: rgba(196, 163, 90, 0.1);
  text-decoration: none;
}

.login-button {
  width: 100%;
  height: 50px;
  padding: 0;
  background: linear-gradient(45deg, #c4a35a, #d4b36a);
  color: white;
  border: none;
  border-radius: 12px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  position: relative;
  overflow: hidden;
  letter-spacing: 0.5px;
  text-transform: uppercase;
  display: flex;
  align-items: center;
  justify-content: center;
  font-family: 'Montserrat', sans-serif;
}

.login-button:hover {
  background: linear-gradient(45deg, #d4b36a, #c4a35a);
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(196, 163, 90, 0.2);
}

.login-button:disabled {
  background: #ccc;
  cursor: not-allowed;
  transform: none;
  box-shadow: none;
}

.loading-spinner {
  display: inline-block;
  width: 20px;
  height: 20px;
  border: 3px solid rgba(255, 255, 255, 0.3);
  border-radius: 50%;
  border-top-color: white;
  animation: spin 1s ease-in-out infinite;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}

.error-container {
  margin-top: 25px;
  padding: 15px;
  background: #fff2f0;
  border: 1px solid #ffccc7;
  border-radius: 12px;
  display: flex;
  align-items: flex-start;
  gap: 12px;
}

.error-container i {
  color: #ff4d4f;
  font-size: 18px;
  margin-top: 2px;
}

.error {
  color: #ff4d4f;
  font-size: 14px;
  margin: 0;
  font-weight: 500;
  font-family: 'Inter', sans-serif;
}

.error-detail {
  color: #666;
  font-size: 13px;
  margin: 5px 0 0 0;
  font-family: 'Inter', sans-serif;
}

@keyframes slideUp {
  from {
    opacity: 0;
    transform: translateY(30px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

/* Responsive styles */
@media (max-width: 480px) {
  .login-content {
    padding: 40px 25px;
  }

  .login-header h2 {
    font-size: 28px;
  }

  .welcome-text {
    font-size: 15px;
  }

  .form-group label {
    font-size: 14px;
  }

  input[type="text"],
  input[type="password"] {
    height: 45px;
    padding: 0 16px;
    font-size: 14px;
  }

  .form-options {
    font-size: 13px;
  }

  .login-button {
    height: 45px;
  }

  .toggle-password {
    width: 36px;
    height: 36px;
    padding: 6px;
  }
}
</style> 