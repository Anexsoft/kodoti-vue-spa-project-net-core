<template>
  <section id="app" class="hero is-light is-fullheight">
    <notifications group="global" position="top right" style="top:20px;right:20px;">
      <template slot="body" scope="props">
        <div :class="'notification ' + props.item.type">
          <button type="button" @click="props.close" class="delete"></button>
          <div v-html="props.item.text"></div>
        </div>
      </template>
    </notifications>

    <template v-if="hasConfig">
      <Header v-if="isLoggedIn" />

      <div class="hero-body">
        <div class="container">
          <router-view v-if="isLoggedIn" />
          <LoginAndRegister v-else />
        </div>
      </div>

      <Footer />
    </template>
    <div v-else class="hero-body">
      <div class="container has-text-centered is-size-5">
        <p>- Estamos inicializando el proyecto, un momento por favor -</p>
      </div>
    </div>
  </section>
</template>

<script>
import Header from "./shared/Header.vue";
import Footer from "./shared/Footer.vue";
import LoginAndRegister from "./shared/LoginAndRegister.vue";

export default {
  name: "app",
  mounted() {
    this.initialize();
  },
  components: {
    Header,
    Footer,
    LoginAndRegister
  },
  data() {
    return {
      hasConfig: false,
      isLoggedIn: false
    };
  },
  methods: {
    initialize() {
      let self = this;

      fetch("/config/version")
        .then(x => x.text())
        .then(x => {
          if (
            !localStorage.getItem("version") ||
            localStorage.getItem("version") != x
          ) {
            localStorage.clear();
            localStorage.setItem("version", x);
          }

          __prepareConfig();
          __isLoggedIn();
        });

      function __prepareConfig() {
        if (!localStorage.getItem("config")) {
          fetch("/config")
            .then(x => x.json())
            .then(x => {
              localStorage.setItem("config", JSON.stringify(x));
              self.hasConfig = true;
              window.location.reload(true);
            });
        } else {
          self.hasConfig = true;
        }
      }

      function __isLoggedIn() {
        if (localStorage.getItem("access_token") != null) {
          self.isLoggedIn = true;
        }
      }
    }
  }
};
</script>