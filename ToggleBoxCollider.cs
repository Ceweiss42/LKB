using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/ToggleBoxCollider")]
	public class ToggleBoxCollider : StateData
	{
		public bool On;
		public bool OnStart;
		public bool OnEnd;
		[Space(10)]
		public bool RepositionSpheres;

		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			if (OnStart)
			{
				
				ToggleBoxCol(characterState.characterControl);
			}
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			if (OnEnd)
			{
				
				ToggleBoxCol(characterState.characterControl);
			}
		}

		private void ToggleBoxCol(CharacterControl control)
		{
			//control.RIGID_BODY.velocity = Vector3.zero;
			//control.RIGID_BODY.useGravity = On;
			control.GetComponent<BoxCollider>().enabled = false;

            if(RepositionSpheres)
			{
				control.colS.Reposition_BottomSpheres();
				control.colS.Reposition_FrontSpheres();
			}
		}
	}
}