<script>
export default {
  props: ['technology']
}
</script>

<template>
  <v-card class="c-pointer bg-ccc-opacity-hover" @click="this.$router.push('/technology?id='+this.technology.id)">
    <v-card-item><h4>{{this.technology.title}}</h4></v-card-item>
  </v-card>
</template>

<style scoped>

</style>