<template>
  <nav class="pagination is-rounded" role="navigation" aria-label="pagination">
    <ul class="pagination-list">
      <li v-for="index in pages" :key="index">
        <a
          @click="go(index)"
          :class="{'is-current': index === page}"
          class="pagination-link"
        >{{index}}</a>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {
  name: "Pager",
  props: {
    page: {
      type: Number,
      required: true
    },
    pages: {
      type: Number,
      required: true
    },
    paging: {
      type: Function,
      required: true
    }
  },
  data() {
    return {};
  },
  methods: {
    go(page) {
      if (page === this.page) {
        return;
      }

      this.paging(page);
    }
  }
};
</script>