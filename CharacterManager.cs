using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    
	public class CharacterManager : Singleton<CharacterManager>
	{
		public List<CharacterControl> Characters = new List<CharacterControl>();

		public CharacterControl GetCharacter(PCT playableCharacterType)
		{
			foreach (CharacterControl control in Characters)
			{
				if (control.playableCharacterType == playableCharacterType)
				{
					return control;
				}
			}

			return null;
		}

		public CharacterControl GetCharacter(Animator animator)
		{
			foreach (CharacterControl control in Characters)
			{
				if (control.SkinnedMeshAnimator == animator)
				{
					return control;
				}
			}

			return null;
		}

        public CharacterControl GetPlayableCharacter()
		{
            
			foreach (CharacterControl control in Characters)
			{
				ManualInput manual = control.GetComponent<ManualInput>();

                if(manual != null)
				{
                    if(manual.enabled == true)
					{
						return control;
					}
				}
				
			}

			return null;

		}
	}
}