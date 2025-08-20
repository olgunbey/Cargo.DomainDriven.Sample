<template>
  <div class="register-container">
    <div class="register-card">
      <h2>Kayıt Ol</h2>

      <Form @submit="handleRegister" :validation-schema="registerSchema" class="form">
        <label for="fullname">Ad Soyad</label>
        <Field
          name="fullname"
          v-model="computedFullName"
          as="input"
          id="computedFullName"
          placeholder="Adınızı ve Soyadınızı giriniz"
          class="form-input"
        />
        <ErrorMessage name="fullname" class="error-message" />

        <label for="mail">E-Posta</label>
        <Field
          name="mail"
          v-model="registerUserDto.mail"
          as="input"
          type="email"
          id="mail"
          placeholder="ornek@mail.com"
          class="form-input"
        />
        <ErrorMessage name="mail" class="error-message" />

        <label for="password">Şifre</label>
        <Field
          name="password"
          as="input"
          v-model="registerUserDto.password"
          type="password"
          id="password"
          placeholder="Şifre giriniz"
          class="form-input"
        />
        <ErrorMessage name="password" class="error-message" />

        <label for="gender">Cinsiyet</label>
        <Field
        v-model="registerUserDto.gender"
          name="gender"
          as="select"
          id="gender"
          class="form-input"
        >
          <option disabled :value="null">Seçiniz</option>
          <option :value="true">Erkek</option>
          <option :value="false">Kadın</option>
        </Field>
        <ErrorMessage name="gender" class="error-message" />

        <button type="submit" class="submit-btn">Kaydol</button>
      </Form>

      <div v-if="registerError.length !==0" class="error-box">
        <ul>
          <li v-for="(error, i) in registerError" :key="i">{{ error }}</li>
        </ul>
      </div>

      <div v-else-if="registerSuccess" class="success-box">
        Kayıt başarıyla oluşturuldu!
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { EndpointCustomer } from "@/Request/EndpointCustomer";
import router from "@/router";


export interface RegisterDto {

    name:string;
    surname:string;
    mail:string;
    password:string;
    gender:boolean;
}


const registerError = ref<string[]>([]);
const registerUserDto= ref<RegisterDto>({} as RegisterDto);
const registerSuccess = ref<Boolean>(false);

const registerSchema = yup.object({
  fullname: yup.string().required("Ad Soyad gerekli"),
  mail: yup.string().email("Geçerli bir email giriniz").required("Email gerekli"),
  password: yup.string().min(6, "Şifre en az 6 karakter olmalı").required("Şifre gerekli"),
  gender: yup.boolean().nullable().required("Cinsiyet seçiniz"),
});




const handleRegister = async () => {
    const response = await new EndpointCustomer().registerCustomer(registerUserDto.value);
    if (response.errors.length!==0) {
      console.log(response.errors);
      registerError.value = response.errors;
    }
    else
    {
      registerSuccess.value=true;
      setTimeout(()=>{router.push({path:'/product'})},500);
    }
};

const computedFullName = computed({
  get: () => {
  const name = registerUserDto.value.name || "";
  const surname = registerUserDto.value.surname || "";
  return (name + " " + surname).trim() || "";
},
  set:(val:string) => {
    const nameParts = val.split(" ")
    const name= nameParts.slice(0,-1).join(" ")
    registerUserDto.value.name=name
    const surname = nameParts[nameParts.length-1]
    registerUserDto.value.surname=surname

  }
}
)

</script>

<style scoped>

.form {
  display: flex;
  flex-direction: column;
  align-items: center; /* yatay ortalama */
  gap: 1.25rem;
  width: 100%;
}


.register-container {
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background: #f3f4f6;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  padding: 1rem;
  box-sizing: border-box;
}

/* Kart tasarımı */
.register-card {
  background: white;
  padding: 2.5rem 2rem;
  border-radius: 1rem;
  box-shadow: 0 12px 30px rgba(0, 0, 0, 0.1);
  width: 100%;
  max-width: 400px;
  transition: transform 0.2s ease-in-out;
}
.register-card:hover {
  transform: translateY(-2px);
}


.register-card label {
  display: block;
  text-align: center; /* label ortalama */
  width: 100%;
  margin-bottom: 0.5rem;
  font-weight: 500;
  color: #374151;
  font-size: 0.9rem;
}


.register-card h2 {
  text-align: center;
  color: #333;
  margin-bottom: 1.5rem;
  font-size: 1.75rem;
}

.form-input {
  width: 90%;
  padding: 0.65rem 1rem;
  border: 1px solid #d1d5db;
  border-radius: 0.5rem;
  font-size: 0.95rem;
  outline: none;
  transition: all 0.2s ease-in-out;
  text-align: center; /* input içindeki yazıyı ortala */
}
.form-input:focus {
  border-color: #2563eb;
  box-shadow: 0 0 0 2px rgba(37, 99, 235, 0.2);
}

/* Hata mesajları */
.error-message {
  height: 1.2rem; /* her zaman bu kadar yer ayır */
  text-align: center;
  font-size: 0.8rem;
  color: #b91c1c;
  margin-top: 0.2rem;
  overflow-wrap: break-word; /* uzun metinleri satırla */
}

.error-box,
.success-box {
  margin-top: 1rem;
  padding: 0.6rem 1rem;
  border-radius: 0.5rem;
  font-size: 0.9rem;
  text-align: center;
  max-width: 400px;
}

.error-box {
  background-color: #fee2e2;
  color: #b91c1c;
  border: 1px solid #fca5a5;
}

.success-box {
  background-color: #d1fae5;
  color: #065f46;
  border: 1px solid #10b981;
}

/* Buton */
.submit-btn {
  width: 100%;
  padding: 0.65rem 0;
  background-color: #2563eb;
  color: #fff;
  font-weight: 600;
  font-size: 1rem;
  border: none;
  border-radius: 0.5rem;
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
}
.submit-btn:hover {
  background-color: #1d4ed8;
  transform: translateY(-1px);
}
</style>
