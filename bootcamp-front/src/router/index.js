import Vue from "vue";
import VueRouter from "vue-router";
import CadasterEmployes from "../components/CadasterEmployes.vue";
import EmployesList from "../components/EmployesList.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/cadaster",
    name: "CadasterEmployes",
    component: CadasterEmployes,
  },

  {
    path: "/list",
    name: "EmployesList",
    component: EmployesList,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
