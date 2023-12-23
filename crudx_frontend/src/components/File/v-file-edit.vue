<script>
import VLoading from "@/components/v-loading.vue";

export default {
  components: {VLoading},
  props: ['file'],
  data(){
    return{
       form: {},
       loading: false,
    }
  },
  mounted() {
    this.form = this.file;
  },
  methods: {
    update(){
      this.loading = true;
      this.$store.dispatch("file/PUT", {form: this.form, id: this.file.id}).then(() => {
        location.reload();
      })
    }
  }
}
</script>

<template>
  <div class="p-fixed d-flex a-items-center j-content-center bg-ccc-opacity top-0 left-0 z-index-max w-max h-max">
    <v-card style="width: 800px;">
      <v-card-title>
        <h4>{{this.file.fileName}} edit</h4>
      </v-card-title>
      <v-card-text>
        <!-- Your form goes here -->
        <v-form>

          <v-text-field v-model="form.path" label="Path" class="mb-3"></v-text-field>
          <v-text-field v-model="form.fileName" label="Filename" class="mb-3"></v-text-field>
          <v-text-field v-model="form.commandLine" label="CommandLine" class="mb-3"></v-text-field>
          <v-text-field v-model="form.dynamicManyLineStart" label="DynamicManyLineStart" class="mb-3"></v-text-field>
          <v-textarea v-model="form.dynamicLine" label="DynamicLine" class="mb-3"></v-textarea>

          <v-textarea v-model="form.text" label="Text" class="mb-3"></v-textarea>

          <div class="d-flex g-gap-1 mt-2">
            <v-btn @click="update" color="primary">Submit</v-btn>
            <v-btn @click="this.$emit('close')">Close</v-btn>
          </div>
        </v-form>
      </v-card-text>
    </v-card>
  </div>

  <v-loading v-if="this.loading"/>
</template>

<style scoped>

</style>