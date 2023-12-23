<script>
import VLoading from "@/components/v-loading.vue";

export default {
  name: 'v-new-project',
  components: {VLoading},
  data(){
    return{
      technologies: [],
      loading: true,

      form:{
        title: '',
        dbName: '',
        dbUser: 'root',
        dbPassword: '<password>',
        technologyId: null,
      }
    }
  },
  mounted() {
    this.loading=true;
    this.$store.dispatch("technology/GET", ``).then(data => {
      this.technologies = data.data;
    }).finally(() => this.loading = false)
  },
  methods:{
    create(){
      this.loading=true;
      this.$store.dispatch("project/POST", this.form).finally(() => {
        location.reload()
      })
    },
  }
}
</script>

<template>

  <v-card>

    <v-card-title>
      Project Form
    </v-card-title>
    <v-card-text>
      <!-- Your form goes here -->
      <v-form>
        <v-text-field v-model="form.title" label="Title" class="mb-3"></v-text-field>
        <v-text-field v-model="form.dbName" label="db name" class="mb-3"></v-text-field>
        <v-text-field v-model="form.dbUser" label="db user" class="mb-3"></v-text-field>
        <v-text-field v-model="form.dbPassword" label="db password" class="mb-3"></v-text-field>
        <v-select
            v-model="form.technologyId"
            :items="technologies"
            label="Select an Item"
            item-value="id"
            item-text="title"
        ></v-select>


        <div class="d-flex g-gap-1 mt-2">
          <v-btn @click="create" color="primary">Submit</v-btn>
          <v-btn @click="this.$emit('close')">Close</v-btn>
        </div>
      </v-form>
    </v-card-text>

    <v-loading v-if="this.loading"/>
  </v-card>



</template>

<style scoped>

</style>