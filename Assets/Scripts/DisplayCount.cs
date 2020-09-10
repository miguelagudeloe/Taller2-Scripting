using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCount : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI alivePlayer;
    [SerializeField]
    TextMeshProUGUI deadPlayer;
    [SerializeField]
    TextMeshProUGUI aliveEnemy;
    [SerializeField]
    TextMeshProUGUI deadEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        alivePlayer.text = Referee.Instance.Player.AliveCritters.Count.ToString();
        deadPlayer.text = Referee.Instance.Player.DeadCritters.Count.ToString();

        aliveEnemy.text = Referee.Instance.Enemy.AliveCritters.Count.ToString();
        deadEnemy.text = Referee.Instance.Enemy.DeadCritters.Count.ToString();
    }
}
