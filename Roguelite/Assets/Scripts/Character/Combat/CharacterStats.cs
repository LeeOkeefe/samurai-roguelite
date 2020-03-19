﻿using Character.Health;
using Player;
using Player.Experience;
using UnityEngine;
using Random = System.Random;

namespace Character.Combat
{
    [RequireComponent(typeof(HealthObject))]
    internal sealed class CharacterStats : MonoBehaviour
    {
        [SerializeField] private int CombatLevel;
        [SerializeField] private Stat m_Damage;
        [SerializeField] private Stat m_Defence;

        private HealthObject m_HealthObject;
        private ExperienceObject m_PlayerExperience;

        private Random m_Random;

        private void Awake()
        {
            m_HealthObject = GetComponent<HealthObject>();
            m_Random = new Random();
        }

        private void Start()
        {
            m_PlayerExperience = GameManager.Instance.PlayerManager.Experience;
        }

        public void TakeDamage(int damage)
        {
            var damageRange = m_Random.Next(damage);
            var defenceRange = m_Random.Next(m_Defence.GetBaseValue());
            var range = (damageRange - defenceRange);

            if (range < 0)
                range = 0;

            Debug.Log($"Character took {range} amount of damage.");
            m_HealthObject.Damage(range);

            if (m_HealthObject.CurrentHealth <= 0)
            {
                m_PlayerExperience.IncreaseExperience(CombatLevel * 10);
                Debug.Log("Character dead.");
            }
        }
    }
}
