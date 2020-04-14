<template>
  <div class="hero-head">
    <header class="navbar">
      <div class="container">
        <div class="navbar-brand">
          <a class="navbar-item">
            <img src="../assets/logo.png" alt="KODOTI" />
          </a>
          <span class="navbar-burger burger" data-target="navbarMenuHeroC">
            <span></span>
            <span></span>
            <span></span>
          </span>
        </div>
        <div id="navbarMenuHeroC" class="navbar-menu">
          <div class="navbar-end">
            <router-link :class="{'is-active': $route.name === 'default'}" class="navbar-item" to="/">Inicio</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/orders')}" class="navbar-item" to="/orders">Órdenes</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/clients')}" class="navbar-item" to="/clients">Clientes</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/products')}" class="navbar-item" to="/products">Productos</router-link>
            <router-link :class="{'is-active': $route.path.startsWith('/users')}" v-if="user.roles.includes('Admin')" class="navbar-item" to="/users">Usuarios</router-link>
            <span class="navbar-item">
              <a @click="logout" class="button is-danger is-inverted">
                <span class="icon">
                  <i class="fas fa-sign-out-alt"></i>
                </span>
                <span>Desconectarse</span>
              </a>
            </span>
          </div>
        </div>
      </div>
    </header>
  </div>
</template>

<script>
export default {
  name: "Header",
  computed: {
      user() {
          return this.$store.getters.user;
      }
  },
  methods: {
    logout() {
      localStorage.removeItem("access_token");
      this.$parent.isLoggedIn = false;
    }
  }
};
</script>