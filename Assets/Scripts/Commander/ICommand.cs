public interface ICommand
{
    void Execute();
    void Register();
    void Unregister();
}