<template>
<body>
    <div class="temp">
      <div class="content">
        <h4>Welcome to</h4>
        <h1>School <span>Management</span></h1>
      </div>
      <div class="Dev">
        <h3><span>Developed by</span></h3>
        <h3>Carlos Romao</h3>
        <h3>Claudio Amantino</h3>
        <h3>Luciano Romano</h3>
        <h3>Rodrigo Fessore</h3>
        <h3>Rafael Alves</h3>
      </div>
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

  .content{
    position: absolute;
    top: 35%;
    left: 8%;
    transform: translateY(-50%);
    border-left: 5px solid white;
    padding-left: 1.5rem;
  }
  h1{
    color: white;
    margin: 20px 0px 20px;
    font-size: 70px;
  }
  span{
    color: #0D6EFD;
  }
  h3{
    color: white;
    font-size: 20px;
    margin-bottom: 10px;
    padding-left: 5px;
  }
  h4{
    color: #C7C8C9;
    font-size: 20px;
    letter-spacing: 2px;
  }
  .Dev{
    position: absolute; 
    top: 70%; 
    left: 80%;
    text-align: right;
    border-right: 5px solid white;
    padding-right: 1.5rem;
  }
</style>
