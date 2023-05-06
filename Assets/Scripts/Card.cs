using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _iconBackground;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _continuousEffectSprite;
    [SerializeField] private Sprite _oneTimeEffectSprite;

    private Effect _effect;

    private EffectsMeneger _effectMeneger;
    private CardManager _cardManager;

    public void Init(EffectsMeneger effectMeneger, CardManager cardManager)
    {
        _effectMeneger = effectMeneger;
        _cardManager = cardManager;
        _button.onClick.AddListener(Click);
    }

    public void Show(Effect effect)
    {
        _effect = effect;
        _nameText.text = _effect.Name;
        _descriptionText.text = _effect.Description;
        _levelText.text = effect.ToString();
        _iconImage.sprite = effect.Sprite;

        if(effect is ContiniuseEffect)
        {
            _iconBackground.sprite = _continuousEffectSprite;
        }
        else if (effect is OneTimeEffect)
        {
            _iconBackground.sprite = _oneTimeEffectSprite;
        }
    }

    public void Click()
    {
        _effectMeneger.AddEffect(_effect);
        _cardManager.Hide();
    }
}
