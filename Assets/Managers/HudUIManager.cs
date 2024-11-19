using UnityEngine;
using UnityEngine.UI;

public class HudUIManager : MonoBehaviour
{   
    #region PROPERTIES
    [SerializeField] private Image lifeSlider;
    [SerializeField] private Image manaSlider;

    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private GunStats _gunStats;
    private float maxLife;
    private float maxMana;
    #endregion

    void Start()
    {
        maxLife = _characterStats.MaxLife;
        maxMana = _gunStats.MaxBullets;
        EventsManager.Instance.OnLifeUpdate += OnLifeUpdate;
        EventsManager.Instance.OnManaUpdate += OnManaUpdate;
    }

    void OnLifeUpdate(float currentLife)
    {
        lifeSlider.fillAmount = currentLife / maxLife;
    }

    void OnManaUpdate(float currentMana)
    {
        manaSlider.fillAmount = currentMana / maxMana;
    }
}
