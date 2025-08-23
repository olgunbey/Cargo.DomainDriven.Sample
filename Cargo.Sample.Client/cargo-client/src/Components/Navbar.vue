<template>
  <nav class="navbar">
    <div class="navbar-container">
      <!-- Sol: Logo -->
      <div class="navbar-brand">
        <h1 class="logo">MyShop</h1>
      </div>

      <div class="navbar-menu" :class="{ 'navbar-menu-active': mobileMenuOpen }">
        <a href="#" class="nav-item">Ana Sayfa</a>

        <div class="nav-item dropdown" @mouseenter="showCategoriesMenu" @mouseleave="hideCategories">
          <span class="dropdown-trigger">
            Kategoriler
            <i class="arrow" :class="{ 'arrow-rotate': showCategories }">▼</i>
          </span>
          <div class="dropdown-content" v-show="showCategories" @mouseenter="showCategoriesMenu"
            @mouseleave="hideCategories">
            <div v-for="category in categories" :key="category.id">
              <RouterLink 
                :to="{ name: 'category', params: { categoryId: `${category.id}` } }" class="dropdown-item"
                @click="showCategories = false">{{ category.name }}</RouterLink>
            </div>
          </div>
        </div>

        <a href="#" class="nav-item">Kampanyalar</a>
        <a href="#" class="nav-item">İletişim</a>
      </div>

      <div class="navbar-actions">
        <div class="search-box">
          <input type="text" placeholder="Ara..." class="search-input" v-model="searchQuery">
          <button class="search-button">🔍</button>
        </div>

        <div class="cart-button" @click="cart.toggleBasket">
          🛒 <span class="cart-count">({{ cart.itemCount }})</span>
        </div>


        <button class="mobile-menu-button" @click="toggleMobileMenu">
          <span class="hamburger-line" :class="{ 'active': mobileMenuOpen }"></span>
        </button>
      </div>
    </div>
  </nav>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useCartStore } from '@/stores/cart'
import { EndpointProduct } from '@/Request/EndpointProduct'
import { ResponseDto,GetAllCategoryResponseDto } from '@/Dtos/index'


const cart = useCartStore()
const categories = ref<CategoryDto[]>()

class CategoryDto {
  public id:string
  public name:string
  
  constructor(id:string,name:string) {
        this.id=id
        this.name=name
  }
}

onMounted(async () => {
   const getAllCategory:ResponseDto<GetAllCategoryResponseDto[]> = await new EndpointProduct().getAllCategories()
  categories.value = getAllCategory.data?.map(category=> new CategoryDto(category.id,category.categoryName))
})

const showCategories = ref(false)
const searchQuery = ref('')
const mobileMenuOpen = ref(false)

let hideTimeout: number | null | undefined

const hideCategories = () => {
  hideTimeout = setTimeout(() => {
    showCategories.value = false
  }, 150)
}



const showCategoriesMenu = () => {
  if (hideTimeout) {
    clearTimeout(hideTimeout)
  }
  showCategories.value = true
}
const toggleMobileMenu = () => {
  mobileMenuOpen.value = !mobileMenuOpen.value
}
</script>

<style scoped>
.navbar {
  background: #1f2937;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);
  position: sticky;
  top: 0;
  z-index: 1;
}

.navbar-container {
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
  height: 64px;
  padding: 0 20px;
}

/* Sol taraf - Logo */
.navbar-brand {
  flex: 0 0 auto;
}

.logo {
  font-size: 1.75rem;
  font-weight: bold;
  color: #10b981;
  margin: 0;
  cursor: pointer;
  transition: color 0.2s ease;
}

.logo:hover {
  color: #059669;
}

/* Orta - Navigation Menü */
.navbar-menu {
  display: flex;
  align-items: center;
  gap: 2rem;
  flex: 1;
  justify-content: center;
}

.nav-item {
  color: #d1d5db;
  text-decoration: none;
  padding: 8px 16px;
  border-radius: 6px;
  font-weight: 500;
  transition: all 0.2s ease;
  white-space: nowrap;
}

.nav-item:hover {
  color: white;
  background: rgba(255, 255, 255, 0.1);
}

/* Dropdown */
.dropdown {
  position: relative;
  cursor: pointer;
}

.dropdown-trigger {
  display: flex;
  align-items: center;
  gap: 6px;
}

.arrow {
  font-size: 12px;
  transition: transform 0.2s ease;
}

.arrow-rotate {
  transform: rotate(180deg);
}

.dropdown-content {
  position: absolute;
  top: 100%;
  left: 0;
  background: white;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
  min-width: 180px;
  padding: 8px 0;
  margin-top: 8px;
  border: 1px solid #e5e7eb;
}

.dropdown-item {
  display: block;
  padding: 10px 16px;
  color: #374151;
  text-decoration: none;
  transition: background 0.2s ease;
}

.dropdown-item:hover {
  background: #f3f4f6;
  color: #10b981;
}

/* Sağ taraf - Actions */
.navbar-actions {
  display: flex;
  align-items: center;
  gap: 1rem;
  flex: 0 0 auto;
}

/* Arama kutusu */
.search-box {
  display: flex;
  background: #374151;
  border-radius: 20px;
  overflow: hidden;
  border: 1px solid #4b5563;
}

.search-input {
  background: transparent;
  border: none;
  padding: 8px 16px;
  color: white;
  outline: none;
  width: 160px;
  font-size: 14px;
}

.search-input::placeholder {
  color: #9ca3af;
}

.search-button {
  background: #10b981;
  border: none;
  padding: 8px 12px;
  color: white;
  cursor: pointer;
  transition: background 0.2s ease;
}

.search-button:hover {
  background: #059669;
}

/* Sepet butonu */
.cart-button {
  background: #10b981;
  color: white;
  padding: 8px 16px;
  border-radius: 20px;
  cursor: pointer;
  font-weight: 600;
  transition: all 0.2s ease;
  display: flex;
  align-items: center;
  gap: 4px;
}

.cart-button:hover {
  background: #059669;
  transform: translateY(-1px);
}

.cart-count {
  font-size: 14px;
}

/* Mobil menü butonu */
.mobile-menu-button {
  display: none;
  background: none;
  border: none;
  cursor: pointer;
  padding: 8px;
}

.hamburger-line {
  display: block;
  width: 24px;
  height: 3px;
  background: #d1d5db;
  position: relative;
  transition: all 0.3s ease;
}

.hamburger-line::before,
.hamburger-line::after {
  content: '';
  position: absolute;
  width: 24px;
  height: 3px;
  background: #d1d5db;
  transition: all 0.3s ease;
}

.hamburger-line::before {
  top: -8px;
}

.hamburger-line::after {
  bottom: -8px;
}

.hamburger-line.active {
  background: transparent;
}

.hamburger-line.active::before {
  transform: rotate(45deg);
  top: 0;
}

.hamburger-line.active::after {
  transform: rotate(-45deg);
  bottom: 0;
}

/* Responsive tasarım */
@media (max-width: 768px) {
  .navbar-container {
    padding: 0 16px;
  }

  .navbar-menu {
    position: absolute;
    top: 100%;
    left: 0;
    right: 0;
    background: #1f2937;
    flex-direction: column;
    gap: 0;
    max-height: 0;
    overflow: hidden;
    transition: max-height 0.3s ease;
    border-top: 1px solid #374151;
  }

  .navbar-menu-active {
    max-height: 300px;
  }

  .nav-item {
    width: 100%;
    text-align: center;
    padding: 16px;
    border-bottom: 1px solid #374151;
  }

  .dropdown-content {
    position: static;
    box-shadow: none;
    background: #374151;
    margin: 0;
    border: none;
  }

  .dropdown-item {
    color: #d1d5db;
    padding-left: 32px;
  }

  .search-box {
    display: none;
  }

  .mobile-menu-button {
    display: block;
  }
}

@media (max-width: 480px) {
  .logo {
    font-size: 1.5rem;
  }

  .cart-button {
    padding: 6px 12px;
    font-size: 14px;
  }
}
</style>