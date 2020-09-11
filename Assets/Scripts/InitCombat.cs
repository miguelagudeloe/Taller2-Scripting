using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitCombat : MonoBehaviour
{
    [SerializeField]
    GameObject button;

    public void Init()
    {
        button.SetActive(false);
        Referee.Instance.NextTurn();
    }
}
