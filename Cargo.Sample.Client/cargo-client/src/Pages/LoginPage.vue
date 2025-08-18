<template>
  <div class="container">
    <div class="login-box">
      <div class="header">
        <h1>E-Ticaret Giriş</h1>
        <p>Lütfen hesabınıza giriş yapın</p>
      </div>

      <form @submit.prevent="handleLogin" class="form">
        <div class="form-group">
          <label>E-posta</label>
          <input
            v-model="email"
            type="email"
            required
            placeholder="ornek@mail.com"
          />
        </div>

        <div class="form-group">
          <label>Şifre</label>
          <input
            v-model="password"
            type="password"
            required
            placeholder="••••••••"
          />
        </div>

        <button type="submit">Giriş Yap</button>
      </form>

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

const email = ref('');
const password = ref('');
const router = useRouter();

const handleLogin = () => {
  console.log('E-posta:', email.value, 'Şifre:', password.value);
  
  router.push('/product'); 
};
</script>

<style scoped>
/* Container: sayfa ortalaması */
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f3f4f6; /* Tailwind bg-gray-100 */
}

/* Form kutusu */
.login-box {
  background-color: #fff;
  border-radius: 1rem; /* Tailwind rounded-2xl */
  padding: 2rem;
  width: 100%;
  max-width: 400px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1); /* Tailwind shadow-lg */
}

/* Başlık kısmı */
.header {
  text-align: center;
  margin-bottom: 1.5rem;
}

.header h1 {
  font-size: 1.5rem;
  font-weight: bold;
  color: #1f2937; /* Tailwind text-gray-800 */
}

.header p {
  color: #6b7280; /* Tailwind text-gray-500 */
  font-size: 0.875rem;
}

/* Form ve inputlar */
.form {
  display: flex;
  flex-direction: column;
  gap: 1rem;
}

.form-group label {
  display: block;
  font-weight: 500;
  margin-bottom: 0.25rem;
  color: #374151; /* Tailwind text-gray-700 */
  font-size: 0.875rem;
}

.form-group input {
  width: 100%;
  padding: 0.5rem 1rem;
  border: 1px solid #d1d5db; /* Tailwind border-gray-300 */
  border-radius: 0.5rem; /* Tailwind rounded-lg */
  outline: none;
  transition: 0.2s;
}

.form-group input:focus {
  border-color: #3b82f6; /* Tailwind focus:ring-blue-500 */
  box-shadow: 0 0 0 2px rgba(59, 130, 246, 0.3);
}

/* Giriş butonu */
button {
  width: 100%;
  background-color: #2563eb; /* Tailwind bg-blue-600 */
  color: white;
  font-weight: 600;
  padding: 0.5rem 0;
  border-radius: 0.5rem;
  cursor: pointer;
  transition: background-color 0.2s;
}

button:hover {
  background-color: #1d4ed8; /* Tailwind hover:bg-blue-700 */
}

/* Kayıt metni */
.register-text {
  margin-top: 1.5rem;
  text-align: center;
  font-size: 0.875rem;
  color: #4b5563; /* Tailwind text-gray-600 */
}

.register-text a {
  color: #2563eb;
  text-decoration: none;
}

.register-text a:hover {
  text-decoration: underline;
}
</style>
