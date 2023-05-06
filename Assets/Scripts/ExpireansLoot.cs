using UnityEngine;

public class ExpireansLoot : Loot
{
    [SerializeField] private int _expirenceValue;

    public override void Take(Collector collector)
    {
        base.Take(collector);

        collector.TakeExperiancr(_expirenceValue);
    }
}
