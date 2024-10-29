<template>
  <v-footer app elevation="2">
    <v-row justify="center" no-gutters>
      <v-btn v-for="link in links" :key="link.text" :href="link.href" text class="mx-2">{{ link.text }}</v-btn>

      <v-col cols="12" class="text-center mt-4">
        {{ new Date().getFullYear() }} — <strong>Rodrigo Gallert</strong>
      </v-col>
    </v-row>
  </v-footer>
</template>

<script>
export default {
  data() {
    return {
      links: [
        { text: 'Home', href: '/' },
        { text: 'About', href: '/about' },
        { text: 'Contact', href: '/contact' }
      ]
    }
  }
}
</script>
