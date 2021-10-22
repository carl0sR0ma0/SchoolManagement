<template>
<div class="temp">
  <div class="container">
    <div class="center">
      <b-button class="btnVoltar" variant="outline-info" @click="voltar()"
      >Voltar</b-button>
      <h1>Editando a Turma</h1>

       <b-row>
        <b-col cols="8">
          <div class="form-floating mb-3">
          <input
            v-model="turma.nome"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Nome</label>
          </div>
        </b-col>
                <b-col cols="4">
          <div class="form-floating mb-3">
          <input
            v-model="turma.serieId"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Série ID</label>
          </div>
        </b-col>
      </b-row>

      <b-row>
        <b-col>
          <div class="form-floating mb-3">
          <input
            v-model="turma.turno"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Turno</label>
          </div>
        </b-col>
        <b-col>
          <div class="form-floating mb-3">
          <input
            v-model="turma.ano"
            type="number"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Ano</label>
          </div>
        </b-col>
      </b-row>

      <b-row>
        <b-col>
          <div class="form-floating mb-3">
          <input
            v-model="turma.sigla"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Sigla</label>
          </div>
        </b-col>
        <b-col>
          <div class="form-floating mb-3">
          <input
            v-model="turma.situacao"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Situação</label>
          </div>
        </b-col>
      </b-row>

    <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">   
    <b-button variant="outline-success" @click="SalvarTurma()">Salvar</b-button> 
    </div>           
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
      turma: {},
      id: this.$route.params.id,
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },
    SalvarTurma() {
      let _turmaEditar = {
        id: this.id,
        nome: this.turma.nome,
        turno: this.turma.turno,
        ano: this.turma.ano,
        sigla: this.turma.sigla,
        situacao: this.turma.situacao,
        serieId: this.turma.serieId,
      };
      axios.put("https://localhost:5001/Turma/update", _turmaEditar);

    },
  },
  created() {
    axios.get(`https://localhost:5001/Turma/get/${this.id}`).then((res) => {
      this.turma = res.data.data;
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