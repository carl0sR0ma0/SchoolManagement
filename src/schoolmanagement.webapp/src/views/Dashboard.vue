<template>
  <div class="center">
    <h1>Cadastro de Alunos</h1>
    <div class="txt_field">
      <input type="text" v-model="ra" required />
      <span></span>
      <label>RA do Aluno</label>
    </div>
    <div class="txt_field">
      <input type="text" v-model="nome" required />
      <span></span>
      <label>Nome</label>
    </div>
    <div class="txt_field">
      <input type="date" v-model="dataNascimento" required />
      <span></span>
      <label>Data de Nascimento</label>
    </div>
    <div class="txt_field">
      <input type="text" v-model="rg" />
      <span></span>
      <label>RG</label>
    </div>
    <div class="txt_field">
      <input type="text" v-model="cpf" />
      <span></span>
      <label>CPF</label>
    </div>
    <div class="txt_field">
      <input type="text" v-model="telefone" />
      <span></span>
      <label>Telefone</label>
    </div>
    <div class="txt_field">
      <input type="number" v-model="sexo" required />
      <span></span>
      <label>Sexo</label>
    </div>
    <button class="btn btnInput" @click="addAluno">Enviar</button>
  </div>
</template>

<script>
import { collapsed, toggleSidebar } from "@/components/sidebar/state";
import axios from "axios";

export default {
  setup() {
    return { collapsed, toggleSidebar };
  },
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
