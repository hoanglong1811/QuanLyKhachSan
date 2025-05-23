import { createRouter, createWebHistory } from 'vue-router';
import SignupPage from '../components/SignUpPage.vue';
import CreateAccPage from '../components/CreateAccPage.vue';
import ForgotPassPage from '../components/ForgotPassPage.vue';
import OTPPage from '../components/OTPPage.vue';
import ResetPass from '../components/ResetPassPage.vue';

const routes = [
  { path: '/login', component: SignupPage },
  { path: '/create-account', component: CreateAccPage },
  { path: '/forgot-password', component: ForgotPassPage },
  { path: '/otp', component: OTPPage },
  { path: '/reset-password', component: ResetPass },
  { path: '/', redirect: '/create-account' }, // Default route
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;