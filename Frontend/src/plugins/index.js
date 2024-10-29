/**
 * plugins/index.js
 *
 * Automatically included in `./src/main.js`
 */

// Plugins
import vuetify from "./vuetify";
import router from "@/router";
import axios from "axios";
import VueTheMask from "vue-the-mask";

export function registerPlugins(app) {
  app
    .use(vuetify)
    .use(router)
    .use(axios)
    .use(VueTheMask)
    .provide("axios", app.config.globalProperties.axios);
}
