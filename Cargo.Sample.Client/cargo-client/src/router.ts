import { createRouter, createWebHistory } from 'vue-router'
import ProductPage from '@/Pages/ProductPage.vue'
import LoginPage from './Pages/LoginPage.vue'
import RegisterPage from './Pages/RegisterPage.vue'

const routes = [
  { path: '/', name: 'login', component: LoginPage },
  { path: '/product', component: ProductPage },
  { path: '/register', component: RegisterPage },
  { path: '/category/:categoryId', name: 'category', component: ProductPage },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})


router.beforeEach((to, from, next) => {

  //burada refresh token kontrolu yapıp, eüer yoksa login'e yönlendirebilirim...
  const data = localStorage.getItem("login");
  const parsedData = data ? JSON.parse(data) : null;

  if (!parsedData && to.path !== "/") {

    next({ path: "/" });
  }
  else {
    next();
  }


})
export default router