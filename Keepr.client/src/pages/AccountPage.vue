<template>
  <div class="container-fluid">
    <div class="row m-5">
      <div class="col-2">
        <router-link :to="{name: 'Profile', params: {id: account.id}}" @click="setActiveProfile">
          <img class="rounded-circle"
               alt=""
               :src="account.picture"
          />
        </router-link>
      </div>
      <div class="col-3">
        <h3>{{ account.name }}</h3>
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
      <div class="col-12 d-flex flex-row">
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
                     minlength="3"
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
                     required
                     v-model="state.newKeep.img"
              >
              <small id="helpId" class="form-text text-muted">Keep Img</small>
              <button class="mt-5 btn btn-block btn-info" type="submit">
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
                       required="true"
                       minlength="3"
                       v-model="state.newVault.name"
                >
                <small id="helpId" class="form-text text-muted mb-2">Vault Name</small>
                <input type="text"
                       class="form-control"
                       name="vaultDescription"
                       id=""
                       aria-describedby="helpId"
                       placeholder=""
                       required="true"
                       minlength="3"
                       v-model="state.newVault.description"
                >
                <small id="helpId" class="form-text text-muted">Vault Description</small>
                <div class="col-12 d-flex justify-content-beginning">
                  <p class="mt-3 ">
                    Private?

                    <input type="checkbox"
                           name="isPrivate"

                           v-model="state.newVault.isPrivate"
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
        <div class="masonry-with-flex m-2 flex-wrap">
          <Keep v-for="k in keeps" :key="k.id" :keep="k" class="keep" />
        </div>
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createKeepModal">
          +
        </button>
      </h2>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
export default {
  setup() {
    onMounted(() => {
      vaultsService.getVaults()
      keepsService.getAllKeeps()
    })
    const state = reactive({
      newKeep: {},
      newVault: {}
    })
    return {
      state,
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account),
      createKeep() {
        keepsService.createKeep(state.newKeep)
      },
      createVault() {
        vaultsService.createVault(state.newVault)
        vaultsService.getVaultsById()
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
