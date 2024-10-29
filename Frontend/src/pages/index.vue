<!-- eslint-disable vue/multi-word-component-names -->
<script setup>
import SupplierModal from '@/components/modals/SupplierModal.vue';
import DeleteSupplierModal from '@/components/modals/DeleteSupplierModal.vue';
import { getSuppliers, searchSuppliers } from '@/services/SuppliersServices';
</script>

<script>
export default {
  data() {
    return {
      isSuplierModalOpen: false,
      isDeleteSupplierModalOpen: false,
      selectedSupplier: null,
      isLoading: false,
      suppliers: [],
      headers: [
        { title: 'Nome', align: 'start', sortable: true, key: 'name' },
        { title: 'CNPJ', align: 'start', sortable: false, key: 'taxIdentificationNumber' },
        { title: 'Telefone', align: 'start', sortable: false, key: 'phone' },
        { title: 'Email', align: 'start', sortable: false, key: 'email' },
        { title: 'Endereco', align: 'start', sortable: false, key: 'address' },
        { title: '', align: 'center', sortable: false, key: 'actions' }
      ],
      search: '',
      itemsPerPage: 1,
      page: 1,
      totalItems: 0
    }
  },
  methods: {
    toggleDeleteSupplierModal(supplier, event) {
      this.selectedSupplier = supplier;
      this.isDeleteSupplierModalOpen = event;
    },
    toggleEditSupplierModal(supplier, event) {
      this.isSuplierModalOpen = event;
      this.selectedSupplier = supplier;
    },
    async testFilter() {
      if (this.search === '') {
        await this.loadItems({
          page: this.page,
          itemsPerPage: this.itemsPerPage
        });
        return;
      }
      if (this.search.length < 3) {
        return;
      }

      await this.filterSuppliers();
    },
    async filterSuppliers() {
      this.isLoading = true;

      try {
        const controller = new AbortController();
        const signal = controller.signal;
        const response = await searchSuppliers(this.search, this.page, this.itemsPerPage, signal);

        this.suppliers = response.items;
        this.totalItems = response.totalItems;
      } catch (error) {
        console.error(error)
      } finally {
        this.isLoading = false;
      }
    },
    async loadItems({ page, itemsPerPage }) {
      const response = await getSuppliers(page, itemsPerPage);

      this.suppliers = response.items;
      this.totalItems = response.totalItems;
    }
  },
}
</script>

<template>
  <v-container>
    <v-row>
      <v-col>
        <v-card>
          <v-card-text>
            <v-row>
              <v-col>
                <v-data-table-server :headers="headers" :items="suppliers" :items-length="totalItems"
                  :loading="isLoading" v-model:items-per-page="itemsPerPage" class="elevation-1"
                  no-data-text="Nenhum fornecedor encontrado" hover items-per-page-text="Itens por Pagina"
                  @update:options="loadItems">

                  <template v-slot:top>
                    <v-toolbar flat>
                      <v-toolbar-title>Gestao de Fornecedores</v-toolbar-title>
                      <v-spacer></v-spacer>
                      <v-text-field v-model="search" append-inner-icon="mdi-magnify" label="Pesquisar" single-line
                        hide-details max-width="250" variant="solo" type="text" density="compact"
                        @click:append-inner="testFilter" @update:model-value="testFilter" />
                      <v-btn color="primary" prepend-icon="mdi-plus" variant="flat"
                        @click="toggleEditSupplierModal(null, true)" class="ms-6">Adicionar</v-btn>
                    </v-toolbar>
                  </template>

                  <template v-slot:loading>
                    <v-skeleton-loader type="table-row@5" />
                  </template>

                  <template v-slot:item.actions="{ item }">
                    <v-icon @click="toggleEditSupplierModal(item, true)" class="mr-2">mdi-pencil</v-icon>
                    <v-icon @click="toggleDeleteSupplierModal(item, true)" color="red">mdi-delete</v-icon>
                  </template>
                </v-data-table-server>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>

  <SupplierModal v-model="isSuplierModalOpen" @update:modelValue="loadItems({ page: page, itemsPerPage: pageSize })"
    :supplierId="selectedSupplier?.id" />
  <DeleteSupplierModal v-model="isDeleteSupplierModalOpen" :supplier="selectedSupplier"
    @update:modelValue="loadItems({ page: page, itemsPerPage: pageSize })" />
</template>
