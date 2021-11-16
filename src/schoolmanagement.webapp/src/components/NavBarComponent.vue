<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <b-icon
        style="margin-left: 15px"
        icon="building"
        font-scale="2"
        variant="primary"
      />
      <b-navbar-brand to="/" style="padding-left: 15px"
        >School Management</b-navbar-brand
      >

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>

      <!-- Right aligned nav items -->
      <b-navbar-nav style="padding-left:35px" class="ml-auto">
        <b-nav-item to="/Dashboard">Dashboard</b-nav-item>
        <b-nav-item-dropdown text="Cadastro" right>
          <b-dropdown-item to="/Cadastro_Aluno">Aluno</b-dropdown-item>
          <b-dropdown-item to="/Cadastro_Colaborador">Colaborador</b-dropdown-item>
          <b-dropdown-item to="/Cadastro_Curso">Curso</b-dropdown-item>
          <b-dropdown-item to="/Cadastro_Professor">Professor</b-dropdown-item>
          <b-dropdown-item to="/Cadastro_Serie">Serie</b-dropdown-item>
          <b-dropdown-item to="/Cadastro_Turma">Turma</b-dropdown-item>
        </b-nav-item-dropdown>
        <b-nav-item-dropdown text="Consulta" right>
          <b-dropdown-item to="/Consulta_Aluno">Aluno</b-dropdown-item>
           <b-dropdown-item to="/Consulta_Colaborador">Colaborador</b-dropdown-item>
          <b-dropdown-item to="/Consulta_Curso">Curso</b-dropdown-item>
          <b-dropdown-item to="/Consulta_Professor">Professor</b-dropdown-item>
          <b-dropdown-item to="/Consulta_Serie">Serie</b-dropdown-item>
          <b-dropdown-item to="/Consulta_Turma">Turma</b-dropdown-item>
            <b-nav-item-dropdown text="Matricula" right>
            <b-dropdown-item to="/Matricula">Nova Matricula</b-dropdown-item>
              <b-dropdown-item to="/MatriculaPorTurma">Alunos Matriculados Por Turma</b-dropdown-item>
        </b-nav-item-dropdown>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</div>
</template>

<script>
export default {
  name: "NavBarComponent",
};
</script>

<style scoped></style>
