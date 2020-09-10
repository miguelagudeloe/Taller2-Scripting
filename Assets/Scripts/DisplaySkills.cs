using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySkills : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropwdonSkill;

    Dictionary<int, Skill> skills = new Dictionary<int, Skill>();

    public delegate void DisplayEvent(Skill skill);
    public static event DisplayEvent OnSelected;

    private void OnEnable()
    {
        Referee.OnPlayerTurn += showDisplay;
        Referee.OnEnemyTurn += hideDisplay;
    }

    private void OnDisable()
    {
        Referee.OnPlayerTurn -= hideDisplay;
        Referee.OnEnemyTurn -= showDisplay;
    }

    private void showDisplay()
    {
        dropwdonSkill.gameObject.SetActive(true);

        List<string> skillList = new List<string>() { "None" };
        foreach (Skill skill in Referee.Instance.Critter1.MoveSet)
        {
            skillList.Add(skill.name);
        }
        dropwdonSkill.AddOptions(skillList);
        dropwdonSkill.Show();

        for (int i = 1; i < dropwdonSkill.options.Count; i++)
        {
            skills.Add(i, Referee.Instance.Critter1.MoveSet[i - 1]);
        }
    }

    private void hideDisplay()
    {
        dropwdonSkill.ClearOptions();
        skills.Clear();
        dropwdonSkill.gameObject.SetActive(false);
    }

    public void Select()
    {
        OnSelected?.Invoke(skills[dropwdonSkill.value]);
    }
}
