using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Modes : MonoBehaviour
{
    [SerializeField] private AudioClip tapSound;
    [SerializeField] private AudioSource playSound;
    
    [Header("Reference")] 
    public Button PlayButton;
    public Button editButton;

    private Ball ball;
    private Book book;
    private balloon balloon;
    private Plank plank;
    private ForceReleaser forceReleaser;
    private Scissor scissor;
    private DunkTank dunkTank;

    public enum Mode
    {
        PlayMode,
        EditMode
    }
    
    public Mode mode;

    private void Start()
    {
        InitializeComponents();
        SetButtonListeners();
    }

    private void InitializeComponents()
    {
        ball = FindObjectOfType<Ball>();
        balloon = FindObjectOfType<balloon>();
        plank = FindObjectOfType<Plank>();
        forceReleaser = FindObjectOfType<ForceReleaser>();
        scissor = FindObjectOfType<Scissor>();
        dunkTank = FindObjectOfType<DunkTank>();
        book = FindObjectOfType<Book>();
    }

    private void SetButtonListeners()
    {
        if (PlayButton != null)
        {
            PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        if (editButton != null)
        {
            editButton.onClick.AddListener(OnEditButtonClicked);
        }
    }

    private void Update()
    {
        ToggleMode();
    }

    private void ToggleMode()
    {
        if (mode == Mode.PlayMode)
        {
            EnterPlayMode();
        }
        else
        {
            EnterEditMode();
        }
    }

    private void EnterPlayMode()
    {
        UIArrowManager.Instance.isEditMode = false;
        UIArrowManager.Instance.WhenClicked(false, false, false, false);

        SetRigidbodyType(RigidbodyType2D.Dynamic);
    }

    private void EnterEditMode()
    {
        UIArrowManager.Instance.isEditMode = true;
        SetRigidbodyType(RigidbodyType2D.Static);
    }

    private void SetRigidbodyType(RigidbodyType2D bodyType)
    {
        if (ball != null) ball.GetComponent<Rigidbody2D>().bodyType = bodyType;
        if (balloon != null) balloon.GetComponent<Rigidbody2D>().bodyType = bodyType;
        if (book != null) book.rb.bodyType = bodyType;
    }

    public void OnPlayButtonClicked()
    {
        PlaySound();
        mode = Mode.PlayMode;
    }
    
    public void OnEditButtonClicked()
    {
        PlaySound();
        mode = Mode.EditMode;
    }

    public void Replay()
    {
        PlaySound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        PlaySound();
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelScene()
    {
        PlaySound();
        SceneManager.LoadScene("LevelScene");
    }

    private void PlaySound()
    {
        if (tapSound != null && playSound != null)
        {
            playSound.PlayOneShot(tapSound);
        }
    }
}
