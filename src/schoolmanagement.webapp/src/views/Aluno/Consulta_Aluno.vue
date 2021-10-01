<template>
  <div class="container">
    <div class="center">
      <h1>Consulta de Alunos</h1>
    </div>
    <b-col lg="6" class="my-1">
      <b-form-group
        label-for="filter-input"
        label-cols-sm="3"
        label-align-sm="right"
        label-size="sm"
        class="mb-0"
      >
        <b-input-group size="sm">
          <b-form-input
            id="filter-input"
            v-model="filter"
            type="search"
            placeholder="Procurar Aluno"
          ></b-form-input>

          <b-input-group-append style="margin-left: 10px">
            <b-button :disabled="!filter" @click="filter = ''">Limpar</b-button>
          </b-input-group-append>
        </b-input-group>
      </b-form-group>
    </b-col>

    <b-table
      striped
      hover
      :items="alunos"
      :fields="fields"
      :filter="filter"
      :filter-included-fields="filterOn"
    > 
      <template v-slot:cell(options)="data">
        <b-row cols="2" cols-sm="4" class="text-center">
        <b-button @click="Excluir(data)"
                  size="sm"
                  variant="outline-danger" 
                  class="mb-2"
                  >
          <b-icon icon="trash" aria-hidden="true"></b-icon>
        </b-button>
        <b-button @click="Editar(data)"
                  style="margin: 0 15px;"
                  size="sm"
                  variant="outline-primary" 
                  class="mb-2"
                  >
          <b-icon icon="pencil-square" aria-hidden="true"></b-icon>
        </b-button>
        </b-row>
      </template>
    </b-table>
    <b-modal centered ref="modalExcluir" >
      <template v-slot:modal-header>
        <b-container class="mb-2">
          <b-icon scale="2.5" style="display: block; margin-left: auto; margin-right: auto" icon="exclamation-diamond" variant="danger"></b-icon>
        </b-container>
      </template>
      <b-container fluid> Deseja Realmente Remover o Aluno ?</b-container>
      <template v-slot:modal-footer="{hide, ok}">
        <b-button variant="outline-danger" @click="hide()" > Não </b-button>
        <b-button variant="outline-success" @click="ok()" > Sim </b-button>
      </template>
    </b-modal>
    <b-modal centered ref="modalEditar" >
      <template v-slot:modal-header>
          <h5 style="margin: 0 10px; color:blue" >Editando o Aluno - Nome do Aluno</h5>
      </template>
        <b-container fluid> 
          <form>
            <b-form-group label="Nome" label-for="name-input">
              <b-form-input
                id="nome"
                v-model="name"
                required
              > Nome do Aluno </b-form-input>
            </b-form-group>
            <b-form-group label="Data de Nascimento" label-for="name-input">
              <b-form-input
                id="datanascimento"
                v-model="name"
                type="date"
                required
              > Nome do Aluno </b-form-input>
            </b-form-group>
          </form>
        </b-container>
      <template v-slot:modal-footer="{hide, ok}">
        <b-button variant="outline-danger" @click="hide()" > Cancelar </b-button>
        <b-button variant="outline-success" @click="ok()" > Salvar </b-button>
      </template>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Consulta_Aluno",
  data() {
    return {
      show: false,
      alunos: [],
      fields: [
        {
          key: "nome",
          label: 'Nome',
          sortable: true,
        },
        {
          key: "ra",
        },
        {
          key: "options",
          label: '',
        },
      ],
      filter: null,
      filterOn: [],
    };
  },
  methods: {
    Excluir(){
      this.$refs.modalExcluir.show();
    },
    Editar(){
      this.$refs.modalEditar.show();
    },
  },
  created() {
    axios.get("https://localhost:5001/Aluno/get").then((res) => {
      this.alunos = res.data.data;
    });
  },


};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
* {
  font-family: "Poppins", sans-serif;
}
</style>
