﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Cartwheel")]
	public class Cartwheel : StateData
	{
		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			animator.SetBool(TransitionParameter.Jump.ToString(), false);
			animator.SetBool(TransitionParameter.Attack.ToString(), false);
			animator.SetBool(TransitionParameter.Cartwheel.ToString(), false);
			animator.SetBool(TransitionParameter.Move.ToString(), false);
            
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			animator.SetBool(TransitionParameter.Jump.ToString(), false);
			animator.SetBool(TransitionParameter.Attack.ToString(), false);
			animator.SetBool(TransitionParameter.Cartwheel.ToString(), false);
			animator.SetBool(TransitionParameter.Move.ToString(), false);
		}
	}
}