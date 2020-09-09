using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable] 
class Skill : ScriptableObject
{
    [SerializeField] private string nombre;
    [SerializeField] private Affinity.AffinityType affinity;
  
    public string Name { get => nombre; }
    internal Affinity.AffinityType Affinity { get => affinity; }
}

