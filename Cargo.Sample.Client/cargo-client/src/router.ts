import { createRouter, createWebHistory } from 'vue-router'
import ProductPage from '@/Pages/ProductPage.vue'
import LoginPage from './Pages/LoginPage.vue'
import RegisterPage from './Pages/RegisterPage.vue'
import OrderListPage from './Pages/OrderListPage.vue'
import { UserDto } from './Dtos/UserDto'
import { EndpointIdentity } from './Request/EndpointIdentity'

const routes = [
  { path: '/', name: 'login', component: LoginPage },
  { path: '/product', component: ProductPage },
  { path: '/register', component: RegisterPage },
  { path: '/category/:categoryId', name: 'category', component: ProductPage },
  { path: '/orderList', component: OrderListPage }
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})



function parseIsoWithMicroseconds(isoString: string): Date {
    const correctedIso = isoString.replace(/\.(\d{3})\d+Z$/, '.$1Z');
    return new Date(correctedIso);
}

router.beforeEach(async (to, from, next) => {

  const endpoint = EndpointIdentity.GetEndpointIdentity()
  const data = localStorage.getItem("login");
  const parsedData: UserDto | null = data ? JSON.parse(data) as UserDto : null;

  if (parsedData && parseIsoWithMicroseconds(parsedData.accessTokenLifeTime.toString()) < new Date()) {
  const response =  await endpoint.Refresh(parsedData.refreshToken)

  console.log("New token ",response)
  const setLocalStorage:UserDto = response.data as UserDto; 
  localStorage.removeItem("login");
  localStorage.setItem("login",JSON.stringify(setLocalStorage))
  }


  if (parsedData && to.path == "/") {

    next({ path: "/product" });
  }
  else {
    next();
  }
})
export default router