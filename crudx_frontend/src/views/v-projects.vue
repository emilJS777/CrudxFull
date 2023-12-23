<script>
  import VProject from "@/components/project/v-project.vue";
  import VNewProject from "@/components/project/v-new-project.vue";
  import VLoading from "@/components/v-loading.vue";

  export default {
    components: {VLoading, VNewProject, VProject},
    data(){
      return{
        newForm: false,
        projects: [],
        loading: false,
      }
    },
    mounted() {
      this.loading = true;
      this.$store.dispatch("project/GET", '').then(data => {
        this.projects = data.data
      }).finally(() => this.loading = false)
    }
  }
</script>

<template>
  <v-btn @click="newForm=true"><v-icon class="mr-1">mdi-file-plus-outline</v-icon> New Project</v-btn>
  <v-new-project v-if="newForm" @close="newForm=false;" class="mt-8"/>

  <div class="d-grid g-gap-2 cards_block mt-8">
    <v-project v-for="project in this.projects" :project="project"/>
  </div>

  <v-loading v-if="this.loading"/>
</template>

<style scoped>
.cards_block{
  grid-template-columns: 1fr 1fr 1fr;
}
</style>