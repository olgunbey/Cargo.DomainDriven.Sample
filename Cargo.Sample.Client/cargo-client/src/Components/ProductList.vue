<template>
  <div class="product-grid">
    <div v-for="product in productList" :key="product?.productId" class="product-card"
      @click.stop="addToCart(product)">
      <div class="product-image-wrapper">
        <img :src="product.image" :alt="product.name" class="product-image" />
      </div>
      <div class="product-info">
        <h2 class="product-title">{{ product.name }}</h2>
        <p class="product-description">{{ product.description }}</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useCartStore } from "@/stores/cart"
import { ProductDto } from "@/Dtos"

const cart = useCartStore()

const props = defineProps<{ productList: ProductDto[] }>()

function addToCart(product:ProductDto) {
  cart.addItem(product)
}


</script>

<style scoped>
:root {
  --bg: #0b1020;
  --fg: #e7eaf3;
  --muted: #a9b0c6;
  --card: rgba(255, 255, 255, 0.06);
  --stroke: rgba(255, 255, 255, 0.15);
  --accent: #6ea8fe;
  --accent-2: #b17bff;
}

@media (prefers-color-scheme: light) {
  :root {
    --bg: #f6f8ff;
    --fg: #0d1321;
    --muted: #495060;
    --card: rgba(255, 255, 255, 0.9);
    --stroke: rgba(0, 0, 0, 0.08);
    --accent: #4f7cff;
    --accent-2: #8f5bff;
  }
}





html,
body,
#app {
  margin: 0;
  padding: 0;
  height: 100%;
}

.product-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
  gap: 0;
  padding: 0;
  min-height: 100vh;
  background: linear-gradient(135deg, #f8fafc 0%, #e2e8f0 100%);
  box-sizing: border-box;
}

.product-card {
  background: linear-gradient(145deg, #ffffff 0%, #f8fafc 100%);
  border-radius: 16px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.08), 0 1px 8px rgba(0, 0, 0, 0.02),
    inset 0 1px 0 rgba(255, 255, 255, 0.7);
  overflow: hidden;
  transition: all 0.4s cubic-bezier(0.175, 0.885, 0.32, 1.275);
  display: flex;
  flex-direction: column;
  position: relative;
  border: 1px solid rgba(255, 255, 255, 0.8);
  width: 100%;
  max-width: 280px;
  margin: 0;
  height: 320px;
  cursor: pointer;
}

.product-card:hover {
  transform: translateY(-12px) scale(1.02);
  box-shadow: 0 25px 50px rgba(0, 0, 0, 0.15), 0 10px 20px rgba(0, 0, 0, 0.1),
    inset 0 1px 0 rgba(255, 255, 255, 0.9);
}

.product-image-wrapper {
  position: relative;
  overflow: hidden;
  background: linear-gradient(45deg, #f1f5f9, #e2e8f0);
}

.product-image {
  width: 100%;
  height: 240px;
  object-fit: cover;
  transition: all 0.6s cubic-bezier(0.25, 0.46, 0.45, 0.94);
}

.product-image-wrapper:hover .product-image {
  transform: scale(1.1) rotate(1deg);
}

/* Overlay sadece görsel alanında ve sadece hover'da aktif */
.product-overlay {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: linear-gradient(135deg,
      rgba(0, 0, 0, 0.4) 0%,
      rgba(0, 0, 0, 0.1) 100%);
  opacity: 0;
  transition: all 0.3s ease;
  display: flex;
  align-items: center;
  justify-content: center;
  pointer-events: none;
}

.product-image-wrapper:hover .product-overlay {
  opacity: 1;
}

.favorite-btn {
  position: absolute;
  top: 16px;
  right: 16px;
  background: rgba(255, 255, 255, 0.9);
  backdrop-filter: blur(10px);
  border: none;
  border-radius: 50%;
  width: 44px;
  height: 44px;
  cursor: pointer;
  transition: all 0.3s ease;
  display: flex;
  align-items: center;
  justify-content: center;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  pointer-events: auto;
}

.favorite-btn:hover {
  background: rgba(255, 255, 255, 1);
  transform: scale(1.1);
}

.heart-icon {
  width: 20px;
  height: 20px;
  color: #64748b;
  transition: all 0.3s ease;
}

.heart-icon.filled {
  color: #ef4444;
  fill: currentColor;
}

.product-badge {
  position: absolute;
  top: 16px;
  left: 16px;
  background: linear-gradient(135deg, #ef4444 0%, #dc2626 100%);
  color: white;
  padding: 6px 12px;
  border-radius: 20px;
  font-size: 11px;
  font-weight: 700;
  letter-spacing: 0.5px;
  box-shadow: 0 2px 8px rgba(239, 68, 68, 0.3);
  pointer-events: none;
}

.product-info {
  padding: 12px 16px;
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 8px;
  user-select: none;
  background: transparent;
  /* Burada herhangi bir kararma yok */
}

.product-category {
  font-size: 12px;
  color: #64748b;
  font-weight: 500;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

.product-title {
  font-size: 18px;
  font-weight: 700;
  color: #1e293b;
  margin: 0;
  line-height: 1.3;
}

.product-description {
  font-size: 14px;
  color: #64748b;
  flex: 1;
  line-height: 1.5;
  margin: 0;
  display: -webkit-box;
  -webkit-line-clamp: 3;
  -webkit-box-orient: vertical;
  overflow: hidden;
  text-overflow: ellipsis;
}

.product-rating {
  display: flex;
  align-items: center;
  gap: 8px;
  margin: 8px 0;
}

.stars {
  display: flex;
  gap: 2px;
}

.star {
  color: #e2e8f0;
  font-size: 14px;
  transition: color 0.2s ease;
}

.star.filled {
  color: #fbbf24;
}

.rating-text {
  font-size: 12px;
  color: #64748b;
}

.product-bottom {
  margin-top: auto;
  padding-top: 16px;
}

.price-section {
  display: flex;
  align-items: center;
  gap: 8px;
  flex-wrap: wrap;
}

.old-price {
  font-size: 14px;
  color: #94a3b8;
  text-decoration: line-through;
}

.product-price {
  font-size: 20px;
  font-weight: 800;
  color: #16a34a;
  background: linear-gradient(135deg, #16a34a 0%, #15803d 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.discount-badge {
  background: linear-gradient(135deg, #ef4444 0%, #dc2626 100%);
  color: white;
  padding: 4px 8px;
  border-radius: 12px;
  font-size: 11px;
  font-weight: 700;
  box-shadow: 0 2px 4px rgba(239, 68, 68, 0.2);
}

/* Responsive */
@media (max-width: 768px) {
  .product-grid {
    grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  }

  .product-info {
    padding: 10px 12px;
  }

  .product-image {
    height: 200px;
  }
}
</style>
