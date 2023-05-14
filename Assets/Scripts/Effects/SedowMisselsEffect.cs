using UnityEngine;


[CreateAssetMenu(fileName = nameof(SedowMisselsEffect), menuName = "Effects/ContiniuseEffect" + nameof(SedowMisselsEffect))]
public class SedowMisselsEffect : ContiniuseEffect
{

    [Space(10)]
    [SerializeField] private ShadowMissel _shadowMisselPrefab;
    [SerializeField] private float _bulletSpeed;

    protected override void Produce()
    {
        base.Produce();

        Transform playerTransform = _player.transform;
        int number = 5;

        for (int i = 0; i < number; i++)
        {
            float angel = (360f / number) * i;
            Vector3 direction = Quaternion.Euler(0, angel, 0) * playerTransform.forward;
            ShadowMissel newBullet = Instantiate(_shadowMisselPrefab, playerTransform.position, Quaternion.identity);
            newBullet.Setup(direction * _bulletSpeed, 20, 2);
        }
    }
}
