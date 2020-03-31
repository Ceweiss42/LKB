using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	[CreateAssetMenu(fileName = "New State", menuName = "Roundbeargames/AbilityData/SpawnObject")]
	public class SpawnObject : StateData
	{

		public PoolObjectType ObjectType;
		[Range(0f, 1f)]
		public float SpawnTiming;
		public string ParentObjectName = string.Empty;
		public bool StickToParent;

		public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			if (SpawnTiming == 0f)
			{
				
				SpawnObj(characterState.characterControl);
				
			}
		}

		public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{
			

			if (!characterState.characterControl.ap.PoolObjectList.Contains(ObjectType))
			{
				if (stateInfo.normalizedTime >= SpawnTiming)
				{
					
					SpawnObj(characterState.characterControl);
					
				}
			}
		}

		public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
		{

			
			if (characterState.characterControl.ap.PoolObjectList.Contains(ObjectType))
			{
                characterState.characterControl.ap.PoolObjectList.Remove(ObjectType);
			}
		}

		private void SpawnObj(CharacterControl control)
		{

			if (control.ap.PoolObjectList.Contains(ObjectType))
			{
				return;
			}

			Debug.Log("Spawning " + ObjectType.ToString() + "|||||||||||||| Looking for: " + ParentObjectName);

			GameObject obj = PoolManager.Instance.GetObject(ObjectType);

			if (!string.IsNullOrEmpty(ParentObjectName))
			{
				GameObject p = control.GetChildObj(ParentObjectName);
				obj.transform.parent = p.transform;
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
			}

            if(!StickToParent)
			{
				obj.transform.parent = null;
			}

			obj.SetActive(true);

			control.ap.PoolObjectList.Add(ObjectType);
		}
	}
}