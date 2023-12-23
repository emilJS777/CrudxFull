<script>

import VLoading from "@/components/v-loading.vue";

export default {
  name: 'v-new-crud-static',
  components: {VLoading},
  props: ['technology'],
  data(){
    return{
      form:{
        title: '',
        dynamicTitle: '',
        dynamicFieldTitle: '',
        dynamicFieldType: '',
        fieldTypes: [],
        files: [],
        technologyId: 0,
        loading: false,
      }
    }
  },
  mounted() {
    this.form.technologyId = this.technology.id;
  },
  methods:{
    create(){
      this.loading = true;
      this.$store.dispatch("crudStatic/POST", this.form).finally(() => {
        location.reload()
      })
    },
    addFile(){
      let newFile = {
        path: '/',
        fileName: '',
        commandLine: '',
        text: '',
      }
      this.form.files.push(newFile);
    },
    removeFile(){
      this.form.files.splice(this.form.files.length-1, 1);
    },
    addFieldType(){
      let newFieldType = {
        title: "",
        type: "",
      }
      this.form.fieldTypes.push(newFieldType);
    },
    removeFieldType(){
      this.form.fieldTypes.splice(this.form.fieldTypes.length-1, 1);
    }
  }
}
</script>

<template>
  <v-card>
    <v-card-title>
      Crud Static Form
    </v-card-title>
    <v-card-text>
      <!-- Your form goes here -->
      <v-form>
        <v-text-field v-model="form.title" label="Title" class="mb-3"></v-text-field>
        <v-text-field v-model="form.dynamicTitle" label="DynamicTitle" class="mb-3"></v-text-field>
        <v-text-field v-model="form.dynamicFieldTitle" label="DynamicFiledTitle" class="mb-3"></v-text-field>
        <v-text-field v-model="form.dynamicFieldType" label="DynamicFieldType" class="mb-3"></v-text-field>
        <!--          <v-text-field v-model="form.email" label="Email"></v-text-field>-->
        <div v-for="(file, index) in form.files" class="mt-5">
          <span>file {{index+1}}</span>
          <v-text-field v-model="form.files[index].path" label="Path"></v-text-field>
          <v-text-field v-model="form.files[index].fileName" label="FileName"></v-text-field>
          <v-text-field v-model="form.files[index].commandLine" label="CommandLine"></v-text-field>
          <v-textarea v-model="form.files[index].text" label="Text"></v-textarea>
        </div>

        <div v-for="(field, index) in form.fieldTypes" class="mt-5">
          <span>field type {{index+1}}</span>
          <v-text-field v-model="form.fieldTypes[index].title" label="Title"></v-text-field>
          <v-text-field v-model="form.fieldTypes[index].type" label="Type"></v-text-field>
        </div>


        <div class="d-flex g-gap-1 mt-2">
          <v-btn @click="create" color="primary">Submit</v-btn>
          <v-btn @click="this.$emit('close')">Close</v-btn>

          <v-btn @click="this.addFieldType">
            <v-icon>mdi-plus</v-icon>
            Add Field
          </v-btn>
          <v-btn @click="this.removeFieldType" v-if="form.fieldTypes.length > 0">
            <v-icon>mdi-minus</v-icon>
            Remove Field
          </v-btn>

          <v-btn @click="this.addFile">
            <v-icon>mdi-plus</v-icon>
            Add File
          </v-btn>
          <v-btn @click="this.removeFile" v-if="form.files.length > 0">
            <v-icon>mdi-minus</v-icon>
            Remove File
          </v-btn>
        </div>
      </v-form>
    </v-card-text>
  </v-card>

  <v-loading v-if="this.loading"/>
</template>

<style scoped>

</style>