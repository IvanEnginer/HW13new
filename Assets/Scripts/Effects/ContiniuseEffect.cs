using UnityEngine;

public class ContiniuseEffect : Effect
{
    [SerializeField] private float _colldown;
    private float _timer;

    public void ProcessFrame(float frameTime)
    {
        _timer += frameTime;
        if (_timer > _colldown) 
        {
            Produce();
            _timer = 0f;
        }
    }

    protected virtual void Produce()
    {

    }
}
