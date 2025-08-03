<script setup lang="ts">
    import { ref } from 'vue';
    import { Dialog, Button, InputText } from 'primevue';
    import { userStore } from '@/stores/user';

    const props = defineProps<{
        isVisible: boolean
    }>();


    const emits = defineEmits<{
        (e: 'logged'): void
        (e: 'canceled'): void
    }>();

    var usersStore = userStore();

    var username = ref('');
    
    function Login()
    {
        usersStore.login(username.value);
        emits('logged');
    }

    function Cancel() { emits('canceled'); }
</script>
<template>
    <Dialog :visible="props.isVisible" modal header="Edit Profile" :style="{ width: '25rem' }">
        <span class="text-surface-500 dark:text-surface-400 block mb-8">Update your information.</span>
        <div class="flex items-center gap-4 mb-4">
            <label for="username" class="font-semibold w-24">Username</label>
            <InputText id="username" v-model="username" class="flex-auto" autocomplete="off" />
        </div>
        <div class="flex items-center gap-4 mb-8">
            <label for="email" class="font-semibold w-24">Email</label>
            <InputText id="email" class="flex-auto" autocomplete="off" />
        </div>
        <div class="flex justify-end gap-2">
            <Button type="button" label="Cancel" severity="secondary" @click="Cancel"></Button>
            <Button type="button" label="Save" @click="Login"></Button>
        </div>
    </Dialog>
</template>

<style scoped>

</style>