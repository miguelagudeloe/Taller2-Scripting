public abstract class BaseControllerCommander : ICommand
{
    protected PlayerController owner;

    public abstract void Execute();

    public abstract void Register();

    public abstract void Unregister();

    public void EndAction()
    {
        owner.EndAction();
    }

}