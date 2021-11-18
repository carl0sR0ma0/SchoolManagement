<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <b-button class="btnVoltar" variant="outline-info" @click="back()"
          >Voltar</b-button
        >
        <h1>Editando Disciplina</h1>
        <div class="form-floating mb-3">
          <input
            type="text"
            class="form-control"
            placeholder="teste"
            v-model="disciplina.nome"
          />
          <label for="floatingInput">Nome</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="disciplina.sigla"
            type="text"
            class="form-control"
            placeholder="Ex: MAT01"
            required
          />
          <label for="floatingInput">Sigla</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="disciplina.cargaHoraria"
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
            v-model="disciplina.conteudoProgramatico"
            placeholder="Ex: Aula01: Ensinando o Início da Matemática; Aula 02: Ensinando Adição Simples..."
            rows="3"
            max-rows="6"
          ></b-form-textarea>
          <label for="floatingInput">Conteúdo Programático</label>
        </div>
        <div class="form-floating mb-3">
          <b-form-textarea
            id="textarea"
            v-model="disciplina.ementa"
            placeholder="Ex: Cálculos Básicos: Adição, Subtração, Multiplicação e Divisão..."
            rows="3"
            max-rows="6"
          ></b-form-textarea>
          <label for="floatingInput">Ementa</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="disciplina.aulasSemanais"
            type="number"
            class="form-control"
            placeholder="Ex: 4"
            required
          />
          <label for="floatingInput">Aulas Semanais</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="disciplina.faltasPermitidas"
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
            v-b-modal="'ModalConfirm'"
            type="button"
            class="btn btn-success"
            @click="saveDisciplina"
          >
            Salvar
          </b-button>
        </div>
        <!-- Modal -->
        <b-modal
          ref="modalConfirmEdit"
          id="modalConfirmEdit"
          body-bg-variant="success"
          body-text-variant="light"
          centered
          hide-footer
          hide-header
        >
          <b-container fluid>
            <b-row class="mb-1 text-center">
              <b-col cols="3"></b-col>
              <b-col>Disciplina Atualizada!</b-col>
              <b-col><b-button @click="close()">OK</b-button></b-col>
            </b-row>
          </b-container>
        </b-modal>

        <b-modal
          id="mceditDisciplina"
          header-bg-variant="success"
          header-text-variant="light"
          centered
          hide-footer
        >
          <template v-slot:modal-header="{ close }">
            Disciplina Alterada
            <b-button @click="close">
              <b-icon icon="arrow90deg-left" />
            </b-button>
          </template>
          <div class="text-center">
            A disciplina {{ memoria }} foi alterada com sucesso!
          </div>
        </b-modal>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Detalhe_Disciplina",

  data() {
    return {
      disciplina: {},
      id: this.$route.params.id,
      visualizando: true,
      memoria: null,
    };
  },

  created() {
    this.loadDisciplina();
  },

  methods: {
    back() {
      this.$router.back();
    },

    saveDisciplina() {
      let _disciplinaEditar = {
        id: this.disciplina.id,
        nome: this.disciplina.nome,
        sigla: this.disciplina.sigla,
        cargaHoraria: this.disciplina.cargaHoraria,
        conteudoProgramatico: this.disciplina.conteudoProgramatico,
        ementa: this.disciplina.ementa,
        aulasSemanais: this.disciplina.aulasSemanais,
        faltasPermitidas: this.disciplina.faltasPermitidas,
        memoria: this.disciplina.memoria,
      };
      this.memoria = _disciplinaEditar.nome;

      const url = `https://localhost:5001/Disciplina/update`;
      axios.put(url, _disciplinaEditar).then(() => {
        this.$bvModal.show("mceditDisciplina");
        this.visualizando = !this.visualizando;
      });
    },

    close() {
      this.$refs.modalConfirmEdit.hide();
    },

    closeModalConfirmEdit() {
      this.$refs.mceditDisciplina.hide();
    },

    loadDisciplina() {
      const url = `https://localhost:5001/Disciplina/get/${this.id}`;

      axios.get(url).then((res) => {
        this.disciplina = res.data.data;
      });
    },
  },
};
</script>

<style>
.btnVoltar {
  float: right;
  margin-top: 25px;
}
</style>
