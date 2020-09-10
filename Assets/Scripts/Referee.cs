using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField]
    Player player1;
    [SerializeField]
    Player player2;

    Critter currentCritter;
    Player currentPlayer;

    Critter critter1;
    Critter critter2;

    public static event refereeEvent OnPlayer1Turn;
    public static event refereeEvent OnPlayer2Turn;
    public delegate void refereeEvent();

    int turn;
    public static Referee Instance { get; private set; }

    public Critter Critter1 { get => critter1; }
    public Critter Critter2 { get => critter2; }


    private void Start()
    {
        turn = 0;
        critter1 = player1.Critters[0];
        critter2 = player2.Critters[0];


    }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NextTurn();

            if (currentPlayer == player1)
                OnPlayer1Turn?.Invoke();
            else
                OnPlayer2Turn?.Invoke();
        }


    }

    private void ChangeCritters(Player playerTake, Player playerPut, Critter critter)
    {
        playerPut.AddCritter(critter);
        playerTake.RemoveCritter(critter);
    }


    public Critter NextTurn()
    {
        turn++;
        if (turn == 1)
        {
            if (critter1.BaseSpeed > critter2.BaseSpeed)
            {
                currentPlayer = player1;
                return critter1;
            }
            else
            {
                currentPlayer = player2;
                return critter2;
            }
        }

        if (currentPlayer == player2)
        {
            foreach (Critter critter in player1.Critters)
                if (critter.IsDead == false)
                {
                    currentPlayer = player1;
                    return critter;
                }

            return null;
        }
        else
        {
            foreach (Critter critter in player2.Critters)
                if (critter.IsDead == false)
                {
                    currentPlayer = player2;
                    return critter;
                }

            return null;
        }
    }
}
