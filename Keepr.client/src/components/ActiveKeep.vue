<template>
  <div class="modal"
       id="activeKeepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="activeKeepModalTitle"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="comment-form modal-content">
        <div class="row">
          <div class="col-6 d-flex align-items-center">
            <h5 class="modal-title text-dark m-1" id="exampleModalLongTitle">
              <img :src="activeKeep.img" class="rounded img-fluid" />
            </h5>
          </div>
          <div class="col-6">
            <button type="button" class="close text-dark" data-dismiss="modal" aria-label="Close" title="close task">
              x
            </button>
            Views: {{ activeKeep.views }}
            Keeps: {{ activeKeep.keeps }}
            <div class="pt-5 text-center">
              <h2>
                {{ activeKeep.name }}
              </h2>
            </div>
            <div class="p-3">
              {{ activeKeep.description }}
            </div>
            <div class="row">
              <div class="col-12 problem-child d-flex align-items-end">
                <div class="dropdown px-5 ">
                  <button class=" btn btn-secondary dropdown-toggle"
                          type="button"
                          id="dropdownMenuButton"
                          data-toggle="dropdown"
                          aria-haspopup="true"
                          aria-expanded="false"
                          title="Add to vault"
                  >
                    Add to Vault...
                  </button>
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <a
                      class="dropdown-item"

                      v-for="vault in vaults"
                      :key="vault.id"
                      @click="addToVault(vault.id)"
                      :title="vault.name"
                    >
                      {{ vault.name }}
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'

export default {
  setup() {
    const state = reactive({
      newKeep: { id: AppState.activeKeep.id }
    })
    return {
      state,
      activeKeep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      async addToVault(vaultId) {
        state.newKeep.vaultId = vaultId
        state.newKeep.keepId = AppState.activeKeep.id
        await keepsService.addToVault(state.newKeep)
      }
    }
  }

}
</script>

<style lang="scss" scoped>
// .vaultbutton{
//   bottom: 0;
// }

// .problem-child{
//   min-height: 25vh;
// }
</style>
