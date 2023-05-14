using UnityEngine;

public class ActionState : GameState
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private RigitbodyMove _rigitbodyMove;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private ExperiansManager _experiansManager;

    public override void EnterFirstTime()
    {
        base.EnterFirstTime();
        _enemyManager.StartNewWave(0);
        _experiansManager.UpLavel();
    }

    public override void Enter()
    {
        base.Enter();
        _joystick.Activate();
        _rigitbodyMove.enabled = true;
    }

    public override void Exit() 
    { 
        base.Exit();
        _joystick.Deactivate();
        _rigitbodyMove.enabled = false;
    }


}
