<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Consultar Alunos Matriculados por Turma</h1>
      </div>
      <div class="gridCombo">
        <select class="form-select" v-model="cursoId">
          <option v-for="curso in cursos" :key="curso.id" :value="curso.id">
            {{ curso.nome }}
          </option>
        </select>
        <select class="form-select" v-model="serieId">
          <option v-for="serie in seriesAux" :key="serie.id" :value="serie.id">
            {{ serie.nome }}
          </option>
        </select>
        <select class="form-select" v-model="turmaId">
          <option v-for="turma in turmasAux" :key="turma.id" :value="turma.id">
            {{ turma.nome }}
          </option>
        </select>
      </div>
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
            <b-button
              @click="Excluir(data.item.id)"
              v-b-modal="'ModalExcluir'"
              size="sm"
              variant="outline-danger"
              class="mb-2"
            >
              <b-icon icon="trash" aria-hidden="true"></b-icon>
            </b-button>
            <b-button
              :href="`#/Detalhe_Aluno/${data.item.id}`"
              style="margin: 0 15px"
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
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "AlunosMatriculados",
  data() {
    return {
      cursoId: null,
      cursos: [],
      serieId: null,
      series: [],
      turmaId: null,
      turmas: [],
      seriesAux: [{ id: null, nome: "Selecione uma série" }],
      turmasAux: [{ id: null, nome: "Selecione uma turma" }],
      alunos: [],
      fields: [
        {
          key: "nome",
          label: "Nome",
          sortable: true,
        },
        {
          key: "ra",
        },
        {
          key: "dataNascimento",
        },
        {
          key: "telefone",
        },
      ],
      filter: null,
      filterOn: [],
    };
  },

  watch: {
    cursoId(value) {
      this.seriesAux = this.series.filter((x) => x.cursoId == value);
      this.serieId = null;
      this.seriesAux.unshift({ id: null, nome: "Selecione uma série" });
    },

    serieId(value) {
      this.turmasAux = this.turmas.filter((x) => x.serieId == value);
      this.turmaId = null;
      this.turmasAux.unshift({ id: null, nome: "Selecione uma turma" });
    },

    turmaId(value) {
      this.turma = this.turmas.find((x) => x.id == value);
      this.loadStudents();
    },

    filter(value) {
      let aluno = this.alunos.filter((x) => x.nome.includes(value));
      if (!value) {
        this.alunoMatriculado = [];
        aluno = [];
      }

      if (aluno) {
        this.alunoMatriculado = [];
        this.alunoMatriculado = aluno;
      }
    },
  },

  methods: {
    loadStudents() {
      this.alunos = [];
      const url = `https://localhost:5001/Matricula/getMatriculasByTurma/${this.turmaId}`;

      axios.get(url).then((res) => {
        let aux = res.data.data;
        aux.forEach((element) => {
          this.alunos.push(element.aluno);
        });
      });
    },

    loadCourse() {
      const url = "https://localhost:5001/Curso/get";

      axios.get(url).then((res) => {
        this.cursos = res.data.data;
        this.cursos.unshift({ id: null, nome: "Selecione um Curso..." });
      });
    },

    loadSeries() {
      const url = "https://localhost:5001/Serie/get";

      axios.get(url).then((res) => {
        this.series = res.data.data;
        this.series.unshift({ id: null, nome: "Selecione uma Série..." });
      });
    },

    loadClasses() {
      const url = "https://localhost:5001/Turma/get";

      axios.get(url).then((res) => {
        this.turmas = res.data.data;
        this.turmas.unshift({ id: null, nome: "Selecione uma Turma..." });
      });
    },
  },

  created() {
    this.loadCourse();
    this.loadSeries();
    this.loadClasses();
  },
};
</script>

<style scoped>
.gridCombo {
  display: grid;
  grid-template-columns: 33.33% 33.33% 33.33%;
}
</style>
