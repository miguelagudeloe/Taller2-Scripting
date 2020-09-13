using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ControllType controllType;

    [Header("Only AI Controll")]
    [SerializeField] float thinkTime;

    ICommand controller;

    public delegate void PlayerEvent();
    public static event PlayerEvent OnEndAction;

    string msg;

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
        if (controllType == ControllType.AI)
            Invoke("ExecuteAction", thinkTime);
        else
            controller.Execute();
    }

    private void ExecuteAction()
    {
        controller.Execute();
    }

    public void EndAction(string msg)
    {
        this.msg = msg;

        if (controllType == ControllType.AI)
            // Invoke("EndActionAI", thinkTime);
            EndActionAI();
        else
            EndActionPlayer();
    }

    private void EndActionAI()
    {
        DisplayDialogBox.Instance.SetEnemyText(msg);
        OnEndAction?.Invoke();
    }

    private void EndActionPlayer()
    {
        DisplayDialogBox.Instance.SetPlayerText(msg);
        OnEndAction?.Invoke();
    }

    private void Awake()
    {
        if (controllType == ControllType.Player)
            controller = new PlayerControllerCommander(this);
        else
            controller = new AIControllerCommander(this, thinkTime);

        controller.Register();
    }
}

public enum ControllType
{
    Player,
    AI
}
