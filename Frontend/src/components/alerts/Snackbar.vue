<!-- eslint-disable vue/multi-word-component-names -->
<script>
export default {
    props: {
        modelValue: {
            type: Boolean,
            required: true
        },
        message: {
            type: String,
            required: true
        },
        color: {
            type: String,
            required: true
        },
        timeout: {
            type: Number,
            required: false,
            default: 3000
        },
        location: {
            type: String,
            required: false,
            default: 'top'
        }
    },
    emits: ['update:modelValue'],
    computed: {
        show: {
            get() {
                return this.modelValue;
            },
            set(value) {
                this.$emit('update:modelValue', value);
            }
        },
    }
}
</script>

<template>
    <v-snackbar v-model="show" :color="color" elevation="24" actions="close" :timeout="timeout" timer>
        {{ message }}
        <template v-slot:actions>
            <v-btn @click="$emit('update:modelValue', false)" variant="tonal" size="x-small" class="me-2">
                Dismiss <v-icon>mdi-close</v-icon>
            </v-btn>
        </template>
    </v-snackbar>
</template>
