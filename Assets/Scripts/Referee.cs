using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Player enemy;

    Critter attackerCritter;
    Critter defenderCritter;
    Player attackerPlayer;
    Player defenderPlayer;

    Critter critterPlayer;
    Critter critterEnemy;

    public static event EefereeEvent OnPlayerTurn;
    public static event EefereeEvent OnEnemyTurn;

    public static event EefereeEvent OnPlayerCritterChange;
    public static event EefereeEvent OnEnemyCritterChange;

    public delegate void EefereeEvent();

    int turn;

    public static Referee Instance { get; private set; }

    public Critter AttackerCritter { get => attackerCritter; }
    public Critter DefenderCritter { get => defenderCritter; }

    public Player Player { get => player; }
    public Player Enemy { get => enemy; }

    public Critter CritterPlayer { get => critterPlayer; }
    public Critter CritterEnemy { get => critterEnemy; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        critterPlayer = player.AliveCritters[0];
        critterEnemy = enemy.AliveCritters[0];
        turn = 0;
    }

    private void EndTurn()
    {
        if (defenderCritter.IsDead)
        {
            SwapCritters(defenderPlayer, attackerPlayer, defenderCritter);
            SetNextLiveCritter();
        }

        NextTurn();
    }

    private void SetNextLiveCritter()
    {
        if (defenderPlayer.AliveCritters.Count > 0)
        {
            defenderCritter = defenderPlayer.AliveCritters[0];
            critterPlayer = player.AliveCritters[0];
            critterEnemy = enemy.AliveCritters[0];
        }
        else
        {
            defenderCritter = null;
            Unregister();
            print("End of match");
        }

        NotificateCritterChange();
    }

    private void SwapCritters(Player playerTake, Player playerPut, Critter critter)
    {
        playerPut.AddCritter(critter);
        playerTake.RemoveCritter(critter);
    }

    public void NextTurn()
    {
        turn++;

        if (turn == 1)
        {
            if (critterPlayer.BaseSpeed >= critterEnemy.BaseSpeed)
                AssignContesters(player, enemy, critterPlayer, critterEnemy);
            else
                AssignContesters(enemy, player, critterEnemy, critterPlayer);

            Register();
            NotificateCritterChange();
        }
        else
        {
            if (attackerPlayer == enemy)
            {
                if (player.AliveCritters.Count > 0)
                    AssignContesters(player, enemy, critterPlayer, critterEnemy);
                else
                {
                    // TODO: si llega aquí, es porque no tiene critters vivos, por ende, gana el otro jugador
                }

            }
            else
            {
                if (enemy.AliveCritters.Count > 0)
                    AssignContesters(enemy, player, critterEnemy, critterPlayer);
                else
                {
                    // TODO: si llega aquí, es porque no tiene critters vivos, por ende, gana el otro jugador
                }

            }
        }

        NotificateAttackTurn();
    }

    void Register()
    {
        PlayerController.OnEndAction += EndTurn;
    }

    void Unregister()
    {
        PlayerController.OnEndAction -= EndTurn;
    }

    void AssignContesters(Player attackerPlayer, Player defenderPlayer, Critter attackerCritter, Critter defenderCritter)
    {
        this.attackerPlayer = attackerPlayer;
        this.defenderPlayer = defenderPlayer;
        this.attackerCritter = attackerCritter;
        this.defenderCritter = defenderCritter;
    }

    void NotificateAttackTurn()
    {
        if (attackerPlayer == player)
            OnPlayerTurn?.Invoke();
        else
            OnEnemyTurn?.Invoke();
    }

    void NotificateCritterChange()
    {
        if (turn == 1)
        {
            OnEnemyCritterChange?.Invoke();
            OnPlayerCritterChange?.Invoke();
        }
        else
        {
            if (defenderPlayer == player)
                OnPlayerCritterChange?.Invoke();
            else
                OnEnemyCritterChange?.Invoke();
        }
    }
}
