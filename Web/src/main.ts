import './assets/main.css';
import 'primeicons/primeicons.css';

import { createApp } from 'vue';
import PrimeVue from 'primevue/config';
import Aura from '@primeuix/themes/aura';
import { createPinia } from 'pinia'
import piniaPluginPersistedstate from 'pinia-plugin-persistedstate'
import App from './App.vue';
import router from './router/index'
import { DialogService, ToastService } from 'primevue';

const pinia = createPinia();
pinia.use(piniaPluginPersistedstate)
const app = createApp(App);

app.use(pinia);
app.use(router);
app.use(DialogService);
app.use(ToastService);
app.use(PrimeVue, {
  theme: {
    preset: Aura
  }
});

app.mount('#app');
