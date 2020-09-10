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
    public delegate void EefereeEvent();

    int turn;

    public static Referee Instance { get; private set; }

    public Critter CritterPlayer { get => critterPlayer; }
    public Critter CritterEnemy { get => critterEnemy; }

    private void OnEnable()
    {
        DisplaySkills.OnAttackSelected += Attack;
        DisplaySkills.OnSupportSelected += Support;
    }

    private void OnDisable()
    {
        DisplaySkills.OnAttackSelected -= Attack;
        DisplaySkills.OnSupportSelected -= Support;
    }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        critterPlayer = player.Critters[0];
        critterEnemy = enemy.Critters[0];
        turn = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NextTurn();

            if (attackerPlayer == player)
                OnPlayerTurn?.Invoke();
            else
                OnEnemyTurn?.Invoke();
        }
    }

    private void Attack(AttackSkill attackSkill)
    {
        attackerCritter.Attack(attackSkill, defenderCritter);
        if (defenderCritter.IsDead)
            SwapCritters(attackerPlayer, defenderPlayer, defenderCritter);
        NextTurn();
    }

    private void Support(SupportSkill supportSkill)
    {
        supportSkill.Use(attackerCritter);
        NextTurn();
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
                AsignContesters(player, enemy, critterPlayer, critterEnemy);
            else
                AsignContesters(enemy, player, critterEnemy, critterPlayer);

            return;
        }

        if (attackerPlayer == enemy)
        {
            foreach (Critter critter in player.Critters)
                if (critter.IsDead == false)
                {
                    AsignContesters(player, enemy, critterPlayer, critterEnemy);
                    return;
                }

            // TODO: si llega aquí, es porque no tiene critters vivos, por ende, gana el otro jugador

            return;
        }
        else
        {
            foreach (Critter critter in enemy.Critters)
                if (critter.IsDead == false)
                {
                    AsignContesters(enemy, player, critterEnemy, critterPlayer);
                    return;
                }

            // TODO: si llega aquí, es porque no tiene critters vivos, por ende, gana el otro jugador

            return;
        }
    }

    void AsignContesters(Player attackerPlayer, Player defenderPlayer, Critter attackerCritter, Critter defenderCritter)
    {
        this.attackerPlayer = attackerPlayer;
        this.defenderPlayer = defenderPlayer;
        this.attackerCritter = attackerCritter;
        this.defenderCritter = defenderCritter;
    }
}
