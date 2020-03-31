using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public class dest : MonoBehaviour
	{
		private CharacterControl characterControl;

		private void Awake()
		{
			characterControl = this.gameObject.GetComponent<CharacterControl>();
		}
		// Start is called before the first frame update
		/*private IEnumerator Start()
		{
			yield return new WaitForSeconds(5f);
			Debug.Log("Go");
			yield return new WaitForSeconds(1f);
			Destroy(this.gameObject);
		}*/
		// Update is called once per frame
		void Update()
		{

			//Debug.Log(characterControl.spine.transform.position);
		}
	}

}
