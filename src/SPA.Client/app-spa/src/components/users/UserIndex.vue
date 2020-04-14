<template>
  <div>
    <h1 class="title">Módulo de usuarios</h1>
    <h2 class="subtitle">Desde aquí puede gestionar sus usuarios.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <table class="table is-striped is-fullwidth">
        <thead>
          <th>Nombre</th>
          <th>E-mail</th>
          <th style="width:100px;">Admin</th>
          <th style="width:100px;">Seller</th>
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.id">
            <td>{{item.fullName}}</td>
            <td>{{item.email}}</td>
            <td>
              <span class="icon">
                <i v-if="item.roles.includes('Admin')" class="fa fa-check"></i>
                <i v-else class="fa fa-times"></i>
              </span>
            </td>
            <td>
              <span class="icon">
                <i v-if="item.roles.includes('Seller')" class="fa fa-check"></i>
                <i v-else class="fa fa-times"></i>
              </span>
            </td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./UserIndex.js"></script>