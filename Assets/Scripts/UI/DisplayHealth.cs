using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private Slider sliderPlayer;
    [SerializeField] private Slider sliderAI;

    private void OnEnable()
    {
        Critter.OnDamageTake += Refresh;
    }

    private void OnDisable()
    {
        Critter.OnDamageTake -= Refresh;
    }

    void Refresh(Critter sender)
    {
        sliderPlayer.maxValue = Referee.Instance.CritterPlayer.MaxHP;
        sliderAI.maxValue = Referee.Instance.CritterEnemy.MaxHP;

        sliderPlayer.value = Referee.Instance.CritterPlayer.Hp;
        sliderAI.value = Referee.Instance.CritterEnemy.Hp;
    }
}
