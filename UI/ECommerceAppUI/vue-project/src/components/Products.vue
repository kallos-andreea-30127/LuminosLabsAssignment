
<script setup>

import { ref, watch } from 'vue'
import Grid from "../components/Grid.vue"

const products = ref(null)
const searchQuery = ref('')
const gridColumns = ['productName', 'price']

async function getProducts() {
  products.value = null
  const res = await fetch('/api/Product')
  products.value = await res.json()
}

function onAddToCart(id){
  let products = JSON.parse(localStorage.getItem('cartProducts'));
  if(products == null) products = [];
  products.push(id)
  localStorage.setItem('cartProducts', JSON.stringify(products));
}

getProducts()

const gridData = products

</script>

<template>
  <form id="search">
    Search <input name="query" v-model="searchQuery">
  </form>
  <Grid :data="gridData" :columns="gridColumns" :filter-key="searchQuery" @add-to-cart="onAddToCart"/>
</template>

