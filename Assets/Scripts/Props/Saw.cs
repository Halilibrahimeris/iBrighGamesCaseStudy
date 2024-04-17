using UnityEngine;

public class Saw : MonoBehaviour
{
    private bool _giveDamageOneTime = true;
    private Platform _platform;

    private void Start()
    {
        _platform = GetComponentInParent<Platform>();
    }

    private void Update()
    {
        if (_platform.reset)
        {
            _giveDamageOneTime = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out IDamageable player))
        {
            if (_giveDamageOneTime)
            {
                Debug.Log("Player girdi");
                player.TakeDamage();
                _giveDamageOneTime=false;
            }
        }
    }
}
