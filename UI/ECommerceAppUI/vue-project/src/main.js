import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import LogIn from './components/LogIn.vue';
import SignUp from './components/SignUp.vue';
import { createRouter, createWebHistory } from 'vue-router';

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', component: App },
    { path: '/login', component: LogIn },
    { path: '/signup', component: SignUp }
  ]
});

const app = createApp(App);
app.use(router);

createApp(App).mount('#app')
