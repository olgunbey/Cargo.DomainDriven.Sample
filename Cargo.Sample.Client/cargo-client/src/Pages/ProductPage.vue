<template>
  <div>
    <div class="page-wrapper">
      <div class="product-list-wrapper">
        <div v-if="loading"></div>
        <div v-else-if="!products || products.length === 0">
          <NotProduct />
        </div>
        <div v-else>
          <ProductList :product-list="products ?? []" />
        </div>
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
import ProductList from "@/Components/ProductList.vue";
import {  ref, watch } from "vue";
import { ProductDto, ResponseDto } from "@/Dtos";
import { EndpointProduct } from "@/Request/EndpointProduct";
import router from "@/router";
import NotProduct from "@/Components/NotProduct.vue";

const products = ref<ProductDto[]>()

const loading = ref<boolean>(true)

watch(
  ()=> router.currentRoute.value.params["categoryId"] as string,
  async (categoryId:string)=>{
    if(categoryId !=null)
    {
      loading.value = true
      const response: ResponseDto<ProductDto[]> =await new EndpointProduct().getProductsByCategoryId(categoryId)
      products.value = response.data ?? []
      loading.value=false
    }
  },
  {immediate:true}
)


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
