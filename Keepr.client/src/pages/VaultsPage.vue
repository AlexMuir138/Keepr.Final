<template>
  <div class="row">
    <div class="col-12 ">
      <h2 class="p-5">
        {{ vault.name }}
      </h2>
      <h4 class="mx-3">
        Keeps: {{ keeps.length }}
      </h4>
    </div>
    <div class="row d-flex mx-4">
      <div class="masonry-with-flex">
        <VaultKeep v-for="k in keeps" :key="k.id" :keep="k" class="keep" />
      </div>
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    const route = useRoute()
    onMounted(() => {
      vaultsService.getVaultById(route.params.id)
      keepsService.getKeepsByVaultId(route.params.id)
    })
    const state = reactive({
    })
    return {
      state,
      activeVault: computed(() => AppState.activeVault),
      vault: computed(() => AppState.vault),
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>
<style scoped lang="scss">
body {
  margin: 0;
  padding: 1rem;
}

.masonry-with-flex {
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  max-height: 1000px;
  .keep {
    width: 150px;
    background-size: cover;
    background-color: black;
    color: black;
    margin: 0 1rem 1rem 0
  }
  @for $i from 1 through 500 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
