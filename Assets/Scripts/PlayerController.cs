using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ControllType controllType;

    ICommand controller;

    public delegate void PlayerEvent();
    public static event PlayerEvent OnEndAction;

    private void OnEnable()
    {
        if (controllType == ControllType.Player)
            Referee.OnPlayerTurn += Execute;
        else
            Referee.OnEnemyTurn += Execute;
    }

    private void OnDisable()
    {
        controller.Unregister();
    }

    private void Execute()
    {
        controller.Execute();
    }

    public void EndAction()
    {
        OnEndAction?.Invoke();
    }

    private void Awake()
    {
        if (controllType == ControllType.Player)
            controller = new PlayerControllerCommander(this);
        else
            controller = new AIControllerCommander(this);

        controller.Register();
    }
}

public enum ControllType
{
    Player,
    IA
}
