using System;
using UnityEngine;

public class PlayerControllerCommander : BaseControllerCommander
{
    public PlayerControllerCommander(PlayerController owner)
    {
        this.owner = owner;
    }

    public override void Register()
    {
        DisplaySkills.OnAttackSelected += Attack;
        DisplaySkills.OnSupportSelected += Support;
    }

    public override void Unregister()
    {
        DisplaySkills.OnAttackSelected -= Attack;
        DisplaySkills.OnSupportSelected -= Support;
    }

    public override void Execute()
    {
    }

    private void Attack(AttackSkill attackSkill)
    {
        float damage = Referee.Instance.CritterPlayer.AttackDamage(attackSkill, Referee.Instance.CritterEnemy);
        Referee.Instance.CritterEnemy.TakeDamage(damage);
        EndAction();
    }

    private void Support(SupportSkill supportSkill)
    {
        supportSkill.Use(Referee.Instance.DefenderCritter);
        EndAction();
    }

}