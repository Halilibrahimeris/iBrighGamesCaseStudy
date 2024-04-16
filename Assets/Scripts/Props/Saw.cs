using UnityEngine;

public class Saw : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out IDamageable player))
        {
            Debug.Log("Player girdi");
            player.TakeDamage();
        }
    }
}
