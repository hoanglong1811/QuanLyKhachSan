import { createRouter, createWebHistory } from 'vue-router';

import ServiceSelection from '@/pages/employee/ServiceSelection.vue';
import SignupPage from '../pages/employee/SignUpPage.vue';
import CreateAccPage from '../pages/employee/CreateAccPage.vue';
import ForgotPassPage from '../pages/employee/ForgotPassPage.vue';
import OTPPage from '../pages/employee/OTPPage.vue';
import ResetPass from '../pages/employee/ResetPassPage.vue';
import Dashboard from '../pages/employee/Dashboard.vue';
import UserBooking from '@/pages/employee/UserBooking.vue';
import UserManager from '@/pages/employee/UserManager.vue';
import UserInformation from '@/pages/employee/UserInformation.vue';


const routes = [
    
    { path: '/employee/service-selection', name: 'ServiceSelection', component: ServiceSelection },
    { path: '/login', component: SignupPage },
    { path: '/create-account', component: CreateAccPage },
    { path: '/forgot-password', component: ForgotPassPage },
    { path: '/otp', component: OTPPage },
    { path: '/user-manager', component: UserManager },
    { path: '/reset-password', component: ResetPass },
    { path: '/', redirect: '/create-account' }, // Default route
    { path: '/dashboard', component: Dashboard },
    { path: '/booking', component: UserBooking },
    { path: '/personal-info', component: UserInformation },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;