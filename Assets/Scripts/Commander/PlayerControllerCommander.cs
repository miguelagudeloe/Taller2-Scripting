using System;
using UnityEngine;

public class PlayerControllerCommander : BaseControllerCommander
{
    public PlayerControllerCommander(PlayerController owner)
    {
        this.owner = owner;
    }

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

    public override void Execute()
    {
    }

    private void Attack(AttackSkill attackSkill)
    {
        Referee.Instance.CritterPlayer.Attack(attackSkill, Referee.Instance.CritterEnemy);
        EndAction();
    }

    private void Support(SupportSkill supportSkill)
    {
        supportSkill.Use(Referee.Instance.DefenderCritter);
        EndAction();
    }

}