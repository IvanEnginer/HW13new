using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private GameStateManager _gameStateManager;

    private void Awake()
    {
        _gameStateManager.Init();
    }
}
