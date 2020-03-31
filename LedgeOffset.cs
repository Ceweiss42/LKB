using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/Offset-Ledge")]
	public class LedgeOffset : StateData
	{

		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
			GameObject anim = characterState.characterControl.SkinnedMeshAnimator.gameObject;
			anim.transform.parent = characterState.characterControl.lc.GrabbedLedge.transform;
			anim.transform.localPosition = characterState.characterControl.lc.GrabbedLedge.Offset;

            characterState.characterControl.RIGID_BODY.velocity = Vector3.zero;
			
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			

		}
	}
}