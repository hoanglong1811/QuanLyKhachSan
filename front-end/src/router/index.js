import { createRouter, createWebHistory } from 'vue-router';

import ServiceSelection from '@/pages/employee/ServiceSelection.vue';
<<<<<<< HEAD
import SignupPage from '../pages/employee/SignUpPage.vue';
import CreateAccPage from '../pages/employee/CreateAccPage.vue';
import ForgotPassPage from '../pages/employee/ForgotPassPage.vue';
import OTPPage from '../pages/employee/OTPPage.vue';
import ResetPass from '../pages/employee/ResetPassPage.vue';
import Dashboard from '../pages/employee/Dashboard.vue';
import UserBooking from '@/pages/employee/UserBooking.vue';
import UserManager from '@/pages/employee/UserManager.vue';
import UserInformation from '@/pages/employee/UserInformation.vue';
=======
<<<<<<< HEAD
import InvoiceManagement from '@/pages/employee/InvoiceManagement.vue';
import InvoiceDetail from '@/pages/employee/InvoiceDetail.vue';
=======
import SignupPage from '../components/SignUpPage.vue';
import CreateAccPage from '../components/CreateAccPage.vue';
import ForgotPassPage from '../components/ForgotPassPage.vue';
import OTPPage from '../components/OTPPage.vue';
import ResetPass from '../components/ResetPassPage.vue';
>>>>>>> 7300a5d08830b1926b39c13ea51735805e5bc6b1


>>>>>>> e80509423673707e0a34d3b6d68ad335425b25b7
const routes = [
    
    { path: '/employee/service-selection', name: 'ServiceSelection', component: ServiceSelection },
<<<<<<< HEAD
    {path: '/employee/invoice-management', name: 'InvoiceManagement', component: InvoiceManagement },
{path: '/employee/invoice-detail/:id', name: 'InvoiceDetail', component: InvoiceDetail, props: true },
=======
    { path: '/login', component: SignupPage },
<<<<<<< HEAD
    { path: '/create-account', component: CreateAccPage },
    { path: '/forgot-password', component: ForgotPassPage },
    { path: '/otp', component: OTPPage },
    { path: '/user-manager', component: UserManager },
    { path: '/reset-password', component: ResetPass },
    { path: '/', redirect: '/create-account' }, // Default route
    { path: '/dashboard', component: Dashboard },
    { path: '/booking', component: UserBooking },
    { path: '/personal-info', component: UserInformation },
=======
  { path: '/create-account', component: CreateAccPage },
  { path: '/forgot-password', component: ForgotPassPage },
  { path: '/otp', component: OTPPage },
  { path: '/reset-password', component: ResetPass },
  { path: '/', redirect: '/create-account' }, // Default route
>>>>>>> e80509423673707e0a34d3b6d68ad335425b25b7
>>>>>>> 7300a5d08830b1926b39c13ea51735805e5bc6b1
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;