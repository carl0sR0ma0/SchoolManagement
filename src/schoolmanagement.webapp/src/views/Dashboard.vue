<template>
    <body>
      <div class="center">
        <h1>Cadastro de Alunos</h1>
        <form action="" method="post">
          <div class="txt_field">
            <input type="text" v-model="RaAluno" required>
            <span></span>
            <label>RA do Aluno</label>
          </div>
          <div class="txt_field">
            <input type="text" v-model="NomeAluno" required>
            <span></span>
            <label>Nome</label>
          </div>
          <div class="txt_field">
            <input type="text" v-model="DataNasAluno" required>
            <span></span>
            <label>Data de Nascimento</label>
          </div>
          <div class="txt_field">
            <input type="text" v-model="RgAluno" required>
            <span></span>
            <label>RG</label>
          </div>
          <div class="txt_field">
            <input type="text" v-model="CpfAluno" required>
            <span></span>
            <label>CPF</label>
          </div>
          <div class="txt_field">
            <input type="text" v-model="TelefoneAluno" required>
            <span></span>
            <label>Telefone</label>
          </div>
          <div class="txt_field">
            <input type="text" v-model="SexoAluno" required>
            <span></span>
            <label>Sexo</label>
          </div>
          <button class="btn btnInput" @click="addAluno"> Enviar </button>
        </form>
      </div>
    </body>
</template>

<script>
import { collapsed, toggleSidebar } from '@/components/sidebar/state'

export default {
  setup() {
    return { collapsed, toggleSidebar }
  },
  data() {
  return {
    RaAluno: "",
    NomeAluno: "",
    DataNasAluno: "",
    RgAluno: "",
    CpfAluno: "",
    TelefoneAluno: "",
    Sexo: "",
    alunos:[
      {
            Ra: "",
            Nome: "",
            DataNascimento: "",
            Rg: "",
            Cpf: "",
            Telefone: "",
            Sexo: "",
      },
    ]
  }
},
    created(){
      this.$http
      .get('http://localhost:8080/')
      .then( res => res.json())
      .then( alunos => this.alunos = alunos)
    },

  methods: {
    addAluno(){
      let _aluno ={
        RaAluno: this.Ra,
        nomeAluno: this.Nome,
        DataNasAluno: this.DataNascimento,
        RgAluno:this.Rg,
        CpfAluno:this.Cpf,
        TelefoneAluno:this.telefone,
        SexoAluno:this.Sexo,
      }
      this.$http
      .post('http://localhost:8080/', _aluno)
      .then( res => res.json())

      this.alunos.push(_aluno);
            this.Ra = "";
            this.Nome = "";
            this.DataNascimento = "";
            this.Rg = "";
            this.Cpf = "";
            this.Telefone = "";
            this.Sexo = "";
      },
    },
}

</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap');
*{
  font-family: 'Poppins',sans-serif;
}

.center h1{
  text-align: center;
  color: #1d1b31;;
  padding: 20px 0;
  border-bottom: 1px solid black;
  font-weight: bold;
}
.center form{
  padding: 0 40px;
  box-sizing: border-box;
}
form .txt_field{
  position: relative;
  border-bottom: 2px solid black;
  margin: 30px 0;
}
.txt_field input{
  width: 100%;
  padding: 0 5px;
  height: 40px;
  font-size: 16px;
  border: none;
  background: none;
  outline: none;
  color: black;
}
.txt_field label{
  position: absolute;
  top: 50%;
  left: 5px;
  color: black;
  transform: translateY(-50%);
  font-size: 16px;
  pointer-events: none;
  transition: .5s;
}
.txt_field span::before{
  content: '';
  position: absolute;
  top: 40px;
  left: 0;
  width: 0%;
  height: 2px;
  background: #2691d9;
  transition: .5s;
}
.txt_field input:focus ~ label,
.txt_field input:valid ~ label{
  top: -5px;
  color: #2691d9;
}
.txt_field input:focus ~ span::before,
.txt_field input:valid ~ span::before{
  width: 100%;
}
.pass{
  margin: -5px 0 20px 5px;
  color: #a6a6a6;
  cursor: pointer;
}
.pass:hover{
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
.btnInput:hover{
  border-color: #2691d9;
  background: #38a169;
  color: #1d1b31;
  transition: .5s;
}

</style>