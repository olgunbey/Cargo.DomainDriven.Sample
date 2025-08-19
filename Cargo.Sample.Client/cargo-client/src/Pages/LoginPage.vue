<template>
  <div class="container">
    <div class="login-box">
      <div class="header">
        <h1>E-Ticaret Giriş</h1>
        <p>Lütfen hesabınıza giriş yapın</p>
      </div>

      <Form @submit="handleLogin" class="form" :validation-schema="loginSchema">

        <div class="form-group">
          <label for="email">E-Posta</label>
          <Field v-model="loginDto.email" name="email" placeholder="ornek@mail.com" />
          <ErrorMessage name="email" class="error-message" />
        </div>

        <div class="form-group">
          <label for="password">Password</label>
          <Field v-model="loginDto.password" name="password" placeholder="••••••••" type="password" />
          <ErrorMessage name="password" class="error-message" />

        </div>

        <button type="submit">Giriş Yap</button>

      </Form>


      <p class="register-text">
        Hesabınız yok mu?
        <a href="/register">Kayıt Ol</a>
      </p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { Form, Field, ErrorMessage } from 'vee-validate';
import * as yup from "yup";
import { LoginDto } from '@/Dtos/LoginDto';


const router = useRouter();

const loginDto = ref<LoginDto>({} as LoginDto);


const loginSchema = yup.object({
  email:yup.string().required("E-Posta giriniz"),
  password:yup.string().required("Password giriniz")
})

const handleLogin = () => {
  console.log('E-posta:', loginDto.value.email, 'Şifre:', loginDto.value.password);

  setTimeout(()=>{router.push('/product')},500);
};
</script>

<style scoped>

.container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f3f4f6; /* açık gri arka plan */
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  padding: 1rem;
  box-sizing: border-box;
}

/* Form kutusu */
.login-box {
  background-color: #fff;
  border-radius: 1rem; /* yuvarlatılmış köşeler */
  padding: 2.5rem 2rem;
  width: 100%;
  max-width: 400px;
  box-shadow: 0 12px 30px rgba(0, 0, 0, 0.1); /* gölgeyi biraz derinleştirdik */
  transition: transform 0.2s ease-in-out;
}

.login-box:hover {
  transform: translateY(-2px);
}

/* Başlık kısmı */
.header {
  text-align: center;
  margin-bottom: 2rem;
}

.header h1 {
  font-size: 1.75rem;
  font-weight: 700;
  color: #1f2937; /* koyu gri */
  margin-bottom: 0.5rem;
}

.header p {
  font-size: 0.9rem;
  color: #6b7280; /* orta gri */
}

/* Form ve inputlar */
.form {
  display: flex;
  flex-direction: column;
  align-items: center; /* yatay ortalama */
  gap: 1.25rem;
}

.form-group {
  position: relative; /* hata mesajı için referans */
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-bottom: 1.5rem; /* error mesajı için boşluk */
}

.form-group label {
  display: block;
  font-weight: 500;
  margin-bottom: 0.5rem;
  color: #374151;
  font-size: 0.9rem;
  text-align: center; /* label ortalama */
}

.form-group input {
  width: 90%; /* input genişliği biraz daraltıldı */
  padding: 0.65rem 1rem;
  border: 1px solid #d1d5db;
  border-radius: 0.5rem;
  font-size: 0.95rem;
  outline: none;
  transition: all 0.2s ease-in-out;
  text-align: center; /* input içindeki yazıyı ortala */
}

.form-group input:focus {
  border-color: #2563eb;
  box-shadow: 0 0 0 2px rgba(37, 99, 235, 0.2);
}


.error-message {
  position: absolute;
  bottom: -1.2rem; /* inputun hemen altı */
  left: 50%;
  transform: translateX(-50%);
  text-align: center;
  font-size: 0.8rem;
  color: #b91c1c;
  max-width: 90%; /* input ile uyumlu */
  white-space: normal; /* satır kaymasını sağla */
}


/* Giriş butonu */
button {
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

button:hover {
  background-color: #1d4ed8;
  transform: translateY(-1px);
}

/* Kayıt metni */
.register-text {
  margin-top: 1.75rem;
  text-align: center;
  font-size: 0.875rem;
  color: #4b5563;
}

.register-text a {
  color: #2563eb;
  text-decoration: none;
  font-weight: 500;
}

.register-text a:hover {
  text-decoration: underline;
}

</style>
