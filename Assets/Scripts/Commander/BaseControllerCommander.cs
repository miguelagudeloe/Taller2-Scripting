public abstract class BaseControllerCommander : ICommand
{
    protected PlayerController owner;

    public abstract void Execute();

    public void EndAction()
    {
        owner.EndAction();
    }
}