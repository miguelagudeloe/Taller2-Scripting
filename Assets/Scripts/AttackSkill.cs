using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

    [CreateAssetMenu(fileName = "new skill", menuName = "AttackSkill")]
    class AttackSkill : Skill
    {
        [SerializeField]
        private float power;

       /* private void Start()
        {
            // El rango del poder es de 0 a 10. Pero los AttackSkils no pueden ser menores a 1
            power = Mathf.Clamp(power, 1, 10);
        }*/

        public float Power { get => power; }
    }

