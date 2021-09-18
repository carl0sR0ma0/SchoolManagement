<template>
<div class="container">
  <div class="center">
    <h1>Cadastro de Professor</h1>
    <div class="form-floating mb-3">
      <input v-model="ra" type="text" class="form-control" placeholder="teste" required>
      <label for="floatingInput">RA do Aluno</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="nome" type="text" class="form-control" placeholder="teste" required>
      <label for="floatingInput">Nome</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="dataNascimento" type="text" class="form-control" placeholder="teste"
      onfocus="(this.type='date')" onblur="(this.type='text')" required>
      <label for="floatingInput">Data de Nascimento</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="rg" type="text" class="form-control" placeholder="teste">
      <label for="floatingInput">RG</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="nome" type="text" class="form-control" placeholder="teste">
      <label for="floatingInput">CPF</label>
    </div>
    <div class="form-floating mb-3">
      <input v-model="telefone" type="text" class="form-control" placeholder="teste">
      <label for="floatingInput">Telefone</label>
    </div>
  <fieldset class="row mb-3">
    <legend class="col-form-label col-sm-2 pt-0">Sexo</legend>
    <div class="col-sm-10">
      <div class="form-check">
        <input class="form-check-input" type="radio" name="gridRadios" id="sexo0" checked>
        <label class="form-check-label" for="gridRadios1">
          Masculino
        </label>
      </div>
      <div class="form-check">
        <input class="form-check-input" type="radio" name="gridRadios" id="sexo1">
        <label class="form-check-label" for="gridRadios2">
          Feminino
        </label>
      </div>
    </div>
    </fieldset>
    <div class="d-grid gap-2">
    <button type="button" class="btn btn-success" @click="addAluno" >Enviar</button>
    </div>
  </div>
</div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Professor",
  data() {
    return {
      ra: "",
      nome: "",
      dataNascimento: "",
      rg: "",
      cpf: "",
      telefone: "",
      sexo: "",

      alunos: [],
    };
  },
  created() {
    // this.$http
    //   .get("https://localhost:5001/Aluno/getAll")
    //   .then((res) => res.json())
    //   .then((alunos) => (this.alunos = alunos));
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
        console.log(res.data.data);
        this.alunos.push(res.data);
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

.center h1 {
  text-align: center;
  color: #1d1b31;
  padding: 20px 0;
  border-bottom: 1px solid black;
  font-weight: bold;
}
.center {
  padding: 0 40px;
  box-sizing: border-box;
}
.txt_field {
  position: relative;
  border-bottom: 2px solid black;
  margin: 30px 0;
}
.txt_field input {
  width: 100%;
  padding: 0 5px;
  height: 40px;
  font-size: 16px;
  border: none;
  background: none;
  outline: none;
  color: black;
}
.txt_field label {
  position: absolute;
  top: 50%;
  left: 5px;
  color: black;
  transform: translateY(-50%);
  font-size: 16px;
  pointer-events: none;
  transition: 0.5s;
}
.txt_field span::before {
  content: "";
  position: absolute;
  top: 40px;
  left: 0;
  width: 0%;
  height: 2px;
  background: #2691d9;
  transition: 0.5s;
}
.txt_field input:focus ~ label,
.txt_field input:valid ~ label {
  top: -5px;
  color: #2691d9;
}
.txt_field input:focus ~ span::before,
.txt_field input:valid ~ span::before {
  width: 100%;
}
.pass {
  margin: -5px 0 20px 5px;
  color: #a6a6a6;
  cursor: pointer;
}
.pass:hover {
  text-decoration: underline;
}
.btnInput {
  width: 100%;
  height: 50px;
  border: 1px solid;
  background: #1d1b31;
  border-radius: 25px;
  font-size: 18px;
  color: white;
  font-weight: 700;
  cursor: pointer;
  outline: none;
}
.btnInput:hover {
  border-color: #2691d9;
  background: #38a169;
  color: #1d1b31;
  transition: 0.5s;
}
</style>
