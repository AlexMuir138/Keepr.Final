<template>
  <div class="container-fluid">
    <div class="row m-5">
      <div class="col-2">
        <img class="rounded-circle shadow"
             alt=""
             :src="profile.picture"
        />
      </div>
      <div class="col-3">
        <h3>{{ profile.name }}</h3>
        <h4>Vaults: {{ vaults.length }}</h4>
        <h4>Keeps: {{ keeps.length }}</h4>
      </div>

      <div class="col-12 m-5">
        <h2>
          Vaults
          <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createVaultModal">
            +
          </button>
        </h2>
      </div>
      <div class="col-12 d-flex flex-wrap">
        <Vault v-for="v in vaults" :key="v.id" :vault="v" />
      </div>
    </div>
    <div class="modal fade"
         id="createKeepModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              Modal title
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form class="form-group text-center" @submit.prevent="createKeep">
              <h3 class="mb-3">
                Create A New Keep
              </h3>
              <hr>
              <input type="text"
                     class="form-control "
                     name="vaultName"
                     id=""
                     aria-describedby="helpId"
                     placeholder=""
                     v-model="state.newKeep.name"
                     required
              >
              <small id="helpId" class="form-text text-muted mb-2">Keep Name</small>
              <input type="text"
                     class="form-control"
                     name="merchantName"
                     id=""
                     aria-describedby="helpId"
                     placeholder=""
                     v-model="state.newKeep.description"
                     required
              >
              <small id="helpId" class="form-text text-muted">Keep Description</small>
              <input type="text"
                     class="form-control"
                     name="merchantName"
                     id=""
                     aria-describedby="helpId"
                     placeholder=""
                     v-model="state.newKeep.img"
              >
              <small id="helpId" class="form-text text-muted">Keep Img</small>
              <button class="mt-5 btn btn-block btn-info">
                Create
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>

    <div class="modal fade"
         id="createVaultModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h3 class="mb-3">
              Create A New Vault
            </h3>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="col-12 d-flex justify-content-center">
              <form class="form-group col-md-8 text-center" @submit.prevent="createVault">
                <hr>
                <input type="text"
                       class="form-control "
                       name="vaultName"
                       id=""
                       aria-describedby="helpId"
                       placeholder=""
                       v-model="state.newVault.name"
                >
                <small id="helpId" class="form-text text-muted mb-2">Vault Name</small>
                <input type="text"
                       class="form-control"
                       name="vaultDescription"
                       id=""
                       aria-describedby="helpId"
                       placeholder=""
                       v-model="state.newVault.description"
                       required
                >
                <small id="helpId" class="form-text text-muted">Vault Description</small>
                <div class="col-12 d-flex justify-content-beginning">
                  <p class="mt-3 ">
                    Private?

                    <input type="checkbox"
                           name="isPrivate"
                           v-model="state.newVault.isPrivate"
                           required
                    >
                  </p>
                </div>

                <button class=" btn btn-block btn-info">
                  Create
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="col-12">
      <h2 class="m-4">
        Keeps:
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createKeepModal">
          +
        </button>
      </h2>
    </div>
    <div class="masonry-with-flex m-2 flex-wrap">
      <Keep v-for="k in keeps" :key="k.id" :keep="k" class="keep" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import { profilesService } from '../services/ProfilesService'
export default {
  setup() {
    const route = useRoute()
    onMounted(() => {
      profilesService.getProfileById(route.params.id)
      keepsService.getKeepsById(route.params.id)
      vaultsService.getVaultsById(route.params.id)
    })
    const state = reactive({
      newKeep: {},
      newVault: {}
    })
    return {
      state,
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      profile: computed(() => AppState.profile),
      activeProfile: computed(() => AppState.activeProfile),
      createKeep() {
        keepsService.createKeep(state.newKeep)
        vaultsService.getVaultsById(route.params.id)
      },
      createVault() {
        vaultsService.createVault(state.newVault)
        vaultsService.getVaultsById(route.params.id)
      }
    }
  }
}
</script>

<style lang="scss" scoped>
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
  @for $i from 1 through 500 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100) + px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
