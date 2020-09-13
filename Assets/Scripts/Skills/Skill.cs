using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class Skill : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private Affinity.AffinityType affinity;

    public string Name { get => name; }
    internal Affinity.AffinityType Affinity { get => affinity; }
}
