<template>
  <div class="container">
    <div class="center">
      <h1>Cadastro de Alunos</h1>

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
          v-model="dataNascimento"
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
          v-model="rg"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">RG</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="cpf"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">CPF</label>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="telefone"
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Telefone</label>
      </div>
            <fieldset class="row mb-3">
        <legend class="col-form-label col-sm-2 pt-0" style="margin-left:15px">Sexo</legend>
        <div class="col-sm">
          <div class="form-check">
            <input
              class="form-check-input"
              type="radio"
              name="gridRadios1"
              v-model="sexo"
              value="Masculino"
              checked
            />
            <label class="form-check-label" for="gridRadios1"> Masculino </label>
          </div>
          <div class="form-check">
            <input
              class="form-check-input"
              type="radio"
              name="gridRadios2"
              v-model="sexo"
              value="Feminino"
            />
            <label class="form-check-label" for="gridRadios2"> Feminino </label>
          </div>
        </div>
      </fieldset>
      <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">
        <b-button type="button" class="btn btn-success" @click="addAluno">
          Salvar
        </b-button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Aluno",


  data() {
    return {
      ra: "",
      nome: "",
      dataNascimento: "",
      rg: "",
      cpf: "",
      telefone: "",
      sexo: "",
    };
  },

  created() {},

  randomNumber: function () {
  this.random = Math.floor(Math.random())
  },

  methods: {
    addAluno() {
      let _aluno = {
        ra: this.ra,
        nome: this.nome,
        dataNascimento: this.dataNascimento,
        rg: this.rg,
        cpf: this.cpf,
        telefone: this.telefone,
        sexo: this.sexo,
      };

      axios.post("https://localhost:5001/Aluno/create", _aluno).then((res) => {
        console.log(res.data);
      });

      this.ra = "";
      this.Nome = "";
      this.DataNascimento = "";
      this.Rg = "";
      this.Cpf = "";
      this.Telefone = "";
      this.Sexo = "";
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
