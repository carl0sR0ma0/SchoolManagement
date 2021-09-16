import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import VueSidebarMenu from "vue-sidebar-menu";
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'

//pages
import Cadastro_Aluno from "./views/Aluno/Cadastro_Aluno.vue";
import Cadastro_Professor from "./views/Professor/Cadastro_Professor.vue";
import Cadastro_Curso from "./views/Curso/Cadastro_Curso.vue";
import Cadastro_Serie from "./views/Serie/Cadastro_Serie.vue";
import Cadastro_Turma from "./views/Turma/Cadastro_Turma.vue";
import Consulta_Aluno from "./views/Aluno/Consulta_Aluno.vue";

// Import Bootstrap an BootstrapVue CSS files (order is important)
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import '@fortawesome/fontawesome-free/css/all.css';
import '@fortawesome/fontawesome-free/js/all.js';

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueSidebarMenu)
Vue.use(VueRouter)
library.add(fas)
Vue.component('font-awesome-icon', FontAwesomeIcon)

const router = new VueRouter({
  routes: [
    {
      path: "/Cadastro_Aluno",
      name: "Cadastro_Aluno",
      component: Cadastro_Aluno
    },
    {
      path: "/Cadastro_Professor",
      name: "Cadastro_Professor",
      component: Cadastro_Professor
    },
    {
      path: "/Cadastro_Curso",
      name: "Cadastro_Curso",
      component: Cadastro_Curso
    },
    {
      path: "/Cadastro_Serie",
      name: "Cadastro_Serie",
      component: Cadastro_Serie
    },
    {
      path: "/Cadastro_Turma",
      name: "Cadastro_Turma",
      component: Cadastro_Turma
    },
    {
      path: "/Consulta_Aluno",
      name: "Consulta_Aluno",
      component: Consulta_Aluno
    },
  ]
});

Vue.config.productionTip = false;

new Vue({
  router,
  render: (h) => h(App)
}).$mount("#app");
