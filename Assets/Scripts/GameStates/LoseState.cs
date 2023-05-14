using UnityEngine;

public class LoseState : GameState
{
    [SerializeField] private LoseWindow _loseWindow;

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0f;
        _loseWindow.Show();
    }
}
