using UnityEngine;

public class CardState : GameState
{
    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0f;
    }

    public override void Exit()
    { 
        base.Exit();
        Time.timeScale = 1f;
    }
}
