<template>
  <div class="product-grid">
    <div v-if="products?.length !== 0" v-for="product in products" :key="product?.productId" class="product-card"
      @click.stop="addToCart(product)">
      <div class="product-image-wrapper">
        <img :src="product.image" :alt="product.name" class="product-image" />
      </div>
      <div class="product-info">
        <h2 class="product-title">{{ product.name }}</h2>
        <p class="product-description">{{ product.description }}</p>
      </div>
    </div>
    <div v-else class="no-products">
      <div class="empty-card" role="status" aria-live="polite">
        <span class="glow"></span>
        <div class="icon" aria-hidden="true">
          <svg viewBox="0 0 24 24" width="64" height="64">
            <path d="M3 7h18M7 7l2.4 9.6a2 2 0 0 0 2 1.4h2.2a2 2 0 0 0 2-1.4L18 7" fill="none" stroke="currentColor"
              stroke-width="1.5" stroke-linecap="round" />
            <circle cx="10" cy="12" r="2.2" fill="none" stroke="currentColor" stroke-width="1.5" />
            <circle cx="10" cy="12" r="4.2" fill="none" stroke="currentColor" stroke-width="1.2" opacity="0.25" />
            <path d="M15.5 15.5l4 4" stroke="currentColor" stroke-width="1.8" stroke-linecap="round" />
          </svg>
        </div>
        <h2>Ürün bulunamadı</h2>
        <p>Filtreleri daralttın mı? Kategoriyi değiştirerek yeniden dene.</p>

        <div class="actions">
          <a class="btn ghost">Filtreleri temizle</a>
          <a class="btn">Tüm ürünleri göster</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from "vue";
import { useCartStore } from "@/stores/cart";
import { EndpointProduct } from "@/Request/EndpointProduct";
import { ProductDto, ResponseDto } from "@/Dtos";

const cart = useCartStore();
const products = ref<ProductDto[]>();

watch(
  () => cart.categoryId,
  async (newCategoryId) => {
    if (!newCategoryId) return;
    const response: ResponseDto<ProductDto[]> = await new EndpointProduct().getProductsByCategoryId(newCategoryId);
    products.value = response.data ?? [];
  }
)



function addToCart(product:ProductDto) {
  cart.addItem(product);
}


function formatPrice(price:number) {
  return new Intl.NumberFormat("tr-TR", {
    style: "currency",
    currency: "TRY",
  }).format(price);
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

.no-products {
  position: absolute;
  /* sayfaya göre konumlandır */
  top: 50%;
  /* dikey ortala */
  left: 50%;
  /* yatay ortala */
  transform: translate(-50%, -50%);
  /* tam ortalama */
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  max-width: 400px;
  /* opsiyonel, kart boyutu */
  pointer-events: none;
  /* tıklanabilirliği kapat */
  z-index: 10;
  /* diğer elementlerin üstünde */
}

.empty-card {
  position: relative;
  width: min(720px, 92vw);
  border-radius: 24px;
  padding: 28px 28px 30px;
  background: var(--card);
  color: var(--fg);
  border: 1px solid var(--stroke);
  backdrop-filter: blur(8px) saturate(120%);
  box-shadow:
    0 10px 30px rgba(0, 0, 0, 0.18),
    inset 0 1px 0 rgba(255, 255, 255, 0.08);
  text-align: center;
  overflow: hidden;
}

/* animasyonlu çerçeve ışıltısı */
.empty-card::after {
  content: "";
  position: absolute;
  inset: -2px;
  border-radius: 26px;
  padding: 2px;
  background: conic-gradient(from 180deg,
      var(--accent), var(--accent-2), var(--accent), var(--accent-2));
  -webkit-mask:
    linear-gradient(#000 0 0) content-box,
    linear-gradient(#000 0 0);
  -webkit-mask-composite: xor;
  mask-composite: exclude;
  animation: spin 6s linear infinite;
  opacity: .35;
}

/* yumuşak parıltı */
.glow {
  position: absolute;
  inset: -40%;
  background: radial-gradient(closest-side, color-mix(in oklab, var(--accent) 35%, transparent), transparent 70%);
  filter: blur(40px);
  animation: float 10s ease-in-out infinite;
  opacity: .25;
}

.icon {
  width: 96px;
  height: 96px;
  margin: 4px auto 10px;
  display: grid;
  place-items: center;
  border-radius: 50%;
  background: linear-gradient(180deg, color-mix(in oklab, var(--accent) 22%, transparent), transparent);
  border: 1px solid var(--stroke);
  box-shadow: inset 0 1px 8px rgba(0, 0, 0, 0.06);
  color: color-mix(in oklab, var(--accent) 70%, var(--fg));
  animation: rise 700ms cubic-bezier(.2, .7, .2, 1) both;
}

h2 {
  font-size: clamp(20px, 2.4vw, 28px);
  letter-spacing: .2px;
  margin: 6px 0 6px;
}

p {
  margin: 0 auto 18px;
  max-width: 42ch;
  color: var(--muted);
  line-height: 1.5;
}

.actions {
  display: flex;
  gap: 10px;
  justify-content: center;
  flex-wrap: wrap;
}

.btn {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  padding: 10px 14px;
  border-radius: 12px;
  border: 1px solid var(--stroke);
  background: linear-gradient(180deg, color-mix(in oklab, var(--accent) 18%, transparent), transparent);
  font-weight: 600;
  text-decoration: none;
  transition: transform .15s ease, box-shadow .15s ease, background .2s ease;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.08);
  cursor: pointer;
  user-select: none;
}

.btn:hover {
  transform: translateY(-1px);
}

.btn:active {
  transform: translateY(0);
}

.btn.ghost {
  background: transparent;
  backdrop-filter: none;
}

@keyframes spin {
  to {
    transform: rotate(1turn);
  }
}

@keyframes float {

  0%,
  100% {
    transform: translateY(-2%);
  }

  50% {
    transform: translateY(2%);
  }
}

@keyframes rise {
  from {
    transform: translateY(10px);
    opacity: 0;
  }

  to {
    transform: translateY(0);
    opacity: 1;
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
