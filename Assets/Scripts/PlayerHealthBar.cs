using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _scale;
    [SerializeField] private PlayerHealth _playrHealth;

    private void Awake()
    {
        _playrHealth.OnHealthChange += SetScale;        
    }
    public void SetScale(float currentHealth, float maxHealth)
    {
        _scale.fillAmount = currentHealth/maxHealth;
    }
}
