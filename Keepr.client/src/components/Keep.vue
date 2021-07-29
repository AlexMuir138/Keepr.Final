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
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { profilesService } from '../services/ProfilesService'
import { AppState } from '../AppState'
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
      account: computed(() => AppState.account),

      setActiveKeep() {
        keepsService.setActiveKeep(props.keep.id)
        keepsService.viewCount(props.keep.id, props.keep)
      },
      async deleteKeep(id) {
        await keepsService.deleteKeep(id)
      },
      setActiveProfile() {
        profilesService.setActiveProfile(props.profile.id)
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
