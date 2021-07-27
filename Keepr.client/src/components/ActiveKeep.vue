<template>
  <div class="modal"
       id="activeKeepModal +"
       tabindex="-1"
       role="dialog"
       aria-labelledby="activeKeepModalTitle"
       aria-hidden="true"
  >
    <div class=" modal-dialog modal-dialog-centered" role="document">
      <div class="comment-form modal-content">
        <div class="modal-header">
          <h5 class="modal-title text-light" id="exampleModalLongTitle">
            <u> {{ activeKeep.name }}</u>
          </h5>
          <div class="dropdown px-5">
          </div>
          <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close" title="close task">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: { keepProp: { type: Object, required: true } },
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep)
    }
  }

}
</script>

<style lang="scss" scoped>

</style>
