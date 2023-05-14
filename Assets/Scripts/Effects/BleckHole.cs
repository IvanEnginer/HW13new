using UnityEngine;

public class BleckHole : MonoBehaviour
{
    private float _damage;
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Setup(float damage)
    {
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            enemy.SetDamage(_damage);
            
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
