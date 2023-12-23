import { createRouter, createWebHistory } from "vue-router";

const routes = [
    {
        path: "/technologies",
        name: "technologies",
        component: () => import("@/views/v-technologies.vue"),
        beforeEnter: [],
    },
    {
        path: "/technology",
        name: "technology",
        component: () => import("@/views/v-technology.vue"),
        beforeEnter: [],
    },
    {
        path: "/projects",
        name: "projects",
        component: () => import("@/views/v-projects.vue"),
        beforeEnter: [],
    },
    {
        path: "/project",
        name: "project",
        component: () => import("@/views/v-project.vue"),
        beforeEnter: [],
    },
];
const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router