<template>
  <v-container fluid grid-list-md>
    <v-layout row wrap class="lxContainer">
      <v-flex lg3 md4 sm6 xs12 v-for="(i,index) in champList" :key="index">
        <!--
        <v-card class="ma-2" >
          <v-img
            class="white--text" 
            :src="`http://ddragon.leagueoflegends.com/cdn/img/champion/splash/${i}_${skinCode}.jpg`"
          >
            <v-card-title class="align-top" style="font-size: 21px; text-shadow: -1px -1px 0 #000,  1px -1px 0 #000, -1px 1px 0 #000,1px 1px 0 #000;">{{i}}</v-card-title>
          </v-img>      
           
        </v-card>
        -->
        <div class="panels">
          <div class="panel">
            <div
              class="background"
              :style="`background-image: url(http://ddragon.leagueoflegends.com/cdn/img/champion/splash/${i}_${skinCode}.jpg);`"
            ></div>
            <div class="text">
              <div class="xtitle">
                {{i}}
                <!-- <span class="location">{{rawList[i].title}}</span> -->
              </div>
              <div class="author">0 Addons</div>
              <a class="link" target="_blank" rel="noreferrer">View Lists</a>
            </div>
          </div>
        </div>
      </v-flex>
    </v-layout>
    <v-overlay :value="overlay">
      <v-progress-circular indeterminate size="64"></v-progress-circular>
    </v-overlay>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      version: "9.9.1",
      champList: {},
      rawList: [],
      skinCode: 0,
      overlay: false
    };
  },
  mounted() {
    this.overlay = true;
    this.$http
      .get(
        `https://ddragon.leagueoflegends.com/cdn/${
          this.version
        }/data/en_US/champion.json`
      )
      .then(result => {
        this.rawList = result.data.data;
        this.champList = Object.keys(result.data.data);
        this.overlay = false;
      });
  }
};
</script>

<style scoped>
.lxContainer {
  padding-left: 8%;
  padding-right: 8%;
}

a {
  color: inherit;
  text-decoration: none;
}

.panels {
  display: flex;
  flex-wrap: nowrap;
}
.xtitle {
  text-shadow: -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000,
    1px 1px 0 #000;
}
.author {
  text-shadow: -1px -1px 0 #000, 1px -1px 0 #000, -1px 1px 0 #000,
    1px 1px 0 #000;
}
.panels .panel {
  color: white;
  width: 100%;
  height: 200px;
  outline: 0.25em solid rgba(26, 97, 203, 0);
  transition: 500ms;
  position: relative;
  margin: 7px;
}
.panels .panel .background:after,
.panels .panel .text > * {
  transition: opacity 200ms, -webkit-transform 200ms;
  transition: transform 200ms, opacity 200ms;
  transition: transform 200ms, opacity 200ms, -webkit-transform 200ms;
}
.panels .panel .background {
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
  transition: 100ms;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
}
.panels .panel .background:before,
.panels .panel .background:after {
  content: "";
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
}
.panels .panel .background:before {
  opacity: 0;
}
.panels .panel .background:after {
  opacity: 0.4;
  background: linear-gradient(
    to bottom,
    rgba(0, 0, 0, 0) 20%,
    rgba(23, 86, 181, 0.6) 70%,
    #04152f 100%
  );
}
.panels .panel .text {
  cursor: default;
  position: absolute;
  left: 1em;
  right: 1em;
  bottom: -2.5em;
}
.panels .panel .text .location {
  font-weight: 100;
  font-size: 0.5em;
  margin-bottom: 1em;
}
.panels .panel .text .xtitle {
  font-weight: 700;
  font-size: 1.8em;
  margin-bottom: 0.5em;
}
.panels .panel .text .author {
  font-weight: 400;
  font-size: 1.1em;
  margin-bottom: 1em;
  text-align: right;
}
.panels .panel .text .link {
  display: inline-block;
  padding: 0.5em;
  width: 100%;
  background: #1a61cb;
  text-align: center;
  opacity: 0;
}
.panels .panel.hover,
.panels .panel:hover {
  outline: 0.875em solid #1a61cb;
  transition: 300ms;
}
.panels .panel.hover .background,
.panels .panel:hover .background {
  transition: 125ms;
  top: -0.5em;
  left: -0.5em;
  right: -0.5em;
  bottom: -0.5em;
}
.panels .panel.hover .background:after,
.panels .panel:hover .background:after {
  opacity: 1;
}
.panels .panel.hover .text > *,
.panels .panel:hover .text > * {
  -webkit-transform: translate3d(0, -3.5rem, 0);
  transform: translate3d(0, -3.5rem, 0);
}
.panels .panel.hover .text .location,
.panels .panel:hover .text .location {
  transition-delay: 0ms;
}
.panels .panel.hover .text .xtitle,
.panels .panel:hover .text .xtitle {
  transition-delay: 60ms;
}
.panels .panel.hover .text .author,
.panels .panel:hover .text .author {
  transition-delay: 110ms;
}
.panels .panel.hover .text .link,
.panels .panel:hover .text .link {
  opacity: 1;
  transition-delay: 150ms;
}
</style>