using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySkills : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropwdonSkill;

    private void OnEnable()
    {
        Referee.OnPlayer1Turn += showDisplay;
        Referee.OnPlayer2Turn += hideDisplay;
    }

    private void OnDisable()
    {
        Referee.OnPlayer1Turn -= hideDisplay;
        Referee.OnPlayer2Turn -= showDisplay;
    }

    private void showDisplay()
    {
        dropwdonSkill.gameObject.SetActive(true);

        List<string> skillList = new List<string>();
        foreach (Skill skill in Referee.Instance.Critter1.MoveSet)
        {
            skillList.Add(skill.name);
        }
        dropwdonSkill.AddOptions(skillList);
    }

    private void hideDisplay()
    {
        dropwdonSkill.ClearOptions();

        dropwdonSkill.gameObject.SetActive(false);
    }
}
