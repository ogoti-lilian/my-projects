<template>
  <td>
    <h2>Index Page</h2>
    {{ res_display }}
  </td>
</template>

<script>
  export default {
    data() {
      return {
        res_display: []
      }
    },
    async mounted() {
      const res_display = await this.$axios.$get('weatherforecast')
      this.res_display = res_display
    }
  }
</script>

