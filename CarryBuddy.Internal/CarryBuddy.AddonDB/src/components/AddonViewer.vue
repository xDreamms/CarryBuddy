<template>
  <div class="shav_card card">
    <div
      class="wrapper"
      :style="mSwitch ? stdSl:stdOl"
      @mouseenter="mSwitch = true"
      @mouseleave="mSwitch = false"
    >
      <div class="header">
        <ul class="menu-content">
          <li>
            <v-icon dark>favorite_border</v-icon>
            <span>{{rec}}</span>
          </li>
          <li>
            <v-icon dark>subject</v-icon>
            <span>3</span>
          </li>
        </ul>
      </div>
      <div class="data">
        <div class="content">
          <span class="author">By {{author}}</span>
          <h1 class="title">
            <a href="#">{{title}}</a>
          </h1>
          <p class="text">{{desc}}</p>
          <a href="#" class="button">Installing Script</a>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: {
    champName: String,
    skinNumber: Number,
    author: String,
    desc: String,
    title: String,
    rec: Number
  },
  computed: {
    stdOl: function() {
      return `background: linear-gradient(to bottom left,rgba(0, 0, 0, 0.1),rgba(0, 0, 0, 0.295) 30%,rgba(0, 0, 0, 0.842)),url(http://ddragon.leagueoflegends.com/cdn/img/champion/splash/${
        this.champName
      }_${this.skinNumber}.jpg)center/cover no-repeat;`;
    },
    stdSl: function() {
      return `background: linear-gradient(to bottom left,rgba(0, 0, 0, 0.8),rgba(0, 0, 0, 0.8)),url(http://ddragon.leagueoflegends.com/cdn/img/champion/splash/${
        this.champName
      }_${this.skinNumber}.jpg)center/cover no-repeat;`;
    }
  },
  data() {
    return {
      mSwitch: false
    };
  }
};
</script>


<style scoped>
a {
  text-decoration: none;
}

.card {
  float: left;
  padding: 0 1.7rem;
  width: 100%;
}
.card .menu-content {
  margin: 0;
  padding: 15px;
  list-style-type: none;
}
.card .menu-content::before,
.card .menu-content::after {
  content: "";
  display: table;
}
.card .menu-content::after {
  clear: both;
}
.card .menu-content li {
  display: inline-block;
}
.card .menu-content a {
  color: #fff;
}
.card .menu-content span {
  position: absolute;
  left: 50%;
  top: 0;
  font-size: 10px;
  font-weight: 700;
  -webkit-transform: translate(-50%, 0);
  transform: translate(-50%, 0);
}
.card .wrapper {
  background-color: #fff;
  min-height: 250px;
  position: relative;
  overflow: hidden;
  box-shadow: 0 19px 38px rgba(0, 0, 0, 0.3), 0 15px 12px rgba(0, 0, 0, 0.2);
}

.card .wrapper:hover .data {
  -webkit-transform: translateY(0);
  transform: translateY(0);
}
.card .data {
  position: absolute;
  bottom: 0;
  width: 100%;
  -webkit-transform: translateY(calc(70px + 1em));
  transform: translateY(calc(70px + 1em));
  transition: -webkit-transform 0.3s;
  transition: transform 0.3s;
  transition: transform 0.3s, -webkit-transform 0.3s;
}
.card .data .content {
  padding: 2.3em;
  position: relative;
  z-index: 1;
}
.card .author {
  font-size: 12px;
  font-weight: 300;
}
.card .title {
  margin-top: 10px;
  margin-bottom: 20px;
}
.card .text {
  height: 50px;
  margin: 0;
}

.shav_card .wrapper:hover .menu-content span {
  -webkit-transform: translate(-50%, -15px);
  transform: translate(-50%, -15px);
  opacity: 1;
}
.shav_card .header {
  color: #fff;
  padding: 1em;
}
.shav_card .header::before,
.shav_card .header::after {
  content: "";
  display: table;
}
.shav_card .header::after {
  clear: both;
}
.shav_card .menu-content {
  float: right;
}
.shav_card .menu-content li {
  margin: 0 5px;
  position: relative;
}
.shav_card .menu-content span {
  transition: all 0.3s;
  opacity: 0;
}
.shav_card .data {
  color: #fff;
  -webkit-transform: translateY(calc(70px + 4em));
  transform: translateY(calc(70px + 4em));
}
.shav_card .title a {
  color: #fff;
  font-size: 1.6em;
  font-weight: 100;
}
.shav_card .button {
  display: block;
  width: 100px;
  margin: 2em auto 1em;
  text-align: center;
  font-size: 12px;
  color: #fff;
  line-height: 1;
  position: relative;
  font-weight: 500;
}
.shav_card .button::after {
  content: "\2192";
  opacity: 0;
  position: absolute;
  right: 20;
  top: 50%;
  -webkit-transform: translate(0, -50%);
  transform: translate(50px, -50%);
  transition: all 0.3s;
}
.shav_card .button:hover::after {
  -webkit-transform: translate(5px, -50%);
  transform: translate(5px, -50%);
  opacity: 1;
}
.shav_card {
  margin-bottom: 30px;
}
</style>
