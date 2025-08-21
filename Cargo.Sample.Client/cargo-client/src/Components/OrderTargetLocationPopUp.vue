<template>
  <div>
    <div class="popup-overlay">
      <div class="popup">
        <h2>Adres Bilgileri</h2>

        <!-- Şehir -->
        <label for="city">Şehir</label>
        <select id="city" v-model="cityComputed">
          <option disabled value="">Seçiniz</option>
          <option :value="location" v-for="location in locationDto">{{ location.name }}</option>
        </select>

        <!-- İlçe -->
        <label for="district">İlçe</label>
        <select id="district" v-model="district">
          <option disabled value="">Seçiniz</option>
          <option v-for="district in districts" :key="district.districtId" :value="district.districtId">
            {{ district.name }}</option>
        </select>

        <!-- Detay -->
        <label for="detail">Adres Detayı</label>
        <textarea id="detail" v-model="detail" placeholder="Adres detayını giriniz..."></textarea>

        <!-- Butonlar -->
        <div class="btn-group">
          <button @click="save">Kaydet</button>
          <button @click="cart.closeOrderLocationPopUp()" class="cancel-btn">
            Kapat
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted, ref } from "vue";
import { useCartStore } from "@/stores/cart";
import { EndpointLocation } from "@/Request/EndpointLocation";

export interface LocationDto {
  cityId: string;
  name: string;
  districtResponses: District[];
}
export interface District {
  districtId: string;
  name: string;
}
const endpointLocation = EndpointLocation.SingletonEndpointRequest();

const selectedCityId = ref("")

const districts = ref<District[]>([] as District[]);

const cityComputed = computed({
  get: () => locationDto.value.find(x => x.cityId === selectedCityId.value),
  set: (city: LocationDto) => {
    selectedCityId.value = city.cityId
    districts.value = city.districtResponses
  },
});

onMounted(async () => {
  const response = await endpointLocation.GetAllCity();
  if (response.errors != null) {
    locationDto.value = response.data ? response.data : [];
  }
});

const cart = useCartStore();

const city = ref("");
const detail = ref("");
const district = ref("");
const locationDto = ref([] as LocationDto[])

function save() {
  console.log("Seçilen Şehir:", cityComputed.value)
  console.log("Seçilen ilçe", district.value)
  console.log("Adres Detayı:", detail.value)

  cart.closeOrderLocationPopUp();
}
</script>

<style scoped>
/* Arka plan */
.popup-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
}

/* Popup kutusu */
.popup {
  background: #fff;
  padding: 20px;
  border-radius: 12px;
  width: 350px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
}

.popup h2 {
  margin-bottom: 15px;
}

label {
  display: block;
  margin: 10px 0 5px;
}

select,
textarea {
  width: 100%;
  padding: 8px;
  margin-bottom: 10px;
  border-radius: 6px;
  border: 1px solid #ccc;
}

textarea {
  min-height: 60px;
  resize: vertical;
}

.btn-group {
  display: flex;
  justify-content: flex-end;
  gap: 10px;
}

button {
  padding: 8px 14px;
  border: none;
  border-radius: 6px;
  cursor: pointer;
}

.open-btn {
  margin: 20px;
  background: #007bff;
  color: white;
}

.cancel-btn {
  background: #aaa;
  color: white;
}

button:not(.cancel-btn) {
  background: #28a745;
  color: white;
}
</style>
