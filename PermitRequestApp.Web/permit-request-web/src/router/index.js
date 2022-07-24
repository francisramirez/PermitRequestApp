import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import PermitList from '@/components/permits/List.vue'
import CreateOrEdit from '@/components/permits/CreateOrEdit.vue'

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/Permits",
        name: "PermitList",
        component: PermitList,
    },
    {
        path: "/Permits/create",
        name: "Create",
        component: CreateOrEdit,
    },
    {
        path: "/Permits/:id/edit",
        name: "Edit",
        component: CreateOrEdit,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;