using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public class AnimationProgress : MonoBehaviour
	{
		public List<PoolObjectType> PoolObjectList = new List<PoolObjectType>();

		[Header("UpdateBoxCollider")]
		public float sizeSpeed, centerSpeed;
		public Vector3 targetSize, targetCenter;
		public bool Updating;
		public bool Updating_Spheres;
        public bool Taking_Damage;

	}
}
