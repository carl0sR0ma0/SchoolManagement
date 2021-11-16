<template >
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Dashboard</h1>
      </div>
      <div class="row">
        <div class="col-6 col-md-4">
          <div class="data-card">
            <h3>{{ alunos.length }}</h3>
            <h4>Alunos Cadastrados</h4>
      </div>
    </div>
        <div class="col-6 col-md-4">
          <div class="data-card">
            <h3>{{ turmas.length }}</h3>
            <h4>Turmas Cadastradas</h4>
  </div>
        </div>
        <div class="col-6 col-md-4">
          <div class="data-card">
            <h3>{{ cursos.length }}</h3>
            <h4>Cursos Cadastrados</h4>
          </div>
        </div>
      </div>
      <div class="container">
        <column-chart
          :data="[
            ['Alunos', alunos.length],
            ['Turmas', turmas.length],
            ['Cursos', cursos.length],
          ]"
        ></column-chart>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Dashboard",
  data() {
    return {
      alunos: [],
      turmas: [],
      cursos: [],
    };
  },
  methods: {
    loadAluno() {
      const url = "https://localhost:5001/Aluno/get";

      axios.get(url).then((res) => {
        this.alunos = res.data.data;
      });
    },
    loadTurma() {
      const url = "https://localhost:5001/Turma/get";

      axios.get(url).then((res) => {
        this.turmas = res.data.data;
      });
    },
    loadCurso() {
      const url = "https://localhost:5001/Curso/get";

      axios.get(url).then((res) => {
        this.cursos = res.data.data;
      });
    },
  },
  created() {
    this.loadAluno();
    this.loadTurma();
    this.loadCurso();
  },
};
</script>

<style scoped>
.data-card {
  display: flex;
  flex-direction: column;
  max-width: 20.75em;
  overflow: hidden;
  border-radius: 0.5em;
  text-decoration: none;
  background: white;
  margin: 1em;
  padding: 2.75em 2.5em;
  box-shadow: 0 1.5em 2.5em -0.5em rgba(#000000, 1);
}
h3 {
  color: #2e3c40;
  font-size: 3.5em;
  font-weight: 600;
  line-height: 1;
  padding-bottom: 0.5em;
  margin: 0 0 0.142857143em;
  border-bottom: 2px solid #0d6efd;
  transition: color 0.45s ease, border 0.45s ease;
}

h4 {
  color: #627084;
  text-transform: uppercase;
  font-size: 1.125em;
  font-weight: 700;
  line-height: 1;
  letter-spacing: 0.1em;
  margin: 0 0 1.777777778em;
  transition: color 0.45s ease;
}
</style>
