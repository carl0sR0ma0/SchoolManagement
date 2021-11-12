<template>
  <div id="app">
    <nav-bar-component />
    <router-view />
  </div>
</template>

<script>
import NavBarComponent from "./components/NavBarComponent.vue";
export default {
  components: {
    NavBarComponent,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
* {
  font-family: "Poppins", sans-serif;
}
.temp {
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  min-height: 100vh;
  background: #212529;
}

.container {
  background: #fff;
  border-radius: 15px;
}
.center h1 {
  text-align: center;
  color: #1d1b31;
  padding: 20px 0;
  border-bottom: 2px solid black;
  font-weight: bold;
}
.center {
  padding: 0 40px;
  box-sizing: border-box;
}
</style>
