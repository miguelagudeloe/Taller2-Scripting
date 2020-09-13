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

        string msg = $"Used {attackSkill.Name} \nDamage {damage}";
        EndAction(msg);
    }

    private void Support(SupportSkill supportSkill)
    {
        supportSkill.Use(Referee.Instance.AttackerCritter);

        string msg = $"Selected {supportSkill.Name} \n{Referee.Instance.AttackerCritter.LastUpgraded}";
        EndAction(msg);
    }

}