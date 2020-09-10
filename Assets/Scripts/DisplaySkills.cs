using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySkills : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownAttackSkill;
    [SerializeField] private TMP_Dropdown dropdownSupportSkill;

    [SerializeField] private List<string> attackSkillList = new List<string>();
    [SerializeField] private List<string> supportSkillList = new List<string>();

    Dictionary<int, AttackSkill> attackSkills = new Dictionary<int, AttackSkill>();
    Dictionary<int, SupportSkill> supportSkills = new Dictionary<int, SupportSkill>();

    public delegate void DisplayEvent(AttackSkill skill);
    public static event DisplayEvent OnAttackSelected;

    public delegate void DisplaySupportEvent(SupportSkill supportSkill);
    public static event DisplaySupportEvent OnSupportSelected;

    private void OnEnable()
    {
        Referee.OnPlayerTurn += ShowDisplay;
        Referee.OnEnemyTurn += HideDisplay;
    }

    private void OnDisable()
    {
        Referee.OnPlayerTurn -= HideDisplay;
        Referee.OnEnemyTurn -= ShowDisplay;
    }

    private void ShowDisplay()
    {
        dropdownAttackSkill.gameObject.SetActive(true);
        dropdownSupportSkill.gameObject.SetActive(true);

        attackSkillList = new List<string>() { "None" };
        supportSkillList = new List<string>() { "None" };

        int indexAttack = 1;
        int indexSupport = 1;

        for (int i = 0; i < Referee.Instance.CritterPlayer.MoveSet.Length; i++)
        {
            if (Referee.Instance.CritterPlayer.MoveSet[i] is AttackSkill)
            {
                AttackSkill skill = Referee.Instance.CritterPlayer.MoveSet[i] as AttackSkill;
                attackSkillList.Add(skill.name);
                attackSkills.Add(indexAttack++, skill);
            }
            else
            {
                SupportSkill skill = Referee.Instance.CritterPlayer.MoveSet[i] as SupportSkill;
                supportSkillList.Add(skill.name);
                supportSkills.Add(indexSupport++, skill);
            }
        }

        dropdownAttackSkill.AddOptions(attackSkillList);
        dropdownAttackSkill.Show();

        dropdownSupportSkill.AddOptions(supportSkillList);
        dropdownSupportSkill.Show();

    }

    private void HideDisplay()
    {
        dropdownAttackSkill.ClearOptions();
        attackSkills.Clear();

        dropdownSupportSkill.ClearOptions();
        supportSkills.Clear();

        dropdownAttackSkill.gameObject.SetActive(false);
        dropdownSupportSkill.gameObject.SetActive(false);
    }

    public void SelectAttackSkill()
    {
        if (dropdownAttackSkill.value != 0)
            OnAttackSelected?.Invoke(attackSkills[dropdownAttackSkill.value]);
        HideDisplay();
    }

    public void SelectSupportSkill()
    {
        if (dropdownSupportSkill.value != 0)
            OnSupportSelected?.Invoke(supportSkills[dropdownSupportSkill.value]);
        HideDisplay();
    }
}
