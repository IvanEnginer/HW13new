using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MagekMisselEffect), menuName = "Effects/ContiniuseEffect" + nameof(MagekMisselEffect))]

public class MagekMisselEffect : ContiniuseEffect
{
    [SerializeField] private MagekMissel _magekMisselPrefab;
    [SerializeField] private float _bulletSpeed;

    protected override void Produce()
    {
        base.Produce();

        _effectsMeneger.StartCoroutine(EffectProcess());
    }

    private IEnumerator EffectProcess()
    {
        int number = 4;
        Enemy[] nearestEnemies = _enemyManager.GetNearest(_player.transform.position, number);

        if(nearestEnemies.Length > 0 )
        {
            for( int i = 0; i < nearestEnemies.Length; i++ )
            {
                Vector3 position = _player.transform.position;
                MagekMissel magekMissel = Instantiate(_magekMisselPrefab, position, Quaternion.identity);
                magekMissel.Init(nearestEnemies[i], 20, _bulletSpeed);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
