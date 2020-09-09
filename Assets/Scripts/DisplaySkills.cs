using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySkills : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropwdonSkill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Referee.onplayer1Turn += showDisplay;

        Referee.onplayer2Turn += hideDisplay;

    }

    private void OnDisable()
    {

        Referee.onplayer1Turn -= hideDisplay;

        Referee.onplayer2Turn -= showDisplay;
    }

    private void showDisplay()
    {
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
    }
}
