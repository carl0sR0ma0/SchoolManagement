<template >
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Curso</h1>

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
            v-model="coordenador"
            type="text"
            class="form-control"
            placeholder="teste"
            required
          />
          <label for="floatingInput">Coordenador</label>
        </div>

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="serieIni"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Serie Inicial</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="serieFin"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Serie Final</label>
            </div>
          </b-col>
        </b-row>

        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button type="button" class="btn btn-success" @click="addCurso">
            Salvar
          </b-button>
        </div>
      </div>

      <b-modal
        id="mccadCurso"
        header-bg-variant="success"
        header-text-variant="light"
        centered
        hide-footer
      >
        <template v-slot:modal-header="{ close }">
          <div center>Curso Cadastrado</div>
          <b-button @click="close">
            <b-icon icon="arrow90deg-left" />
          </b-button>
        </template>
        <div class="text-center">
          O curso {{ memoria3 }} foi cadastrado com sucesso!
        </div>
      </b-modal>

      <b-modal
        id="mccadCursoFail"
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
          <p>Não foi possivel cadastrar o Curso</p>
          <p>- É necessário inserir um nome.</p>
          <p>- O nome deve ter no mínimo 3 caracteres.</p>
        </div>
      </b-modal>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Curso",

  data() {
    return {
      nome: "",
      coordenador: "",
      serieIni: "",
      serieFin: "",
      memoria3: "",
    };
  },

  created() {},

  methods: {
    addCurso() {
      let _curso = {
        nome: this.nome,
        coordenador: this.coordenador,
        serieIni: this.serieIni,
        serieFin: this.serieFin,
      };

      this.memoria3 = _curso.nome;
      if (_curso.nome != "") {
        axios
          .post("https://localhost:5001/Curso/create", _curso)
          .then((res) => {
            this.$bvModal.show("mccadCurso");
          });
        this.nome = "";
        this.coordenador = "";
        this.serieIni = "";
        this.serieFin = "";
      } else {
        this.$bvModal.show("mccadCursoFail");
      }
    },
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
