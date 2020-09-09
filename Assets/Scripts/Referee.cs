using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    public static Referee Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
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
