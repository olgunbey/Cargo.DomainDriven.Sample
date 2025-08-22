import { GetAllLocationForOrderResponseDto } from "@/Components/Basket.vue";
import { LocalStorageProductListDto, ProductDto } from "@/Dtos";
import { LoginResponseDto } from "@/Pages";
import { EndpointLocation } from "@/Request/EndpointLocation";
import { defineStore } from "pinia";

export const useCartStore = defineStore("cart", {
  state: (): {
    items: LocalStorageProductListDto[];
    basketOpen: boolean;
    categoryId: string;
    orderLocationPopUp: boolean;
    getAllLocationForOrderResponseDto: GetAllLocationForOrderResponseDto[];
  } => ({
    items: (() => {
      const stored = localStorage.getItem("cartItems");
      return stored ? (JSON.parse(stored) as LocalStorageProductListDto[]) : [];
    })(),
    basketOpen: false,
    categoryId: "",
    orderLocationPopUp: false,
    getAllLocationForOrderResponseDto: [],
  }),

  actions: {
    getItems(): LocalStorageProductListDto[] {
      return this.items;
    },
    toggleBasket() {
      this.basketOpen = !this.basketOpen;
    },
    closeBasket() {
      this.basketOpen = false;
    },
    addItem(product: ProductDto) {
      const existing = this.items.find(
        (i) => i.product.productId === product.productId
      );
      if (existing) {
        existing.quantity++;
      } else {
        const storageAddItem = new LocalStorageProductListDto(product, 1);
        this.items.push(storageAddItem);
      }
      this.saveToLocalStorage();
    },
    seletedCategoryId(categoryId: string) {
      this.categoryId = categoryId;
    },
    removeItem(productId: string) {
      const index = this.items.findIndex(
        (item) => item.product.productId === productId
      );
      if (index === -1) return;
      const item = this.items[index];
      if (item.quantity > 1) {
        item.quantity--;
      } else {
        this.items.splice(index, 1);
      }
      this.saveToLocalStorage();
    },
    saveToLocalStorage() {
      localStorage.setItem("cartItems", JSON.stringify(this.items));
    },
    removeBasket() {
      this.items = [];
      this.saveToLocalStorage();
    },
    async getAllLocation(){
      const endpointLocation = EndpointLocation.SingletonEndpointRequest();
      const localStorageLogin = localStorage.getItem("login");
      const parseLogin = JSON.parse(
        localStorageLogin ?? ""
      ) as LoginResponseDto;
      const data = await endpointLocation.GetAllLocationForOrder(
        parseLogin.userId
      );
      this.getAllLocationForOrderResponseDto = data.data ?? [];
    },
    toggleOrderLocationPopUp() {
      this.orderLocationPopUp = !this.orderLocationPopUp;
    },
    closeOrderLocationPopUp() {
      this.orderLocationPopUp = false;
    },
  },
  getters: {
    itemCount: (state) =>
      state.items.reduce((sum, item) => sum + item.quantity, 0)
  },
});
