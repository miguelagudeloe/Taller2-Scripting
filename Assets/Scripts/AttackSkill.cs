using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "new skill", menuName = "AttackSkill")]
class AttackSkill : Skill
{
    [SerializeField]
    private float power;

    public float Power { get => power = Mathf.Clamp(power, 1, 10); }
}

