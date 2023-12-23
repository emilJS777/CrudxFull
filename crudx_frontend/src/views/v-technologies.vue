<script>
import VTechnology from "@/components/technology/v-technology.vue";
import VNewTechnology from "@/components/technology/v-new-technology.vue";
import VLoading from "@/components/v-loading.vue";

export default {
  components: {VLoading, VNewTechnology, VTechnology},
  data() {
    return {
      newForm: false,
      technologies: [],
      loading: false,
    };
  },
  mounted() {
    this.loading = true;
    this.$store.dispatch("technology/GET", '').then(data => {
      this.technologies = data.data
    }).finally(() => this.loading = false)
  }
}
</script>

<template>
  <v-btn @click="newForm=true"><v-icon class="mr-1">mdi-file-plus-outline</v-icon> New Technology</v-btn>

  <v-new-technology v-if="newForm" @close="newForm=false;" class="mt-8"/>

  <div class="d-grid g-gap-2 cards_block mt-8">
    <v-technology v-for="technology in this.technologies" :technology="technology"/>
  </div>

  <v-loading v-if="this.loading"/>
</template>

<style scoped>
.cards_block{
  grid-template-columns: 1fr 1fr 1fr;
}
</style>