import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class ProfilesService {
  setActiveProfile(id) {
    const profile = AppState.profile.find(p => p.id === id)
    AppState.activeProfile = profile
    logger.log('da profile', profile)
  }

  async getProfileById(profileId) {
    const res = await api.get('api/profiles/' + profileId)
    logger.log('da profile', res.data)
    AppState.profile = res.data
  }
}
export const profilesService = new ProfilesService()
