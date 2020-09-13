using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Referee : MonoBehaviour
{
    [SerializeField] float coolDown;

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
    public static event EefereeEvent OnFinished;

    public static event EefereeEvent OnPlayerCritterChange;
    public static event EefereeEvent OnEnemyCritterChange;

    public delegate void EefereeEvent();

    int turn;

    bool hasFinished;

    public static Referee Instance { get; private set; }

    public Critter AttackerCritter { get => attackerCritter; }
    public Critter DefenderCritter { get => defenderCritter; }

    public Player Player { get => player; }
    public Player Enemy { get => enemy; }

    public Critter CritterPlayer { get => critterPlayer; }
    public Critter CritterEnemy { get => critterEnemy; }
    public Player AttackerPlayer { get => attackerPlayer; }
    public Player DefenderPlayer { get => defenderPlayer; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        turn = 0;
        hasFinished = false;
    }

    private void EndTurn()
    {
        if (defenderCritter.IsDead)
        {
            SwapCritters(defenderPlayer, attackerPlayer, defenderCritter);
            SetNextLiveCritter();
        }

        if (!hasFinished)
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

            if (defenderPlayer == player)
                critterPlayer = null;
            else
                critterEnemy = null;

            hasFinished = true;

            Unregister();
            DisplayMessage("End of game");

            OnFinished?.Invoke();
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
            critterPlayer = player.AliveCritters[0];
            critterEnemy = enemy.AliveCritters[0];

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
            }
            else
            {
                if (enemy.AliveCritters.Count > 0)
                    AssignContesters(enemy, player, critterEnemy, critterPlayer);
            }
        }

        Invoke("NotificateAttackTurn", coolDown);

        DisplayMessage($"Turn {turn} \nAttacker {attackerPlayer.name} \nCritter {attackerCritter.name}");
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

    void DisplayMessage(string msg)
    {
        DisplayDialogBox.Instance.SetRefereeText(msg);
    }
}
