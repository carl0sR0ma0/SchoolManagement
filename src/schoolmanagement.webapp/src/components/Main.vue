<template>
<body>
  <img src="@/assets/professor_1.png" class="controller" alt="">
  <div class="box">
        <h2>School Management</h2>
  </div>
</body>
</template>

<script>
export default {
  name: "Main",
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  * {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  }

  body {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: #222;
  }

  .box{
  position: relative;
  width: 90vh;
  height: 50vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background: rgba(0, 0, 0, 0.5);
  overflow: hidden;
  border-radius: 20px;
  left: -100px;
  }

  .box:before{
  content:'';
  position: absolute;
  width: 150%;
  height: 140%;
  background: linear-gradient(#14260d,#3b7326);
  animation: animate 4s linear infinite;
  }

  .box:after{
  content:'';
  position: absolute;
  inset: 4px;
  background: rgba(0, 0, 0, 0.9);
  }
  
  @keyframes animate {
    0%
    {
      transform: rotate(0deg);
    }
    100%
    {
      transform: rotate(350deg);
    }
  }

  .box h2{
    font-size: 54px;
    color: white;
    z-index: 10;
  }

  .controller{
    z-index:11;
    width: 30vh;
    left: 50px;
    top: 100px;
    position: relative;
  }

</style>
