using UnityEngine;

public class ShadowMissel : MonoBehaviour
{
    private float _damage;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _particleSystem;
    private int _passCount;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Setup(Vector3 velocity, float damage, int passCount)
    {
        transform.rotation = Quaternion.LookRotation(velocity);
        _damage = damage;
        _rigidbody.velocity = velocity;
        _passCount = passCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Enemy>() is Enemy enemy)
        {
            enemy.SetDamage(_damage);
            _passCount--;

            if(_passCount == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        _rigidbody.velocity = Vector3.zero;
        _collider.enabled = false;
        _particleSystem.Stop();
        Destroy(gameObject, 2f);
    }
}
