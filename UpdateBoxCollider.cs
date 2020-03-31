using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/UpdateBoxCollider")]
	public class UpdateBoxCollider : StateData
	{

		public Vector3 targetSize, targetCenter;
		public float sizeUpdateSpeed, centerUpdateSpeed;

		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

            characterState.characterControl.ap.Updating = true;
            characterState.characterControl.ap.Updating_Spheres = true;
            characterState.characterControl.ap.targetSize = targetSize;
            characterState.characterControl.ap.sizeSpeed = sizeUpdateSpeed;
            characterState.characterControl.ap.targetCenter = targetCenter;
            characterState.characterControl.ap.centerSpeed = centerUpdateSpeed;
			
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

            characterState.characterControl.ap.Updating = false;
            characterState.characterControl.ap.Updating_Spheres = false;

		}
	}
}