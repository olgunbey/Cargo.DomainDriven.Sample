<template>
  <div>
    <Navbar />

    <!-- Sayfa içeriği -->
    <div class="page-wrapper">
      <!-- Ürün Listesi -->
      <div class="product-list-wrapper">
        <ProductList />
      </div><Basket />
    </div>
  </div>
</template>
<script setup lang="ts">
import ProductList from '@/Components/ProductList.vue'
import Basket from '@/Components/Basket.vue'
import Navbar from '@/Components/Navbar.vue';


</script>

<style scoped>
.page-wrapper {
  display: flex;
  gap: 24px;
  padding: 24px;
  background-color: #f3f4f6;
  min-height: 100vh;
  box-sizing: border-box;
  align-items: flex-start;
  flex-wrap: wrap;
}

.product-list-wrapper {
  flex: 1 1 60%;
  min-width: 320px;
}

.basket-wrapper {
  flex: 1 1 35%;
  min-width: 280px;
  background: white;
  border-radius: 8px;
  padding: 16px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 0.1);
  height: fit-content;
}

.page-title {
  font-size: 1.75rem;
  font-weight: 700;
  margin-bottom: 16px;
}

.basket-title {
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 12px;
}
</style>