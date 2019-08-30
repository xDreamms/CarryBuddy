<template>
  <v-app>
    <v-toolbar app dark height="64">
      <v-toolbar-title class="headline font-weight-light">
        <span class="hidden-md-and-up">{{title}} DB</span>
        <span class="hidden-sm-and-down" style="over">{{title}} Addon Database</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <template v-if="$vuetify.breakpoint.mdAndUp">
        <v-btn
          active-class="slBtn"
          v-for="(nl, index) in navLists"
          :key="index"
          :to="nl.hLink"
          class="mdBtn overflow-hidden"
          flat
          :ripple="false"
        >
          <span class="mr-2 text-none">{{nl.name}}</span>
        </v-btn>
      </template>
      <template v-else>
        <v-btn icon>
          <v-icon>menu</v-icon>
        </v-btn>
      </template>
    </v-toolbar>

    <v-content>
      <router-view/>
    </v-content>
  </v-app>
</template>
<style scoped>
.mdBtn {
  height: 100%;
  margin: 0px;
  transition: none;
  color: rgb(122, 122, 122);
}
.mdBtn::before {
  opacity: 0.01;
}
.slBtn {
  text-shadow: 0 0 7px;
  color: #fff;
}
</style>

<script>
export default {
  components: {},
  data() {
    return {
      title: "CarryBuddy",
      navLists: [
        {
          name: "Top Addons",
          hLink: "/top"
        },
        {
          name: "Official Addons",
          hLink: "/official"
        },
        {
          name: "Champion",
          hLink: "/champions"
        },
        {
          name: "Utility",
          hLink: "/util"
        },
        {
          name: "Visual",
          hLink: "visual"
        },
        {
          name: "Submit",
          hLink: "submit"
        }
      ]
    };
  }
};
</script>
