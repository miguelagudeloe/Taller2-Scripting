using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    Player enemy;

    Critter attackerCritter;
    Critter defenderCritter;
    Player currentPlayer;

    Critter critterPlayer;
    Critter critterEnemy;

    public static event refereeEvent OnPlayerTurn;
    public static event refereeEvent OnEnemyTurn;
    public delegate void refereeEvent();

    int turn;
    public static Referee Instance { get; private set; }

    public Critter Critter1 { get => critterPlayer; }
    public Critter Critter2 { get => critterEnemy; }

    private void OnEnable()
    {
        DisplaySkills.OnSelected += Attack;
    }

    private void OnDisable()
    {
        DisplaySkills.OnSelected -= Attack;
    }

    private void Start()
    {
        turn = 0;
        critterPlayer = player.Critters[0];
        critterEnemy = enemy.Critters[0];
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

            if (currentPlayer == player)
                OnPlayerTurn?.Invoke();
            else
                OnEnemyTurn?.Invoke();
        }

    }

    private void Attack(Skill skill)
    {

    }

    private void ChangeCritters(Player playerTake, Player playerPut, Critter critter)
    {
        playerPut.AddCritter(critter);
        playerTake.RemoveCritter(critter);
    }

    public void NextTurn()
    {
        turn++;
        if (turn == 1)
        {
            if (critterPlayer.BaseSpeed > critterEnemy.BaseSpeed)
            {
                currentPlayer = player;
                attackerCritter = critterPlayer;
                defenderCritter = critterEnemy;
                return;
            }
            else
            {
                currentPlayer = enemy;
                attackerCritter = critterPlayer;
                defenderCritter = critterEnemy;
                return;
            }
        }

        if (currentPlayer == enemy)
        {
            foreach (Critter critter in player.Critters)
                if (critter.IsDead == false)
                {
                    currentPlayer = player;
                    attackerCritter = critterPlayer;
                    defenderCritter = critterEnemy;
                    return;
                }

            return;
        }
        else
        {
            foreach (Critter critter in enemy.Critters)
                if (critter.IsDead == false)
                {
                    currentPlayer = enemy;
                    attackerCritter = critterPlayer;
                    defenderCritter = critterEnemy;
                    return;
                }

            return;
        }
    }
}
