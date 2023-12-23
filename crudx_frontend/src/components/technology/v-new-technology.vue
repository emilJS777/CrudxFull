<script>
  import VLoading from "@/components/v-loading.vue";

  export default {
    components: {VLoading},
    data(){
      return{
        form:{
          title: '',
          dynamicTitle: '',
          dynamicDbName: "",
          dynamicDbUser: "",
          dynamicDbPassword: "",
          dynamicPort: '',
          dynamicSession: '',
          runDevCommandLine: "",
          stopDevCommandLine: '',
          files: [],
          loading: false
        }
      }
    },
    methods:{
      create(){
        this.loading = true;
        this.$store.dispatch("technology/POST", this.form).finally(() => {
          location.reload()
        })
      },
      addFile(){
        let newFile = {
          path: '/',
          fileName: '',
          commandLine: '',
          text: '',
          dynamicManyLineStart: '',
          dynamicLine: '',
        }
        this.form.files.push(newFile);
      },
      removeFile(){
        this.form.files.splice(this.form.files.length-1, 1);
      }
    }
  }
</script>

<template>
    <v-card>
      <v-card-title>
        Technology Form
      </v-card-title>
      <v-card-text>
        <!-- Your form goes here -->
        <v-form>
          <v-text-field v-model="form.title" label="Title" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicTitle" label="dynamic title" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicDbName" label="dynamic db name" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicDbUser" label="dynamic db user" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicDbPassword" label="dynamic db password" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicPort" label="dynamic port" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicSession" label="dynamic session" class="mb-3"></v-text-field>

          <v-text-field v-model="form.runDevCommandLine" label="run dev command line" class="mb-3"></v-text-field>
          <v-text-field v-model="form.stopDevCommandLine" label="stop dev command line" class="mb-3"></v-text-field>

<!--          <v-text-field v-model="form.email" label="Email"></v-text-field>-->
          <div v-for="(file, index) in form.files" class="mt-5">
            <span>file {{index+1}}</span>
            <v-text-field v-model="form.files[index].path" label="Path"></v-text-field>
            <v-text-field v-model="form.files[index].fileName" label="FileName"></v-text-field>
            <v-text-field v-model="form.files[index].commandLine" label="CommandLine"></v-text-field>
            <v-text-field v-model="form.files[index].dynamicManyLineStart" label="dynamic many line start" class="mb-3"></v-text-field>
            <v-textarea v-model="form.files[index].dynamicLine" label="dynamic line" class="mb-3"></v-textarea>
            <v-textarea v-model="form.files[index].text" label="Text"></v-textarea>
          </div>


          <div class="d-flex g-gap-1 mt-2">
            <v-btn @click="create" color="primary">Submit</v-btn>
            <v-btn @click="this.$emit('close')">Close</v-btn>

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