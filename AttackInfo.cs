﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class AttackInfo : MonoBehaviour
    {
        public CharacterControl Attacker = null;
        public Attack AttackAbility;
        public List<string> ColliderNames = new List<string>();
        //public List<AttackPartType> AttackParts = new List<AttackPartType>();
        //public DeathType deathType;
        public bool MustCollide;
        public bool MustFaceAttacker;
        public float LethalRange;
        public int MaxHits;
        public int CurrentHits;
        public bool isRegisterd;
        public bool isFinished;

        public void ResetInfo(Attack attack, CharacterControl attacker)
        {
            isRegisterd = false;
            isFinished = false;
            AttackAbility = attack;
            Attacker = attacker;
        }

        public void Register(Attack attack)
        {
            isRegisterd = true;

            AttackAbility = attack;
            ColliderNames = attack.ColliderNames;
            //AttackParts = attack.AttackParts;
            //deathType = attack.deathType;
            MustCollide = attack.MustCollide;
            MustFaceAttacker = attack.MustFaceAttacker;
            LethalRange = attack.LethalRange;
            MaxHits = attack.MaxHits;
            CurrentHits = 0;
        }

        private void OnDisable()
        {
            isFinished = true;
        }
    }
}
