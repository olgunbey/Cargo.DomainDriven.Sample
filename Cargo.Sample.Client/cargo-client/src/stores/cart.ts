import { defineStore } from 'pinia'

export const useCartStore = defineStore('cart', {
  state: () => ({
    items: JSON.parse(localStorage.getItem('cartItems')) || [],
    basketOpen: false,
    categoryId:"",
  }),

  actions: {
    toggleBasket() {
      this.basketOpen = !this.basketOpen
    },
    closeBasket() {
      this.basketOpen = false
    },
    addItem(product) {
      const existing = this.items.find(i => i.product.id === product.id)
      if (existing) {
        existing.quantity++
      } else {
        this.items.push({ product, quantity: 1 })
      }
      this.saveToLocalStorage()
    },
    seletedCategoryId(categoryId:string){
      this.categoryId = categoryId
    },
    removeItem(productId) {
      const index = this.items.findIndex(item => item.product.id === productId)
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
    removeBasket(){
      this.items = []
      this.saveToLocalStorage()
    }
  },
  getters: {
    itemCount: (state) => state.items.reduce((sum, item) => sum + item.quantity, 0),
    totalPrice: (state) =>
      state.items.reduce((sum, item) => sum + item.product.price * item.quantity, 0)
  }
})
