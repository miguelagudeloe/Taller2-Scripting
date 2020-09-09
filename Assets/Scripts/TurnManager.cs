using UnityEngine;

public class TurnManager : MonoBehaviour
{
    Player player1;
    Player player2;

    public static TurnManager Instance { get; private set; }

    int turn;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;

        var players = FindObjectsOfType<Player>();
        player1 = players[0];
        player2 = players[1];
    }

    private void Start()
    {
        turn = 0;
    }

    public Critter NextTurn()
    {
        turn++;

        if (turn % 2 == 1)
        {
            foreach (Critter critter in player1.Critters)
                if (critter != null)
                    return critter;
            return null;
        }
        else
        {
            foreach (Critter critter in player2.Critters)
                if (critter != null)
                    return critter;
            return null;
        }
    }
}