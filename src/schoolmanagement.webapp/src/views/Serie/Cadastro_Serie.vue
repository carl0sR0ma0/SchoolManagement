<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Série</h1>

        <div class="form-floating mb-3">
          <input
            v-model="nome"
            type="text"
            class="form-control"
            placeholder="teste"
            required
          />
          <label for="floatingInput">Nome</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="descricao"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Descrição</label>
        </div>
        <div class="form-floating mb-3">
          <select class="form-select" v-model="cursoId">
            <option v-for="curso in cursos" :key="curso.id" :value="curso.id">
              {{ curso.nome }}
            </option>
          </select>
        </div>
        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button type="button" class="btn btn-success" @click="addSerie">
            Salvar
          </b-button>
        </div>
      </div>
    </div>
    <b-modal
      id="mccadSerie"
      header-bg-variant="success"
      header-text-variant="light"
      centered
      hide-footer
    >
      <template v-slot:modal-header="{ close }">
        <div center>Série Cadastrada</div>
        <b-button @click="close">
          <b-icon icon="arrow90deg-left" />
        </b-button>
      </template>
      <div class="text-center">
        A Série {{ memoria5 }} foi cadastrado com sucesso!
      </div>
    </b-modal>

    <b-modal
      id="mccadSerieFail"
      header-bg-variant="danger"
      header-text-variant="light"
      centered
      hide-footer
    >
      <template v-slot:modal-header="{ close }">
        <div center>Erro ao Cadastrar</div>
        <b-button @click="close">
          <b-icon icon="arrow90deg-left" />
        </b-button>
      </template>
      <div class="text-center">
        <p>Não foi possivel cadastrar a Série</p>
        <p>- O nome deve ter no mínimo 3 caracteres.</p>
        <p>- A descrição deve ter no mínimo 10 caracteres.</p>
      </div>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Serie",

  data() {
    return {
      nome: "",
      descricao: "",
      cursoId: null,
      memoria5: "",
      cursos: [],
    };
  },

  methods: {
    addSerie() {
      let _serie = {
        nome: this.nome,
        descricao: this.descricao,
        cursoId: this.cursoId,
      };

      this.memoria5 = _serie.nome;

      if (
        _serie.nome != "" &&
        _serie.cursoId > 0 &&
        _serie.descricao.length > 10
      ) {
        axios
          .post("https://localhost:5001/Serie/create", _serie)
          .then((res) => {
            this.$bvModal.show("mccadSerie");
          });
        this.nome = "";
        this.descricao = "";
        this.cursoId = null;
      } else {
        this.$bvModal.show("mccadSerieFail");
      }
    },
    loadCurso() {
      const url = "https://localhost:5001/Curso/get";

      axios.get(url).then((res) => {
        this.cursos = res.data.data;
        this.cursos.unshift({ id: null, nome: "Selecione um Curso" });
      });
    },
  },

  created() {
    this.loadCurso();
  },
};
</script>

<style scoped>
.temp {
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  min-height: 100vh;
  background: #212529;
}

.container {
  background: #fff;
  border-radius: 15px;
}
</style>
