using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/SwitchAnimator")]
	public class SwitchAnimator : StateData
	{

		public float SwitchTiming;
		public RuntimeAnimatorController TargetAnimator;

		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			//characterState.characterControlTwo.SkinnedMeshAnimator.runtimeAnimatorController = TargetAnimator;
			
		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
            //characterState.characterControlTwo.SkinnedMeshAnimator.runtimeAnimatorController = TargetAnimator;
            //if()
            //characterState.characterControlTwo.CacheCharacterControl(characterState.characterControlTwo.SkinnedMeshAnimator);
           
        }
	}
}