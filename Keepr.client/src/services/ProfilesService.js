import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class ProfilesService {
  setActiveProfile(id) {
    const profile = AppState.profile.find(p => p.id === id)
    logger.log(profile)
    AppState.activeProfile = profile
  }
}
export const profilesService = new ProfilesService()
