
<script setup>

import LogIn from "../components/Login.vue"
import SignUp from "../components/SignUp.vue"

</script>

<template>
  <h1> Welcome to E-Comm </h1>
  <div>
    <router-link to="/login">
      <LogIn/>
    </router-link>
    <router-link to="/signup">
      <button>Sign Up</button>
    </router-link>
  </div>
  </template>