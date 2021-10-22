<template>
<div class="temp">
  <div class="container">
    <div class="center">
      <b-button class="btnVoltar" variant="outline-info" @click="voltar()"
      >Voltar</b-button>
      <h1>Editando o Série</h1>

           <div class="form-floating mb-3">
        <input
          v-model="serie.nome"
          type="text"
          class="form-control"
          placeholder="teste"
          required
        />
        <label for="floatingInput">Nome</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="serie.descricao"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Descrição</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="serie.cursoId"
          type="number"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Curso ID</label>
      </div>

    <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">
        <b-button v-b-modal="'ModalConfirm'" type="button" class="btn btn-success" @click="SalvarSerie">
          Salvar
        </b-button>
      </div>

    <b-modal  ref="ModalConfirm"
              id="ModalConfirm"
              body-bg-variant="success"
              body-text-variant="light"
              centered 
              hide-footer
              hide-header
           >
      <b-container fluid>
        <b-row class="mb-1 text-center">
          <b-col cols="3"></b-col>
          <b-col>Série Atualizada!</b-col>
          <b-col><b-button @click="close()">OK</b-button></b-col>
        </b-row>
      </b-container>
    </b-modal>                   
    </div>
  </div>
</div>
</template>

<script>
import axios from "axios";

export default {
  components: {},
  data() {
    return {
      serie: {},
      id: this.$route.params.id,
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },
    SalvarSerie() {
      let _serieEditar = {
        id: this.id,
        nome: this.serie.nome,
        descricao: this.serie.descricao,
        cursoId: this.serie.cursoId,
      };
      axios.put("https://localhost:5001/Serie/update", _serieEditar);
    },
  },
  created() {
    axios.get(`https://localhost:5001/Serie/get/${this.id}`).then((res) => {
      this.serie = res.data.data;
    });
  },
};
</script>

<style scoped>
.btnVoltar {
  float: right;
  margin-top: 25px; 
}
</style>