<script setup lang="ts">
import { computed, ref } from 'vue';
import { Button } from 'primevue';
import { userStore } from '@/stores/user'
import { Menubar, Toast } from 'primevue'; 
import PopUpLogin from './components/PopUpLogin.vue'

const usersStore = userStore();

const popupIsvisible = ref(false);

const items = computed(() => {
  return [
    {
      label: 'Home',
      icon: 'pi pi-home',
      url: '/'
    },
    (usersStore.isLogged ?  
      {
        label: "Areas",
        icon: 'pi pi-search',
        badge: 3,
        items: [
          {
            label: 'Customers',
            icon: 'pi pi-user',
            url: '/customers'
          },
          {
            label: 'Contracts',
            icon: 'pi pi-file',
            url: '/contracts'
          },
          {
            separator: true
          },
          {
            label: 'Human Resources',
            icon: 'pi pi-id-card',
            url: '/humanresources'
          }
        ]
      }
      : {}
    )];
  });

  function showPopUp(){
    popupIsvisible.value = true;
  }

  function clearPopUp(){
    popupIsvisible.value = false;
  }

</script>

<template>
  <header>
    <Menubar :model="items">
      <template #end>
        <Button v-if="!usersStore.isLogged" label="Login" @click="showPopUp"></Button>
        <Button v-if="usersStore.isLogged" severity="danger" label="Logout" @click="usersStore.logout()"></Button>
      </template>
    </Menubar>
  </header>
  
  <RouterView style="flex-grow: 1;"></RouterView>
  
  <PopUpLogin :isVisible=popupIsvisible @logged="clearPopUp" @canceled="clearPopUp" ></PopUpLogin>
  <Toast />
</template>

<style scoped>

@media (min-width: 1024px) {

}
</style>
