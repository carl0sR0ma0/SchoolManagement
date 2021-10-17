<template>
<div class="container">
  <div class="center">
    <h1>Cadastro de Curso</h1>

    <div class="form-floating mb-3">
      <input v-model="nome" type="text" class="form-control" placeholder="teste" required>
      <label for="floatingInput">Nome</label>
    </div>

    <div class="form-floating mb-3">
      <input v-model="serieInicial" type="text" class="form-control" placeholder="teste" required>
      <label for="floatingInput">Série Inicial</label>
    </div>

    <div class="form-floating mb-3">
      <input v-model="serieFinal" type="text" class="form-control" placeholder="teste" required>
      <label for="floatingInput">Série Final</label>
    </div>

    <div class="form-floating mb-3">
      <input v-model="coordenador" type="text" class="form-control" placeholder="teste" required>
      <label for="floatingInput">Coordenador</label>
    </div>

    <div class="d-grid gap-2">
    <button type="button" class="btn btn-success" @click="addCurso">Enviar</button>
    </div>
  </div>
</div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Curso",
  data() {
    return {
      nome: "",
      serieInicial: "",
      serieFinal: "",
      coordenador: "",
    };
  },
  

  methods: {
    addCurso() {
      let _curso = {
        nome: this.nome,
        serieIni: this.serieInicial,
        serieFin: this.serieFinal,
        coordenador: this.coordenador,
      };

      axios.post("https://localhost:5001/Curso/create", _curso).then((res) => {   
        alert(res.data.message);
      });

      this.nome = "";
      this.serieInicial = "";
      this.serieFinal = "";
      this.coordenador = "";
    },
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
* {
  font-family: "Poppins", sans-serif;
}

</style>
