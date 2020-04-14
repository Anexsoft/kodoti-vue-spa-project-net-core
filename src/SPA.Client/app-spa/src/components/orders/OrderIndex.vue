<template>
  <div>
    <h1 class="title">Módulo de órdenes</h1>
    <h2 class="subtitle">Desde aquí puede gestionar sus órdenes.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="field has-text-right">
        <router-link to="/orders/create">Agregar nueva orden</router-link>
      </div>
      <table class="table is-striped is-fullwidth">
        <thead>
          <th>Cliente</th>
          <th style="width:200px;" class="has-text-right">Iva</th>
          <th style="width:200px;" class="has-text-right">Sub Total</th>
          <th style="width:200px;" class="has-text-right">Total</th>
          <th style="width:150px;"></th>
        </thead>
        <tbody>
          <tr v-for="item in collection.items" :key="item.id">
            <td>{{item.client.name}}</td>
            <td class="has-text-right">US$ {{item.iva.toFixed(2)}}</td>
            <td class="has-text-right">US$ {{item.subTotal.toFixed(2)}}</td>
            <td class="has-text-right">US$ {{item.total.toFixed(2)}}</td>
            <td class="has-text-centered">
              <router-link :to="`/orders/${item.orderId}/detail`">Ver detalle</router-link>
            </td>
          </tr>
        </tbody>
      </table>
      <Pager :paging="p => getAll(p)" :page="collection.page" :pages="collection.pages" />
    </template>
  </div>
</template>

<script src="./OrderIndex.js"></script>