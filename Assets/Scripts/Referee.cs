using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    Player player1;
    Player player2;

    public static Referee Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        var players = FindObjectsOfType<Player>();
        player1 = players[0];
        player2 = players[1];
    }

    void Update()
    {

    }

    private void ChangeCritters(Player playerTake, Player playerPut, Critter critter)
    {
        playerPut.AddCritter(critter);
        playerTake.RemoveCritter(critter);
    }
}
