<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Disciplina</h1>
        <div class="form-floating mb-3">
          <input
            v-model="nome"
            type="text"
            class="form-control"
            placeholder="Ex: Matemática I"
            required
          />
          <label for="floatingInput">Nome</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="sigla"
            type="text"
            class="form-control"
            placeholder="Ex: MAT01"
            required
          />
          <label for="floatingInput">Sigla</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="cargaHoraria"
            type="number"
            class="form-control"
            placeholder="Horas/Aulas"
            required
          />
          <label for="floatingInput">Carga Horária</label>
        </div>
        <div class="form-floating mb-3">
          <b-form-textarea
            id="textarea"
            v-model="conteudoProgramatico"
            placeholder="Ex: Aula01: Ensinando o Início da Matemática; Aula 02: Ensinando Adição Simples..."
            rows="3"
            max-rows="6"
          ></b-form-textarea>
          <label for="floatingInput">Conteúdo Programático</label>
        </div>
        <div class="form-floating mb-3">
          <b-form-textarea
            id="textarea"
            v-model="ementa"
            placeholder="Ex: Cálculos Básicos: Adição, Subtração, Multiplicação e Divisão..."
            rows="3"
            max-rows="6"
          ></b-form-textarea>
          <label for="floatingInput">Ementa</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="aulasSemanais"
            type="number"
            class="form-control"
            placeholder="Ex: 4"
            required
          />
          <label for="floatingInput">Aulas Semanais</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="faltasPermitidas"
            type="number"
            class="form-control"
            placeholder="Ex: 20"
            required
          />
          <label for="floatingInput">Faltas Permitidas</label>
        </div>
        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button
            type="button"
            class="btn btn-success"
            @click="addDisciplina"
          >
            Salvar
          </b-button>
        </div>
      </div>
      <!-- Modais -->
      <b-modal
        id="mccadDisciplina"
        header-bg-variant="success"
        header-text-variant="light"
        centered
        hide-footer
      >
        <template v-slot:modal-header="{ close }">
          Disciplina Cadastrada
          <b-button @click="close">
            <b-icon icon="arrow90deg-left" />
          </b-button>
        </template>
        <div class="text-center">
          A disciplina {{ memoria }} foi cadastrada com sucesso!
        </div>
      </b-modal>
      <b-modal
        id="mccadDisciplinaFail"
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
          <p>Não foi possivel cadastrar a Disciplina</p>
          <p>- É necessário inserir um nome.</p>
          <p>- É necessário inserir a Sigla.</p>
          <p>- É necessário inserir a Carga Horária.</p>
          <p>- É necessário inserir a Quantidade de Aulas Semanais.</p>
        </div>
      </b-modal>
      <!-- Fim Modais -->
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Disciplina",

  data() {
    return {
      nome: null,
      sigla: null,
      cargaHoraria: null,
      conteudoProgramatico: null,
      ementa: null,
      aulasSemanais: null,
      faltasPermitidas: null,
      memoria: null,
    };
  },

  created() {},

  methods: {
    addDisciplina() {
      let disciplina = {
        Nome: this.nome,
        Sigla: this.sigla,
        CargaHoraria: this.cargaHoraria,
        ConteudoProgramatico: this.conteudoProgramatico,
        Ementa: this.ementa,
        AulasSemanais: this.aulasSemanais,
        FaltasPermitidas: this.faltasPermitidas,
      };

      this.memoria = disciplina.Nome;
      if (
        disciplina.Nome &&
        disciplina.Sigla &&
        disciplina.CargaHoraria &&
        disciplina.AulasSemanais
      ) {
        axios
          .post("https://localhost:5001/Disciplina/create", disciplina)
          .then(() => {
            this.$bvModal.show("mccadDisciplina");
          });
        this.clearFields();
      } else {
        this.$bvModal.show("mccadDisciplinaFail");
      }
    },

    clearFields() {
      this.nome = null;
      this.sigla = null;
      this.cargaHoraria = null;
      this.conteudoProgramatico = null;
      this.ementa = null;
      this.aulasSemanais = null;
      this.faltasPermitidas = null;
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
