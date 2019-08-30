const routers = [
  {
    path: "/",
    meta: {
      title: "CarryBuddy Addon DB"
    },
    component: resolve => require(["../views/Main.vue"], resolve)
  },
  {
    path: "/list",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Main.vue"], resolve)
  },
  {
    path: "/champions",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Champions.vue"], resolve)
  }
];
export default routers;
