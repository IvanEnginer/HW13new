using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WindEffect), menuName = "Effects/ContiniuseEffect" + nameof(WindEffect))]

public class WindEffect : ContiniuseEffect
{
    [SerializeField] private Wind _windPrefab;

    protected override void Produce()
    {
        base.Produce();

        Transform playerTransform = _player.transform;

        Wind newWind = Instantiate(_windPrefab, playerTransform.position, Quaternion.identity);
    }
}
