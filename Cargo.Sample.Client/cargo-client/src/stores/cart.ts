import { LocalStorageProductListDto, ProductDto } from '@/Dtos';
import { defineStore } from 'pinia'

export const useCartStore = defineStore('cart', {
  state: (): {
    items: LocalStorageProductListDto[];
    basketOpen: boolean;
    categoryId: string;
    orderLocationPopUp: boolean;
    

  } => ({
    items: (() => {
      const stored = localStorage.getItem('cartItems');
      return stored ? JSON.parse(stored) as LocalStorageProductListDto[] : [];
    })(),
    basketOpen: false,
    categoryId: "",
    orderLocationPopUp: false
  }),

  actions: {
    getItems(): LocalStorageProductListDto[] {
      return this.items
    },
    toggleBasket() {
      this.basketOpen = !this.basketOpen
    },
    closeBasket() {
      this.basketOpen = false
    },
    addItem(product: ProductDto) {
      const existing = this.items.find(i => i.product.productId === product.productId)
      if (existing) {
        existing.quantity++
      } else {
        const storageAddItem = new LocalStorageProductListDto(product, 1)
        this.items.push(storageAddItem);
      }
      this.saveToLocalStorage()
    },
    seletedCategoryId(categoryId: string) {
      this.categoryId = categoryId
    },
    removeItem(productId: string) {

      const index = this.items.findIndex(item => item.product.productId === productId)
      if (index === -1) return
      const item = this.items[index]
      if (item.quantity > 1) {
        item.quantity--
      } else {
        this.items.splice(index, 1)
      }
      this.saveToLocalStorage()
    },
    saveToLocalStorage() {
      localStorage.setItem('cartItems', JSON.stringify(this.items))
    },
    removeBasket() {
      this.items = []
      this.saveToLocalStorage()
    },
    toggleOrderLocationPopUp(){
      this.orderLocationPopUp = !this.orderLocationPopUp
    },
    closeOrderLocationPopUp(){
      this.orderLocationPopUp = false;
    }
  },
  getters: {
    itemCount: (state) => state.items.reduce((sum, item) => sum + item.quantity, 0),
    totalPrice: (state) =>
      state.items.reduce((sum, item) => sum + item.product.price * item.quantity, 0)
  }
})
