<template>
  <div v-if="vault.isPrivate == false" class="vault-bg m-1">
    <router-link :to="{name: 'Vault', params: {id: vault.id}}" @click="setActiveVault">
      <div class="Vault card m-3 shadow">
        <div class="p-3 my-3">
          <h5 class="vault-name text-primary text-center">
          </h5>
        </div>
      </div>
    </router-link>
    <div>
      <p>{{ vault.name }}</p>
    </div>
    <div class="d-flex justify-content-center">
      <button @click="deleteVault(vault.id)" v-if="vault.creatorId === account.id" class="btn btn-danger shadow" title="Delete Vault">
        Delete
      </button>
    </div>
  </div>
  <div v-if="vault.isPrivate == true" class="vault-bg m-1">
    <router-link :to="{name: 'Vault', params: {id: vault.id}}" @click="setActiveVault">
      <div class="Vault card m-3 shadow">
        <div class="p-2 my-2">
          <div class="vault-name text-danger text-center">
            <h5>Private!</h5>
          </div>
        </div>
      </div>
    </router-link>
    <div>
      <u>{{ vault.name }}</u>
    </div>
    <div class="d-flex justify-content-center">
      <button @click="deleteVault(vault.id)" v-if="vault.creatorId === account.id" class="btn btn-danger shadow" title="Delete Vault">
        Delete
      </button>
    </div>
  </div>
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
        if (confirm('do you really want to delete')) {
          await vaultsService.deleteVault(id)
        }
      },
      setActiveVault() {
        vaultsService.setActiveVault(props.vault.id)
      }
    }
  }
}
</script>

<style scoped>
 .Vault {
  background-image: url("../assets/img/vault.jpeg");
  background-size: cover;
}
.vault-name {
  background-color: rgba(0, 0, 0, 0.5);
}

.vault-bg{
  transition: all .2s ease-in-out;
}
.vault-bg:hover {
  transform: scale(1.1); }

</style>
