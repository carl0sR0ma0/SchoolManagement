<template>
<div class="temp">
  <div class="container">
    <div class="center">
      <h1>Consulta de Turmas</h1>
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
            placeholder="Procurar Turma"
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
      :items="turmas"
      :fields="fields"
      :filter="filter"
      :filter-included-fields="filterOn"
    > 
      <template v-slot:cell(options)="data">
        <b-row cols="2" cols-sm="4" class="text-center">
        <b-button @click="Excluir(data.item.id)"
                  v-b-modal="'ModalExcluir'"
                  size="sm"
                  variant="outline-danger" 
                  class="mb-2"
                  >
          <b-icon icon="trash" aria-hidden="true"></b-icon>
        </b-button>
        <b-button :href="`#/Detalhe_Turma/${data.item.id}`"
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
  </div>
    <b-modal ref="ModalExcluir"
           id="ModalExcluir"
           body-bg-variant="danger"
           body-text-variant="light"
           centered 
           hide-footer
           hide-header
           >
      <b-container fluid>
        <b-row class="mb-1 text-center">
          <b-col cols="3"></b-col>
          <b-col>Turma Excluída</b-col>
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
  name: "Consulta_Turma",
  data() {
    return {
      show: false,
      turmas: [],
      fields: [
        {
          key: "nome",
          label: 'Nome',
          sortable: true,
        },
        {
          key: "turno",
          label: 'Turno',
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
    CarregarTurmas(){
      axios.get("https://localhost:5001/Turma/get").then((res) => {
      this.alunos = res.data.data;
    });
    },

    Excluir(id){
      axios.delete(`https://localhost:5001/Turma/delete/${id}`);
    },

    close(){
      this.CarregarTurmas();
      this.$refs.ModalExcluir.hide();
    }
  },

  created() {
    this.CarregarTurmas();
  },



};
</script>

<style scoped>
</style>
