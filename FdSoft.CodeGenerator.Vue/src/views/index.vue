<template>
  <div class="app-container home">
    <el-row :gutter="20">
      <el-col :sm="24" :lg="24">
        
      </el-col>
    </el-row>
    <el-row :gutter="20">
      <el-col :lg="16" :sm="24">
        <h2>FdSoft.CodeGenerator.NET管理框架</h2>
      </el-col>
      <el-col :sm="24" :lg="8">
        <el-row>
          <h2>技术选型</h2>
          <el-col :span="10">
            <h4>后端技术</h4>
            <ul>
              <li>NET5</li>
              <li>JWT</li>
              <li>SqlSugar</li>
              <li>Quartz.Net</li>
              <li>MySql</li>
              <li>Mapster</li>
              <li>Epplus</li>
              <li>Signalr</li>
              <li>...</li>
            </ul>
          </el-col>
          <el-col :span="10">
            <h4>前端技术</h4>
            <ul>
              <li>Vue</li>
              <li>Vuex</li>
              <li>Element-ui</li>
              <li>Axios</li>
              <li>Sass</li>
              <li>Quill</li>
              <li>...</li>
            </ul>
          </el-col>
        </el-row>
      </el-col>
    </el-row>
    <el-divider />
    <el-row :gutter="20" class="mt10">
      <el-col :span="10">
        <!-- <el-card>
          <div slot="header" class="clearfix">
            <span></span>
          </div>
        </el-card> -->
      </el-col>
    </el-row>
    <el-divider />
  </div>
</template>

<script>
const defaultSettings = require("@/settings.js");
export default {
  name: "index",
  data() {
    return {
      // 版本号
      version: defaultSettings.version,
    };
  },
  methods: {
    goTarget(href) {
      window.open(href, "_blank");
    },
  },
};
</script>

<style scoped lang="scss">
.tip {
  color: red;
  display: inline-block;
  height: 30px;
  line-height: 30px;
}
.home {
  blockquote {
    padding: 10px 20px;
    margin: 0 0 20px;
    font-size: 17.5px;
    border-left: 5px solid #eee;
  }
  hr {
    margin-top: 20px;
    margin-bottom: 20px;
    border: 0;
    border-top: 1px solid #eee;
  }
  .col-item {
    margin-bottom: 20px;
  }

  ul {
    padding: 0;
    margin: 0;
  }

  font-family: "open sans", "Helvetica Neue", Helvetica, Arial, sans-serif;
  font-size: 13px;
  color: #676a6c;
  overflow-x: hidden;

  ul {
    list-style-type: none;
  }

  h4 {
    margin-top: 0px;
  }

  h2 {
    margin-top: 10px;
    font-size: 26px;
    font-weight: 100;
  }

  p {
    margin-top: 10px;

    b {
      font-weight: 700;
    }
  }

  .update-log {
    ol {
      display: block;
      list-style-type: decimal;
      margin-block-start: 1em;
      margin-block-end: 1em;
      margin-inline-start: 0;
      margin-inline-end: 0;
      padding-inline-start: 40px;
    }
  }
}
</style>

