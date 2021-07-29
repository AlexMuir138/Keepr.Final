import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  profile: {},
  vault: {},
  keeps: [],
  vaults: [],
  activeVault: null,
  activeKeep: null,
  activeProfile: null
})
