<template>
<div class="temp">
  <div class="container">
    <div class="center">
      <b-button class="btnVoltar" variant="info" @click="voltar()"
      >Voltar</b-button>
      <h1>Editando o Curso</h1>

     <div class="form-floating mb-3">
        <input
          v-model="curso.nome"
          type="text"
          class="form-control"
          placeholder="teste"
          required
        />
        <label for="floatingInput">Nome</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="curso.coordenador"
          type="text"
          class="form-control"
          placeholder="teste"
          required
        />
        <label for="floatingInput">Coordenador</label>
      </div>

      <b-row>
        <b-col>
          <div class="form-floating mb-3">
          <input
            v-model="curso.serieIni"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Serie Inicial</label>
          </div>
        </b-col>
        <b-col>
          <div class="form-floating mb-3">
          <input
            v-model="curso.serieFin"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Serie Final</label>
          </div>
        </b-col>
      </b-row>

      <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">
        <b-button v-b-modal="'ModalConfirm'" type="button" class="btn btn-success" @click="SalvarCurso">
          Salvar
        </b-button>
      </div>
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
          <b-col>Curso Atualizado!</b-col>
          <b-col><b-button @click="close()">OK</b-button></b-col>
        </b-row>
      </b-container>
  </b-modal>

    </div>
</div>
</template>

<script>
import axios from "axios";

export default {
  components: {},
  data() {
    return {
      curso: {},
      id: this.$route.params.id,
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },
    SalvarCurso() {
      let _cursoEditar = {
        id: this.id,
        nome: this.curso.nome,
        coordenador: this.curso.coordenador,
        serieIni: this.curso.serieIni,
        serieFin: this.curso.serieFin,
      };
      axios.put("https://localhost:5001/Curso/update", _cursoEditar);
    },

      close(){
      this.$refs.ModalConfirm.hide();
    }
  },
  created() {
    axios.get(`https://localhost:5001/Curso/get/${this.id}`).then((res) => {
      this.curso = res.data.data;
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