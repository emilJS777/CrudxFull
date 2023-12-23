<script>
export default {
  data() {
    return {
      itemsNav: [
        { title: 'Home', icon: 'mdi-home', route: '/' },
        { title: 'Projects', icon: 'mdi-folder', route: '/projects' },
        { title: 'Technologies', icon: 'mdi-file-code', route: '/technologies' },
      ],
    };
  },
  methods: {
    navigate(route) {
      this.$router.push(route);
    },
  },
};
</script>

<template>
  <v-app>
    <v-navigation-drawer color="primary" class="text-h6" app>
      <v-list>
        <v-list-item v-for="(item, index) in itemsNav" :key="index"   @click="navigate(item.route)" link>
          <div class="d-flex g-gap-1 a-items-center">
            <v-icon>{{ item.icon }}</v-icon>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </div>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-container>
      <div class="padding-2">
            <router-view></router-view>
      </div>
    </v-container>
  </v-app>
  <main>
  </main>
</template>

<style src="@/assets/main.css">

</style>
