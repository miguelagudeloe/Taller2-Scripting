using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI alivePlayer;
    [SerializeField] TextMeshProUGUI deadPlayer;
    [SerializeField] TextMeshProUGUI aliveEnemy;
    [SerializeField] TextMeshProUGUI deadEnemy;


    // Update is called once per frame
    void Update()
    {
        alivePlayer.text = $"x{Referee.Instance.Player.AliveCritters.Count.ToString()}";
        deadPlayer.text = $"x{Referee.Instance.Player.DeadCritters.Count.ToString()}";

        aliveEnemy.text = $"x{Referee.Instance.Enemy.AliveCritters.Count.ToString()}";
        deadEnemy.text = $"x{Referee.Instance.Enemy.DeadCritters.Count.ToString()}";
    }
}
