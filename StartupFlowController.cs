csharp

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartupFlowController : MonoBehaviour
{
[Header("Panels")]
public GameObject splashPanel;
public GameObject loginPanel;
public GameObject tapToStartPanel;

[Header("UI Elements")]
public CanvasGroup splashCanvasGroup;
public Button guestLoginButton;
public Button googlePlayLoginButton;
public Button tapToStartButton;

[Header("Audio")]
public AudioSource sfxSource;
public AudioClip splashClip;
public AudioClip clickClip;

[Header("Settings")]
public float splashDuration = 2.0f;
public string lobbySceneName = "LobbyScene";

private void Start()
{
if (splashPanel != null) splashPanel.SetActive(true);
if (loginPanel != null) loginPanel.SetActive(false);
if (tapToStartPanel != null) tapToStartPanel.SetActive(false);

if (guestLoginButton != null)
guestLoginButton.onClick.AddListener(OnGuestLoginClicked);

if (googlePlayLoginButton != null)
googlePlayLoginButton.onClick.AddListener(OnGooglePlayLoginClicked);

if (tapToStartButton != null)
tapToStartButton.onClick.AddListener(OnTapToStartClicked);

StartCoroutine(PlaySplashSequence());
}

private IEnumerator PlaySplashSequence()
{
if (sfxSource != null && splashClip != null)
sfxSource.PlayOneShot(splashClip);

float elapsed = 0f;
while (elapsed < splashDuration)
{
elapsed += Time.deltaTime;
if (splashCanvasGroup != null)
splashCanvasGroup.alpha = Mathf.Clamp01(elapsed / splashDuration);
yield return null;
}

if (splashPanel != null) splashPanel.SetActive(false);
if (loginPanel != null) loginPanel.SetActive(true);
}

private void OnGuestLoginClicked()
{
PlayClickSound();
PlayerPrefs.SetString("LoginType", "Guest");
PlayerPrefs.Save();
ShowTapToStart();
}

private void OnGooglePlayLoginClicked()
{
PlayClickSound();
PlayerPrefs.SetString("LoginType", "GooglePlay");
PlayerPrefs.Save();
ShowTapToStart();
}

private void ShowTapToStart()
{
if (loginPanel != null) loginPanel.SetActive(false);
if (tapToStartPanel != null) tapToStartPanel.SetActive(true);
}

private void OnTapToStartClicked()
{
PlayClickSound();
SceneManager.LoadScene(lobbySceneName);
}

private void PlayClickSound()
{
if (sfxSource != null && clickClip != null)
sfxSource.PlayOneShot(clickClip);
}
}