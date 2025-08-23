<template>
  <Navbar></Navbar>
  <Basket></Basket>
  <RouterView></RouterView>
</template>

<script setup>
import Basket from "./Components/Basket.vue";
import Navbar from "./Components/Navbar.vue";
</script>

<style scoped></style>
