import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    logger.log('da keeps', res.data)
    AppState.keeps = res.data
  }

  async getKeepsById(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/keeps')
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

  setActiveKeep(id) {
    const keep = AppState.keeps.find(k => k.id === id)
    logger.log('active keep', keep)
    AppState.activeKeep = keep
  }

  async addToVault(newVaultKeep) {
    const res = await api.post('api/vaultkeeps', newVaultKeep)
    logger.log(res.data)
  }
}
export const keepsService = new KeepsService()
