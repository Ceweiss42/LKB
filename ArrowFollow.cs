using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	
	public class ArrowFollow : MonoBehaviour
	{
		public Vector3 screenPos;
		public Vector2 onScreenPos;
		public float max;
		public Camera camera;

		void Awake()
		{
			camera = GetComponent<Camera>();
		}

		void Update()
		{
			screenPos = camera.WorldToViewportPoint(transform.position); //get viewport positions

			if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
			{
				Debug.Log("already on screen, don't bother with the rest!");
				return;
			}

			onScreenPos = new Vector2(screenPos.x - 0.5f, screenPos.y - 0.5f) * 2; //2D version, new mapping
			max = Mathf.Max(Mathf.Abs(onScreenPos.x), Mathf.Abs(onScreenPos.y)); //get largest offset
			onScreenPos = (onScreenPos / (max * 2)) + new Vector2(0.5f, 0.5f); //undo mapping
			Debug.Log(onScreenPos);
		}

	}
}
