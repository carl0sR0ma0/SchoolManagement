<template >
  <div class="temp">
    <div class="container">
      <div class="center">
        <h1>Cadastro de Aluno</h1>
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
        <b-row>
          <b-col cols="8">
            <div class="form-floating mb-3">
              <input
                v-model="logradouro"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Endereço</label>
            </div>
          </b-col>
          <b-col cols="4">
            <div class="form-floating mb-3">
              <input
                v-model="numero"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Numero</label>
            </div>
          </b-col>
        </b-row>
        <b-row>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="bairro"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Bairro</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="cidade"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">Cidade</label>
            </div>
          </b-col>
          <b-col>
            <div class="form-floating mb-3">
              <input
                v-model="cep"
                type="text"
                class="form-control"
                placeholder="teste"
              />
              <label for="floatingInput">CEP</label>
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
            @click="addAluno"
          >
            Salvar
          </b-button>
        </div>
      </div>

      <b-modal
        id="mccadAluno"
        header-bg-variant="success"
        header-text-variant="light"
        centered
        hide-footer
      >
        <template v-slot:modal-header="{ close }">
          Aluno Cadastrado
          <b-button @click="close">
            <b-icon icon="arrow90deg-left" />
          </b-button>
        </template>
        <div class="text-center">
          O aluno {{ memoria }} foi cadastrado com sucesso!
        </div>
      </b-modal>

      <b-modal
        id="mccadAlunoFail"
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
          <p>Não foi possivel cadastrar o Aluno</p>
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
  name: "Cadastro_Aluno",

  data() {
    return {
      ra: "",
      nome: "",
      dataNascimento: "",
      rg: "",
      cpf: "",
      telefone: "",
      sexo: "",
      memoria: "",
      logradouro: "",
      numero: "",
      bairro: "",
      cidade: "",
      cep: "",
    };
  },

  created() {},

  methods: {
    addAluno() {
      let _aluno = {
        ra: this.randomNumber(),
        nome: this.nome,
        dataNascimento: this.dataNascimento,
        rg: this.rg,
        cpf: this.cpf,
        telefone: this.telefone,
        sexo: this.sexo,
        logradouro: this.logradouro,
        numero: this.numero,
        bairro: this.bairro,
        cidade: this.cidade,
        cep: this.cep,
      };
      this.memoria = _aluno.nome;
      if (_aluno.nome != "" && _aluno.dataNascimento != "") {
        axios
          .post("https://localhost:5001/Aluno/create", _aluno)
          .then((res) => {
            this.$bvModal.show("mccadAluno");
          });
        this.nome = "";
        this.dataNascimento = "";
        this.rg = "";
        this.cpf = "";
        this.telefone = "";
        this.sexo = "";
        this.logradouro = "";
        this.numero = "";
        this.bairro = "";
        this.cidade = "";
        this.cep = "";
      } else {
        this.$bvModal.show("mccadAlunoFail");
      }
    },

    randomNumber() {
      const random = Math.floor(Math.random() * 256);
      const cpf1 = this.cpf;
      const ra1 = random + cpf1;
      return ra1;
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
