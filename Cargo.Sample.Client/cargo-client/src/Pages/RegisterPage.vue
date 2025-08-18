<template>
  <div class="register-container">
    <div class="register-card">
      <h2>Kayıt Ol</h2>

      <Form @submit="handleRegister(registerUser)" :validation-schema="registerSchema">
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
          v-model="registerUser.mail"
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
          v-model="registerUser.password"
          type="password"
          id="password"
          placeholder="Şifre giriniz"
          class="form-input"
        />
        <ErrorMessage name="password" class="error-message" />

        <label for="gender">Cinsiyet</label>
        <Field
        v-model="registerUser.gender"
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
import { RegisterDto } from "@/Dtos";
import router from "@/router";

const registerError = ref<string[]>([]);
const registerUser= ref<RegisterDto>({} as RegisterDto);
const registerSuccess = ref<Boolean>(false);

const registerSchema = yup.object({
  fullname: yup.string().required("Ad Soyad gerekli"),
  mail: yup.string().email("Geçerli bir email giriniz").required("Email gerekli"),
  password: yup.string().min(6, "Şifre en az 6 karakter olmalı").required("Şifre gerekli"),
  gender: yup.boolean().nullable().required("Cinsiyet seçiniz"),
});


const handleRegister = async (values: RegisterDto) => {
    const response = await new EndpointCustomer().registerCustomer(values);
    if (response.errors.length!==0) {
      console.log(response.errors);
      registerError.value = response.errors;
    }
    else
    {
      registerSuccess.value=true;
      setTimeout(()=>{router.push({path:'/product'});},500);
      
    }
};


const computedFullName = computed({
  get: () => {
  const name = registerUser.value.name || "";
  const surname = registerUser.value.surname || "";
  return (name + " " + surname).trim() || "";
},
  set:(val:string) => {
    const nameParts = val.split(" ")
    const name= nameParts.slice(0,-1).join(" ")
    registerUser.value.name=name
    const surname = nameParts[nameParts.length-1]
    registerUser.value.surname=surname

  }
}
)

</script>

<style scoped>
.register-container {
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background: #f3f4f6;
  font-family: Arial, sans-serif;
}

/* Kart tasarımı */
.register-card {
  background: white;
  padding: 2rem;
  border-radius: 16px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  width: 100%;
  max-width: 400px;
}

.register-card h2 {
  text-align: center;
  color: #333;
  margin-bottom: 1.5rem;
  font-size: 1.8rem;
}

/* Form inputları */
.form-input {
  padding: 0.6rem 0.8rem;
  margin-bottom: 1rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  outline: none;
  width: 100%;
  box-sizing: border-box;
  transition: border-color 0.2s;
}

.form-input:focus {
  border-color: #6366f1;
}

/* Hata mesajları */
.error-message {
  color: #b91c1c;
  font-size: 0.85rem;
  margin-bottom: 0.8rem;
  display: block;
}

.error-box {
  margin-top: 1rem;
  padding: 0.6rem 1rem;
  background-color: #fee2e2;
  color: #b91c1c;
  border: 1px solid #fca5a5;
  border-radius: 8px;
  font-size: 0.9rem;
  text-align: center;
  max-width: 400px;
}

/* Buton */
.submit-btn {
  background: #6366f1;
  color: white;
  padding: 0.7rem;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  font-weight: bold;
  cursor: pointer;
  transition: background 0.3s;
}

.submit-btn:hover {
  background: #4f46e5;
}
.success-box {
  margin-top: 1rem;
  padding: 0.6rem 1rem;
  background-color: #d1fae5; /* açık yeşil */
  color: #065f46; /* koyu yeşil */
  border: 1px solid #10b981;
  border-radius: 8px;
  font-size: 0.9rem;
  text-align: center;
  max-width: 400px;
}
</style>
