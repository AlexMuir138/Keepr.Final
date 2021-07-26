<template>
  <div class="container-fluid">
    <div class="row m-2">
      <div class="col-2">
        <img class="rounded" :src="account.picture" alt="" />
      </div>
      <div class="col-3">
        <div class="">
          <h3>{{ account.name }}</h3>
          <h4>Vaults: {{ vaults.length }}</h4>
          <h4>Keeps: {{ keeps.length }}</h4>
        </div>
      </div>
      <div class="col-12">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
          Create a New Keep
        </button>
      </div>
      <div class="col-12 d-flex flex-row">
        <Vault v-for="v in vaults" :key="v.id" :vault="v" />
      </div>
    </div>
    <div class="modal fade"
         id="exampleModal"
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
              >
              <small id="helpId" class="form-text text-muted mb-2">Keep Name</small>
              <input type="text"
                     class="form-control"
                     name="merchantName"
                     id=""
                     aria-describedby="helpId"
                     placeholder=""
                     v-model="state.newKeep.description"
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
              >
              <small id="helpId" class="form-text text-muted mb-2">Keep Name</small>
              <input type="text"
                     class="form-control"
                     name="merchantName"
                     id=""
                     aria-describedby="helpId"
                     placeholder=""
                     v-model="state.newKeep.description"
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
                >
                <small id="helpId" class="form-text text-muted">Vault Description</small>
                <button class="mt-5 btn btn-block btn-info">
                  Create
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#createVaultModal">
      Create a New Vault
    </button>
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
        vaultsService.getVaults()
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
