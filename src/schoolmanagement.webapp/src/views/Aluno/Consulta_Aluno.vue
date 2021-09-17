<template>
  <div class="container">
    <div class="center">
      <h1>Consulta de Alunos</h1>
      <div>
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

            <b-input-group-append>
              <b-button :disabled="!filter" @click="filter = ''">Limpar</b-button>
            </b-input-group-append>
          </b-input-group>
        </b-form-group>
      </b-col>
    <b-table striped hover :items="alunos" :fields="fields" :filter="filter" :filter-included-fields="filterOn">
      <template v-slot:cell(actions)= "data">
        <b-button variant="outline-primary" :to="'/Detalhe_Aluno/${alunos.ra}'" @click="editar(data.id)">Editar</b-button>
      </template>
    </b-table>
  </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Consulta_Aluno",
  data() {
    return {
      alunos: [],
      fields: [
        {
          key: "nome",
          sortable: true,
        },
        {
          key: "ra",
          sortable: false,
        },
        {
          key: "dataNascimento",
          label: "Data Nascimento",
          sortable: false,
          variant: "", //Colocar cor na tabela
        },
        {
          key: "actions",
          label: "Ações",
        },
      ],
      filter: null,
      filterOn: [],
    };
  },
  created() {
    axios.get("https://localhost:5001/Aluno/get").then((res) => {
      this.alunos = res.data.data;
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
</style>
