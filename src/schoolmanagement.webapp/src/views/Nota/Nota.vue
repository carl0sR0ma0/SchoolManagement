<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Lançamento de Notas</h1>
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
        <select class="form-select" v-model="disciplinaId">
          <option
            v-for="disciplina in disciplinas"
            :key="disciplina.id"
            :value="disciplina.id"
          >
            {{ disciplina.nome }}
          </option>
        </select>
      </div>
      <b-table striped hover :items="alunos" :fields="fields">
        <template v-slot:cell(nota1)="nota1">
          <b-form-input class="nota" v-model="nota1.item.nota1" />
        </template>
        <template v-slot:cell(nota2)="nota2">
          <b-form-input class="nota" v-model="nota2.item.nota2" />
        </template>
        <template v-slot:cell(nota3)="nota3">
          <b-form-input class="nota" v-model="nota3.item.nota3" />
        </template>
        <template v-slot:cell(nota4)="nota4">
          <b-form-input class="nota" v-model="nota4.item.nota4" />
        </template>
        <template v-slot:cell(media)="media">
          <b-form-input class="nota" v-model="media.item.media" />
        </template>
      </b-table>
      <div
        class="d-grid gap-5"
        style="padding-left: 100px; padding-right: 100px"
      >
        <b-button type="button" class="btn btn-success" @click="lancarNotas">
          Lançar Notas
        </b-button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Nota",

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

  data() {
    return {
      cursoId: null,
      cursos: [],
      serieId: null,
      series: [],
      turmaId: null,
      turmas: [],
      disciplinas: [],
      disciplinaId: null,
      disciplinaMatriculadas: [],
      seriesAux: [{ id: null, nome: "Selecione uma série" }],
      turmasAux: [{ id: null, nome: "Selecione uma turma" }],
      alunos: [],
      filter: null,
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
        {
          key: "nota1",
        },
        {
          key: "nota2",
        },
        {
          key: "nota3",
        },
        {
          key: "nota4",
        },
        {
          key: "media",
        },
      ],
      fieldsOfStudents: { Name: "name", Age: "age" },
      items: [
        { name: "Joe", age: 33 },
        { name: "Sue", age: 77 },
      ],
    };
  },

  methods: {
    loadStudents() {
      this.alunos = [];
      const url = `https://localhost:5001/Matricula/getMatriculasByTurma/${this.turmaId}`;

      axios.get(url).then((res) => {
        let aux = res.data.data;
        this.disciplinaMatriculadas = aux[0].disciplinaMatriculadas;
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

    loadDisciplinas() {
      const url = "https://localhost:5001/Disciplina/get";

      axios.get(url).then((res) => {
        this.disciplinas = res.data.data;
        this.disciplinas.unshift({
          id: null,
          nome: "Selecione uma Disciplina...",
        });
      });
    },

    lancarNotas() {
      this.disciplinaMatriculadas.forEach((el) => {
        const urlDP = `https://localhost:5001/DisciplinaProfessor/get/${el.disicplinaProfessorId}`;

        axios.get(urlDP).then(() => {});
      });

      this.alunos.forEach((element) => {
        let lancaNotaAluno = {
          alunoId: element.Id,
          disciplinaMatriculadaId: 1,
        };
        if (!element.nota2) {
          //create
        } else {
          //update
        }
      });
    },
  },

  created() {
    this.loadCourse();
    this.loadSeries();
    this.loadClasses();
    this.loadDisciplinas();
  },
};
</script>

<style scoped>
.gridCombo {
  display: grid;
  grid-template-columns: 33.33% 33.33% 33.33%;
}

.nota {
  max-width: 70px;
}
</style>