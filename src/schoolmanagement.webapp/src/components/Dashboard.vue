<template >
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Dashboard</h1>
      </div>
      <div class="row">
        <div class="col-6 col-md-4">{{ alunos.length }}</div>
        <div class="col-6 col-md-4">{{ turmas.length }}</div>
        <div class="col-6 col-md-4">{{ cursos.length }}</div>
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
      turmas:[],
      cursos:[],
    };
  },
  methods: {
    loadAluno() {
      const url = "https://localhost:5001/Aluno/get";

      axios.get(url).then((res) => {
        this.alunos = res.data.data;
      });
    },
    loadturma() {
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
</style>
