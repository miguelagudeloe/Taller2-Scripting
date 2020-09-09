using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

abstract class SupportSkill : Skill
{
    [SerializeField] private float power;

    public abstract void Use(Critter critter);

    public float Power { get => (power != 0) ? 0 : power; }
}
