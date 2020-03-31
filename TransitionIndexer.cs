using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{

    public enum TransitionConditionType
	{
        up,
        down,
        left,
        right,
        grabbing_ledge,
	}
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/TransitionIndexer")]
	public class TransitionIndexer : StateData
	{
		public int Index;
		public List<TransitionConditionType> transitionConditions = new List<TransitionConditionType>();
        
		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
			if(MakeTransition(characterState.characterControl))
			{
				animator.SetInteger(TransitionParameter.TransitionIndex.ToString(), Index);
			}

		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			
			if (MakeTransition(characterState.characterControl))
			{
				animator.SetInteger(TransitionParameter.TransitionIndex.ToString(), Index);
			}
            
		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			animator.SetInteger(TransitionParameter.TransitionIndex.ToString(), 0);

		}

        private bool MakeTransition(CharacterControl control)
		{
            foreach(TransitionConditionType c in transitionConditions)
			{
                switch(c)
				{
					case TransitionConditionType.up:
						{
                            if(!control.Jump)
							{
								return false;
							}
						}
						break; 

					case TransitionConditionType.down:
						{
                            if(!control.Down)
							{
								return false;
							}
						}
						break;

					case TransitionConditionType.left:
						{
							if (!control.MoveLeft)
							{
								return false;
							}
						}
						break;

					case TransitionConditionType.right:
						{
							if (!control.MoveRight)
							{
								return false;
							}
						}
						break;

					case TransitionConditionType.grabbing_ledge:
						{
                            if(!control.lc.IsGrabbingLedge)
							{
								return false;
							} 
						}
						break;

				}
			}
			return true;
		}
	}
}