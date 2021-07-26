<template>
  <div class="col-12 d-flex flex-row">
    <Vault v-for="v in vaults" :key="v.id" :vault="v" />
  </div>
</template>
<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
export default {
  setup() {
    onMounted(() => {
      vaultsService.getVaults()
    })
    const state = reactive({
    })
    return {
      state,
      vaults: computed(() => AppState.vaults)
    }
  }
}
</script>
