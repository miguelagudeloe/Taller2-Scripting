using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySkills : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdownAttackSkill;
    [SerializeField] private TMP_Dropdown dropdownSupportSkill;

    [SerializeField]
    private List<string> attackSkillList = new List<string>();
    [SerializeField]
    private List<string> supportSkillList = new List<string>();



    Dictionary<int, AttackSkill> attackSkills = new Dictionary<int, AttackSkill>();
    Dictionary<int, SupportSkill> supportSkills = new Dictionary<int, SupportSkill>();

    public delegate void DisplayEvent(AttackSkill skill);
    public static event DisplayEvent OnAttackSelected;

    public delegate void DisplaySupportEvent(SupportSkill supportSkill);
    public static event DisplaySupportEvent OnSupportSelected;

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
        dropdownAttackSkill.gameObject.SetActive(true);
        dropdownSupportSkill.gameObject.SetActive(true);

         attackSkillList = new List<string>() { "None" };
         supportSkillList = new List<string>() { "None" };

        int indexAttack = 1;
        int indexSupport = 1;

        for (int i = 0; i < Referee.Instance.Critter1.MoveSet.Length; i++)
        {

            if (Referee.Instance.Critter1.MoveSet[i] is AttackSkill)
            {
                AttackSkill skill = Referee.Instance.Critter1.MoveSet[i] as AttackSkill;
                attackSkillList.Add(skill.name);

                attackSkills.Add(indexAttack++, skill);
            }


            else
            {
                SupportSkill skill = Referee.Instance.Critter1.MoveSet[i] as SupportSkill;
                supportSkillList.Add(skill.name);
                supportSkills.Add(indexSupport++, skill);
            }
                

        }
                
        dropdownAttackSkill.AddOptions(attackSkillList);
        dropdownAttackSkill.Show();

        dropdownSupportSkill.AddOptions(supportSkillList);
        dropdownSupportSkill.Show();

        
    }

    private void hideDisplay()
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
        foreach (var item in attackSkills)
        {
            print(item);
        }
        
        if(dropdownAttackSkill.value!=0)
        OnAttackSelected?.Invoke(attackSkills[dropdownAttackSkill.value]);
        hideDisplay();
    }

    public void SelectSupportSkill()
    {
        foreach (var item in supportSkills)
        {
            print(item);
        }
        if (dropdownSupportSkill.value!=0)
          OnSupportSelected?.Invoke(supportSkills[dropdownSupportSkill.value]);
          hideDisplay();
    }
}
