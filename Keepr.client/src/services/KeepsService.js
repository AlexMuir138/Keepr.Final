import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    logger.log('da keeps', res.data)
    AppState.keeps = res.data
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    logger.log(res.data)
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
  }

  setActiveKeep(keepData) {
    AppState.activeKeep = AppState.keeps[keepData.VaultId].find(k => k.id === keepData.id)
    logger.log(AppState.activeKeep)
  }

  async changeVault(vaultId, updatedKeep) {
    const res = await api.put('api/vaults/' + vaultId + '/keeps/' + updatedKeep.id, updatedKeep)
    AppState.keeps[vaultId] = AppState.keeps[vaultId].filter(k => k.id !== res.data.id)
    AppState.keeps[res.data.vaultId].push(res.data)
  }
}
export const keepsService = new KeepsService()

// vvv this is the function that worked for kanban
// async changeList(listId, updatedTask) {
//   const res = await api.put('api/lists/' + listId + '/tasks/' + updatedTask.id, updatedTask)
//   AppState.tasks[listId] = AppState.tasks[listId].filter(t => t.id !== res.data.id)
//   AppState.tasks[res.data.listId].push(res.data)
// }

// ActiveKeep template

// import { computed, reactive } from '@vue/runtime-core'
// import { AppState } from '../AppState'
// import { keepsService } from '../services/KeepsService'
// import { vaultsService } from '../services/VaultsService'
// import { useRoute } from 'vue-router'
// import Notification from '../utils/Notification'
// export default {
//   setup() {
//     const route = useRoute()
//     const state = reactive({
//       updatedKeep: { id: AppState.activeKeep.id }
//     })
//     return {
//       state,
//       activeKeep: computed(() => AppState.activeKeep),
//       vaults: computed(() => AppState.lists),
//       async changeKeep(newVaultId) {
//         state.updatedTask.listId = newVaultId
//         try {
//           await keepsService.changeVault(AppState.activeKeep.vaultId, state.updatedKeep)
//         } catch (error) {
//           Notification.toast(error.message, 'error')
//         }
//         // eslint-disable-next-line no-undef
//         $('#exampleModalCenter').hide()
//         // eslint-disable-next-line no-undef
//         $('.modal-backdrop').hide()

//         await vaultsService.getVaults(route.params.id)
//       }

//     }
//   }
// }
// </script>

// <style >

// </style> */}
