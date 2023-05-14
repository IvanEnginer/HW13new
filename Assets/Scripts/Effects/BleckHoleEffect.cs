using UnityEngine;

[CreateAssetMenu(fileName = nameof(BleckHoleEffect), menuName = "Effects/ContiniuseEffect" + nameof(BleckHoleEffect))]
public class BleckHoleEffect : ContiniuseEffect
{
    [SerializeField] private float _creationRadius = 20f;
    [SerializeField] private float _damage;
    [SerializeField] private BleckHole _bleckHolePrefab;

    protected override void Produce()
    {
        base.Produce();

        Transform playerTransform = _player.transform;

        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 position = new Vector3(randomPoint.x, 0, randomPoint.y) * _creationRadius + playerTransform.position;
        BleckHole newBleckHole = Instantiate(_bleckHolePrefab, position, Quaternion.identity);

        newBleckHole.Setup(_damage);
    }
}
