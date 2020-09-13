using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDialogBox : MonoBehaviour
{
    [SerializeField] float vanishTime;

    [SerializeField] TextMeshProUGUI dialogPlayer;
    [SerializeField] TextMeshProUGUI dialogEnemy;
    [SerializeField] TextMeshProUGUI dialogReferee;

    public static DisplayDialogBox Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }

    public void SetPlayerText(string msg)
    {
        dialogPlayer.text = msg;
        StartCoroutine("ClearText", dialogPlayer);
    }

    public void SetEnemyText(string msg)
    {
        dialogEnemy.text = msg;
        StartCoroutine("ClearText", dialogEnemy);
    }

    public void SetRefereeText(string msg)
    {
        dialogReferee.text = msg;
    }

    private IEnumerator ClearText(TextMeshProUGUI dialog)
    {
        yield return new WaitForSeconds(vanishTime);
        dialog.text = "";
    }
}
