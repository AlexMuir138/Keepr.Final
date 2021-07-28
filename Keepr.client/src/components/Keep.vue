<template>
  <div class="row keep-bg rounded shadow" :style="{ backgroundImage: `url(${keep.img})`}" @click="setActiveKeep" data-toggle="modal" data-target="#activeKeepModal">
    <div class="d-flex align-items-end justify-content-center mx-1">
      <h5 class="keep-name text-light text-center rounded shadow p-1">
        {{ keep.name }}
        <router-link :to="{name: 'Profile', params: {id: keep.creatorId}}" @click="setActiveProfile">
          <img class="rounded-circle"
               :src="keep.creator.picture"
               height="30"
          />
        </router-link>
      </h5>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { profilesService } from '../services/ProfilesService'
export default {
  props: {
    keep: { type: Object, required: true },
    profile: { type: Object, required: true }
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
      },
      setActiveProfile() {
        try {
          profilesService.setActiveProfile(props.profile.id)
        } catch (error) {
          Notification.toast(error.message, 'error')
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
