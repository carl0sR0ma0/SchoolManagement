<template>
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Professor</h1>

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

        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="dataNascimento"
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
                v-model="dataAdmissao"
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
                v-model="rg"
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
                v-model="cpf"
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
                v-model="telefone"
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
                v-model="ctps"
                type="number"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">CTPS</label>
            </div>
          </b-col>

          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="licenca"
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
                v-model="titulacao"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Titulação</label>
            </div>
          </b-col>
        </b-row>

        <fieldset class="row mb-3">
          <legend
            class="col-form-label col-sm-2 pt-0"
            style="margin-left: 15px"
          >
            Sexo
          </legend>
          <div class="col-sm">
            <div class="form-check">
              <input
                class="form-check-input"
                type="radio"
                name="gridRadios1"
                v-model="sexo"
                value="Masculino"
                checked
              />
              <label class="form-check-label" for="gridRadios1">
                Masculino
              </label>
            </div>
            <div class="form-check">
              <input
                class="form-check-input"
                type="radio"
                name="gridRadios2"
                v-model="sexo"
                value="Feminino"
              />
              <label class="form-check-label" for="gridRadios2">
                Feminino
              </label>
            </div>
          </div>
        </fieldset>

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

        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px; margin-top: 50px"
        >
          <b-button type="button" class="btn btn-success" @click="addProfessor">
            Salvar
          </b-button>
        </div>
      </div>

      <b-modal
        id="mccadProfessor"
        header-bg-variant="success"
        header-text-variant="light"
        centered
        hide-footer
      >
        <template v-slot:modal-header="{ close }">
          <div center>Professor Cadastrado</div>
          <b-button @click="close">
            <b-icon icon="arrow90deg-left" />
          </b-button>
        </template>
        <div class="text-center">
          O Professor {{ tempProf }} foi cadastrado com sucesso!
        </div>
      </b-modal>

      <b-modal
        id="mccadProfessorFail"
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
          <p>Não foi possivel cadastrar o professor</p>
          <p>- É necessário inserir um nome.</p>
          <p>- É necessário inserir a data de nascimento.</p>
        </div>
      </b-modal>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Cadastro_Professor",

  data() {
    return {
      nome: null,
      dataNascimento: null,
      rg: null,
      cpf: null,
      sexo: null,
      telefone: null,
      ctps: null,
      licenca: null,
      titulacao: null,
      dataAdmissao: null,
      tempProf: null,
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

  created() {
    this.loadDisciplinas();
  },

  methods: {
    loadDisciplinas() {
      const url = "https://localhost:5001/Disciplina/get";

      axios.get(url).then((res) => {
        this.disciplinas = res.data.data;
      });
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

    removeDisciplinasProfessor(item) {
      if (!this.disciplinas.find((x) => x.id == item.id)) {
        this.disciplinas.push(item);
        let i = this.disciplinasProfessor.indexOf(item);
        if (i > -1) this.disciplinasProfessor.splice(i, 1);
      }
    },

    addProfessor() {
      let auxDisciplinas = [];
      this.disciplinasProfessor.forEach((element) => {
        let dp = {
          disciplinaId: element.id,
          professorId: 0,
          dia: element.dia,
          horario: element.horario,
        };
        auxDisciplinas.push(dp);
      });

      let _professor = {
        ctps: parseInt(this.ctps),
        nome: this.nome,
        dataNascimento: this.dataNascimento,
        rg: this.rg,
        cpf: this.cpf,
        telefone: this.telefone,
        sexo: this.sexo,
        licenca: this.licenca,
        titulacao: this.titulacao,
        dataAdmissao: this.dataAdmissao,
        disciplinas: auxDisciplinas,
      };
      this.tempProf = _professor.nome;

      const url = `https://localhost:5001/Professor/create`;

      if (_professor.nome && _professor.dataNascimento) {
        axios.post(url, _professor).then((res) => {
          this.$bvModal.show("mccadProfessor");
          this.clearFields();
        });
      } else {
        this.$bvModal.show("mccadProfessorFail");
      }
    },

    clearDisciplinas() {
      this.disciplinasProfessor.forEach((element) => {
        this.disciplinas.push(element);
      });
      this.disciplinasProfessor = [];
    },

    clearFields() {
      this.nome = null;
      this.dataNascimento = null;
      this.rg = null;
      this.cpf = null;
      this.telefone = null;
      this.sexo = null;
      this.ctps = null;
      this.licenca = null;
      this.titulacao = null;
      this.dataAdmissao = null;

      this.clearDisciplinas();
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
  min-height: 95vh;
  background: #212529;
}

.container {
  background: #fff;
  border-radius: 15px;
}
</style>
