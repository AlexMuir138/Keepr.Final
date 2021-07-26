<template>
  <div class="modal"
       id="keepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="keepModalTitle"
       aria-hidden="true"
  >
    <div class=" modal-dialog modal-dialog-centered" role="document">
      <div class="comment-form modal-content">
        <div class="modal-header">
          <div class="dropdown px-5">
            <button class="btn btn-secondary dropdown-toggle"
                    type="button"
                    id="dropdownMenuButton"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                    title="Move to new vault"
            >
              Move to Vault...
            </button>
          </div>
          <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close" title="close keep">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  setup() {
    const state = reactive({
    })
    return {
      state,
      activeKeep: computed(() => AppState.activeKeep)
    }
  }
}
</script>

<style>

</style>
