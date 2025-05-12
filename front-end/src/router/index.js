import { createRouter, createWebHistory } from 'vue-router';
import HomePage from '../pages/HomePage.vue';
import AboutUs from '../pages/AboutUs.vue';

const routes = [
    { path: '/', name: 'Home', component: HomePage },
    { path: '/about', name: 'AboutUs', component: AboutUs }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;