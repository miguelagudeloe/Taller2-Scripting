using System.Collections;
using UnityEngine;

public class AIControllerCommander : BaseControllerCommander
{
    float thinkTime;

    System.Random rand;

    float currentTime;

    public AIControllerCommander(PlayerController owner, float time)
    {
        this.owner = owner;
        thinkTime = time;
        currentTime = 0;
        rand = new System.Random();
    }

    public override void Execute()
    {
        // currentTime = thinkTime;
        // StartCoroutine("Attack");
        Attack();
    }

    // private void Update()
    // {
    //     if (currentTime == thinkTime)
    //         Attack();

    //     currentTime -= Time.deltaTime;
    // }

    private void Attack()
    {
        Critter mine = Referee.Instance.AttackerCritter;
        Critter enemy = Referee.Instance.DefenderCritter;

        Skill[] moves = mine.MoveSet;
        int ind = rand.Next(moves.Length);

        Skill skill = moves[ind];

        string msg;

        if (skill is AttackSkill)
        {
            float damage = mine.AttackDamage(skill as AttackSkill, enemy);
            Referee.Instance.CritterPlayer.TakeDamage(damage);

            msg = $"Used {skill.Name} \nDamage {damage}";
        }
        else
        {
            SupportSkill supportSkill = skill as SupportSkill;
            supportSkill.Use(mine);

            msg = $"Selected {skill.Name} \n{mine.LastUpgraded}";
        }

        EndAction(msg);
    }

    public override void Register()
    {
    }

    public override void Unregister()
    {
    }

}