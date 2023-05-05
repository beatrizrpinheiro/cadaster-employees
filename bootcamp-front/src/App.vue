<template>
  <div>
    <b-navbar style="padding: 7px" toggleable="lg" type="dark" variant="dark">
      <b-navbar-brand href="#">BootCamp1st</b-navbar-brand>

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item to="cadaster">Cadastro de Funcionários</b-nav-item>
          <b-nav-item to="list">Funcionários cadastrados</b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <b-container style="padding: 20px">
      <router-view></router-view>
    </b-container>
  </div>
</template>

<style></style>

<script>
import router from "./router";

export default {
  name: "App",
  router,
};
</script>
