<template>
  <td>
    <h2>Sign-In Page</h2>
    <button @click="btn">Auth0 Sign-In</button>
  </td>
</template>

<script>
export default {
  methods: {
    name: 'LoginButton',
    btn() {
      this.$auth.loginWith('auth0')
    }
  }
}
</script>
