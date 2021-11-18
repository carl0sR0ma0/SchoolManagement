<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <b-button class="btnVoltar" variant="outline-info" @click="voltar()"
          >Voltar</b-button
        >
        <h1>Editando o Professor</h1>

        <div class="form-floating mb-3">
          <input
            v-model="professor.nome"
            type="text"
            class="form-control"
            placeholder="teste"
            required
          />
          <label for="floatingInput">Nome</label>
        </div>

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.dataNascimento"
                type="text"
                class="form-control"
                placeholder="teste"
                onfocus="(this.type='date')"
                onblur="(this.type='text')"
                required
              />
              <label for="floatingInput">Data de Nascimento</label>
            </div>
          </b-col>

          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.dataAdmissao"
                type="text"
                class="form-control"
                placeholder="teste"
                onfocus="(this.type='date')"
                onblur="(this.type='text')"
                required
              />
              <label for="floatingInput">Data de Admissão</label>
            </div>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.rg"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">RG</label>
            </div>
          </b-col>

          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.cpf"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">CPF</label>
            </div>
          </b-col>

          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.telefone"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Telefone</label>
            </div>
          </b-col>
        </b-row>

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.ctps"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">CTPS</label>
            </div>
          </b-col>

          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.licenca"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Licença</label>
            </div>
          </b-col>

          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="professor.titulacao"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Titulação</label>
            </div>
          </b-col>
        </b-row>

        <div v-if="disciplinasProfessor.length >= 1">
          <h1>Disciplinas Ministradas</h1>
          <b-table
            striped
            hover
            :items="disciplinasProfessor"
            :fields="fieldsDisciplinasProfessor"
            :filter="filterDisciplina"
            :filter-included-fields="filterOn"
          >
            <template v-slot:cell(nome)="data">
              <b-row cols="2" cols-sm="4" class="text-center">
                <a
                  @click="removeDisciplinasProfessor(data.item)"
                  size="sm"
                  class="mb-2"
                >
                  {{ data.item.nome }}
                </a>
              </b-row>
            </template>
            <template v-slot:cell(dia)="row">
              <b-form-input v-model="row.item.dia" />
            </template>
            <template v-slot:cell(horario)="row2">
              <b-form-input v-model="row2.item.horario" />
            </template>
          </b-table>
        </div>

        <h1>Disciplinas Disponíveis</h1>

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
                  @click="clearDisciplinas"
                  >Limpar</b-button
                >
              </b-input-group-append>
            </b-input-group>
          </b-form-group>
        </b-col>

        <b-table
          striped
          hover
          :items="disciplinas"
          :fields="fieldsDisciplinas"
          :filter="filterDisciplina"
          :filter-included-fields="filterOn"
        >
          <template v-slot:cell(nome)="data">
            <b-row cols="2" cols-sm="4" class="text-center">
              <a
                @click="addDisciplinasProfessor(data.item)"
                size="sm"
                class="mb-2"
              >
                {{ data.item.nome }}
              </a>
            </b-row>
          </template>
        </b-table>

        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button
            v-b-modal="'ModalConfirm'"
            type="button"
            class="btn btn-success"
            @click="SalvarProfessor"
          >
            Salvar
          </b-button>
        </div>

        <b-modal
          ref="ModalConfirm"
          id="ModalConfirm"
          body-bg-variant="success"
          body-text-variant="light"
          centered
          hide-footer
          hide-header
        >
          <b-container fluid>
            <b-row class="mb-1 text-center">
              <b-col cols="3"></b-col>
              <b-col>Professor Atualizado!</b-col>
              <b-col><b-button @click="close()">OK</b-button></b-col>
            </b-row>
          </b-container>
        </b-modal>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  components: {},
  data() {
    return {
      professor: {},
      id: this.$route.params.id,
      visualizando: true,
      disciplinasByProfessor: [],
      filter: null,
      filterDisciplina: null,
      disciplinas: [],
      disciplinasProfessor: [],
      filterOn: [],
      fieldsDisciplinas: [
        {
          key: "nome",
          label: "Nome",
          sortable: true,
        },
        {
          key: "sigla",
        },
        {
          key: "aulasSemanais",
        },
      ],
      fieldsDisciplinasProfessor: [
        {
          key: "nome",
          label: "Nome",
          sortable: true,
        },
        {
          key: "sigla",
        },
        {
          key: "aulasSemanais",
        },
        {
          key: "dia",
        },
        {
          key: "horario",
        },
      ],
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },

    SalvarProfessor() {
      let auxDisciplinas = [];
      this.disciplinasProfessor.forEach((element) => {
        let dp = {
          id: element.disciplinaProfessorId,
          disciplinaId: element.id,
          professorId: 0,
          dia: element.dia,
          horario: element.horario,
        };
        auxDisciplinas.push(dp);
      });

      let _professorEditar = {
        id: this.id,
        ra: this.professor.ra,
        nome: this.professor.nome,
        dataNascimento: this.professor.dataNascimento,
        rg: this.professor.rg,
        cpf: this.professor.cpf,
        telefone: this.professor.telefone,
        sexo: this.professor.sexo,
        ctps: parseInt(this.professor.ctps),
        licenca: this.professor.licenca,
        titulacao: this.professor.titulacao,
        dataAdmissao: this.professor.dataAdmissao,
        disciplinas: auxDisciplinas,
      };

      axios.put("https://localhost:5001/Professor/update", _professorEditar);
      this.visualizando = !this.visualizando;
    },

    close() {
      this.$refs.ModalConfirm.hide();
    },

    clearDisciplinas() {
      this.disciplinasProfessor.forEach((element) => {
        this.disciplinas.push(element);
      });
      this.disciplinasProfessor = [];
    },

    loadDisciplinasMinistradas() {
      const url = `https://localhost:5001/DisciplinaProfessor/getdisciplinaprofessorByProfessor/${this.id}`;

      axios.get(url).then((res) => {
        this.disciplinasByProfessor = res.data.data;

        this.disciplinasByProfessor.forEach((element) => {
          let dp = {
            id: null,
            disciplinaProfessorId: null,
            nome: null,
            sigla: null,
            dia: null,
            horario: null,
            aulasSemanais: null,
          };
          dp.dia = element.dia;
          dp.horario = element.horario;
          dp.id = element.disciplinaId;
          dp.disciplinaProfessorId = element.id;
          const urlD = `https://localhost:5001/Disciplina/get/${element.disciplinaId}`;
          axios.get(urlD).then((res) => {
            dp.nome = res.data.data.nome;
            dp.sigla = res.data.data.sigla;
            dp.aulasSemanais = res.data.data.aulasSemanais;
            this.disciplinasProfessor.push(dp);
          });
        });
      });
    },

    loadDisciplinas() {
      const url = "https://localhost:5001/Disciplina/get";

      axios.get(url).then((res) => {
        this.disciplinas = res.data.data;
      });
    },

    removeDisciplinasProfessor(item) {
      if (!this.disciplinas.find((x) => x.id == item.id)) {
        this.disciplinas.push(item);
        let i = this.disciplinasProfessor.indexOf(item);
        if (i > -1) this.disciplinasProfessor.splice(i, 1);
      }
    },

    addDisciplinasProfessor(item) {
      if (!this.disciplinasProfessor.find((x) => x.id == item.id)) {
        item.dia = "";
        item.horario = "";
        this.disciplinasProfessor.push(item);
        let i = this.disciplinas.indexOf(item);
        if (i > -1) this.disciplinas.splice(i, 1);
      }
    },
  },

  created() {
    axios.get(`https://localhost:5001/Professor/get/${this.id}`).then((res) => {
      this.professor = res.data.data;
    });

    this.loadDisciplinas();
    this.loadDisciplinasMinistradas();
  },
};
</script>

<style scoped>
.btnVoltar {
  float: right;
  margin-top: 25px;
}
</style>
