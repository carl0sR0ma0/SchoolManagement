import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import VueSidebarMenu from "vue-sidebar-menu";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";

//pages
import Main from "./components/Main.vue";
import Dashboard from "./components/Dashboard.vue";
//Cadastro
import Cadastro_Aluno from "./views/Aluno/Cadastro_Aluno.vue";
import Cadastro_Colaborador from "./views/Colaborador/Cadastro_Colaborador.vue";
import Cadastro_Curso from "./views/Curso/Cadastro_Curso.vue";
import Cadastro_Professor from "./views/Professor/Cadastro_Professor.vue";
import Cadastro_Serie from "./views/Serie/Cadastro_Serie.vue";
import Cadastro_Turma from "./views/Turma/Cadastro_Turma.vue";
//Consulta
import Consulta_Aluno from "./views/Aluno/Consulta_Aluno.vue";
import Consulta_Colaborador from "./views/Colaborador/Consulta_Colaborador.vue";
import Consulta_Curso from "./views/Curso/Consulta_Curso.vue";
import Consulta_Professor from "./views/Professor/Consulta_Professor.vue";
import Consulta_Serie from "./views/Serie/Consulta_Serie.vue";
import Consulta_Turma from "./views/Turma/Consulta_Turma.vue";
//Detalhe
import Detalhe_Aluno from "./views/Aluno/Detalhe_Aluno.vue";
import Detalhe_Colaborador from "./views/Colaborador/Detalhe_Colaborador.vue";
import Detalhe_Curso from "./views/Curso/Detalhe_Curso.vue";
import Detalhe_Professor from "./views/Professor/Detalhe_Professor.vue";
import Detalhe_Serie from "./views/Serie/Detalhe_Serie.vue";
import Detalhe_Turma from "./views/Turma/Detalhe_Turma.vue";


// Import Bootstrap an BootstrapVue CSS files (order is important)
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(VueSidebarMenu);
Vue.use(VueRouter);
library.add(fas);
Vue.component("font-awesome-icon", FontAwesomeIcon);

const router = new VueRouter({
  routes: [
    {
      path: "/",
      name: "Main",
      component: Main,
    },
    //Dashboard
    {
      path: "/Dashboard",
      name: "Dashboard",
      component: Dashboard,
    },
    // Rotas Cadastro
    {
      path: "/Cadastro_Aluno",
      name: "Cadastro_Aluno",
      component: Cadastro_Aluno,
    },
    {
      path: "/Cadastro_Colaborador",
      name: "Cadastro_Colaborador",
      component: Cadastro_Colaborador,
    },
    {
      path: "/Cadastro_Curso",
      name: "Cadastro_Curso",
      component: Cadastro_Curso,
    },    
    {
      path: "/Cadastro_Professor",
      name: "Cadastro_Professor",
      component: Cadastro_Professor,
    },
    {
      path: "/Cadastro_Serie",
      name: "Cadastro_Serie",
      component: Cadastro_Serie,
    },
    {
      path: "/Cadastro_Turma",
      name: "Cadastro_Turma",
      component: Cadastro_Turma,
    },
    // Rotas Consulta
    {
      path: "/Consulta_Aluno",
      name: "Consulta_Aluno",
      component: Consulta_Aluno,
    },
    {
      path: "/Consulta_Colaborador",
      name: "Consulta_Colaborador",
      component: Consulta_Colaborador,
    },
    {
      path: "/Consulta_Curso",
      name: "Consulta_Curso",
      component: Consulta_Curso,
    },
    {
      path: "/Consulta_Professor",
      name: "Consulta_Professor",
      component: Consulta_Professor,
    },
    {
      path: "/Consulta_Serie",
      name: "Consulta_Serie",
      component: Consulta_Serie,
    },
    {
      path: "/Consulta_Turma",
      name: "Consulta_Turma",
      component: Consulta_Turma,
    },
    // Rotas Detalhe da Consulta
    {
      path: "/Detalhe_Aluno/:id",
      name: "/Detalhe_Aluno",
      component: Detalhe_Aluno,
    },
    {
      path: "/Detalhe_Colaborador/:id",
      name: "Detalhe_Colaborador",
      component: Detalhe_Colaborador,
    },
    {
      path: "/Detalhe_Curso/:id",
      name: "Detalhe_Curso",
      component: Detalhe_Curso,
    },
    {
      path: "/Detalhe_Professor/:id",
      name: "Detalhe_Professor",
      component: Detalhe_Professor,
    },
    {
      path: "/Detalhe_Serie/:id",
      name: "Detalhe_Serie",
      component: Detalhe_Serie,
    },
    {
      path: "/Detalhe_Turma/:id",
      name: "Detalhe_Turma",
      component: Detalhe_Turma,
    },
  ],
});

Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App),
}).$mount("#app");
