import "@babel/polyfill";
import Vue from "vue";
import App from "./App.vue";
import VueRouter from "vue-router";
import Routers from "./router";
import axios from "axios";
import "@/plugins/vuetify";

Vue.prototype.$http = axios;
Vue.config.productionTip = false;

Vue.use(VueRouter);

new Vue({
  router: new VueRouter({
    mode: "history",
    routes: Routers
  }),
  render: h => h(App)
}).$mount("#app");
