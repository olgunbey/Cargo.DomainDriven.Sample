<template>
  <div v-if="cart.basketOpen" class="overlay" @click="cart.closeBasket"></div>
  <div class="basket" :class="{ open: cart.basketOpen }">
    <header class="basket-header">
      <h2>Sepetiniz</h2>
      <button class="close-btn" @click="cart.closeBasket">×</button>
    </header>

    <div class="basket-content">
      <div v-if="cart.items.length === 0" class="empty-cart">Sepetiniz boş</div>
      <ul v-else>
        <li v-for="item in cart.items" :key="item.product.productId" class="basket-item">
          <img :src="item.product.image" :alt="item.product.name" />
          <div class="basket-item-info">
            <span class="name">{{ item.product.name }}</span>
            <span class="quantity">× {{ item.quantity }}</span>
          </div>
          <span class="price">{{ formatPrice(item.product.price * item.quantity) }}</span>
          <button class="remove-btn" @click="cart.removeItem(item.product.productId)">×</button>
        </li>
      </ul>
    </div>

    <footer v-if="cart.items.length" class="basket-footer">
      <div class="total">
        <span>Toplam:</span>
        <strong>{{ formatPrice(cart.totalPrice) }}</strong>
      </div>

      <button class="checkout-btn" @click="buyProduct">Satın Al</button>


      <button class="clear-cart-btn" @click="deleteBasket">
        🗑 Sepeti Sıfırla
      </button>
    </footer>

    <button @click="isOpenLocation" class="addLocation-btn">Adres Ekle</button>

    <div v-if="cart.orderLocationPopUp">
      <OrderTargetLocationPopUp></OrderTargetLocationPopUp>
    </div>

  </div>
</template>

<script setup lang="ts">

import { LocalStorageProductListDto } from '@/Dtos';
import { useCartStore } from '@/stores/cart'
import OrderTargetLocationPopUp from "./OrderTargetLocationPopUp.vue"

const cart = useCartStore()

function formatPrice(price: any) {
  return new Intl.NumberFormat('tr-TR', {
    style: 'currency',
    currency: 'TRY',
  }).format(price)
}

function deleteBasket() {
  cart.removeBasket()
}

const isOpenLocation = () => {
  cart.toggleOrderLocationPopUp()
}


const buyProduct = async () => {

  const productListDto: LocalStorageProductListDto[] = cart.getItems();


}
</script>

<style scoped>
/* Arka plan */
.overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: transparent;
  z-index: 9;
}

.basket {
  position: fixed;
  top: 80px;
  /* Navbar yüksekliği + boşluk */
  right: -350px;
  width: 320px;
  max-height: calc(100vh - 100px);
  background: white;
  border-radius: 12px;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.15);
  padding: 16px;
  display: flex;
  flex-direction: column;
  transition: right 0.3s ease;
  z-index: 1000;
}

.basket.open {
  right: 20px;
}

/* Başlık */
.basket-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 12px;
}

.close-btn {
  background: none;
  border: none;
  font-size: 22px;
  cursor: pointer;
  color: #666;
}

/* İçerik */
.basket-content {
  flex: 1;
  overflow-y: auto;
}

.empty-cart {
  text-align: center;
  color: #888;
  font-style: italic;
  padding: 20px 0;
}

/* Sepet item */
.basket-item {
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 8px 0;
  border-bottom: 1px solid #eee;
}

.basket-item img {
  width: 40px;
  height: 40px;
  border-radius: 6px;
  object-fit: cover;
}

.basket-item-info {
  flex: 1;
  display: flex;
  flex-direction: column;
}

.name {
  font-size: 14px;
  font-weight: 500;
}

.quantity {
  font-size: 12px;
  color: #666;
}

.price {
  font-weight: 600;
  color: #16a34a;
}

/* Çarpı butonu */
.remove-btn {
  background: none;
  border: none;
  font-size: 18px;
  color: #ef4444;
  cursor: pointer;
}

.remove-btn:hover {
  color: #dc2626;
}

/* Footer */
.basket-footer {
  padding-top: 12px;
  border-top: 1px solid #eee;
}

.total {
  display: flex;
  justify-content: space-between;
  margin-bottom: 12px;
  font-size: 14px;
}

/* Satın Al */
.checkout-btn {
  width: 100%;
  padding: 10px;
  background: #16a34a;
  color: white;
  font-weight: 600;
  border: none;
  border-radius: 6px;
  cursor: pointer;
}

.addLocation-btn {
  width: 100%;
  padding: 10px;
  background: wheat;
  color: white;
  font-weight: 600;
  border: none;
  border-radius: 6px;
  cursor: pointer;
}

.checkout-btn:hover {
  background: #15803d;
}

/* Sepeti Sıfırla */
.clear-cart-btn {
  margin-top: 8px;
  width: 100%;
  padding: 8px;
  background: #ef4444;
  color: white;
  font-weight: 500;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 14px;
  opacity: 0.85;
}

.clear-cart-btn:hover {
  background: #dc2626;
  opacity: 1;
}
</style>
