<template>
  <div class="Vault card m-3 shadow" v-if="vault.isPrivate == false">
    <div class="p-3">
      <h3 class="text-primary text-center">
        <u>{{ vault.name }}</u>
        <u></u>
      </h3>
      <h4 class="text-center p-3">
        {{ vault.description }}
      </h4>
      <div class="d-flex justify-content-center">
        <button @click="deleteVault(vault.id)" class="btn btn-danger" title="Delete Vault">
          Delete
        </button>
      </div>
    </div>
  </div>
  <div class="Vault card m-3 shadow" v-if="vault.isPrivate == true">
    <div class="p-3">
      <h3 class="text-primary text-center">
        <u>{{ vault.name }}</u>
        <u></u>
      </h3>
      <h4 class="text-center p-3">
        {{ vault.description }}
      </h4>
      <div>
        <p>Private man!</p>
      </div>
      <div class="d-flex justify-content-center">
        <button @click="deleteVault(vault.id)" class="btn btn-danger" title="Delete Vault">
          Delete
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup() {
    const state = reactive({
    })
    return {
      state,
      async deleteVault(id) {
        await vaultsService.deleteVault(id)
      }
    }
  }
}
</script>

<style scoped>

</style>
