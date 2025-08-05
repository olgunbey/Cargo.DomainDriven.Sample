import { createRouter, createWebHistory } from 'vue-router'
import ProductPage from './Pages/ProductPage.vue'


const routes = [
  { path: '/:category', name:'category', component: ProductPage }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router