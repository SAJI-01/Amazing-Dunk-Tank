using UnityEngine;

public class ForceReleaser : MonoBehaviour
{
    [SerializeField] private Collider2D topCollider2D;
    [SerializeField] private Collider2D bottomCollider2D;
    private GameObject ball;
    [SerializeField] private CircleCollider2D ballCollider2D;

    [SerializeField] private Transform TopPosition;
    [SerializeField] private Transform BottomPosition;

    private void Start()
    {
        InitializeBall();
    }

    private void InitializeBall()
    {
        ball = FindObjectOfType<Ball>()?.gameObject;
        ballCollider2D = ball?.GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        DetectionCollider();
    }

    private void DetectionCollider()
    {
        if (ballCollider2D == null) return;

        if (ballCollider2D.IsTouching(topCollider2D))
        {
            var dd = Vector2.Dot(-TopPosition.right, ballCollider2D.attachedRigidbody.velocity.normalized);
            if (dd > 0.7f)
            {
                TeleportBall();
            }
        }
    }

    private void TeleportBall()
    {
        ballCollider2D.transform.position = BottomPosition.position;
        var velocity = ballCollider2D.attachedRigidbody.velocity;
        ballCollider2D.attachedRigidbody.velocity = BottomPosition.right * velocity.magnitude * 2f;
    }

    public void DestroyForceReleaser()
    {
        Destroy(transform.parent.gameObject);
    }
}