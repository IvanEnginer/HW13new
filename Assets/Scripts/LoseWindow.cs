using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWindow : MonoBehaviour
{
    [SerializeField] private Button _comtinueButton;

    private void Awake()
    {
        _comtinueButton.onClick.AddListener(Continue);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
