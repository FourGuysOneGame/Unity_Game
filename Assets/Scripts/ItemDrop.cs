using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody2D itemRb;
    public float dropForce = 2;

    private void Start()
    {
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().Actions.Heal();
            Destroy(gameObject);
        }
        else if(other.collider.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision( other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
