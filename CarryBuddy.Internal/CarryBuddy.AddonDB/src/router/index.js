const routers = [
  {
    path: "/",
    meta: {
      title: "CarryBuddy Addon DB"
    },
    component: resolve => require(["../views/Main.vue"], resolve)
  },
  {
    path: "/official",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Official.vue"], resolve)
  },
  {
    path: "/top",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Top.vue"], resolve)
  },
  {
    path: "/visual",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Visual.vue"], resolve)
  },
  {
    path: "/utility",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Utility.vue"], resolve)
  },
  {
    path: "/champions",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Champions.vue"], resolve)
  },
  {
    path: "/submit",
    meta: {
      title: ""
    },
    component: resolve => require(["../views/Submit.vue"], resolve)
  }
];
export default routers;
