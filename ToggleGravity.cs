using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/ToggleGravity")]
	public class ToggleGravity : StateData
	{
		public bool On, OnStart, OnEnd;
		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
            if (OnStart)
			{
				
				TGOff(characterState.characterControl);
			}
			
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
			characterState.characterControl.RIGID_BODY.useGravity = true;

		}

        private void TGOff(CharacterControl control)
		{
			
			control.RIGID_BODY.velocity = Vector3.zero;
			control.RIGID_BODY.useGravity = On;
		}

	}
}