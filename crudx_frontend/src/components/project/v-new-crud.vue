<script>
import VLoading from "@/components/v-loading.vue";

export default {
  name: 'v-new-crud',
  components: {VLoading},
  props: ['projectId', 'technologyId'],
  data(){
    return{
      crudStatics: [],
      selectedCrudStatic: null,
      form:{
        title: '',
        fields: [],
        projectId: 0,
        crudStaticId: null,
      },
      loading: false,
    }
  },
  mounted() {
    this.loading=true;
    this.form.projectId = this.projectId;
    this.$store.dispatch("crudStatic/GET", `?technologyId=${this.technologyId}`).then(data => {
      this.crudStatics = data.data;
    }).finally(() => this.loading = false)
  },
  methods:{
    create(){
      this.loading=true;
      this.$store.dispatch("crud/POST", this.form).finally(() => {
        location.reload()
      })
    },
    addField(){
      let newField = {
        title: '',
        fieldTypeId: null,
      }
      this.form.fields.push(newField);
    },
    removeField(){
      this.form.fields.splice(this.form.fields.length-1, 1);
    }
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
        <v-select
            v-model="form.crudStaticId"
            :items="this.crudStatics"
            label="Select an Crud static"
            item-value="id"
            item-text="title"
        ></v-select>

        <div v-for="(field, index) in form.fields" class="mt-5" v-if="form.crudStaticId">
          <span>field {{index+1}}</span>
          <v-text-field v-model="form.fields[index].title" label="Field Title"></v-text-field>

            <v-select v-for="(crudStatic) in crudStatics.filter(c => c.id == form.crudStaticId)"
                v-model="form.fields[index].fieldTypeId"
                :items="crudStatic.fieldTypes"
                label="Select an Field type"
                item-value="id"
                item-text="title"
            ></v-select>
        </div>


        <div class="d-flex g-gap-1 mt-2">
          <v-btn @click="create" color="primary">Submit</v-btn>
          <v-btn @click="this.$emit('close')">Close</v-btn>

          <v-btn @click="this.addField" v-if="form.crudStaticId">
            <v-icon>mdi-plus</v-icon>
            Add Field
          </v-btn>
          <v-btn @click="this.removeField" v-if="form.fields.length > 0">
            <v-icon>mdi-minus</v-icon>
            Remove Field
          </v-btn>
        </div>
      </v-form>
    </v-card-text>
  </v-card>

  <v-loading v-if="this.loading"/>
</template>

<style scoped>

</style>