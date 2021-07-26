<template>
  <div class="row d-flex">
    <div class="col-12">
      <ActiveKeep v-if="activeKeep" />
    </div>
  </div>
  <div class="masonry-with-flex">
    <Keep v-for="k in keeps" :key="k.id" :keep="k" />
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
  div {
    width: 150px;
    background-size: cover;
    color: white;
    margin: 0 1rem 1rem 0;
    text-align: center;
    font-family: system-ui;
    font-weight: 900;
    font-size: 2rem;
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
