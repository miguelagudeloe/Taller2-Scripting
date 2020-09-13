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
        Referee.OnPlayerTurn += Refresh;
        Referee.OnEnemyTurn += Refresh;
        Referee.OnFinished += Desactivate;
    }

    private void Unregister()
    {
        Referee.OnPlayerTurn -= Refresh;
        Referee.OnEnemyTurn -= Refresh;
        Referee.OnFinished -= Desactivate;
    }

    private void Refresh()
    {
        if (Referee.Instance.CritterPlayer != null)
        {
            sliderPlayer.maxValue = Referee.Instance.CritterPlayer.MaxHP;
            sliderPlayer.value = Referee.Instance.CritterPlayer.Hp;
        }
        if (Referee.Instance.CritterEnemy != null)
        {
            sliderAI.maxValue = Referee.Instance.CritterEnemy.MaxHP;
            sliderAI.value = Referee.Instance.CritterEnemy.Hp;
        }
    }

    private void Desactivate()
    {
        sliderPlayer.transform.gameObject.SetActive(false);
        sliderAI.transform.gameObject.SetActive(false);

        Unregister();
    }
}
