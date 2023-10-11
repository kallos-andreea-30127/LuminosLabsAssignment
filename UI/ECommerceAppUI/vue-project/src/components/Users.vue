
<script setup>

import { ref, watch } from 'vue'

const users = ref(null)

async function getUsers() {
  users.value = null
  const res = await fetch(
    'https://localhost:44368/api/User'
  )
  users.value = await res.json()
}

getUsers()

watch(getUsers)

</script>

<template>
        
        <p v-if="!users">Loading...</p>
  <pre v-else>{{ users }}</pre>
</template>

<style scoped>

</style>