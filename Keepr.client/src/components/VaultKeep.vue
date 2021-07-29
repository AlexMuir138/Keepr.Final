<template>
  <div class="row keep-bg rounded shadow" :style="{ backgroundImage: `url(${keep.img})`}" @click="setActiveKeep" data-toggle="modal" data-target="#activeKeepModal">
    <div class="d-flex align-items-end justify-content-center mx-1">
      <div>
      </div>
      <h5 class="keep-name text-light text-center rounded shadow p-1">
        {{ keep.name }}
        <div>
          <button @click="deleteVaultKeep(keep.vaultKeepId)" v-if="keep.creatorId === account.id" class="" title="Delete Vault">
            x
          </button>
        </div>
      </h5>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
export default {
  props: {
    keep: { type: Object, required: true },
    profile: { type: Object, required: true }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
    })
    return {
      state,
      account: computed(() => AppState.account),

      setActiveKeep() {
        keepsService.setActiveKeep(props.keep.id)
        keepsService.viewCount(props.keep.id, props.keep)
      },
      async deleteVaultKeep(id) {
        if (confirm('do you really want to delete')) {
          await keepsService.deleteVaultKeep(id)
          await keepsService.getKeepsByVaultId(route.params.id)
        }
      }
    }
  }
}
</script>

<style scoped>
.keep-name {
  background-color: rgba(0, 0, 0, 0.5);
}

.keep-bg{
  transition: all .2s ease-in-out;
}
.keep-bg:hover {
  transform: scale(1.1); }

</style>
