using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


    abstract class SupportSkill : Skill
    {
        [SerializeField]
        private float power;

        private void Start ()
        {
            // El rango del poder es de 0 a 10. Pero los SupportSkils no pueden ser mayores a 0
            power = (power != 0) ? 0 : power;
        }

        public abstract void Use(Critter critter);

        public float Power { get => power; }

    }

