import axios from 'axios';

// Tạo instance của axios với cấu hình mặc định
const apiClient = axios.create({
    baseURL: 'http://localhost:5012', // URL của .NET backend
    headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
    },
    withCredentials: true // Cho phép gửi cookies trong các request
});

// Interceptor cho request
apiClient.interceptors.request.use(
    config => {
        // Log request details
        console.log('Request details:', {
            url: `${config.baseURL}${config.url}`,
            method: config.method?.toUpperCase(),
            headers: config.headers,
            data: config.data ? JSON.stringify(config.data) : undefined
        });

        // Thêm token vào header nếu có
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    error => {
        console.error('Request error:', error);
        return Promise.reject(error);
    }
);

// Interceptor cho response
apiClient.interceptors.response.use(
    response => {
        // Log response details
        console.log('Response details:', {
            status: response.status,
            statusText: response.statusText,
            headers: response.headers,
            data: response.data
        });
        return response;
    },
    error => {
        // Log error details
        if (error.response) {
            console.error('Response error:', {
                status: error.response.status,
                statusText: error.response.statusText,
                headers: error.response.headers,
                data: error.response.data
            });

            // Xử lý các lỗi cụ thể
            switch (error.response.status) {
                case 401:
                    console.error('Unauthorized - Invalid credentials or token');
                    // Xóa token và thông tin user nếu hết hạn
                    localStorage.removeItem('token');
                    localStorage.removeItem('user');
                    break;
                case 403:
                    console.error('Forbidden - Access denied');
                    break;
                case 404:
                    console.error('Not found - Resource not available');
                    break;
                case 500:
                    console.error('Server error:', error.response.data);
                    break;
                default:
                    console.error('Other error:', error.response.data);
                    break;
            }
        } else if (error.request) {
            console.error('No response received:', {
                request: error.request,
                config: error.config
            });
        } else {
            console.error('Error setting up request:', error.message);
        }
        return Promise.reject(error);
    }
);

// Test connection function
export const testConnection = async () => {
    try {
        const response = await apiClient.get('/api/health');
        console.log('API connection test successful:', response.data);
        return true;
    } catch (error) {
        console.error('API connection test failed:', error);
        return false;
    }
};

export default apiClient; 