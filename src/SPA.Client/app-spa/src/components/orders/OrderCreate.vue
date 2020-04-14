<template>
  <div>
    <h1 class="title">Creación de orden</h1>
    <h2 class="subtitle">Desde aquí podrá crear una nueva orden de compra.</h2>

    <Loader v-if="isLoading" />
    <template v-else>
      <div class="box">
        <div class="select is-fullwidth">
          <select v-model.number="model.clientId">
            <option
              v-for="client in clients"
              :key="client.clientId"
              :value="client.clientId"
            >{{client.name}}</option>
          </select>
        </div>
      </div>

      <div class="box">
        <table class="table is-fullwidth is-striped">
          <thead>
            <tr>
              <th colspan="2">Producto</th>
              <th class="has-text-right" style="width:150px;">Cantidad</th>
              <th class="has-text-right" style="width:150px;">P.U</th>
              <th class="has-text-right" style="width:150px;">IVA</th>
              <th class="has-text-right" style="width:150px;">Sub Total</th>
              <th class="has-text-right" style="width:150px;">Total</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td colspan="2">
                <div class="select is-fullwidth">
                  <select @change="onChangeProductSelection" v-model.number="product.productId">
                    <option
                      v-for="product in products"
                      :key="product.productId"
                      :value="product.productId"
                    >{{product.name}}</option>
                  </select>
                </div>
              </td>
              <td>
                <input class="input" type="number" v-model.number="product.quantity" />
              </td>
              <td>
                <input class="input" type="number" v-model.number="product.unitPrice" />
              </td>
              <td class="has-text-right" colspan="3">
                <button @click="addProduct" class="button">Agregar</button>
              </td>
            </tr>

            <tr v-if="model.items.length === 0">
              <td class="has-text-centered is-size-5" colspan="7">No se ha seleccionado un producto</td>
            </tr>
            <tr v-else v-for="item in model.items" :key="item.productId">
              <td class="has-text-centered" style="width:100px;">
                <a class="has-text-danger" @click="removeProduct(item.productId)">Retirar</a>
              </td>
              <td>{{item.name}}</td>
              <td class="has-text-right">{{item.quantity}}</td>
              <td class="has-text-right">US$ {{item.unitPrice}}</td>
              <td class="has-text-right">US$ {{item.iva}}</td>
              <td class="has-text-right">US$ {{item.subTotal}}</td>
              <td class="has-text-right">US$ {{item.total}}</td>
            </tr>
          </tbody>
          <tfoot class="has-text-weight-bold">
            <tr>
              <td colspan="6" class="has-text-right">IVA</td>
              <td class="has-text-right">US$ {{iva}}</td>
            </tr>
            <tr>
              <td colspan="6" class="has-text-right">Sub Total</td>
              <td class="has-text-right">US$ {{subTotal}}</td>
            </tr>
            <tr>
              <td colspan="6" class="has-text-right">Total</td>
              <td class="has-text-right">US$ {{total}}</td>
            </tr>
          </tfoot>
        </table>
        <button @click="create" :disabled="model.items.length === 0" class="button is-primary is-medium is-fullwidth">Crear orden</button>
      </div>
    </template>
  </div>
</template>

<script src="./OrderCreate.js"></script>