<script>
import {da} from "vuetify/locale";

export default {
  props: ['project'],
  methods: {
    onLaunch(){
      this.$store.dispatch("project/PATCH", `?projectId=${this.project.id}`).then(data => {
        if(data.status == 200)
          this.project.launched = data.data;
      })
    }
  }
}
</script>

<template>
  <v-card class=" bg-ccc-opacity-hover">
    <v-card-item>
      <div class="d-flex j-content-space-between">
        <h3 class="c-pointer" @click="this.$router.push('/project?id='+this.project.id)">{{this.project.title}}</h3>
        <v-btn color="red" class="padding-02" size="" @click="onLaunch" v-if="this.project.launched">
          <v-icon size="">mdi-stop-circle</v-icon>
        </v-btn>
        <v-btn color="green" class="padding-02" size="" @click="onLaunch" v-else>
          <v-icon size="">mdi-play-circle</v-icon>
        </v-btn>
      </div>
      <p>Port - {{this.project.port}}</p>
      <p>Session - {{this.project.session}}</p>
    </v-card-item>

  </v-card>
</template>

<style scoped>

</style>