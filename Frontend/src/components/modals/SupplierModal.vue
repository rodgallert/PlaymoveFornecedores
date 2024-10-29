<script setup>
import { useDisplay } from 'vuetify';
import { createSupplier, getSupplier, updateSupplier } from '@/services/SuppliersServices';
</script>

<script>
export default {
  data() {
    return {
      displayName: useDisplay().name,
      isLoading: false,
      supplier: {
        name: '',
        taxIdentificationNumber: '',
        phone: '',
        email: '',
        address: '',
        contacts: []
      },
      fieldValidationRules: {
        required: (value) => !!value || 'Campo obrigatório',
        email: (value) => /.+@.+\..+/.test(value) || 'Email inválido',
        phone: (value) => /^\d{10,11}$/.test(value) || 'Telefone inválido',
        tin: (value) => /^\d{14}$/.test(value) || 'CNPJ inválido'
      },
      isFormValid: this.$refs.form?.validate(),
      isEditingSupplier: false,
    }
  },
  props: {
    modelValue: {
      type: Boolean,
      required: true
    },
    supplierId: {
      type: Number,
      required: false
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
    async handleConfirm() {
      if (this.isEditingSupplier) {
        await this.editSupplier()
      } else {
        await this.addSupplier()
      }
    },
    async addSupplier() {
      this.isLoading = true
      try {
        await createSupplier(this.supplier);
        this.$emit('supplierAdded')
        this.show = false
      } catch (error) {
        console.error(error)
      } finally {
        this.isLoading = false
      }
    },
    async editSupplier() {
      this.isLoading = true;
      try {
        await updateSupplier(this.supplier);
        this.$emit('supplierAdded')
        this.show = false
      } catch (error) {
        console.log(error)
      } finally {
        this.isLoading = false
      }
    }
  },
  watch: {
    supplierId: {
      handler: async function (newValue) {
        if (!newValue) {
          this.isEditingSupplier = false;
          this.supplier = {
            name: '',
            taxIdentificationNumber: '',
            phone: '',
            email: '',
            address: ''
          }
          return
        }

        this.isEditingSupplier = true;
        this.isLoading = true;
        try {
          this.supplier = await getSupplier(newValue);
        } catch (error) {
          console.error(error)
        } finally {
          this.isLoading = false;
        }
      },
      immediate: true
    }
  },
  emits: ['update:modelValue', 'supplierAdded']
}
</script>

<template>
  <v-dialog v-model="show" :width="width">
    <v-card :loading="isLoading">
      <v-card-title>{{ isEditingSupplier ? 'Adicionar' : 'Editar' }} Fornecedor</v-card-title>
      <v-card-text>
        <v-form validate-on="input" v-model="isFormValid">
          <v-row>
            <v-col cols="12">
              <v-text-field v-model="supplier.name" label="Nome" variant="outlined" density="comfortable"
                :disabled="isLoading" :rules="[fieldValidationRules.required]" />
            </v-col>
            <v-col cols="12">
              <v-text-field v-model="supplier.taxIdentificationNumber" label="CNPJ" variant="outlined"
                density="comfortable" type="number" :disabled="isLoading || isEditingSupplier"
                :rules="[fieldValidationRules.required, fieldValidationRules.tin]" hide-spin-buttons />
            </v-col>
            <v-col cols="12">
              <v-text-field v-model="supplier.address" label="Endereço" variant="outlined" density="comfortable"
                :disabled="isLoading" :rules="[fieldValidationRules.required]" />
            </v-col>
            <v-col cols="7">
              <v-text-field v-model="supplier.email" label="Email" type="email" variant="outlined" density="comfortable"
                :disabled="isLoading" :rules="[fieldValidationRules.required]" />
            </v-col>
            <v-col cols="5">
              <v-text-field v-model="supplier.phone" label="Telefone" type="tel" variant="outlined"
                density="comfortable" :disabled="isLoading" v-mask="'(##) #####-####'" :rules="[fieldValidationRules.required]" />
            </v-col>
            <v-col cols="12">
            </v-col>
          </v-row>
        </v-form>
      </v-card-text>
      <v-card-actions>
        <v-btn color="secondary" @click="show = false" class="mb-2">Cancelar</v-btn>
        <v-btn color="primary" @click="handleConfirm" :disabled="isLoading || !isFormValid" variant="flat"
          class="me-4 mb-2">Adicionar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
