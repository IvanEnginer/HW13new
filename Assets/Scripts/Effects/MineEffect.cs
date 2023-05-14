using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MineEffect), menuName = "Effects/ContiniuseEffect" + nameof(MineEffect))]

public class MineEffect : ContiniuseEffect
{
    [SerializeField] private Mine _minePrefab;

    protected override void Produce()
    {
        base.Produce();

        _effectsMeneger.StartCoroutine(EffectProcess());
    }

    private IEnumerator EffectProcess()
    {
        Transform playerTransform = _player.transform;

        yield return new WaitForSeconds(2f);
        Vector3 position = _player.transform.position;
        Mine mine = Instantiate(_minePrefab, playerTransform.position, Quaternion.identity);
        mine.Setup(20);

    }
}
