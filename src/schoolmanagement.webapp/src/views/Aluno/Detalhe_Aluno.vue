<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <b-button class="btnVoltar" variant="outline-info" @click="voltar()"
          >Voltar</b-button
        >
        <h1>Editando o Aluno</h1>

        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="teste"
            v-model="aluno.nome"
          />
          <label for="floatingInput">Nome</label>
        </div>
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="teste"
            v-model="aluno.dataNascimento"
          />
          <label for="floatingInput">Data de Nascimento</label>
        </div>
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="teste"
            v-model="aluno.rg"
          />
          <label for="floatingInput">RG</label>
        </div>
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="teste"
            v-model="aluno.cpf"
          />
          <label for="floatingInput">CPF</label>
        </div>
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="teste"
            v-model="aluno.telefone"
          />
          <label for="floatingInput">Telefone</label>
        </div>
        <b-row>
          <b-col cols="8">
            <div class="form-floating mb-3">
              <input
                v-model="aluno.logradouro"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Endereço</label>
            </div>
          </b-col>
          <b-col cols="4">
            <div class="form-floating mb-3">
              <input
                v-model="aluno.numero"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Numero</label>
            </div>
          </b-col>
        </b-row>
        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="aluno.bairro"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Bairro</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="aluno.cidade"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Cidade</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="aluno.cep"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">CEP</label>
            </div>
          </b-col>
        </b-row>
        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button
            v-b-modal="'ModalConfirm'"
            type="button"
            class="btn btn-success"
            @click="SalvarAluno"
          >
            Salvar
          </b-button>
        </div>

        <b-modal
          ref="ModalConfirm"
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
              <b-col>Aluno Atualizado!</b-col>
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
  name: "Detalhe_Aluno",
  components: {},
  data() {
    return {
      aluno: {},
      id: this.$route.params.id,
      visualizando: true,
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },
    SalvarAluno() {
      let _alunoEditar = {
        id: this.id,
        ra: this.aluno.ra,
        nome: this.aluno.nome,
        dataNascimento: this.aluno.dataNascimento,
        rg: this.aluno.rg,
        cpf: this.aluno.cpf,
        telefone: this.aluno.telefone,
        sexo: this.aluno.sexo,
        logradouro: this.aluno.logradouro,
        numero: this.aluno.numero,
        bairro: this.aluno.bairro,
        cidade: this.aluno.cidade,
        cep: this.aluno.cep,
      };
      axios.put("https://localhost:5001/Aluno/update", _alunoEditar);
      this.visualizando = !this.visualizando;
    },

    close() {
      this.$refs.ModalConfirm.hide();
    },
  },
  created() {
    axios.get(`https://localhost:5001/Aluno/get/${this.id}`).then((res) => {
      this.aluno = res.data.data;
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
