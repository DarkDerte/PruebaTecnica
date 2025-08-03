<script setup lang="ts">
    import { ref, inject } from 'vue';
    
    import { InputGroup, InputNumber, Button, InputText, IftaLabel, Textarea, useToast} from 'primevue';

    import { userStore } from '@/stores/user';
    import type { ContractEntity } from '@/entities/ContractEntity';
    import type { DialogContract } from '@/types/DialogContract';
    import axios, { type AxiosResponse } from 'axios';

    const dialogContract = inject<DialogContract>('dialogRef');
    if (!dialogContract) {
        throw new Error('dialogContract is not provided');
    }

    const model = ref(dialogContract.value.data.model as ContractEntity); 
    const isNew = ref(dialogContract.value.data.isNew as boolean);
    const toDelete = ref(dialogContract.value.data.toDelete as boolean);

    var usersStore = userStore();
    var toast = useToast();

    async function UpdateData() {
        try{
            const res = await axios.put(import.meta.env.VITE_APP_API_URL + '/Contract/'+model.value.id, model.value);
            if (res.status == 200)
                toast.add({ severity: 'info', summary: 'Updated', detail: 'Current Contract', life: 3000 });
            else
                toast.add({ severity: 'error', summary: 'Error', detail: 'Error on save data', life: 3000 });
            dialogContract?.value.close();
        } catch (error) { console.error("Error on save data:", error); }
    }

    async function DeleteData() {
        try{
            const res =  await axios.delete(import.meta.env.VITE_APP_API_URL + '/Contract/'+model.value.id);
            if (res.status == 200)
                toast.add({ severity: 'info', summary: 'Deleted', detail: 'Removed Contract', life: 3000 });
            else
                toast.add({ severity: 'error', summary: 'Error', detail: 'Error on remove data', life: 3000 });
            dialogContract?.value.close();
        } catch (error) { console.error("Error on remove data:", error); }
    }

    async function CreateData() {
        try{
            const res =  await axios.post(import.meta.env.VITE_APP_API_URL + '/Contract', model.value);
            if (res.status == 201)
                toast.add({ severity: 'info', summary: 'Created', detail: 'New Contract', life: 3000 });
            else
                toast.add({ severity: 'error', summary: 'Error', detail: 'Error on save data', life: 3000 });
            dialogContract?.value.close();
        } catch (error) { console.error("Error on save data:", error); }
    }


    async function Save(){
        if (isNew.value) 
            await CreateData();
        else if (toDelete.value)
            await DeleteData();
        else
            await UpdateData();
    }

    async function Cancel(){
        dialogContract?.value.close();
    }
</script>
<template>
    <InputGroup class="boxData">
        <IftaLabel v-if="!isNew">
            <InputNumber id="id" v-model="model.id" disabled/>
            <label for="id">Id</label>
        </IftaLabel>
    </InputGroup>
    <InputGroup class="boxData">
        <IftaLabel v-if="!isNew" >
            <InputText id="author" v-model="model.author" disabled />
            <label for="author">Author</label>
        </IftaLabel>
    </InputGroup>
    <InputGroup class="boxData">
        <IftaLabel>
            <InputText id="name" v-model="model.name" :disabled="toDelete"  />
            <label for="name">Name</label>
        </IftaLabel>
    </InputGroup>
    <InputGroup class="boxData">
        <IftaLabel>
            <Textarea id="description" v-model="model.description" style="min-width: 400px;min-height: 250px;" :disabled="toDelete" />
            <label for="description">Description</label>
        </IftaLabel>
    </InputGroup>
    <InputGroup class="boxData">
        <IftaLabel v-if="!isNew">
            <InputText id="createDate" v-model="model.createdDate" disabled />
            <label for="createDate">Created Date</label>
        </IftaLabel>
    </InputGroup>
    <InputGroup class="boxData">
        <IftaLabel v-if="!isNew">
            <InputText id="updateDate" v-model="model.updatedDate" disabled />
            <label for="updateDate">Updated Date</label>
        </IftaLabel>
    </InputGroup>
    <div class="boxButton">
        <Button class="btn" label="Cancel" severity="danger" v-on:click="Cancel"></Button>
        <Button class="btn" label="Save" severity="success" v-on:click="Save"></Button>
    </div>
    <Toast />
</template>

<style scoped>
.boxData{
    padding: 7px
}
.boxButton{
    display:flex;
    flex-direction: row;
    justify-content: space-between;
    .btn {
        min-width: 5rem;
    }
}
</style>