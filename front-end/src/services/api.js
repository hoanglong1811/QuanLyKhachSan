import axios from 'axios';

// Tạo instance của axios với cấu hình mặc định
const apiClient = axios.create({
    baseURL: 'https://localhost:7095', // URL của .NET backend
    headers: {
        'Content-Type': 'application/json',
    },
    withCredentials: true // Cho phép gửi cookies trong các request
});

// Interceptor cho request
apiClient.interceptors.request.use(
    config => {
        // Có thể thêm token vào header ở đây nếu cần
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    error => {
        return Promise.reject(error);
    }
);

// Interceptor cho response
apiClient.interceptors.response.use(
    response => response,
    error => {
        // Xử lý các lỗi response ở đây
        if (error.response) {
            switch (error.response.status) {
                case 401:
                    // Xử lý lỗi unauthorized
                    break;
                case 404:
                    // Xử lý lỗi not found
                    break;
                default:
                    // Xử lý các lỗi khác
                    break;
            }
        }
        return Promise.reject(error);
    }
);

export default apiClient; 