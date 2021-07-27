<template>
  <div class="modal"
       id="activeKeepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="activeKeepModalTitle"
       aria-hidden="true"
  >
    <div class=" modal-dialog modal-dialog-centered" role="document">
      <div class="comment-form modal-content row">
        <div class="modal-header">
          <div class="col-6">
            <h5 class="modal-title text-dark" id="exampleModalLongTitle">
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
              {{ activeKeep.name }}
            </div>
            <div>
              {{ activeKeep.description }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep)
    }
  }

}
</script>

<style lang="scss" scoped>

</style>
