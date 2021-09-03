import { createApp } from "vue"
import App from "./App.vue"
import router from "./router"
import VueResorce from "vue-resource"


import '@fortawesome/fontawesome-free/js/all'

createApp(App).use(router, VueResorce).mount("#app")
