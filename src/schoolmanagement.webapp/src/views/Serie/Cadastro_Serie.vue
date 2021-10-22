<template >
<div class="temp">
  <div class="container">
    <div class="center">
      <h1>Cadastro de Série</h1>

      <div class="form-floating mb-3">
        <input
          v-model="nome"
          type="text"
          class="form-control"
          placeholder="teste"
          required
        />
        <label for="floatingInput">Nome</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="descricao"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Descrição</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="cursoId"
          type="number"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Curso ID</label>
      </div>

      <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">
        <b-button v-b-modal="'ModalConfirm'" type="button" class="btn btn-success" @click="addSerie">
          Salvar
        </b-button>
      </div>
  </div>

  <b-modal id="ModalConfirm"
           header-bg-variant="success"
           header-text-variant="light"
           centered 
           hide-footer
           >
      <template v-slot:modal-header="{close}">
      <div center>
        Série Cadastrada
      </div>
      <b-button @click="close">
        <b-icon icon="arrow90deg-left"/>
      </b-button>
      </template>
      <div class="text-center">
        A Série {{memoria5}} foi cadastrado com sucesso!
      </div>
  </b-modal>

    </div>
</div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Serie",


  data() {
    return {
      nome: "",
      descricao: "",
      cursoId: "",
      memoria5: "",
    };
  },

  created() {},

  methods: {
    addSerie() {
      let _serie = {
        nome: this.nome,
        descricao: this.descricao,
        cursoId: this.cursoId,
      };

      this.memoria5 = _serie.nome;

      axios.post("https://localhost:5001/Serie/create", _serie).then((res) => {
        console.log(res.data);
      });

      this.nome = "";
      this.descricao = "";
      this.cursoId = "";
    },
  },
};
</script>

<style scoped>
.temp {
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  min-height: 100vh;
  background: #212529;
}

.container{
  background: #fff;
  border-radius: 15px;
}
</style>
