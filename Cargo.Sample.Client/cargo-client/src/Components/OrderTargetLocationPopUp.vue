<template>
  <form @submit="onSubmit">
    <div class="popup-overlay">
      <div class="popup">
        <h2>Adres Bilgileri</h2>

        <label for="header">Adres Başlığı</label>
        <Field id="header" name="header" type="text" :rules="[required]" />
        <ErrorMessage name="header" class="error-message" />

        <label for="city">Şehir</label>
        <Field as="select" name="city" v-model="cityId" :rules="[required]">
          <option disabled value="">Seçiniz</option>
          <option v-for="location in locationDto" :key="location.cityId" :value="location.cityId">
            {{ location.cityName }}
          </option>
        </Field>
        <ErrorMessage name="city" class="error-message" />

        <label for="district">İlçe</label>
        <Field as="select" name="district" :rules="[required]">
          <option disabled value="">Seçiniz</option>
          <option v-for="dist in districts" :key="dist.districtId" :value="dist.districtId">
            {{ dist.districtName }}
          </option>
        </Field>
        <ErrorMessage name="district" class="error-message" />

        <label for="detail">Adres Detayı</label>
        <Field as="textarea" id="detail" name="detail" placeholder="Adres detayını giriniz..." :rules="[required]" />
        <ErrorMessage name="detail" class="error-message" />

        <div class="btn-group">
          <button type="submit">Kaydet</button>
          <button type="button" @click="cart.closeOrderLocationPopUp()" class="cancel-btn">
            Kapat
          </button>
        </div>
      </div>
    </div>
  </form>
</template>

<script setup lang="ts">
import { ref, onMounted, computed } from "vue";
import { useCartStore } from "@/stores/cart";
import { EndpointLocation } from "@/Request/EndpointLocation";
import { LoginResponseDto } from "@/Pages";
import { SaveLocationForOrderRequestDto } from "@/Dtos/SaveLocationForOrderRequestDto";
import { Field, ErrorMessage, useForm } from "vee-validate";
import { required } from "@vee-validate/rules";
import  "@/ExtendsMethod/EfCoreMethods";

interface LocationForm {
  header: string;
  city: string;
  district: string;
  detail: string;
}

export interface District {
  districtId: string;
  districtName: string;
}

export interface CityDto {
  cityId: string;
  cityName: string;
  districtResponses: District[];
}

const { resetForm, handleSubmit, setValues } = useForm<LocationForm>();
const cart = useCartStore();

const endpointLocation = EndpointLocation.SingletonEndpointRequest();

const districts = ref<District[]>([]);
const locationDto = ref<CityDto[]>([]);

const selectedId = ref<string>();

const cityId = computed({
  get: () =>
    locationDto.value.find((y) => y.cityId == selectedId.value)?.cityId,
  set: (city: string) => {
    selectedId.value = city;
    districts.value = locationDto.value.Single(y => y.cityId == selectedId.value).districtResponses ?? []
  },
});

const onSubmit = handleSubmit(async (values) => {
  const loginLocalStorage = localStorage.getItem("login");
  if (!loginLocalStorage) {
    console.error("Login bilgisi bulunamadı");
    return;
  }

  const jsonLoginLocalStorage = JSON.parse(
    loginLocalStorage
  ) as LoginResponseDto;

  const dto = new SaveLocationForOrderRequestDto(
    values.city,
    values.district,
    jsonLoginLocalStorage.userId,
    values.detail,
    values.header
  );

  const response = await endpointLocation.SaveLocationForOrder(dto);

  if (response.errors.length === 0) {
    await cart.getAllLocation();
    cart.closeOrderLocationPopUp();
  } else {
  }
});
onMounted(async () => {
  locationDto.value = await cart.loadCity();

  if (!cart.sendComponent) {
    resetForm();
  } else if (cart.updateLocation) {
    cityId.value = cart.updateLocation.cityId;
    setValues({
      header: cart.updateLocation.locationHeader,
      city: cart.updateLocation.cityId,
      district: cart.updateLocation.districtId,
      detail: cart.updateLocation.detail,
    });
  }
});
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
