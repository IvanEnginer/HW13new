using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            Die();
        }
    }

    private void Die()
    {
        _collider.enabled = false;
        _particleSystem.Stop();
        Destroy(gameObject, 2f);
    }
}
