<script setup>

import {ref} from 'vue'

let email = ref('')
let password = ref('')

async function submitForm() {
        const response = await fetch('/api/Login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            email: email.value,
            password: password.value
          })
        });
        console.log(email.value)
        if (response.ok) {
          alert("Hello " + email.value + "!");
        } else {
          alert("Incorrect Email/Password!")
        }
        this.$emit('close');
      } 
</script>

<template>
    <div class="modal">
        <div class="modal-content">
      <label>Email:</label>
      <input v-model="email" />
      <label>Password:</label>
      <input v-model="password" type="password"/>
      <button @click="submitForm">Submit</button>
    </div>
</div>
  </template>
