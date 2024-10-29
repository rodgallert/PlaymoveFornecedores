<script setup>
import { useDisplay } from 'vuetify';
import { deleteSupplier } from '@/services/SuppliersServices';
</script>

<script>
export default {
  data() {
    return {
      displayName: useDisplay().name,
      isLoading: false,
      snackbarOptions: {
        isShowing: false,
        message: '',
        color: 'success',
      }
    }
  },
  props: {
    modelValue: {
      type: Boolean,
      required: true
    },
    supplier: {
      type: Object,
      default: () => ({
        name: '',
        taxIdentificationNumber: '',
        phone: '',
        email: '',
        address: ''
      })
    }
  },
  computed: {
    show: {
      get() {
        return this.modelValue
      },
      set(value) {
        this.$emit('update:modelValue', value)
      }
    },
    width() {
      switch (this.displayName) {
        case 'xs':
          return '100%';
        case 'sm':
          return '50%';
        case 'md':
          return '50%';
        case 'lg':
          return '50%';
        case 'xxl':
          return '25%';
        default:
          return '50%'
      }
    }
  },
  methods: {
    async confirmDelete() {
      try {
        this.isLoading = true;
        await deleteSupplier(this.supplier);

        this.snackbarOptions.isShowing = true;
        this.snackbarOptions.message = 'Fornecedor excluído com sucesso';
        this.show = false;
      } catch (error) {
        console.error(error);
        this.snackbarOptions.isShowing = true;
        this.snackbarOptions.message = 'Ocorreu um erro ao excluir o fornecedor';
        this.snackbarOptions.color = 'error';
      } finally {
        this.isLoading = false;
      }
    }
  }
}
</script>

<template>
  <v-dialog v-model="show" :width="width">
    <v-card :loading="isLoading">
      <v-card-title>
        <span class="headline">Confirmar exclusao</span>
      </v-card-title>
      <v-card-text>
        <span>Tem certeza que deseja excluir o fornecedor <strong>{{ supplier.name }}</strong> CNPJ {{
          supplier.taxIdentificationNumber }}?</span>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="red" @click="confirmDelete" :disabled="isLoading">Excluir</v-btn>
        <v-btn text @click="show = false" :disabled="isLoading">Cancelar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <Snackbar v-model="snackbarOptions.isShowing" :message="snackbarOptions.message" :color="snackbarOptions.color" />
</template>
