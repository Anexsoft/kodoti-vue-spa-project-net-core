import Notifications from 'vue-notification'
import Vue from 'vue';
import App from './App.vue';
import proxyConfig from './proxies/_config';
import store from './store/index';
import SimpleVueValidation from 'simple-vue-validator';

Vue.config.productionTip = false;

Vue.use(SimpleVueValidation, {
  mode: 'manual',
  templates: {
    error: 'Error.',
    required: 'Requerido.',
    float: 'Debe ser un número.',
    integer: 'Debe ser un entero.',
    number: 'Debe ser un número.',
    lessThan: 'Debe ser menor a {0}.',
    lessThanOrEqualTo: 'Debería ser menor o igual a {0}.',
    greaterThan: 'Debe ser mayor a {0}.',
    greaterThanOrEqualTo: 'Debería ser mayor o igual a {0}.',
    between: 'Debe estar entre {0} y {1}.',
    size: 'El tamaño debería ser {0}.',
    length: 'Debe ingresar {0} caracteres.',
    minLength: 'Como mínimo se aceptan {0} caracteres.',
    maxLength: 'Como máximo se aceptan {0} caracteres.',
    lengthBetween: 'La longitud debería estar entre {0} y {1}.',
    in: 'Debe ser {0}.',
    notIn: 'No debería ser {0}.',
    match: 'No se pueden comparar.',
    regex: 'Formato inválido.',
    digit: 'Debe ser un dígito.',
    email: 'Email inválido.',
    url: 'Url inválida.'
  }
});

Vue.use({
  install(Vue) {
    Object.defineProperty(Vue.prototype, '$validator', {
      value: SimpleVueValidation.Validator
    })
  }
});

Vue.use({
  install(Vue) {
    Object.defineProperty(Vue.prototype, '$proxies', {
      value: proxyConfig
    })
  }
});

import router from './router';

Vue.use(Notifications);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
