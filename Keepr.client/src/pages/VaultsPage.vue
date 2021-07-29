<template>
  <div class="row">
    <div class="col-12 ">
      <h2 class="p-5">
        {{ vault.name }}
      </h2>
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
export default {
  setup() {
    const route = useRoute()
    onMounted(() => {
      vaultsService.getVaultById(route.params.id)
    })
    const state = reactive({
    })
    return {
      state,
      activeVault: computed(() => AppState.activeVault),
      vault: computed(() => AppState.vault)
    }
  }
}
</script>
