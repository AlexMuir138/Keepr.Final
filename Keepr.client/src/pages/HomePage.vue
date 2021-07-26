<template>
  <div class="row d-flex">
    <div class="col-12">
      <ActiveKeep v-if="activeKeep" />
    </div>
  </div>
  <div class="masonry-with-flex m-2">
    <Keep v-for="k in keeps" :key="k.id" :keep="k" class="keep" />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
export default {
  setup() {
    onMounted(() => {
      keepsService.getAllKeeps()
    })
    return {
      keeps: computed(() => AppState.keeps),
      activeKeep: computed(() => AppState.activeKeep)
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
  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
