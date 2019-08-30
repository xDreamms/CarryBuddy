<template>
  <v-container>
    <v-layout row wrap>
      <v-flex xs12 sm12 md6 v-for="(valu,index) in rawList" :key="index">
        <addon-viewer
          :desc="valu.scriptDesc"
          :title="valu.scriptName"
          :author="valu.authorName"
          :champName="valu.champName"
          :skinNumber="valu.champSkin"
          :rec="valu.recommend"
        />
      </v-flex>
    </v-layout>
    <template v-if="overlay">
      <Spinner/>
    </template>
  </v-container>
</template>



<script>
import Spinner from "../components/LoadingSpinner.vue";
import AddonViewer from "../components/AddonViewer.vue";
export default {
  components: {
    Spinner,
    AddonViewer
  },
  data() {
    return {
      rawList: {},
      overlay: false
    };
  },
  created() {
    this.overlay = true;
    this.$http
      .get(
        `http://ec2-13-209-69-152.ap-northeast-2.compute.amazonaws.com:3000/api/addons/top`
      )
      .then(result => {
        this.rawList = result.data;
        this.overlay = false;
      });
  }
};
</script>
