<template>
  <router-link :to="{name: 'Vault', params: {id: vault.id}}" @click="setActiveVault">
    <div class="Vault card m-3 col-sm-3 shadow" v-if="vault.isPrivate == false">
      <div class="p-3">
        <h3 class="text-primary text-center">
          <u>{{ vault.name }}</u>
          <u></u>
        </h3>
        <h4 class="text-center p-3">
          {{ vault.description }}
        </h4>
        <div class="d-flex justify-content-center">
          <button @click="deleteVault(vault.id)" v-if="vault.creatorId === account.id" class="btn btn-danger" title="Delete Vault">
            Delete
          </button>
        </div>
      </div>
    </div>
  </router-link>
  <router-link :to="{name: 'Vault', params: {id: vault.id}}" @click="setActiveVault">
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
          <button @click="deleteVault(vault.id)" v-if="vault.creatorId === account.id" class="btn btn-danger" title="Delete Vault">
            Delete
          </button>
        </div>
      </div>
    </div>
  </router-link>
</template>

<script>
import { computed, reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
export default {
  props: {
    vault: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
    })
    return {
      state,
      account: computed(() => AppState.account),
      async deleteVault(id) {
        await vaultsService.deleteVault(id)
      },
      setActiveVault() {
        vaultsService.setActiveVault(props.vault.id)
      }
    }
  }
}
</script>

<style scoped>

</style>
