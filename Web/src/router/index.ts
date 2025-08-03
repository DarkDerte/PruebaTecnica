import { createRouter, createWebHistory } from 'vue-router'

import HomeView from '@/views/HomeView.vue'
import ContractsView from '@/views/ContractsView.vue';
import InProgressView from '@/views/InProgressView.vue';

const routes = [
  { path: '/', component: HomeView },
  { path: '/contracts', component: ContractsView },
  { path: '/:pathMatch(.*)*', component: InProgressView },
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router;