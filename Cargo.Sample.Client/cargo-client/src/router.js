import { createRouter, createWebHistory } from 'vue-router'
import ProductPage from './Pages/ProductPage.vue'
import LoginPage from './Pages/LoginPage.vue'

const routes = [
    { path: '/', name:'login', component: LoginPage },
    {path: '/product', component: ProductPage },
    { path: '/category/:categoryId', name:'category', component: ProductPage },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router