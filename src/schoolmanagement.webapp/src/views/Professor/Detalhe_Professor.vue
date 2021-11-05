<template>
<div class="temp">
  <div class="container">
    <div class="center">
      <b-button class="btnVoltar" variant="outline-info" @click="voltar()"
      >Voltar</b-button>
      <h1>Editando o Professor</h1>

     <div class="form-floating mb-3">
        <input
<<<<<<< HEAD
          v-model="professor.nome"
=======
          v-model="nome"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
          v-model="professor.dataNascimento"
=======
          v-model="dataNascimento"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
          v-model="professor.dataAdmissao"
=======
          v-model="dataAdmissao"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
            v-model="professor.rg"
=======
            v-model="rg"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
            v-model="professor.cpf"
=======
            v-model="cpf"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
          v-model="professor.telefone"
=======
          v-model="telefone"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
            v-model="professor.ctps"
=======
            v-model="ctps"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
            v-model="professor.licenca"
=======
            v-model="licenca"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
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
<<<<<<< HEAD
          v-model="professor.titulacao"
=======
          v-model="titulacao"
>>>>>>> 45f91878cff485c1973d67b75e7447d53f68775f
          type="text"
          class="form-control"
          placeholder="teste"
        />
        <label for="floatingInput">Titulação</label>
        </div>
        </b-col>
      </b-row> 

      <div class="d-grid gap-5" style="padding-left:100px; padding-right:100px; ">
        <b-button v-b-modal="'ModalConfirm'" type="button" class="btn btn-success" @click="SalvarProfessor">
          Salvar
        </b-button>
      </div>

    <b-modal  ref="ModalConfirm"
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
    };
  },
  methods: {
    voltar() {
      this.$router.back();
    },
    SalvarProfessor() {
      let _professorEditar = {
        id: this.id,
        ra: this.professor.ra,
        nome: this.professor.nome,
        dataNascimento: this.professor.dataNascimento,
        rg: this.professor.rg,
        cpf: this.professor.cpf,
        telefone: this.professor.telefone,
        sexo: this.professor.sexo,
        ctps: this.professor.ctps,
        licenca: this.professor.licenca,
        titulacao: this.professor.titulacao,
        dataAdmissao: this.professor.dataAdmissao,
      };

      axios.put("https://localhost:5001/Professor/update", _professorEditar);
      this.visualizando = !this.visualizando;
    },

      close(){
      this.$refs.ModalConfirm.hide();
    }
  },
  created() {
    axios.get(`https://localhost:5001/Professor/get/${this.id}`).then((res) => {
      this.professor = res.data.data;
    });
  },
};
</script>

<style scoped>
.btnVoltar {
  float: right;
  margin-top: 25px; 
}
</style>