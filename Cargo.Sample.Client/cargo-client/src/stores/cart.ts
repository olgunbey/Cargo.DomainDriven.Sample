import { GetAllLocationForOrderResponseDto } from "@/Components/Basket.vue";
import { CityDto } from "@/Components/OrderTargetLocationPopUp.vue";
import { LocalStorageProductListDto, ProductDto } from "@/Dtos";
import { UserDto } from "@/Dtos/UserDto";
import { LoginResponseDto } from "@/Pages";
import { EndpointLocation } from "@/Request/EndpointLocation";
import { defineStore } from "pinia";

export const useCartStore = defineStore("cart", {
  state: (): {
    items: LocalStorageProductListDto[];
    basketOpen: boolean;
    orderLocationPopUp: boolean;
    getAllLocationForOrderResponseDto: GetAllLocationForOrderResponseDto[];
    updateLocation: GetAllLocationForOrderResponseDto | null;
    sendComponent: boolean; //false => adres ekle, true => edited,
    selectedLocationId: string
  } => ({
    items: (() => {
      const stored = localStorage.getItem("cartItems");
      return stored ? (JSON.parse(stored) as LocalStorageProductListDto[]) : [];
    })(),
    basketOpen: false,
    orderLocationPopUp: false,
    getAllLocationForOrderResponseDto: [],
    updateLocation: null,
    sendComponent: false,
    selectedLocationId: ""
  }),
  actions: {
    SetLocationIdForOrder(id: string) {
      this.selectedLocationId = id
    },
    async WriteCityCache(): Promise<CityDto[]> {
      const endpointLocation = EndpointLocation.SingletonEndpointRequest();
      const response = await endpointLocation.GetAllCity();
      const data = response.data as CityDto[];
      localStorage.setItem("loadCity", JSON.stringify(data));
      return data;
    },
    async loadCity(): Promise<CityDto[]> {
      const getCache = localStorage.getItem("loadCity");
      if (getCache == null) {
        return this.WriteCityCache();
      }
      return JSON.parse(getCache) as CityDto[];
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
    async getAllLocation() {
      const endpointLocation = EndpointLocation.SingletonEndpointRequest();
      const localStorageLogin = localStorage.getItem("login");


      if (localStorageLogin != null) {
        const parseLogin = JSON.parse(
          localStorageLogin ?? ""
        ) as LoginResponseDto;

        const data = await endpointLocation.GetAllLocationForOrder(
          parseLogin.userId
        );
        this.getAllLocationForOrderResponseDto = [...(data.data ?? [])];
      }



    },
    async removeLocation(locationId: string) {
      const request = EndpointLocation.SingletonEndpointRequest();
      await request.RemoveLocationForOrder(locationId);
      await this.getAllLocation();
    },
    toggleOrderLocationPopUp() {
      this.orderLocationPopUp = !this.orderLocationPopUp;
      this.sendComponent = false;
    },
    closeOrderLocationPopUp() {
      this.orderLocationPopUp = false;
    },
    async LocationPopupOpen(location: GetAllLocationForOrderResponseDto) {
      this.toggleOrderLocationPopUp();
      this.sendComponent = true;
      this.updateLocation = location;
    },
  },
  getters: {
    itemCount: (state) =>
      state.items.reduce((sum, item) => sum + item.quantity, 0),
    totalPrice: (state) =>
      state.items.reduce(
        (sum, item) => sum + item.quantity * item.product.price,
        0
      ),
  },
});
