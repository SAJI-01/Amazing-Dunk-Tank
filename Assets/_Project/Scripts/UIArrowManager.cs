using UnityEngine;
using UnityEngine.UI;

public class UIArrowManager : MonoBehaviour
{
    [SerializeField] private AudioClip tapSound;
    public AudioSource playSound;
    public Button DeleteButton;
    public Button flipButton;
    public Button rotateButton;
    public Button moveButton;
    public GameObject levelBackButton;

    [HideInInspector] public GameObject clickedObject;
    public static UIArrowManager Instance;
    [HideInInspector] public bool isFlipButtonActive;
    [HideInInspector] public bool isRotateButtonActive;
    [HideInInspector] public bool isMoveButtonActive;
    [HideInInspector] public bool isDeleteButtonActive;
    public bool isEditMode;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DeactivateButtons();
        SetButtonListeners();
    }

    private void SetButtonListeners()
    {
        flipButton.onClick.AddListener(FlipButton);
        rotateButton.onClick.AddListener(RotateButton);
        moveButton.onClick.AddListener(MoveButton);
        DeleteButton.onClick.AddListener(DeleteButton_);
    }

    private void Update()
    {
        if (clickedObject == null) return;
        transform.position = clickedObject.transform.position;
        ToggleEditMode();
    }

    private void ToggleEditMode()
    {
        flipButton.gameObject.SetActive(isEditMode);
        rotateButton.gameObject.SetActive(isEditMode);
        moveButton.gameObject.SetActive(isEditMode);
        DeleteButton.gameObject.SetActive(isEditMode);
    }

    private void FlipButton()
    {
        Debug.Log("Flip Button Clicked");
        isFlipButtonActive = !isFlipButtonActive;
        if (clickedObject != null)
            clickedObject.gameObject.transform.rotation = Quaternion.Euler(0, clickedObject.gameObject.transform.rotation.y + 180, 0);
    }

    private void RotateButton()
    {
        PlaySound();
        Debug.Log("Rotate Button Clicked");
        isRotateButtonActive = !isRotateButtonActive;
        if (clickedObject != null)
            clickedObject.transform.Rotate(0, 0, 20);
    }

    private void MoveButton()
    {
        PlaySound();
        Debug.Log("Move Button Clicked");
        isMoveButtonActive = !isMoveButtonActive;
    }

    private void DeleteButton_()
    {
        PlaySound();
        Debug.Log("Delete Button Clicked");
        if (clickedObject != null)
        {
            DestroyBasedOnTag(clickedObject);
        }
        clickedObject = null;
        WhenClicked(false, false, false, false);
    }

    private void DestroyBasedOnTag(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Ball":
                obj.GetComponent<Ball>().DestroyBall();
                break;
            case "Balloon":
                obj.GetComponent<balloon>().PopBalloon();
                break;
            case "Plank":
                obj.GetComponent<Plank>().DestroyPlank();
                break;
            case "ForceReleaser":
                obj.GetComponent<ForceReleaser>().DestroyForceReleaser();
                break;
            case "Scissor":
                obj.GetComponent<Scissor>().DestroyScissor();
                break;
            case "DunkTank":
                obj.GetComponent<DunkTank>().DestroyDunkTank();
                break;
            case "Trampoline":
                obj.GetComponent<Trampoline>().DestroyTrampoline();
                break;
            case "Book":
                obj.GetComponent<Book>().DestroyBook();
                break;
            default:
                break;
        }
    }

    private void PlaySound()
    {
        if (tapSound != null && playSound != null)
        {
            playSound.PlayOneShot(tapSound);
        }
    }

    public void WhenClicked(bool flip, bool rotate, bool move, bool delete = true)
    {
        flipButton.gameObject.SetActive(flip);
        rotateButton.gameObject.SetActive(rotate);
        moveButton.gameObject.SetActive(move);
        DeleteButton.gameObject.SetActive(delete);
    }

    private void DeactivateButtons()
    {
        flipButton.gameObject.SetActive(false);
        rotateButton.gameObject.SetActive(false);
        moveButton.gameObject.SetActive(false);
        DeleteButton.gameObject.SetActive(false);
    }
}
