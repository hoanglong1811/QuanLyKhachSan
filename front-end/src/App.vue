<template>
    <div id="app">
        
        <router-view />
    </div>
</template>

<script>
import AboutUs from './pages/AboutUs.vue';
import HomePage from './pages/HomePage.vue'
export default {
  components: { HomePage, AboutUs },
    name: "App"
    

}
</script>

<style>

</style>