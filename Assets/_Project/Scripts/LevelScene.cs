using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScene : MonoBehaviour
{
    [SerializeField] private AudioClip tapSound;
    [SerializeField] private AudioSource playSound;

    public void BackToMenu()
    {
        PlaySound("MainMenu");
    }

    public void Tutorial()
    {
        PlaySound("Tutorial");
    }

    public void Level1()
    {
        PlaySound("Level1");
    }

    public void Level2()
    {
        PlaySound("Level2");
    }

    public void Level3()
    {
        PlaySound("Level3");
    }

    public void Level4()
    {
        PlaySound("Level4");
    }

    public void Level5()
    {
        PlaySound("Level5");
    }

    public void Level6()
    {
        PlaySound("Level6");
    }

    public void BackToLevelScene()
    {
        PlaySound("LevelScene");
    }

    private void PlaySound(string sceneName)
    {
        Debug.Log($"{sceneName} Button Clicked");
        if (tapSound != null && playSound != null)
        {
            playSound.PlayOneShot(tapSound);
        }
        SceneManager.LoadScene(sceneName);
    }
}