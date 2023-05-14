using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
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
        _collider.enabled = false;
        _particleSystem.Stop();
        Destroy(gameObject, 2f);
    }
}
