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
                  @click="clearFields"
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
          <template v-slot:cell(nome)="data">
            <b-row cols="2" cols-sm="4" class="text-center">
              <a
                @click="aluno = data.item"
                v-b-modal="'ModalExcluir'"
                size="sm"
                class="mb-2"
              >
                {{ data.item.nome }}
              </a>
            </b-row>
          </template>
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
        <div class="form-floating mb-3">
          <select class="form-select" v-model="turmaId">
            <option
              v-for="turma in turmasAux"
              :key="turma.id"
              :value="turma.id"
            >
              {{ turma.nome }}
            </option>
          </select>
        </div>

        <div class="form-floating mb-3">
          <input
            v-model="data"
            type="text"
            class="form-control"
            placeholder="teste"
            onfocus="(this.type='datetime-local')"
            onblur="(this.type='text')"
            required
          />
          <label for="floatingInput">Data da Matricula</label>
        </div>
        <div class="form-floating mb-3">
          <select class="form-select" v-model="situacao">
            <option selected>Selecione uma opção</option>
            <option value="ATIVA">ATIVA</option>
            <option value="INATIVA">INATIVA</option>
          </select>
        </div>
        <div class="form-floating">
          <textarea
            class="form-control"
            placeholder="Leave a comment here"
            id="observacao"
            style="height: 100px"
            v-model="observacao"
          ></textarea>
          <label for="observacao">Observação</label>
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
                v-model="filterDisciplina"
                type="search"
                placeholder="Procurar Disciplina"
              ></b-form-input>

              <b-input-group-append style="margin-left: 10px">
                <b-button
                  :disabled="!filterDisciplina || !disciplinasProfessor"
                  @click="clearFields"
                  >Limpar</b-button
                >
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>

        <b-table
          striped
          hover
          :items="disciplinasProfessor"
          :fields="fieldsDisciplinas"
          :filter="filterDisciplina"
          :filter-included-fields="filterOn"
        >
          <template v-slot:cell(disciplina)="data">
            <b-row cols="2" cols-sm="4" class="text-center">
              <a
                @click="addDisciplinasMatriculadas(data.item)"
                size="sm"
                class="mb-2"
              >
                {{ !data.item.disciplina ? "" : data.item.disciplina.nome }}
              </a>
            </b-row>
          </template>
        </b-table>

        <div v-if="disciplinasMatriculadas.length >= 1">
          <h1>Disciplinas Matriculadas</h1>
          <b-table
            striped
            hover
            :items="disciplinasMatriculadas"
            :fields="fieldsDisciplinas"
            :filter="filterDisciplina"
            :filter-included-fields="filterOn"
          >
            <template v-slot:cell(disciplina)="data">
              <b-row cols="2" cols-sm="4" class="text-center">
                <a
                  @click="removeDisciplinasMatriculadas(data.item)"
                  size="sm"
                  class="mb-2"
                >
                  {{ !data.item.disciplina ? "" : data.item.disciplina.nome }}
                </a>
              </b-row>
            </template>
          </b-table>
        </div>

        <div
          class="d-grid gap-5 mt-3"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button type="button" class="btn btn-success" @click="addMatricula">
            Salvar
          </b-button>
        </div>
      </div>
    </div>

    <b-modal
      id="ModalConfirm"
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
      <div class="text-center">
        O aluno {{ aluno.nome }} foi matriculado na turma {{ turma.nome }} com
        sucesso!
      </div>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "FormMatricula",
  data() {
    return {
      cursoId: null,
      serieId: null,
      turmaId: null,
      aluno: {},
      turma: {},
      data: "",
      situacao: "Selecione uma opção",
      observacao: "",
      filter: null,
      filterDisciplina: null,
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
      fieldsDisciplinas: [
        {
          key: "disciplina",
          label: "Disciplina",
          sortable: true,
        },
        {
          key: "professor.nome",
          label: "Professor",
          sortable: true,
        },
        {
          key: "horario",
        },
      ],
      alunos: [],
      cursos: [],
      series: [],
      turmas: [],
      disciplinas: [],
      professores: [],
      disciplinasProfessor: [],
      disciplinasMatriculadas: [],
      seriesAux: [{ id: null, nome: "Selecione uma Série" }],
      turmasAux: [{ id: null, nome: "Selecione uma Turma" }],
    };
  },

  watch: {
    cursoId(value) {
      this.seriesAux = this.series.filter((x) => x.cursoId == value);
      this.serieId = null;
      this.seriesAux.unshift({ id: null, nome: "Selecione uma Série" });
    },

    serieId(value) {
      this.turmasAux = this.turmas.filter((x) => x.serieId == value);
      this.turmaId = null;
      this.turmasAux.unshift({ id: null, nome: "Selecione uma Turma" });
    },

    turmaId(value) {
      this.turma = this.turmas.find((x) => x.id == value);
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
      const url = "https://localhost:5001/Aluno/get";

      axios.get(url).then((res) => {
        this.alunos = res.data.data;
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

    loadDisciplinaProfessor() {
      const url = "https://localhost:5001/DisciplinaProfessor/get";

      axios.get(url).then((res) => {
        this.disciplinasProfessor = res.data.data;

        this.disciplinasProfessor.forEach((element) => {
          const url2 = `https://localhost:5001/Disciplina/get/${element.disciplinaId}`;
          const url3 = `https://localhost:5001/Professor/get/${element.professorId}`;

          axios.get(url2).then((disciplina) => {
            element.disciplina = disciplina.data.data;
          });

          axios.get(url3).then((professor) => {
            element.professor = professor.data.data;
          });
        });
      });
    },

    addDisciplinasMatriculadas(item) {
      if (!this.disciplinasMatriculadas.find((x) => x.id == item.id)) {
        this.disciplinasMatriculadas.push(item);
        let i = this.disciplinasProfessor.indexOf(item);
        if (i > -1) this.disciplinasProfessor.splice(i, 1);
      }
    },

    removeDisciplinasMatriculadas(item) {
      if (!this.disciplinasProfessor.find((x) => x.id == item.id)) {
        this.disciplinasProfessor.push(item);
        let i = this.disciplinasMatriculadas.indexOf(item);
        if (i > -1) this.disciplinasMatriculadas.splice(i, 1);
      }
    },

    addMatricula() {
      let auxDisciplinas = [];
      this.disciplinasMatriculadas.forEach((element) => {
        let dm = {
          disicplinaProfessorId: element.id,
          matriculaId: 0,
          horario: element.horario,
        };
        auxDisciplinas.push(dm);
      });

      let mat_save = {
        data: this.data,
        situacao: this.situacao,
        observacao: this.observacao,
        alunoId: this.aluno.id,
        turmaId: this.turmaId,
        disciplinaMatriculadas: auxDisciplinas,
      };

      const url = "https://localhost:5001/Matricula/create";

      axios.post(url, mat_save).then(() => {
        this.$bvModal.show("ModalConfirm");
        this.clearFields();
      });
    },

    clearFields() {
      this.alunoMatriculado = [];
      this.filter = null;
      this.cursoId = null;
      this.serieId = null;
      this.turmaId = null;
      this.data = "";
      this.situacao = "Selecione uma opção";
      this.observacao = "";

      this.disciplinasMatriculadas.forEach((element) => {
        this.disciplinasProfessor.push(element);
      });
      this.disciplinasMatriculadas = [];
    },
  },

  created() {
    this.loadStudents();
    this.loadCourse();
    this.loadSeries();
    this.loadClasses();
    this.loadDisciplinaProfessor();
  },
};
</script>

<style scoped></style>
