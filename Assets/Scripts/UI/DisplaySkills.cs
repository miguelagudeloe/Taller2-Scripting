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
        PlayerController.OnEndAction += HideDisplay;
    }

    private void OnDisable()
    {
        Referee.OnPlayerTurn -= HideDisplay;
        PlayerController.OnEndAction -= ShowDisplay;
    }

    private void ShowDisplay()
    {
        Debug.Log("Se llamo prender Display");

        // HideDisplay();

        dropdownAttackSkill.gameObject.SetActive(true);
        dropdownSupportSkill.gameObject.SetActive(true);

        attackSkillList = new List<string>() { "None" };
        supportSkillList = new List<string>() { "None" };

        attackSkills = new Dictionary<int, AttackSkill>();
        supportSkills = new Dictionary<int, SupportSkill>();

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
        if (attackSkillList.Count <= 1)
            dropdownAttackSkill.gameObject.SetActive(false);
        else
            dropdownAttackSkill.Show();

        dropdownSupportSkill.AddOptions(supportSkillList);
        if (supportSkillList.Count <= 1)
            dropdownSupportSkill.gameObject.SetActive(false);
        else
            dropdownSupportSkill.Show();

    }

    private void HideDisplay()
    {
        Debug.Log("Se llamo apagar Display");
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
         //HideDisplay();
    }

    public void SelectSupportSkill()
    {
        if (dropdownSupportSkill.value != 0)
            OnSupportSelected?.Invoke(supportSkills[dropdownSupportSkill.value]);
        // HideDisplay();
    }
}
