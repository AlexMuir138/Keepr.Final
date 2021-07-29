import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import Notifier from '../utils/Notifier'
import { router } from '../router'

class VaultsService {
  async getVaults() {
    const res = await api.get('api/vaults')
    logger.log('da vaults', res.data)
    AppState.vaults = res.data
  }

  async getVaultsById(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    logger.log('da vaults', res.data)
    AppState.vaults = res.data
  }

  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    logger.log(res.data)
  }

  async deleteVault(id) {
    await api.delete('api/vaults/' + id)
    AppState.vaults = AppState.vaults.filter(v => v.id !== id)
  }

  setActiveVault(id) {
    const vault = AppState.vault.find(p => p.id === id)
    AppState.activeVault = vault
    logger.log('da vault', vault)
  }

  async getVaultById(vaultId) {
    try {
      const res = await api.get('api/vaults/' + vaultId)
      logger.log('da vault', res.data)
      AppState.vault = res.data
    } catch (error) {
      router.push({ name: 'Home' })
    }
  }
}
export const vaultsService = new VaultsService()
