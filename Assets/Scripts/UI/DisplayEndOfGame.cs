using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayEndOfGame : MonoBehaviour
{
    [SerializeField] float coolDown;
    [SerializeField] TextMeshProUGUI dialog;

    private void OnEnable()
    {
        Referee.OnFinished += Init;
    }

    private void OnDisable()
    {
        Referee.OnFinished -= Init;
    }

    private void Init()
    {
        Invoke("OpenDialog", coolDown);
    }

    private void OpenDialog()
    {
        dialog.transform.parent.gameObject.SetActive(true);

        if (Referee.Instance.AttackerPlayer == Referee.Instance.Player)
            dialog.text = "You Won";
        else
            dialog.text = "You Lose";
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
