import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from "@/store";
// import { install as VueMonacoEditorPlugin } from '@guolao/vue-monaco-editor'
// Vuetify
// import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
    components,
    directives
})

const app = createApp(App)
// app.use(VueMonacoEditorPlugin, {
//     paths: {
//         // The default CDN config
//         vs: 'https://cdn.jsdelivr.net/npm/monaco-editor@0.41.0/min/vs'
//     },
// })
app.use(vuetify)
app.use(router)
app.use(store)
app.mount('#app')