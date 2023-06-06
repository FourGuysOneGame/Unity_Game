using UnityEngine;

public class HeartDrop : MonoBehaviour, ICollectable
{
    private Rigidbody2D itemRb;
    public float dropForce = 2;

    private void Start()
    {
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    public void Collect(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.GetComponent<Player>().Actions.Heal();
            Destroy(gameObject);
        }
    }
}