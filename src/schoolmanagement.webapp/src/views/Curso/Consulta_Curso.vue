<template>
  <div class="container">
    <div class="center">
      <h1>Consulta de Curso</h1>
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
            placeholder="Procurar Curso"
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
      :items="cursos"
      :fields="fields"
      :filter="filter"
      :filter-included-fields="filterOn"
    > <template #cell(nome)="data">
        <a style="text-decoration: none; color: black" :href="`#/Detalhe_Curso/${data.item.id}`">{{ data.item.nome }}</a>
      </template>
    </b-table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Consulta_Curso",
  data() {
    return {
      cursos: [],
      fields: [
        {
          key: "nome",
          label: 'Nome',
          sortable: true,
        },
        {
          key: "id",
          sortable: false,
        },
      ],
      filter: null,
      filterOn: [],
    };
  },
  created() {
    axios.get("https://localhost:5001/Curso/get").then((res) => {
      this.cursos = res.data.data;

//Comando para visualizar no console do navegador, se os campos estão batendo com o backend
      console.log('this.cursos :>> ', this.cursos);
    });
  },

  methods: {},
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700&display=swap");
* {
  font-family: "Poppins", sans-serif;
}

a:hover {
  color: #f00
}
</style>
