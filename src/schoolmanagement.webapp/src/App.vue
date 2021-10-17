<template>
  <div id="app">
    <nav-bar-component/>
    <router-view/>
  </div>
</template>

<script>
import NavBarComponent from "./components/NavBarComponent.vue"
export default {
  components:{
    NavBarComponent,
}
}
</script>

<style>
</style>