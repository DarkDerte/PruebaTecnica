<script setup lang="ts">
import { Button, useDialog, DataTable, Column, DynamicDialog, useToast } from 'primevue';
import { onMounted, ref } from 'vue';
import { ContractEntity } from '@/entities/ContractEntity';
import axios from 'axios';
import ContractComponent from '@/components/ContractComponent.vue';

const dialogContract = useDialog();

const data = ref(Array());

async function fetchData() {
  try {
        const response = await axios.get(import.meta.env.VITE_APP_API_URL + '/Contract'); 
        if (response.status == 200)
        {
          var res = response.data as Array<ContractEntity>;
          data.value = (res.length > 0) ? res : new Array<ContractEntity>();
        }
        else
          useToast().add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error on fetch data',
            life: 3000
          });
  } catch (error) {
        console.error("Error al obtener datos:", error);
  }
}

async function newContract() {
  dialogContract.open(ContractComponent, {
    props: { header: 'New Contract', modal: true },
    data: { model: new ContractEntity(), isNew: true , toDelete: false},
    onClose: () => { fetchData(); }
  });
}

async function GetContract(id:number) {
  const response = await axios.get(import.meta.env.VITE_APP_API_URL + '/Contract/'+id); 
  if (response.status == 200)
    return response.data as ContractEntity;
  else
    useToast().add({
            severity: 'error',
            summary: 'Error',
            detail: 'Error, no exists this contract',
            life: 3000
          });
    return null;
}

async function editContract(id:number) {
  const res = await GetContract(id);
  if (res)
  {
    dialogContract.open(ContractComponent, {
      props:{ header: 'Edit Contract', modal: true },
      data: { model: res, isNew: false, toDelete: false },
      onClose: () => { fetchData(); }
    });
  }
}

async function deleteContract(id:number) {
  const res = await GetContract(id);
  if (res)
  {
    dialogContract.open(ContractComponent, {
      props:{ header: 'Remove Contract', modal: true },
      data: { model: res, isNew: false, toDelete: true },
      onClose: () => { fetchData(); }
    });
  }
}

onMounted(() => { fetchData() });

</script>

<template>
  <main>
    <DataTable :value="data" tableStyle="min-width: 50rem;" >
      <template #header>
        <div class="headerTable">
            <span>Contracts</span>
            <div>
              <Button icon="pi pi-file-plus" v-on:click="newContract" severity="info" raised rounded></Button>
              <Button icon="pi pi-refresh" v-on:click="fetchData" raised rounded></Button>
            </div>
        </div>
      </template>
      <Column field="id" header="Id"></Column>
      <Column field="author" header="Author"></Column>
      <Column field="name" header="Name"></Column>
      <Column field="createdDate" header="Created"></Column>
      <Column field="updatedDate" header="Last Update"></Column>
      <Column header="Modify">
        <template #body="slotProps">
            <Button icon="pi pi-file-edit" v-on:click="editContract(slotProps.data.id)"></Button>
        </template>
      </Column>
      <Column header="Remove">
        <template #body="slotProps">
            <Button icon="pi pi-trash" severity="danger" v-on:click="deleteContract(slotProps.data.id)"></Button>
        </template>
      </Column>
      <template #footer> In total there are {{ data ? data.length : 0 }} contracts. </template>
    </DataTable>
    <DynamicDialog></DynamicDialog>
  </main>
</template>

<style scoped>

main {
  border-radius: 15px;
  box-shadow: gray 0px 0px 2px;
  max-height: 100%;
}

.headerTable {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  justify-content: space-between;
  gap: .5rem;
  font-weight: bold;

  span {
    font-size: x-large; 
  }

  div {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    justify-content: space-between;
    gap: .5rem;
  }
}

@media (min-width: 1000px) {
 main{
  display: flex;
  align-items: top;
  justify-content: center;
  margin-bottom: 20px;
 }
}
</style>
