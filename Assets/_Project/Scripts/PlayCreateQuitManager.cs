using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCreateQuitManager : MonoBehaviour
{
    [SerializeField] private AudioClip tapSound;
    [SerializeField] private AudioSource playSound;

    public void Play()
    {
        LoadSceneWithSound("LevelScene");
    }

    public void Create()
    {
        LoadSceneWithSound("CreateLevel");
    }

    public void Quit()
    {
        Debug.Log("Quit Button Clicked");
        PlaySound();
        Application.Quit();
    }

    private void LoadSceneWithSound(string sceneName)
    {
        Debug.Log($"{sceneName} Button Clicked");
        PlaySound();
        SceneManager.LoadScene(sceneName);
    }

    private void PlaySound()
    {
        if (tapSound != null && playSound != null)
        {
            playSound.PlayOneShot(tapSound);
        }
    }
}