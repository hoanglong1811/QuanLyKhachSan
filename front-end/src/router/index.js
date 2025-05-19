import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../pages/HomePage.vue';
import AboutUs from '../pages/AboutUs.vue';
import Services from '@/pages/Services.vue';
import ContactUs from '@/pages/ContactUs.vue';


const routes = [
    { path: '/', name: 'Home', component: HomePage },
    { path: '/about', name: 'AboutUs', component: AboutUs },
    { path: '/ser', name: 'Services', component: Services },
    { path: '/contact', name: 'ContactUs', component: ContactUs },
    

];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;