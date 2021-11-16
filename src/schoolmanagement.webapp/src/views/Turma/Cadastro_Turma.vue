<template >
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Turma</h1>

        <b-row>
          <b-col cols="8">
            <div class="form-floating mb-3">
              <input
                v-model="nome"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Nome</label>
            </div>
          </b-col>
          <b-col cols="4">
            <div class="form-floating mb-3">
              <select class="form-select" v-model="serieId">
                <option
                  v-for="serie in series"
                  :key="serie.id"
                  :value="serie.id"
                >
                  {{ serie.nome }}
                </option>
              </select>
            </div>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="turno"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Turno</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="ano"
                type="number"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Ano</label>
            </div>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="sigla"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Sigla</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="situacao"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Situação</label>
            </div>
          </b-col>
        </b-row>

        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button type="button" class="btn btn-success" @click="addTurma">
            Salvar
          </b-button>
        </div>
      </div>

      <b-modal
        id="mccadTurma"
        header-bg-variant="success"
        header-text-variant="light"
        centered
        hide-footer
      >
        <template v-slot:modal-header="{ close }">
          <div center>Turma Cadastrada</div>
          <b-button @click="close">
            <b-icon icon="arrow90deg-left" />
          </b-button>
        </template>
        <div class="text-center">
          A Turma {{ memoria6 }} foi cadastrada com sucesso!
        </div>
      </b-modal>

      <b-modal
        id="mccadTurmaFail"
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
          <p>Não foi possivel cadastrar a Turma</p>
          <p>- É necessário inserir o nome.</p>
        </div>
      </b-modal>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Turma",

  data() {
    return {
      serieId: null,
      nome: "",
      turno: "",
      ano: "",
      sigla: "",
      situacao: "",
      memoria6: "",
      series: [],
    };
  },

  created() {},

  methods: {
    addTurma() {
      let _turma = {
        serieId: this.serieId,
        nome: this.nome,
        turno: this.turno,
        ano: this.ano,
        sigla: this.sigla,
        situacao: this.situacao,
      };

      this.memoria6 = _turma.nome;

      if (_turma.nome != "" && _turma.serieId > 0) {
        axios
          .post("https://localhost:5001/Turma/create", _turma)
          .then((res) => {
            this.$bvModal.show("mccadTurma");
          });
        this.serieId = "";
        this.nome = "";
        this.turno = "";
        this.ano = "";
        this.sigla = "";
        this.situacao = "";
      } else {
        this.$bvModal.show("mccadTurmaFail");
      }
    },

    loadSerie() {
      const url = "https://localhost:5001/Serie/get";

      axios.get(url).then((res) => {
        this.series = res.data.data;
        this.series.unshift({ id: null, nome: "Selecione uma Série" });
      });
    },
  },
  created() {
    this.loadSerie();
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
