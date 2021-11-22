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
        <select
          v-if="disciplinas.length >= 1"
          class="form-select"
          v-model="disciplinaId"
        >
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

    <!-- Modal Confirm -->
    <b-modal
      id="ModalConfirmNotas"
      header-bg-variant="success"
      header-text-variant="light"
      centered
      hide-footer
    >
      <template v-slot:modal-header="{ close }">
        Aluno Matriculado
        <b-button @click="close">
          <b-icon icon="arrow90deg-left" />
        </b-button>
      </template>
      <div class="text-center">As notas foram lançadas com Sucesso!!!</div>
    </b-modal>

    <b-modal
      id="mclanNotaFail"
      header-bg-variant="danger"
      header-text-variant="light"
      centered
      hide-footer
    >
      <template v-slot:modal-header="{ close }">
        <div center>Erro ao Lançar a Nota</div>
        <b-button @click="close">
          <b-icon icon="arrow90deg-left" />
        </b-button>
      </template>
      <div class="text-center">
        <p>
          Por favor selecionar a disciplina em que o aluno esteja matriculado.
        </p>
      </div>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Nota",

  data() {
    return {
      cursoId: null,
      cursos: [],
      serieId: null,
      series: [],
      turmaId: null,
      turmas: [],
      disciplinaId: null,
      disciplinaMatriculadas: [],
      disciplinas: [],
      disciplinaMatriculada: {},
      seriesAux: [{ id: null, nome: "Selecione uma série" }],
      turmasAux: [{ id: null, nome: "Selecione uma turma" }],
      discAux: [{ id: null, nome: "Selecione uma turma" }],
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
      this.loadStudents();
    },

    disciplinaId(value) {
      if (value != null) {
        if (!this.disciplinaMatriculadas.find((x) => x.disciplinaId == value)) {
          this.$bvModal.show("mclanNotaFail");
          this.disciplinaId = null;
        }
      }
      this.discAux = this.disciplinas.find((x) => x.id == value);

      this.disciplinaMatriculada = this.disciplinaMatriculadas.find(
        (x) => x.disciplinaId == this.discAux.id
      );

      this.alunos.forEach((element) => {
        const url = `https://localhost:5001/Nota/getByAlunoDisciplina/${element.id}/${this.disciplinaId}`;

        axios.get(url).then((res) => {
          if (res.data.data.length > 0) {
            element.nota1 = res.data.data[0].nota1;
            element.nota2 = !res.data.data[0].nota2
              ? 0
              : res.data.data[0].nota2;
            element.nota3 = res.data.data[0].nota3;
            element.nota4 = res.data.data[0].nota4;
            element.media =
              (res.data.data[0].nota1 +
                res.data.data[0].nota2 +
                res.data.data[0].nota3 +
                res.data.data[0].nota4) /
              4;
            element.aprovadoReprovado = res.data.data[0].aprovadoReprovado;
          }
        });
      });
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
        aux.forEach((el) => {
          el.disciplinaMatriculadas.forEach((a) => {
            this.disciplinaMatriculadas.push(a);
          });
        });

        const urlD = `https://localhost:5001/Disciplina/get`;

        axios.get(urlD).then((res) => {
          this.disciplinas = res.data.data;
          this.disciplinas.unshift({
            id: null,
            nome: "Selecione uma Disciplina...",
          });
        });
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

    lancarNotas() {
      this.alunos.forEach((element) => {
        let lancaNotaAluno = {
          alunoId: element.id,
          turmaId: this.turmaId,
          disciplinaId: this.disciplinaId,
          media: element.media ? parseFloat(element.media) : 0.0,
          aprovadoReprovado: false,
        };

        if (element.nota2 == undefined) {
          //create
          lancaNotaAluno.nota1 = parseFloat(element.nota1);
          lancaNotaAluno.nota2 = 0;
          lancaNotaAluno.nota3 = 0;
          lancaNotaAluno.nota4 = 0;
          const url = `https://localhost:5001/Nota/create`;

          axios.post(url, lancaNotaAluno).then(() => {
            this.$bvModal.show("ModalConfirmNotas");
            this.clearFields();
          });
        } else {
          //update
          lancaNotaAluno.nota1 = parseFloat(element.nota1);
          lancaNotaAluno.nota2 = parseFloat(element.nota2);
          lancaNotaAluno.nota3 = parseFloat(element.nota3);
          lancaNotaAluno.nota4 = parseFloat(element.nota4);
          const url = `https://localhost:5001/Nota/update`;

          axios.put(url, lancaNotaAluno).then(() => {
            this.$bvModal.show("ModalConfirmNotas");
            this.clearFields();
          });
        }
      });
    },

    clearFields() {
      this.alunos = [];
      this.filter = null;
      this.cursoId = null;
      this.serieId = null;
      this.turmaId = null;
      this.disciplinaId = null;
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

.nota {
  max-width: 70px;
}
</style>
