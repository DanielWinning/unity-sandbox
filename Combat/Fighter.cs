﻿using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        public void Attack(CombatTarget combatTarget)
        {
            Debug.Log(combatTarget.name);
        }
    }
}