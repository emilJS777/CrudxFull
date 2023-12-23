<script>
  import VNewCrud from "@/components/project/v-new-crud.vue";
  import VLoading from "@/components/v-loading.vue";

  export default {
    components: {VLoading, VNewCrud},
    data(){
      return{
        cruds: [],
        crudForm: false,
        project: null,
        loading: false,
        fileBlockShowId: null,
      }
    },
    mounted() {
      this.loading = true;
      this.$store.dispatch("project/GET", this.$route.query.id).then(data => {
        this.project = data.data;
      })

      this.$store.dispatch("crud/GET", `?projectId=${this.$route.query.id}`).then(data => {
        this.cruds = data.data;
      }).finally(() => this.loading = false)
    },
    methods: {
      delete(){
        this.loading = true;
        this.$store.dispatch('project/DELETE', this.$route.query.id).finally(() => {
          location.href = '/projects';
        })
      },
      deleteCrud(crudId){
        this.loading = true;
        this.$store.dispatch('crud/DELETE', crudId).finally(() => {
          location.reload();
        })
      },
      onLaunch(){
        this.$store.dispatch("project/PATCH", `?projectId=${this.project.id}`).then(data => {
          if(data.status == 200)
            this.project.launched = data.data;
        })
      }
    },

  }
</script>

<template>
  <div v-if="this.project">
    <div class="d-grid a-items-center">
      <div class="d-flex a-items-center g-gap-_3 w-max j-content-space-between">
        <div>
          <h1>{{this.project.title}} Details</h1>
          <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">Technology</span> - {{this.project.technology.title}}</p>

          <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">Port</span> - {{this.project.port}}</p>
          <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">Session</span> - {{this.project.session}}</p>

          <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DbName</span> - {{this.project.dbName}}</p>
          <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DbUser</span> - {{this.project.dbUser}}</p>
          <p class="f-size-very-small font-weight-light"><span class="f-weight-bold">DbPassword</span> - {{this.project.dbPassword}}</p>
        </div>
        <div class="d-flex a-items-center g-gap-1">'
          <v-btn @click="onLaunch" v-if="this.project.launched"><v-icon size="22" color="red">mdi-stop-circle</v-icon> Stop</v-btn>
          <v-btn @click="onLaunch" v-else><v-icon size="22" color="green">mdi-play-circle</v-icon> Run</v-btn>
          <v-btn @click="this.crudForm=true;"><v-icon color="blue-darken-4" size="22" class="c-pointer">mdi-plus</v-icon> Crud</v-btn>
          <v-btn @click="this.delete" v-if="!this.project.launched"><v-icon color="red-darken-4" size="22" class="c-pointer">mdi-delete</v-icon> Remove</v-btn>
        </div>
      </div>
    </div>
    <v-new-crud v-if="crudForm" :projectId="this.$route.query.id" :technologyId="this.project.technologyId" @close="this.crudForm=false;" class="mt-8"/>

    <v-card-title class="mt-8">Crud Files</v-card-title>
    <v-card v-for="crud in cruds" class="mt-5">
      <div class="d-flex j-content-space-between padding-1">
        <div class="c-pointer a-items-center d-flex g-gap-_3" @click="fileBlockShowId = fileBlockShowId === crud.id ? false : crud.id">
          <v-icon size="18">{{this.fileBlockShowId === crud.id ? 'mdi-arrow-up' : 'mdi-arrow-down'}}</v-icon>
          <div><span class="f-weight-bold">{{crud.crudStatic.title}}</span></div>
          <div>{{crud.title}}</div>
        </div>
        <div class="d-flex g-gap-_5 h-max-content" v-if="fileBlockShowId === crud.id">
          <v-btn @click="deleteCrud(crud.id)" size="" class="f-size-very-small padding-1">
            <v-icon size="15" color="red-darken-4">mdi-trash-can</v-icon>
            Remove
          </v-btn>
        </div>
      </div>
      <v-card v-if="fileBlockShowId === crud.id" class="animation-from-hidden">
        <v-card-item v-for="file in crud.files">
          <div>Path - {{file.path}}</div>
          <div>Filename - {{file.fileName}}</div>
          <div>CommandLine - {{file.commandLine}}</div>
          <div>Text - {{file.text}}</div>
        </v-card-item>
      </v-card>
    </v-card>
  </div>

  <v-loading v-if="this.loading"/>
</template>

<style scoped>

</style>