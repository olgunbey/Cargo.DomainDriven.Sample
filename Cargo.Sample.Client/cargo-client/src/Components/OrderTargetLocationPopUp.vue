<template>
  <Form @submit="save" :validation-schema="schema">
    <div class="popup-overlay">
      <div class="popup">
        <h2>Adres Bilgileri</h2>
        <label for="header">Adres Başlığı</label>
        <Field id="header" name="header" type="text" v-model="header" />
        <ErrorMessage name="header" class="error-message" />

        <label for="city">Şehir</label>
        <Field as="select" name="city" v-model="selectedCityId">
          <option disabled value="">Seçiniz</option>
          <option
            v-for="location in locationDto"
            :key="location.cityId"
            :value="location.cityId"
          >
            {{ location.cityName }}
          </option>
        </Field>
        <ErrorMessage name="city" class="error-message" />

        <label for="district">İlçe</label>
        <Field as="select" name="district" v-model="district">
          <option disabled value="">Seçiniz</option>
          <option
            v-for="dist in districts"
            :key="dist.districtId"
            :value="dist.districtId"
          >
            {{ dist.districtName }}
          </option>
        </Field>
        <ErrorMessage name="district" class="error-message" />

        <label for="detail">Adres Detayı</label>
        <Field
          as="textarea"
          id="detail"
          name="detail"
          placeholder="Adres detayını giriniz..."
          v-model="detail"
        />
        <ErrorMessage name="detail" class="error-message" />

        <div class="btn-group">
          <button type="submit">Kaydet</button>
          <button
            type="button"
            @click="cart.closeOrderLocationPopUp()"
            class="cancel-btn"
          >
            Kapat
          </button>
        </div>
      </div>
    </div>
  </Form>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from "vue";
import { useCartStore } from "@/stores/cart";
import { EndpointLocation } from "@/Request/EndpointLocation";
import { LoginResponseDto } from "@/Pages";
import { SaveLocationForOrderRequestDto } from "@/Dtos/SaveLocationForOrderRequestDto";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";

export interface District {
  districtId: string;
  districtName: string;
}
export interface LocationDto {
  cityId: string;
  cityName: string;
  districtResponses: District[];
}

const cart = useCartStore();
const endpointLocation = EndpointLocation.SingletonEndpointRequest();

const schema = yup.object({
  header: yup.string().required("Adres başlığı giriniz"),
  city: yup.string().required("Şehir seçiniz"),
  district: yup.string().required("İlçe seçiniz"),
  detail: yup.string().required("Adres detayı giriniz"),
});

const districts = ref<District[]>([]);
const district = ref("");
const detail = ref("");
const header = ref("");
const locationDto = ref<LocationDto[]>([]);


const id = ref<string>()

const selectedCityId=computed({
  get:()=> id.value,
  set:(cityId:string)=>{
    id.value=cityId
    districts.value= locationDto.value.find(c=>c.cityId==cityId)?.districtResponses ?? []
    district.value=""
    detail.value=""
  }
}
)

onMounted(async () => {
  const response = await endpointLocation.GetAllCity();
  if (response.errors.length == 0) {
    locationDto.value = response.data ?? [];
  }
});

async function save() {
  const loginLocalStorage = localStorage.getItem("login")

  const jsonLoginLocalStorage = JSON.parse(
    loginLocalStorage ?? ""
  ) as LoginResponseDto

  
  const dto = new SaveLocationForOrderRequestDto(
    selectedCityId.value ?? "",
    district.value,
    jsonLoginLocalStorage.userId,
    detail.value,
    header.value
  )

  const response = await endpointLocation.SaveLocationForOrder(dto)

  if (response.errors.length == 0) { 
  }
  await cart.getAllLocation()
  cart.closeOrderLocationPopUp()
}
</script>

<style scoped>
label {
  display: block;
  margin: 10px 0 5px;
}

select,
textarea,
input[type="text"] {
  width: 100%;
  padding: 8px;
  margin-bottom: 10px;
  border-radius: 6px;
  border: 1px solid #ccc;
  box-sizing: border-box;
}

textarea {
  min-height: 60px;
  resize: vertical;
}

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

.popup {
  background: #fff;
  padding: 20px;
  border-radius: 12px;
  width: 350px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
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

.cancel-btn {
  background: #aaa;
  color: white;
}

button:not(.cancel-btn) {
  background: #28a745;
  color: white;
}

.error-message {
  color: #b91c1c;
  font-size: 0.8rem;
}
</style>
