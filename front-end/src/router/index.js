import { createRouter, createWebHistory } from "vue-router";

// Guest Pages
import AboutUs from "@/pages/Guest/AboutUs.vue";
import ContactUs from "@/pages/Guest/ContactUs.vue";
import HomePage from "@/pages/Guest/HomePage.vue";
import Services from "@/pages/Guest/Services.vue";
import RoomTypes from "@/pages/Guest/RoomTypes.vue";
import RoomDetail from "@/pages/Guest/RoomDetail.vue";
import RoomDetailExtended from "@/pages/Guest/RoomDetailExtended.vue";
// import GuestBooking from "@/pages/Guest/Booking.vue";

// Auth Pages
import SignupPage from "../pages/employee/SignUpPage.vue";
import LoginPage from "../components/Login.vue";
import CreateAccPage from "../pages/employee/CreateAccPage.vue";
import ForgotPassPage from "../pages/employee/ForgotPassPage.vue";
import OTPPage from "../pages/employee/OTPPage.vue";
import ResetPass from "../pages/employee/ResetPassPage.vue";

// Employee Pages
import Dashboard from "../pages/employee/Dashboard.vue";
import ServiceSelection from "@/pages/employee/ServiceSelection.vue";
import UserBooking from "@/pages/employee/UserBooking.vue";
import UserManager from "@/pages/employee/UserManager.vue";
import UserInformation from "@/pages/employee/UserInformation.vue";
import InvoiceManagement from "@/pages/employee/InvoiceManagement.vue";
import InvoiceDetail from "@/pages/employee/InvoiceDetail.vue";

const routes = [
  // Guest Routes
  {
    path: "/",
    name: "Home",
    component: HomePage,
    meta: { requiresAuth: false }
  },
  {
    path: "/about-us",
    name: "AboutUs",
    component: AboutUs,
    meta: { requiresAuth: false }
  },
  {
    path: "/contact-us",
    name: "ContactUs",
    component: ContactUs,
    meta: { requiresAuth: false }
  },
  {
    path: "/services",
    name: "Services",
    component: Services,
    meta: { requiresAuth: false }
  },
  {
    path: "/room-types",
    name: "RoomTypes",
    component: RoomTypes,
    meta: { requiresAuth: false }
  },
  {
    path: "/room-types/:type",
    name: "RoomDetail",
    component: RoomDetail,
    meta: { requiresAuth: false }
  },
  {
    path: "/room-types/:type/extended/:roomId",
    name: "RoomDetailExtended",
    component: RoomDetailExtended,
    meta: { requiresAuth: false }
  },
  // {
  //   path: "/booking",
  //   name: "GuestBooking",
  //   component: GuestBooking,
  //   meta: { requiresAuth: false }
  // },

  // Authentication Routes
  {
    path: "/signup",
    name: "Signup",
    component: SignupPage,
    meta: { requiresAuth: false }
  },
  {
    path: "/login",
    name: "Login",
    component: LoginPage,
    meta: { requiresAuth: false }
  },
  {
    path: "/create-account",
    name: "CreateAccount",
    component: CreateAccPage,
    meta: { requiresAuth: false }
  },
  {
    path: "/forgot-password",
    name: "ForgotPassword",
    component: ForgotPassPage,
    meta: { requiresAuth: false }
  },
  {
    path: "/otp",
    name: "OTP",
    component: OTPPage,
    meta: { requiresAuth: false }
  },
  {
    path: "/reset-password",
    name: "ResetPassword",
    component: ResetPass,
    meta: { requiresAuth: false }
  },

  // Employee Routes (Protected)
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
    meta: { requiresAuth: true, role: 'employee' }
  },
  {
    path: "/employee/service-selection",
    name: "ServiceSelection",
    component: ServiceSelection,
    meta: { requiresAuth: true, role: 'employee' }
  },
  {
    path: "/employee/invoice-management",
    name: "InvoiceManagement",
    component: InvoiceManagement,
    meta: { requiresAuth: true, role: 'employee' }
  },
  {
    path: "/employee/invoice-detail/:id",
    name: "InvoiceDetail",
    component: InvoiceDetail,
    props: true,
    meta: { requiresAuth: true, role: 'employee' }
  },
  {
    path: "/employee/user-manager",
    name: "UserManager",
    component: UserManager,
    meta: { requiresAuth: true, role: 'employee' }
  },
  {
    path: "/employee/booking",
    name: "UserBooking",
    component: UserBooking,
    meta: { requiresAuth: true, role: 'employee' }
  },
  {
    path: "/employee/personal-info",
    name: "UserInformation",
    component: UserInformation,
    meta: { requiresAuth: true, role: 'employee' }
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

// Navigation guard
router.beforeEach((to, from, next) => {
  // Add your authentication logic here
  // Example:
  // const isAuthenticated = store.getters.isAuthenticated;
  // const userRole = store.getters.userRole;
  
  // if (to.meta.requiresAuth && !isAuthenticated) {
  //   next('/login');
  // } else if (to.meta.role && userRole !== to.meta.role) {
  //   next('/');
  // } else {
  //   next();
  // }
  next();
});

export default router;

