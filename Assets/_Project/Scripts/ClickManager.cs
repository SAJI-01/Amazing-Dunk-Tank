using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    private Vector3 screenPos;
    private float angleOffset;

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mousePos2D = new Vector2(mousePos.x, mousePos.y);
        var hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider == null) return;

        var clickedGameObject = hit.collider.gameObject;
        if (clickedGameObject.GetComponent<Editables>() == null) return;

        UIArrowManager.Instance.clickedObject = clickedGameObject;
        
        if (Input.GetMouseButton(0))
        {
            HandleObjectInteraction(clickedGameObject, mousePos);
        }
    }

    private void HandleObjectInteraction(GameObject clickedGameObject, Vector3 mousePos)
    {
        var tag = clickedGameObject.GetComponent<Collider2D>().tag;
        var isMoveActive = UIArrowManager.Instance.isMoveButtonActive;
        var isDeleteActive = UIArrowManager.Instance.isDeleteButtonActive;
        var isFlipActive = UIArrowManager.Instance.isFlipButtonActive;
        var isRotateActive = UIArrowManager.Instance.isRotateButtonActive;

        switch (tag)
        {
            case "ForceReleaser":
            case "DunkTank":
                UIArrowManager.Instance.WhenClicked(true, false, true);
                if (isFlipActive)
                {
                    UIArrowManager.Instance.clickedObject = clickedGameObject;
                }
                else if (isMoveActive)
                {
                    clickedGameObject.transform.position = tag == "ForceReleaser" ? new Vector3(mousePos.x, mousePos.y, 0) : clickedGameObject.transform.position;
                }
                else if (isDeleteActive)
                {
                    UIArrowManager.Instance.clickedObject = clickedGameObject;
                }
                break;

            case "Scissor":
            case "Plank":
            case "Balloon":
            case "Book":
                UIArrowManager.Instance.WhenClicked(false, true, true);
                if (isRotateActive)
                {
                    UIArrowManager.Instance.clickedObject = clickedGameObject;
                }
                else if (isMoveActive)
                {
                    clickedGameObject.transform.position = tag == "ForceReleaser" ? new Vector3(mousePos.x, mousePos.y, 0) : clickedGameObject.transform.position;
                }
                else if (isDeleteActive)
                {
                    UIArrowManager.Instance.clickedObject = clickedGameObject;
                }
                break;

            case "Ball":
            case "Trampoline":
                UIArrowManager.Instance.WhenClicked(false, false, true);
                if (isMoveActive)
                {
                    clickedGameObject.transform.position = tag == "ForceReleaser" ? new Vector3(mousePos.x, mousePos.y, 0) : clickedGameObject.transform.position;
                }
                else if (isDeleteActive)
                {
                    UIArrowManager.Instance.clickedObject = clickedGameObject;
                }
                break;

            default:
                UIArrowManager.Instance.WhenClicked(false, false, false);
                break;
        }
    }
}
