<script>
  import VNewCrudStatic from "@/components/technology/v-new-crud-static.vue";
  import VFileEdit from "@/components/File/v-file-edit.vue";
  import VLoading from "@/components/v-loading.vue";

  export default {
    components: {VLoading, VFileEdit, VNewCrudStatic},
    data(){
      return{
        fileEdit: null,
        fileBlockShowId: null,
        crudStaticForm: false,
        technology: null,
        crudStatics: [],
        loading: false,
      }
    },
    mounted() {
      this.loading = true;
      this.$store.dispatch("technology/GET", this.$route.query.id).then(data => {
        this.technology = data.data

        this.$store.dispatch("crudStatic/GET", `?technologyId=${this.technology.id}`).then(data => {
          this.crudStatics = data.data
          console.log(data.data)
        })
      }).finally(() => this.loading = false)
    },
    methods: {
      delete(){
        this.loading = true;
        this.$store.dispatch('technology/DELETE', this.$route.query.id).finally(() => {
          location.href = '/technologies';
        })
      },
      fileDelete(fileId){
        this.loading = true;
        this.$store.dispatch('file/DELETE', fileId).finally(() => {
          location.reload();
        })
      },
      removeCrudStatic(crudStaticId){
        this.loading = true;
        this.$store.dispatch('crudStatic/DELETE', crudStaticId).finally(() => {
          location.reload();
        })
      }
    }
  }
</script>

<template>
  <div v-if="this.technology">
    <div class="d-flex a-items-flex-start g-gap-_3 w-max j-content-space-between">
      <div class="w-max-content">
        <h1>{{this.technology.title}}</h1>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DynamicTitle</span> - {{this.technology.dynamicTitle}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DynamicDbName</span> - {{this.technology.dynamicDbName}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DynamicDbUser</span> - {{this.technology.dynamicDbUser}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DynamicDbPassword</span> - {{this.technology.dynamicDbPassword}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DynamicSession</span> - {{this.technology.dynamicSession}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DynamicPort</span> - {{this.technology.dynamicPort}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">RunDevCommandLine</span> - {{this.technology.runDevCommandLine}}</p>
        <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">StopDevCommandLine</span> - {{this.technology.stopDevCommandLine}}</p>
      </div>
      <div class="d-flex a-items-center g-gap-1">
        <v-btn @click="this.delete"><v-icon color="red-darken-4" size="22" class="c-pointer">mdi-delete</v-icon> Remove</v-btn>
        <v-btn @click="this.crudStaticForm=true;"><v-icon color="blue-darken-4" size="22" class="c-pointer">mdi-plus</v-icon> Crud Static</v-btn>
      </div>
    </div>
    <v-new-crud-static v-if="crudStaticForm" @close="crudStaticForm=false;" class="mt-8" :technology="this.technology"/>

    <v-card-title class="mt-8">
      Technology Files

    </v-card-title>
    <v-card v-for="file in technology.files" class="mt-5">
      <div class="padding-1 d-flex j-content-space-between ">
        <h4 class="c-pointer" @click="this.fileBlockShowId = this.fileBlockShowId === file.id ? false : file.id">
          <v-icon size="18">{{this.fileBlockShowId === file.id ? 'mdi-arrow-up' : 'mdi-arrow-down'}}</v-icon>
          {{file.fileName}}
        </h4>
        <div class="d-flex g-gap-_5" v-if="this.fileBlockShowId === file.id">
          <v-btn @click="this.fileEdit=file"  size="" class="f-size-very-small padding-1">
            <v-icon size="15" color="blue-darken-4">mdi-square-edit-outline</v-icon>
            Edit
          </v-btn>
          <v-btn @click="fileDelete(file.id)" size="" class="f-size-very-small padding-1">
            <v-icon size="15" color="red-darken-4">mdi-trash-can</v-icon>
            Remove
          </v-btn>
        </div>
      </div>
      <v-card-item class="animation-from-hidden" v-if="fileBlockShowId === file.id">
        <div class="f-size-small"><span class="f-weight-bold">Path</span> - {{file.path}}</div>
        <div class="f-size-small"><span class="f-weight-bold">Filename</span> - {{file.fileName}}</div>
        <div class="f-size-small"><span class="f-weight-bold">CommandLine</span> - {{file.commandLine}}</div>
        <div class="f-size-small"><span class="f-weight-bold">DynamicManyLineStart</span> - {{file.dynamicManyLineStart}}</div>
        <div class="f-size-small"><span class="f-weight-bold">DynamicLine</span> - {{file.dynamicLine}}</div>
        <div class="f-size-small"><span class="f-weight-bold">Text</span> - {{file.text}}</div>
      </v-card-item>
    </v-card>

    <v-card-title class="mt-8">Static Crud Files</v-card-title>
    <div v-for="crudStatic in crudStatics" class="mt-5 padding-1">
      <div class="d-flex j-content-space-between padding-1 pb-0">
        <h4>{{crudStatic.title}}</h4>
        <div class="d-flex g-gap-_5">
          <v-btn  @click="removeCrudStatic(crudStatic.id)">
            <v-icon size="15" color="red-darken-4">mdi-trash-can</v-icon>
            Remove
          </v-btn>
        </div>
      </div>
      <v-card-item class="pt-0">
        <div class="f-size-very-small"><span class="f-weight-bold">Title</span> - {{crudStatic.title}}</div>
        <div class="f-size-very-small"><span class="f-weight-bold">DynamicTitle</span> - {{crudStatic.dynamicTitle}}</div>
        <div class="f-size-very-small"><span class="f-weight-bold">DynamicFieldTitle</span> - {{crudStatic.dynamicFieldTitle}}</div>
        <div class="f-size-very-small"><span class="f-weight-bold">DynamicFieldType</span> - {{crudStatic.dynamicFieldType}}</div>
      </v-card-item>

      <v-card v-for="file in crudStatic.files" class="mt-4">
        <div class="padding-1 d-flex j-content-space-between ">
          <h4 class="c-pointer" @click="this.fileBlockShowId = this.fileBlockShowId === file.id ? false : file.id">
            <v-icon size="18">{{this.fileBlockShowId === file.id ? 'mdi-arrow-up' : 'mdi-arrow-down'}}</v-icon>
            {{file.fileName}}
          </h4>
          <div class="d-flex g-gap-_5" v-if="fileBlockShowId === file.id">
            <v-btn @click="this.fileEdit=file" size="" class="f-size-very-small padding-1">
              <v-icon size="15" color="blue-darken-4">mdi-square-edit-outline</v-icon>
              Edit
            </v-btn>
            <v-btn @click="fileDelete(file.id)" size="" class="f-size-very-small padding-1">
              <v-icon size="15" color="red-darken-4">mdi-trash-can</v-icon>
              Remove
            </v-btn>
          </div>
        </div>
        <v-card-item  v-if="fileBlockShowId === file.id">
          <div class="f-size-small"><span class="f-weight-bold">Path</span> - {{file.path}}</div>
          <div class="f-size-small"><span class="f-weight-bold">Filename</span> - {{file.fileName}}</div>
          <div class="f-size-small"><span class="f-weight-bold">CommandLine</span> - {{file.commandLine}}</div>
          <div class="f-size-small"><span class="f-weight-bold">Text</span> - {{file.text}}</div>
        </v-card-item>
      </v-card>
    </div>
  </div>

  <v-loading v-if="loading"/>
  <v-file-edit :file="fileEdit" v-if="fileEdit" @close="fileEdit=null;"/>
</template>

<style scoped>

</style>