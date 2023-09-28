using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWarriorTransition : Transitions
{
    [SerializeField] private Warrior _warrior;
    [SerializeField] private AttackEnemyState _attackEnemyState;

    private WarriorAnimations _warriorAnimations;

    private void Start()
    {
        _warriorAnimations = GetComponent<WarriorAnimations>();
    }

    private void Update()
    {
        if (_warrior.Enemy.DieCheck == true)
        {
            _warrior.CallToFight(false);
            _warrior.EnemyDead();
            _attackEnemyState.ResetAttackTime();
            _warriorAnimations.AttackAnimation(false);
            NeedTransit = true;
        }
    }
}
