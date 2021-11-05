<template >
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
        <legend class="col-form-label col-sm-2 pt-0" style="margin-left:15px">Sexo</legend>
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
            <label class="form-check-label" for="gridRadios1"> Masculino </label>
          </div>
          <div class="form-check">
            <input
              class="form-check-input"
              type="radio"
              name="gridRadios2"
              v-model="sexo"
              value="Feminino"
            />
            <label class="form-check-label" for="gridRadios2"> Feminino </label>
          </div>
        </div>
      </fieldset>


      <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; margin-top: 50px ">
        <b-button v-b-modal="'ModalConfirm'" type="button" class="btn btn-success" @click="addProfessor">
          Salvar
        </b-button>
      </div>
  </div>

  <b-modal id="ModalConfirm"
           header-bg-variant="success"
           header-text-variant="light"
           centered 
           hide-footer
           >
      <template v-slot:modal-header="{close}">
      <div center>
        Professor Cadastrado
      </div>
      <b-button @click="close">
        <b-icon icon="arrow90deg-left"/>
      </b-button>
      </template>
      <div class="text-center">
        O Professor {{memoria4}} foi cadastrado com sucesso!
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
      nome: "",
      dataNascimento: "",
      rg: "",
      cpf: "",      
      sexo: "",
      telefone: "",      
      ctps: "",
      licenca: "",
      titulacao:"",
      dataAdmissao:"",      
      memoria4: "",
    };
  },

  created() {},

  methods: {
    addProfessor() {
      let _professor = {
        ctps: this.ctps,
        nome: this.nome,
        dataNascimento: this.dataNascimento,
        rg: this.rg,
        cpf: this.cpf,
        telefone: this.telefone,
        sexo: this.sexo,
        licenca: this.licenca,
        titulacao: this.titulacao,
        dataAdmissao:  this.dataAdmissao,
      };

      this.memoria4 = _professor.nome;

      axios.post("https://localhost:5001/Professor/create", _professor).then((res) => {
        console.log(res.data);
      });

      this.nome = "";
      this.dataNascimento = "";
      this.rg = "";
      this.cpf = "";
      this.telefone = "";
      this.sexo = "";
      this.ctps = "";
      this.licenca = "";
      this.titulacao = "";
      this.dataAdmissao = "";
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

.container{
  background: #fff;
  border-radius: 15px;
}
</style>
