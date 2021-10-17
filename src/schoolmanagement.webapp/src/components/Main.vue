<template>
<div class="temp1">
  <div class="row1">
    <div class="col-1">
        <h2>School Management</h2>
    </div>
    <div class="col-2">
      <img src="@/assets/professor_1.png" class="controller" alt="">
      <div class="color-box"></div>
    </div>
  </div>

</div>
</template>

<script>
export default {
  name: "Main",
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.temp1 {
  margin: 0;
  padding: 0;
  display: flex;
  min-height: 100vh;
  align-items: center;
  background: #222;
}
.row1{
  padding-left: 8%;
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin: 100px 0;
}
 .col-1{
   flex-basis: 40%;
   position: relative;
   margin-left: 50px;
 }
  .col-1 h2{
    font-size: 54px;
    color: white;
}
  .col-1::after{
    content: '';
    width: 10px;
    height: 100%;
    background: linear-gradient(#ff469f, #ff6062);
    position: absolute;
    left: -40px;
    top: 10px;
  }
  .col-1 p{
    font-size: 16px;
    color: #b7b7b7;
    font-weight: 100;
  }
  .col-2 {
    position: relative;
    flex-basis: 70%;
    display: flex;
    align-items: center;
  }
  .col-2 .controller{
    width: 100%;
    z-index: 2;
  }
  .color-box{
    position: absolute;
    right: 0;
    top: 0;
    background: linear-gradient(#ff469f, #ff6062);
    border-radius: 20px 0 0 20px;
    height: 100%;
    width: 80%;
    z-index: 1;
    
  }
  
</style>
