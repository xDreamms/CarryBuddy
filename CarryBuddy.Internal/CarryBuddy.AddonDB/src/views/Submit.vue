<template>
  <v-container>
    <v-container fluid fill-height class="loginOverlay">
      <v-layout flex align-center justify-center>
        <v-flex xs12 sm6 elevation-6>
          <v-card>
            <v-card-text class="pa-5">
              <h1 class="display-2 font-weight-bold mb-5">
                Submit
                <br>Script
              </h1>
              <div>
                <v-form v-model="valid" ref="form">
                  <v-text-field
                    label="Script Name"
                    :rules="[v => !!v || 'Please write down the name of the script to be displayed.']"
                    v-model="scriptName"
                    required
                  ></v-text-field>
                  <v-text-field
                    label="Script Description"
                    :rules="[v => !!v || 'Please write down the description of the script to be displayed.']"
                    v-model="scriptDesc"
                    required
                  ></v-text-field>
                  <v-text-field
                    label="Author"
                    :rules="[v => !!v || 'Please write down the name of the author to be displayed.']"
                    v-model="author"
                    required
                  ></v-text-field>
                  <v-text-field
                    label="GitHub URL"
                    :rules="[v => !!v || 'Please write down the github url of the script.',
            v => /https:\/\/github.com\/+.+/.test(v) || 'Only https://github.com/@ address can be used.']"
                    v-model="githubUrl"
                    required
                  ></v-text-field>
                  <v-select
                    :items="scriptTypes"
                    :rules="[v => !!v || 'Please select the type of script.']"
                    v-model="scriptType"
                    label="Script Type"
                  ></v-select>
                  <v-btn
                    block
                    :disabled="!valid"
                    color="primary"
                    class="text-none"
                    :loading="loadV"
                    @click="submit"
                  >Submit</v-btn>
                </v-form>
              </div>
            </v-card-text>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
    <v-dialog :value="dialogValue" persistent max-width="500">
      <v-toolbar height="64">
        <v-toolbar-title>Sign In to CB Forums</v-toolbar-title>
      </v-toolbar>

      <v-card class="pa-4">
        <v-card-text class="pt-3">
          <v-form v-model="valid2" ref="form2">
            <v-text-field
              label="Email"
              :rules="[v => !!v || 'Please write down the email.', emailValidation]"
              v-model="em"
              required
            ></v-text-field>
            <v-text-field
              label="Password"
              type="password"
              :rules="[v => !!v || 'Please write down the password.']"
              v-model="pw"
              required
            ></v-text-field>

            <v-alert :value="err" type="warning">Error: {{errmsg}}</v-alert>
            <v-btn
              block
              color="error"
              class="text-none mt-4"
              @click="dialogValue=false; loadV = false;"
            >Cancel Upload</v-btn>

            <v-btn
              block
              :disabled="!valid2"
              color="primary"
              class="text-none"
              @click="procForm"
              :loading="loadVB"
            >Login And Submit</v-btn>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-dialog :value="dValue" max-width="500">
      <v-toolbar height="64">
        <v-toolbar-title>Success to upload!</v-toolbar-title>
      </v-toolbar>

      <v-card class="pa-4">
        <v-card-text class="pt-3">
          This script ({{latest}}) will be publish soon.
          <v-btn block color="primary" class="text-none mt-5" @click="dValue = false">Okay.</v-btn>
        </v-card-text>
      </v-card>
    </v-dialog>
  </v-container>
</template> 

<script>
export default {
  name: "",
  data() {
    return {
      scriptTypes: ["Champions", "Visual", "Utility"],
      scriptName: "asd",
      author: "asd",
      forumUrl: "",
      dialogValue: false,
      scriptType: "d",
      githubUrl: "https://github.com/asd",
      valid: false,
      loadV: false,
      loadVB: false,
      valid2: false,
      dValue: false,
      scriptDesc: "",
      latest: "",
      em: "",
      pw: "",
      err: false,
      errmsg: "",
      emailValidation: value => {
        const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return pattern.test(value) || "Please write down the Invalid e-mail.";
      }
    };
  },
  methods: {
    submit() {
      var _ = this;
      if (this.loadV) return;
      this.loadV = true;
      setTimeout(function() {
        _.dialogValue = true;
      }, 350);
    },
    procForm() {
      if (this.loadVB) return;
      this.loadVB = true;
      this.$recaptcha("login").then(token => {
        console.log(token); // Will print the token

        this.$http
          .post(
            `http://ec2-13-209-69-152.ap-northeast-2.compute.amazonaws.com:3000/api/login/submit`,
            {
              scriptDesc: this.scriptDesc,
              scriptName: this.scriptName,
              scriptType: this.scriptType,
              githubURL: this.githubUrl,
              authorName: this.author,
              email: this.em,
              password: this.pw
            }
          )
          .then(result => {
            this.loadVB = false;

            console.log(result.data);
            this.$cookie.set("nSESSID", result.data.token, { expires: "1Y" });
            this.$cookie.set("nMAIL", result.data.email, { expires: "1Y" });

            if (result.data.error) {
              this.err = true;
              this.errmsg = result.data.error;
            } else {
              this.dValue = true;
              this.latest = this.scriptName;
              this.$refs.form.reset();
              this.$refs.form2.reset();
              this.loadV = false;
              this.dialogValue = false;
            }
          })
          .catch(() => {
            this.loadVB = false;
            this.err = true;
            this.errmsg = "unknown error";
          });
      });
    }
  }
};
</script>

<style scoped>
</style>