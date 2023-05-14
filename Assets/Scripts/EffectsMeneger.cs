using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsMeneger : MonoBehaviour
{
    [SerializeField] private List<ContiniuseEffect> _continuesEffectsApplied = new List<ContiniuseEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffectsApplied = new List<OneTimeEffect>();

    [SerializeField] private List<ContiniuseEffect> _continuesEffects = new List<ContiniuseEffect>();
    [SerializeField] private List<OneTimeEffect> _oneTimeEffects = new List<OneTimeEffect>();

    [SerializeField] private CardManager _cardManager;

    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private Player _player;

    private void Awake()
    {
        for (int i = 0; i < _continuesEffects.Count; i++)
        {
            _continuesEffects[i] = Instantiate(_continuesEffects[i]);
            _continuesEffects[i].Initialize(this, _enemyManager, _player);
        }

        for (int i = 0; i < _oneTimeEffects.Count; i++)
        {
            _oneTimeEffects[i] = Instantiate(_oneTimeEffects[i]);
            _oneTimeEffects[i].Initialize(this, _enemyManager, _player);
        }
    }

    private void Update()
    {
        foreach (var effect in _continuesEffectsApplied)
        {
            effect.ProcessFrame(Time.deltaTime);
        }
    }

    [ContextMenu("ShowCards")]
    public void ShowCards()
    {
        List<Effect> effectsToShow = new List<Effect>();

        for (int i = 0; i < _continuesEffectsApplied.Count; i++)
            if (_continuesEffectsApplied[i].Level < 10)
                effectsToShow.Add(_continuesEffectsApplied[i]);

        for (int i = 0; i < _oneTimeEffectsApplied.Count; i++)
            if (_oneTimeEffectsApplied[i].Level < 10)
                effectsToShow.Add(_oneTimeEffectsApplied[i]);

        if (_continuesEffectsApplied.Count < 4)
            effectsToShow.AddRange(_continuesEffects);

        if (_oneTimeEffectsApplied.Count < 4)
            effectsToShow.AddRange(_oneTimeEffects);

        int numverOfCardsToShow = Mathf.Min(effectsToShow.Count, 3);

        int[] randomIndexes = RandomSort(effectsToShow.Count, numverOfCardsToShow);

        List<Effect> effectsForCards = new List<Effect>();

        for (int i = 0; i < randomIndexes.Length; i++)
        {
            int index = randomIndexes[i];
            effectsForCards.Add(effectsToShow[index]);
        }

        StartCoroutine(WaitForShow(effectsForCards));
    }

    private IEnumerator WaitForShow(List<Effect> effects)
    {
        yield return new WaitForSeconds(1);

        _cardManager.ShowCards(effects);
    }

    private int[] RandomSort(int lenght, int number)
    {
        int[] array = new int[lenght];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        for (int i = 0; i < array.Length; i++)
        {
            int oldValue = array[i];
            int newIndex = UnityEngine.Random.Range(0, array.Length);
            array[i] = array[newIndex];
            array[newIndex] = oldValue;
        }

        int[] result = new int[number];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = array[i];
        }
        return result;
    }

    public void AddEffect(Effect effect)
    {
        if(effect is ContiniuseEffect c_effect)
        {
            if(!_continuesEffectsApplied.Contains(c_effect))
            {
                _continuesEffectsApplied.Add(c_effect);
                _continuesEffects.Remove(c_effect);
            }
            else if(effect is OneTimeEffect o_effect)
            {
                if(!_oneTimeEffectsApplied.Contains(o_effect))
                {
                    _oneTimeEffectsApplied.Remove(o_effect);
                    _oneTimeEffects.Add(o_effect);
                }
            }

            //effect.Activate();
        }
    }
}
