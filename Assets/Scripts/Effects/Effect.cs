using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string Name;
    [TextArea(1, 3)]
    public string Description;
    public Sprite Sprite;
    public int Level = -1;

    protected EffectsMeneger _effectsMeneger;
    protected Player _player;
    protected EnemyManager _enemyManager;

    public virtual void Initialize(EffectsMeneger effectsMeneger, EnemyManager enemyManager, Player player)
    {
        _effectsMeneger = effectsMeneger;
        _player = player;
        _enemyManager = enemyManager;
    }

    public virtual void Activate()
    {
        Level++;
    }
}
