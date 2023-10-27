<template>
  <div>
    <svg-icon icon-class="question" @click="goto"/>
  </div>
</template>

<script>
export default {
  name: 'FdSoft.CodeGeneratorDoc',
  data() {
    return {
      url: 'https://gitee.com'
    }
  },
  methods: {
    goto() {
      window.open(this.url)
    }
  }
}
</script>
