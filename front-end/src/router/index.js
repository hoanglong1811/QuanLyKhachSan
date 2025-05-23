import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../pages/Guest/HomePage.vue';
import AboutUs from '../pages/Guest/AboutUs.vue';
import Services from '@/pages/Guest/Services.vue';
import ContactUs from '@/pages/Guest/ContactUs.vue';
import ServiceSelection from '@/pages/employee/ServiceSelection.vue';


const routes = [
    { path: '/', name: 'Home', component: HomePage },
    { path: '/about', name: 'AboutUs', component: AboutUs },
    { path: '/ser', name: 'Services', component: Services },
    { path: '/contact', name: 'ContactUs', component: ContactUs },
    { path: '/employee/service-selection', name: 'ServiceSelection', component: ServiceSelection },
    

];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;