﻿using System.Collections.Generic;
using UnityEngine;

using Random = System.Random;

namespace ItemData
{
    internal sealed class ItemDatabaseManager : MonoBehaviour
    {
        [Header("Weapons (Scriptable Objects)")]
        [SerializeField] private List<EquipmentDefinition> m_Daggers = new List<EquipmentDefinition>();
        [SerializeField] private List<EquipmentDefinition> m_Scimitars = new List<EquipmentDefinition>();
        [SerializeField] private List<EquipmentDefinition> m_Swords = new List<EquipmentDefinition>();
        [SerializeField] private List<EquipmentDefinition> m_Bats = new List<EquipmentDefinition>();

        [Header("Armour (Scriptable Objects)")]
        [SerializeField] private List<EquipmentDefinition> m_Helmets = new List<EquipmentDefinition>();
        [SerializeField] private List<EquipmentDefinition> m_Chestplates = new List<EquipmentDefinition>();
        [SerializeField] private List<EquipmentDefinition> m_Platelegs = new List<EquipmentDefinition>();

        [Header("Consumables (Scriptable Objects)")]
        [SerializeField] private List<ConsumableDefinition> m_HealthPotions = new List<ConsumableDefinition>();

        private Random m_Random;

        private List<List<EquipmentDefinition>> m_Weapons;

        private void Awake()
        {
            m_Random = new Random();
        }

        private void Start()
        {
            m_Weapons = new List<List<EquipmentDefinition>>
            {
                m_Daggers,
                m_Swords,
                m_Scimitars,
                m_Bats
            };
        }

        public ConsumableDefinition GetRandomHealthPotion()
        {
            var number = m_Random.Next(m_HealthPotions.Count);
            return m_HealthPotions[number];
        }

        public EquipmentDefinition GetRandomWeapon()
        {
            var rand = m_Random.Next(m_Weapons.Count);
            Debug.Log($"Database chosen: {rand}");

            var db = m_Weapons[rand];
            Debug.Log($"Database length: {db.Count}");

            var number = m_Random.Next(db.Count);
            Debug.Log($"item number from db: {number}");

            var item = db[number];
            Debug.Log($"chosen weapon slot: {item.EquipmentSlotId}");

            return item;
        }

        public EquipmentDefinition GetRandomHelmet()
        {
            return m_Helmets[m_Random.Next(m_Helmets.Count)];
        }

        public EquipmentDefinition GetRandomChestplate()
        {
            return m_Chestplates[m_Random.Next(m_Chestplates.Count)];
        }

        public EquipmentDefinition GetRandomPlatelegs()
        {
            return m_Platelegs[m_Random.Next(m_Platelegs.Count)];
        }
    }
}
