<template>
  <div id="app">
    <nav-bar-component/>
    <side-bar-component/>
    <router-view/>
  </div>
</template>

<script>
import NavBarComponent from "./components/NavBarComponent.vue"
import SideBarComponent from "./components/SideBarComponent.vue"
export default {
  components:{
    NavBarComponent,
    SideBarComponent
}
}
</script>

<style>
</style>