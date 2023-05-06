using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperiansManager : MonoBehaviour
{
    [SerializeField] private float _expiriance = 0;
    [SerializeField] private float _nextLevelExperiance = 5;

    private int _level;

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _experianceSclae;

    [SerializeField] private EffectsMeneger _effectsMeneger;

    [SerializeField] private AnimationCurve _experianceCurve;

    private void Awake()
    {
        _nextLevelExperiance = _experianceCurve.Evaluate(0);
    }

    public void AddExperience(int value)
    {
        _expiriance += value;

        if (_expiriance >= _nextLevelExperiance)
        {
            UpLavel();
        }

        DisplayExperience();
    }

    public void UpLavel()
    {
        _level++;
        _effectsMeneger.ShowCards();
        _levelText.text = _level.ToString();
        _expiriance = 0;
        _nextLevelExperiance = _experianceCurve.Evaluate(_level);
    }

    public void DisplayExperience()
    {
        _experianceSclae.fillAmount = _expiriance/ _nextLevelExperiance;
    }
}
