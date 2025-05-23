import { createRouter, createWebHistory } from 'vue-router';



import HomePage from '../pages/Guest/HomePage.vue';
import AboutUs from '../pages/Guest/AboutUs.vue';
import Services from '@/pages/Guest/Services.vue';
import ContactUs from '@/pages/Guest/ContactUs.vue';
import ServiceSelection from '@/pages/employee/ServiceSelection.vue';
<<<<<<< HEAD
import InvoiceManagement from '@/pages/employee/InvoiceManagement.vue';
import InvoiceDetail from '@/pages/employee/InvoiceDetail.vue';
=======
import SignupPage from '../components/SignUpPage.vue';
import CreateAccPage from '../components/CreateAccPage.vue';
import ForgotPassPage from '../components/ForgotPassPage.vue';
import OTPPage from '../components/OTPPage.vue';
import ResetPass from '../components/ResetPassPage.vue';


>>>>>>> e80509423673707e0a34d3b6d68ad335425b25b7
const routes = [
    { path: '/', name: 'Home', component: HomePage },
    { path: '/about', name: 'AboutUs', component: AboutUs },
    { path: '/ser', name: 'Services', component: Services },
    { path: '/contact', name: 'ContactUs', component: ContactUs },
    { path: '/employee/service-selection', name: 'ServiceSelection', component: ServiceSelection },
<<<<<<< HEAD
    {path: '/employee/invoice-management', name: 'InvoiceManagement', component: InvoiceManagement },
{path: '/employee/invoice-detail/:id', name: 'InvoiceDetail', component: InvoiceDetail, props: true },
=======
    { path: '/login', component: SignupPage },
  { path: '/create-account', component: CreateAccPage },
  { path: '/forgot-password', component: ForgotPassPage },
  { path: '/otp', component: OTPPage },
  { path: '/reset-password', component: ResetPass },
  { path: '/', redirect: '/create-account' }, // Default route
>>>>>>> e80509423673707e0a34d3b6d68ad335425b25b7
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;