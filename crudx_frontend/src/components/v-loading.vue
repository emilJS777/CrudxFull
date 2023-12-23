<script>
export default {
  name: 'v-loading',
  data(){
    return{
      dialog: true
    }
  }
}
</script>

<template>
  <div class="text-center p-fixed left-0 top-0 w-max h-max bg-ccc-opacity z-index-max">
    <v-dialog
        v-model="dialog"
        :scrim="false"
        persistent
        width="auto"
    >
      <v-card
          color="primary"
      >
        <v-card-text>
          Please stand by
          <v-progress-linear
              indeterminate
              color="white"
              class="mb-0"
          ></v-progress-linear>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>

<style scoped>

</style>