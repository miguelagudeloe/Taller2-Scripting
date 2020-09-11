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

    public Player Player { get => player; }
    public Player Enemy { get => enemy; }

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
        critterPlayer = player.AliveCritters[0];
        critterEnemy = enemy.AliveCritters[0];
        turn = 0;
    }

    void Update()
    {
        
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
                AssignContesters(player, enemy, critterPlayer, critterEnemy);
            else
                AssignContesters(enemy, player, critterEnemy, critterPlayer);


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
        Notificate();

    }

    void AssignContesters(Player attackerPlayer, Player defenderPlayer, Critter attackerCritter, Critter defenderCritter)
    {
        this.attackerPlayer = attackerPlayer;
        this.defenderPlayer = defenderPlayer;
        this.attackerCritter = attackerCritter;
        this.defenderCritter = defenderCritter;
    }

    void Notificate()
    {
        if (attackerPlayer == player)
            OnPlayerTurn?.Invoke();
        else
            OnEnemyTurn?.Invoke();
    }
}
