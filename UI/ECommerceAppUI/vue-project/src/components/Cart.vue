
<script setup>

import { ref } from 'vue';
import Grid from "../components/Grid.vue";

const searchQuery = ref('')
const gridColumns = ['productName', 'price']
const gridData = ref([])

gridData.value = JSON.parse(localStorage.getItem('cartProducts'));

function onRemoveFromCart(idx) {
  let products = JSON.parse(localStorage.getItem('cartProducts'));
  if(products == null) return;

  products.splice(idx, 1)
  gridData.value = products;
  localStorage.setItem('cartProducts', JSON.stringify(products));
}

async function onPlaceOrder(){
  let products = JSON.parse(localStorage.getItem('cartProducts'));
}


</script>

<template>
  <Grid :data="gridData" :columns="gridColumns" :filter-key="searchQuery" :inCart="true"
    @remove-from-cart="onRemoveFromCart" />
    <button @click="onPlaceOrder()">
      Place Order
    </button>
</template>

