import "@babel/polyfill";
import Vue from "vue";
import "./plugins/vuetify";
import App from "./App.vue";
import VueRouter from "vue-router";
import Routers from "./router";
import axios from "axios";
var VueCookie = require("vue-cookie");
import { VueReCaptcha } from "vue-recaptcha-v3";
Vue.prototype.$http = axios;
Vue.config.productionTip = false;

Vue.use(VueRouter);
Vue.use(VueCookie);
Vue.use(VueReCaptcha, {
  siteKey: "6LebjKIUAAAAAP4hlIooryFBaKqgh0P7p6ufPEYP",
  loaderOptions: {
    useRecaptchaNet: true
  }
});
new Vue({
  router: new VueRouter({
    mode: "history",
    routes: Routers
  }),
  render: h => h(App)
}).$mount("#app");
