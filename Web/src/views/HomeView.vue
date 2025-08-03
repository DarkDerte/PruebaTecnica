<script setup lang="ts">
import { Card } from 'primevue';


</script>

<template>
  <main>
    <Card class="card">
      <template #content>
        <article>
          <h1>Let's Start</h1>
          <p>
            1- Login to the system.<br />
            2- In the navbar you can select area you want, but currently only it's developed 'Contracts'.<br />
            3- Enjoy
          </p>
        </article>
      </template>
    </Card>
  </main>
</template>

<style scoped>

.card {
  border-radius: 15px;
  box-shadow: gray 0px 0px 16px;
}

@media (min-width: 1024px) {
 main{
  display: flex;
  align-items: center;
  justify-content: center;
 }
}
</style>
