<template>
  <v-app>
    <v-toolbar app dark height="64" :class="viewpt">
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

    <v-content :class="viewpt">
      <router-view/>
    </v-content>
    <v-footer dark :class="viewpt">
      <v-card class="flex" flat tile>
        <v-card-actions class="font-weight-light justify-center">
          Logged With&nbsp;
          <strong>{{uid}}</strong>
          <span v-if="uid !== 'Guest'" class="ml-3" @click="lgout">[Logout]</span>
        </v-card-actions>
      </v-card>
    </v-footer>
  </v-app>
</template>
<style>
::-webkit-scrollbar {
  display: none;
}
.c_big {
  zoom: 125%;
}
.c_def {
  zoom: 100%;
}
</style>

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
  mounted() {
    var em = this.$cookie.get("nMAIL");
    console.log(em);
    if (em) this.uid = em;
    if (window.devicePixelRatio === 1) {
      this.viewpt = "c_big";
      //console.log("RUNNIN DESKTOP, 1% VP => Auto Zooming (1.25x)");
    } else {
      this.viewpt = "c_def";
      //console.log( "RUNNIN LAPTOP OR MOBILE, " + window.devicePixelRatio + "% VP" );
    }
  },
  methods: {
    lgout() {
      this.$cookie.delete("nMAIL");
      this.$cookie.delete("nSESSID");
      this.$router.go(0);
    }
  },
  data() {
    return {
      uid: "Guest",
      viewpt: "c_def",
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
          name: "Champions",
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
