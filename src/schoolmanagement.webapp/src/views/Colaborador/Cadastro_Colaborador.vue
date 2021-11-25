<template >
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Colaborador</h1>

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
        <div class="form-floating mb-3">
          <input
            v-model="rg"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">RG</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="cpf"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">CPF</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="telefone"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">Telefone</label>
        </div>
        <div class="form-floating mb-3">
          <input
            v-model="ctps"
            type="text"
            class="form-control"
            placeholder="teste"
          />
          <label for="floatingInput">CTPS</label>
        </div>
        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="cargo"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Cargo</label>
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
              />
              <label for="floatingInput">Data de Admissão</label>
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
        <div
          class="d-grid gap-5"
          style="padding-left: 100px; padding-right: 100px"
        >
          <b-button
            type="button"
            class="btn btn-success"
            @click="addColaborador"
          >
            Salvar
          </b-button>
        </div>
      </div>

      <b-modal
        id="mccadColaborador"
        header-bg-variant="success"
        header-text-variant="light"
        centered
        hide-footer
      >
        <template v-slot:modal-header="{ close }">
          <div center>Colaborador Cadastrado</div>
          <b-button @click="close">
            <b-icon icon="arrow90deg-left" />
          </b-button>
        </template>
        <div class="text-center">
          O Colaborador {{ memoria1 }} foi cadastrado com sucesso!
        </div>
      </b-modal>

      <b-modal
        id="mccadColaboradorFail"
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
          <p>Não foi possivel cadastrar o Colaborador</p>
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
  name: "Cadastro_Colaborador",

  data() {
    return {
      nome: "",
      dataNascimento: "",
      rg: "",
      cpf: "",
      telefone: "",
      sexo: "",
      ctps: "",
      cargo: "",
      dataAdmissao: "",
      memoria1: "",
    };
  },

  created() {},

  methods: {
    addColaborador() {
      let _colaborador = {
        nome: this.nome,
        dataNascimento: this.dataNascimento,
        rg: this.rg,
        cpf: this.cpf,
        sexo: this.sexo,
        telefone: this.telefone,
        ctps: this.ctps,
        cargo: this.cargo,
        dataAdmissao: this.dataAdmissao,
      };

      this.memoria1 = _colaborador.nome;

      if (_colaborador.nome != "" && _colaborador.dataNascimento != "") {
        axios
          .post("https://localhost:5001/Colaborador/create", _colaborador)
          .then((res) => {
            this.$bvModal.show("mccadColaborador");
          });
        this.nome = "";
        this.dataNascimento = "";
        this.rg = "";
        this.cpf = "";
        this.telefone = "";
        this.sexo = "";
        this.memoria = "";
        this.ctps = "";
        this.cargo = "";
        this.dataAdmissao = "";
      }else {
        this.$bvModal.show("mccadColaboradorFail");
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
