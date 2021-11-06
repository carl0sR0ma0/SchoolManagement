<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Matriculas</h1>
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
                <b-button
                  :disabled="!filter || !alunoMatriculado"
                  @click="clearFieldSearch"
                  >Limpar</b-button
                >
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>

        <b-table
          striped
          hover
          :items="alunoMatriculado"
          :fields="fields"
          :filter="filter"
          :filter-included-fields="filterOn"
        >
        </b-table>

        <div class="form-floating mb-3">
          <select class="form-select" v-model="cursoId">
            <option v-for="curso in cursos" :key="curso.id" :value="curso.id">
              {{ curso.nome }}
            </option>
          </select>
        </div>

        <div class="form-floating mb-3">
          <select class="form-select" v-model="serieId">
            <option
              v-for="serie in seriesAux"
              :key="serie.id"
              :value="serie.id"
            >
              {{ serie.nome }}
            </option>
          </select>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "FormMatricula",
  data() {
    return {
      cursoId: null,
      serieId: null,
      filter: null,
      alunoMatriculado: [],
      filterOn: [],
      fields: [
        {
          key: "nome",
          label: "Nome",
          sortable: true,
        },
        {
          key: "ra",
        },
      ],
      alunos: [
        { id: 1, nome: "Carlos Romão", ra: 22048192239 },
        { id: 2, nome: "Rodrigo Fessore", ra: 22048192205 },
        { id: 3, nome: "Luciano Romano", ra: 22048192214 },
        { id: 4, nome: "Rafael Alves", ra: 22048182215 },
      ],
      cursos: [
        { id: null, nome: "Selecione um Curso" },
        { id: 1, nome: "Ensino Infantil I" },
        { id: 2, nome: "Ensino Infantil II" },
        { id: 3, nome: "Ensino Infantil III" },
        { id: 4, nome: "Ensino Fundamental I" },
        { id: 5, nome: "Ensino Fundamental II" },
        { id: 6, nome: "Ensino Médio" },
      ],
      series: [
        { id: null, nome: "Selecione uma Série" },
        { id: 1, nome: "1ª Série EFI", cursoId: 4 },
        { id: 2, nome: "2ª Série EFI", cursoId: 4 },
        { id: 3, nome: "3ª Série EFI", cursoId: 4 },
        { id: 4, nome: "4ª Série EFI", cursoId: 4 },
        { id: 5, nome: "5ª Série EFII", cursoId: 5 },
        { id: 6, nome: "6ª Série EFII", cursoId: 5 },
        { id: 7, nome: "7ª Série EFII", cursoId: 5 },
        { id: 8, nome: "8ª Série EFII", cursoId: 5 },
        { id: 9, nome: "1ª Série EM", cursoId: 6 },
        { id: 10, nome: "2ª Série EM", cursoId: 6 },
        { id: 11, nome: "3ª Série EM", cursoId: 6 },
        { id: 12, nome: "Pré I", cursoId: 1 },
        { id: 13, nome: "Pré II", cursoId: 2 },
        { id: 14, nome: "Pré III", cursoId: 2 },
        { id: 15, nome: "Maternal", cursoId: 1 },
      ],
      seriesAux: [{ id: null, nome: "Selecione uma Série" }],
    };
  },

  watch: {
    cursoId(value) {
      console.log("value :>> ", value);
      this.seriesAux = this.series.filter((x) => x.cursoId == value);

      // seriesAux.forEach((element) => {
      //   let obj_serie = {
      //     id: element.id,
      //     nome: element.nome,
      //     cursoId: element.cursoId,
      //   };

      //   if (!this.series.find((a) => a.id == obj_serie.id)) {
      //     this.series.push(obj_serie);
      //   }
      // });
      this.serieId = null;
      this.seriesAux.unshift({ id: null, nome: "Selecione uma Série" });
      console.log("this.series :>> ", this.seriesAux);
    },

    filter(value) {
      let aluno = this.alunos.find((x) => x.nome == value);

      if (aluno) {
        this.alunoMatriculado.push(aluno);
      }
    },
  },

  methods: {
    clearFieldSearch() {
      this.alunoMatriculado = [];
      this.filter = null;
    },
  },
};
</script>

<style scoped></style>
