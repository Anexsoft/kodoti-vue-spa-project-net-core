<template>
  <div>
    <h1 class="title">{{model.productId ? model.name : 'Nuevo producto'}}</h1>
    <h2 class="subtitle">{{model.productId ? model.description : 'Creación de producto.'}}</h2>

    <Loader v-if="isLoading" />
    <form v-else @submit.prevent="save">
      <div class="field">
        <input
          :class="{error: validation.hasError('model.name')}"
          v-model="model.name"
          class="input"
          type="text"
          placeholder="Ingrese el nombre"
        />
        <p class="help is-danger">{{validation.firstError('model.name')}}</p>
      </div>
      <div class="field">
        <input
          :class="{error: validation.hasError('model.price')}"
          v-model.number="model.price"
          class="input"
          type="number"
          placeholder="Ingrese el precio"
        />
        <p class="help is-danger">{{validation.firstError('model.price')}}</p>
      </div>
      <div class="field">
        <textarea
          :class="{error: validation.hasError('model.description')}"
          v-model="model.description"
          class="textarea"
          rows="2"
          placeholder="Ingrese la descripción"
        ></textarea>
        <p class="help is-danger">{{validation.firstError('model.description')}}</p>
      </div>
      <div class="field">
        <button type="submit" class="button is-info">Guardar</button>
      </div>
    </form>
  </div>
</template>

<script src="./ProductCreateOrUpdate.js"></script>