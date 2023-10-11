<script setup>

    import {ref} from 'vue'

    let email = ref('')
let name = ref('')
let password = ref('')

    async function submitForm() {
        if (!name.value || !email.value || !password.value) {
          alert("All fields are required.");
          return;
        }

        const response = await fetch('/api/User', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            name: name.value,
            email: email.value,
            password: password.value
          })
        });

        if (response.ok) {
          // Signup successful
          // Redirect or perform actions accordingly
          alert("Signup successful");
        } else {
          alert("Something went wrong!")
        }
      } 
</script>
<template>
  <div>
    <label>Name:</label>
    <input v-model="name" type="text" required />
    <label>Email:</label>
    <input v-model="email" type="email" required />
    <label>Password:</label>
    <input v-model="password" type="password" required />
    <button @click="submitForm">Sign Up</button>
  </div>
</template>