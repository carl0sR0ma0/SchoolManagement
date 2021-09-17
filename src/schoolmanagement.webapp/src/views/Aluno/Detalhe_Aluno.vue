<template>
    <div class="container">
        <div class="center">
            <h1>{{aluno.nome}}</h1>
        </div>
        <b-button class="btnVoltar" variant="outline-info" @click="voltar()">Voltar</b-button>
    <table class="content-table">
        <tbody>
            <tr>
                <td >Ra</td>
                <td>
                    <label for="">{{aluno.ra}}</label>
                </td>
            </tr>
            <tr>
                <td>Nome</td>
                <td>
                    <label v-if="visualizando" for="">{{aluno.nome}}</label>
                    <b-form-input v-else v-model="aluno.nome" />
                </td>
            </tr>
            <tr>
                <td>Data de Nascimento</td>
                <td>
                    <label v-if="visualizando" for="">{{aluno.dataNascimento}}</label>
                    <b-form-input v-else v-model="aluno.dataNascimento" />
                </td>
            </tr>
            <tr>
                <td>RG</td>
                <td>
                    <label v-if="visualizando" for="">{{aluno.rg}}</label>
                    <b-form-input v-else v-model="aluno.rg" />
                </td>
            </tr>
            <tr>
                <td>CPF</td>
                <td>
                    <label v-if="visualizando" for="">{{aluno.cpf}}</label>
                    <b-form-input v-else v-model="aluno.cpf" />
                </td>
            </tr>
            <tr>
                <td>Telefone</td>
                <td>
                    <label v-if="visualizando" for="">{{aluno.telefone}}</label>
                    <b-form-input v-else v-model="aluno.telefone" />
                </td>
            </tr>
            <tr>
                <td>Sexo</td>
                <td>
                    <label for="">{{aluno.sexo}}</label>
                </td>
            </tr>
            <tr>
                <td><b-button v-if="visualizando" variant="outline-primary" @click="EditarAluno()" >Editar</b-button>
                <b-button v-else variant="outline-danger" @click="Cancelar()" >Cancelar</b-button>
                </td>
            </tr>
            <tr v-if="!visualizar">
                <td></td>
                <td><b-button variant="outline-sucess" @click="SalvarAluno(aluno)" >Salvar</b-button></td>
            </tr>
        </tbody>
    </table>
    </div>
</template>

<script>
import axios from "axios";

export default {
        components:{
        },
        data(){
            return{
                alunos:{},
                ra: this.$route.params.ra,
                visualizando: true,
            }
        },
        methods: {
            voltar(){
                this.$router.back();
            },
            EditarAluno(){
                this.visualizando = !this.visualizando;
            },
            Cancelar(){
                this.visualizando = !this.visualizando;
            },
            SalvarAluno(_aluno){
                let _alunoEditar = {
                        nome: _aluno.nome,
                        dataNascimento: _aluno.dataNascimento,
                        rg: _aluno.rg,
                        cpf: _aluno.cpf,
                        telefone: _aluno.telefone,
                }
                this.$http
                .put('https://localhost:5001/Aluno/${_alunoEditar.id}', _alunoEditar);
        },
        created() {
        axios.get("https://localhost:5001/Aluno/get").then((res) => {
            console.log(res.data.data);
        });
      }
    }
};
</script>

<style scoped>
.btnVoltar {
    float: right;
}

.content-table {
  border-collapse: collapse;
  margin: 25px 0;
  font-size: 0.9em;
  min-width: 400px;
  border-radius: 5px 5px 0 0;
  overflow: hidden;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

.content-table thead tr {
  background-color: #009879;
  color: #ffffff;
  text-align: left;
  font-weight: bold;
}

.content-table th,
.content-table td {
  padding: 12px 15px;
}

.content-table tbody tr {
  border-bottom: 1px solid #dddddd;
}

.content-table tbody tr:nth-of-type(even) {
  background-color: #f3f3f3;
}

.content-table tbody tr:last-of-type {
  border-bottom: 2px solid #009879;
}

.content-table tbody tr.active-row {
  font-weight: bold;
  color: #009879;
}
</style>