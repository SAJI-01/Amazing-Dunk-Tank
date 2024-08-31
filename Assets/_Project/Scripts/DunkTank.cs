using System.Collections;
using UnityEngine;

public class DunkTank : MonoBehaviour
{
    [SerializeField] private GameObject buttonTrigger;
    private Ball ball;
    private Book book;
    [SerializeField] private GameObject playerDunkTrigger;
    [SerializeField] private GameObject player;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        UIArrowManager.Instance.levelBackButton.SetActive(false);
        ball = FindObjectOfType<Ball>();
        book = FindObjectOfType<Book>();
        player.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void Update()
    {
        CheckDunked();
    }

    private void CheckDunked()
    {
        if (ball != null && buttonTrigger.GetComponent<BoxCollider2D>().IsTouching(ball.GetComponent<CircleCollider2D>()))
        {
            Dunked();
        }

        if (playerDunkTrigger != null && player != null &&
            playerDunkTrigger.GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<CapsuleCollider2D>()))
        {
            PlayerDunked();
        }

        if (playerDunkTrigger != null && book != null &&
            playerDunkTrigger.GetComponent<BoxCollider2D>().IsTouching(book.GetComponent<BoxCollider2D>()))
        {
            PlayerDunked();
        }
    }

    private void Dunked()
    {
        Debug.Log("Dunked");
        buttonTrigger.SetActive(false);
    }

    private void PlayerDunked()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(CheckGameOver());
    }

    private IEnumerator CheckGameOver()
    {
        yield return new WaitForSeconds(2f);
        WinGame();
    }

    private void WinGame()
    {
        Debug.Log("You Win!");
        UIArrowManager.Instance.levelBackButton.SetActive(true);
    }

    public void DestroyDunkTank()
    {
        Destroy(gameObject);
    }
}