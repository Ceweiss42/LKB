using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/TeleportOnLedge")]
	public class TeleportOnLedge : StateData
	{
		
		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			CharacterControl control = CharacterManager.Instance.GetCharacter(animator);
			Vector3 endPos = control.lc.GrabbedLedge.transform.position + control.lc.GrabbedLedge.EndPosition;

			control.transform.position = endPos;
			control.SkinnedMeshAnimator.transform.position = endPos;
			control.SkinnedMeshAnimator.transform.parent = control.transform;
			control.RIGID_BODY.velocity = Vector3.zero;
			control.GetComponent<BoxCollider>().enabled = true;

		}
	}
}