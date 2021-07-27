<template>
  <div class="row keep-bg rounded shadow" :style="{ backgroundImage: `url(${keep.img})`}" @click="setActiveKeep" data-toggle="modal" data-target="#activeKeepModal">
    <div class="d-flex align-items-end mx-1">
      <h5 class="keep-name text-light text-center rounded shadow p-1">
        <p>
          {{ keep.name }}
          {{ keep.creator }}
        </p>
      </h5>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
export default {
  props: {
    keep: { type: Object, required: true }
  },
  setup(props) {
    const state = reactive({
    })
    return {
      state,
      setActiveKeep() {
        try {
          keepsService.setActiveKeep(props.keep.id)
        } catch (error) {
          Notification.toast(error.message, 'error')
        }
      },
      async deleteKeep(id) {
        await keepsService.deleteKeep(id)
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
