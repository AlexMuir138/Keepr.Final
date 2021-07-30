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
    logger.log('da profile keeps', res.data)
    AppState.keeps = res.data
  }

  async getKeepsByVaultId(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    logger.log('da vault_keeps', res.data)
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

  async deleteVaultKeep(id) {
    await api.delete('api/vaultkeeps/' + id)
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

  async viewCount(id, keep) {
    keep.views = (keep.views += 1)
    const res = await api.put('api/keeps/views/' + id, keep)
    logger.log(res.data)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
    AppState.keeps = [...AppState.keeps, res.data]
  }
}
export const keepsService = new KeepsService()
