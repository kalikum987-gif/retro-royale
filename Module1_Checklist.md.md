 markdown

# Retro Royale - Module 1: Startup, Intro & Lobby Entry System

## Status
- Core Script: `StartupFlowController.cs` (Uploaded to GitHub)
- Heavy Software Required: None (Cloud/Browser & lightweight workflow)

## 1. Splash Screen & Intro Sequence
- Dark retro background with badge/ribbon logo
- Smooth fade-in (~2 seconds)
- Retro / gun-rack click SFX (`splashlip` via `sfxSource`)
- Transitions to Login screen

## 2. Login & Account Sign-In Page
- Clean container over blurred classic background
- Buttons: `Guest Login` (`guestLoginButton`) and `Google Play Games` (`googlePlayLoginButton`)
- Saves `LoginType` in `PlayerPrefs` and opens TAP-TO-START panel 

## 3. Tap-to-Start Screen
- Clean `TAP TO START` prompt/button (`tapToStartButton`)
- Instant feedback + metallic click SFX (`clickClip` via `sfxsource`)
- Loads `LobbyScene`

## 4. Lobby Entry
- Center: Skill-free `Adam` character model (upgradable later in module 2)
- Retro action buttons: `Start Match`,`Store`,`Vault`,`Battle Pass`
- Classic looping lobby background music (BGM)

## Pending Asset / Scene Hookup Checklist
- [ ] Assign `splashPanel`,`loginPanel`,`tapToStartPanel` in `StartupFlowController`
- [ ] Assign `guestLoginButton`,`googlePlayLoginButton`,`tapToStartButton`
- [ ] Add `splashClip` and `clickClip` audio files
- [ ] Add skill-free `Adam` model, retro UI buttons, and looping lobby BGM for `LobbyScene`
