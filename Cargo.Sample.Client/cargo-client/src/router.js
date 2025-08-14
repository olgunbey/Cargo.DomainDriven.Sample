import { createRouter, createWebHistory } from 'vue-router'
import ProductPage from './Pages/ProductPage.vue'
import Login from './Pages/Login.vue'

const routes = [
    { path: '/', name:'login', component: Login },
    {path: '/products', component: ProductPage },
    { path: '/:category', name:'category', component: ProductPage },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router