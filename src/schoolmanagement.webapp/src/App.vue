<template>
  <div id="app">
    <div id="view" :class="[{'collapsed' : collapsed}]">
      <router-view/>
    </div>
    <sidebar-menu
      class="sidebar"
      :menu="menu"
      :collapsed="collapsed"
      @toggle-collapse="onToggleCollapse"
      @item-click="onItemClick"
      @collapse="onCollapse"
    />
  </div>
</template>

<script>
export default {
  name: "App",
  data() {
    return {
      menu: [
        {
          header: true,
          title: "Sistema Escolar",
          icon: 'fas fa-school',
          hiddenOnCollapse: true
        },
        {
          href: "/",
          title: "Principal",
          icon: 'fa fa-user'
        },
        {
          href: "/",
          title: "Teste",
          icon: "fas fa-address-card",
        },
        {
          title: "Cadastros",
          icon: "fa fa-list-ul",
          child: [
            {
              href: "/Cadastro_Aluno",
              title: "Aluno",
              icon: "fa fa-file-alt",
            },
            {
              href: "/Cadastro_Professor",
              title: "Professor",
              icon: "fa fa-file-alt",
            },
            {
              href: "/Cadastro_Serie",
              title: "Serie",
              icon: "fa fa-file-alt",
            },
            {
              href: "/Cadastro_Turma",
              title: "Turma",
              icon: "fa fa-file-alt",
            },
            {
              href: "/Cadastro_Curso",
              title: "Curso",
              icon: "fa fa-file-alt",
            },
          ],
        },
                {
          title: "Consulta",
          icon: "fa fa-list-ul",
          child: [
            {
              href: "/Consulta_Aluno",
              title: "Consulta Aluno",
              icon: "fa fa-file-alt"
            },
            {
              href: "/Consulta_Professor",
              title: "Consulta_Professor",
              icon: "fa fa-file-alt",
            },
            {
              href: "/Consulta_Curso",
              title: "Consulta_Curso",
              icon: "fa fa-file-alt",
            },
          ],
        },
      ],
      collapsed: true,
    };
  },
    methods: {
    onItemClick() {
      console.log("onItemClick");
    },
    onCollapse(c) {
      console.log("onCollapse");
      this.collapsed = c;
    },
    onToggleCollapse(collapsed) {
      console.log("onCollapse");
      this.collapsed = collapsed;
    },
  }
};
</script>

<style>

#view {
  padding-left: 350px;
}
#view.collapsed {
  padding-left: 50px;
}

.sidebar.v-sidebar-menu .vsm-arrow:after {
  content: "\f105";
  font-family: "FontAwesome";
}
.sidebar.v-sidebar-menu .collapse-btn:after {
  content: "\f07e";
  font-family: "FontAwesome";
}
</style>

<!-- <template>
  <div id="app">
    <nav-bar-component />
    <side-bar-component />
    <router-view />
  </div>
</template>

<script>

import NavBarComponent from './components/NavBarComponent.vue'
import SideBarComponent from './components/SideBarComponent.vue'

export default {
  
  components:{
    NavBarComponent,
    SideBarComponent
  }
}
</script>

<style>

</style>-->