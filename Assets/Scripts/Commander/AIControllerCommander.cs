
public class AIControllerCommander : BaseControllerCommander
{
    System.Random rand;

    public AIControllerCommander(PlayerController owner)
    {
        this.owner = owner;
        rand = new System.Random();
    }

    public override void Execute()
    {
        Critter mine = Referee.Instance.AttackerCritter;
        Critter enemy = Referee.Instance.DefenderCritter;

        Skill[] moves = mine.MoveSet;
        int ind = rand.Next(moves.Length);

        Skill skill = moves[ind];

        if (skill is AttackSkill)
            mine.Attack(skill as AttackSkill, enemy);
        else
        {
            SupportSkill supportSkill = skill as SupportSkill;
            supportSkill.Use(mine);
        }

        EndAction();
    }

}