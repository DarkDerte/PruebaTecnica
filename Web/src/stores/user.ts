import { defineStore } from 'pinia'
import { computed, ref } from 'vue'

export const userStore = defineStore('user', () => {
    const name = ref('');

    const isLogged = computed(()=> name.value !== '' );
    
    function login(new_name:string) {
        name.value = new_name;
    }
    function logout() { 
        name.value = '';
    }

    return {
        name,
        isLogged,
        login,
        logout
    }
}, { persist: true })