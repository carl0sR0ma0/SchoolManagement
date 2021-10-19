<template>
<div class="temp">
  <div class="container">
    <div class="center">
      <b-button class="btnVoltar" variant="info" @click="voltar()"
      >Voltar</b-button>
      <h1>Editando o Colaborador</h1>

      <div class="form-floating mb-3">
        <input
          v-model="colaborador.nome"
          type="text"
          class="form-control"
          placeholder="teste"
          required
        />
        <label for="floatingInput">Nome</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="colaborador.dataNascimento"
          type="text"
          class="form-control"
          placeholder="teste"
          onfocus="(this.type='date')"
          onblur="(this.type='text')"
          required
        />
        <label for="floatingInput">Data de Nascimento</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="colaborador.rg"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">RG</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="colaborador.cpf"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">CPF</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="colaborador.telefone"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Telefone</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="colaborador.cargo"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Cargo</label>
      </div>

      <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">
        <b-button v-b-modal="'ModalConfirm'" type="button" class="btn btn-success" @click="SalvarColaborador">
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
          <b-col>Colaborador Atualizado!</b-col>
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
      colaborador: {},
      id: this.$route.params.id,
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },
    SalvarColaborador() {
      let _colaboradorEditar = {
        id: this.id,
        nome: this.colaborador.nome,
        dataNascimento: this.colaborador.dataNascimento,
        rg: this.colaborador.rg,
        cpf: this.colaborador.cpf,
        sexo: this.colaborador.sexo,
        telefone: this.colaborador.telefone,
        ctps: this.colaborador.ctps,
        cargo: this.colaborador.cargo,
        dataAdmissao: this.colaborador.dataAdmissao,
      };
      axios.put("https://localhost:5001/Colaborador/update", _colaboradorEditar);
    },

      close(){
      this.$refs.ModalConfirm.hide();
    }
  },
  created() {
    axios.get(`https://localhost:5001/Colaborador/get/${this.id}`).then((res) => {
      this.colaborador = res.data.data;
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