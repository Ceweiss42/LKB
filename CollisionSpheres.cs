using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public class CollisionSpheres : MonoBehaviour
	{
        public CharacterControl owner;
        public List<GameObject> BottomSpheres = new List<GameObject>();
        public List<GameObject> FrontSpheres = new List<GameObject>();
        public List<GameObject> BackSpheres = new List<GameObject>();

        public void Reposition_FrontSpheres()
        {
            float bottom = owner.boxCollider.bounds.center.y - owner.boxCollider.bounds.extents.y;
            float top = owner.boxCollider.bounds.center.y + owner.boxCollider.bounds.extents.y;
            float front = owner.boxCollider.bounds.center.z + owner.boxCollider.bounds.extents.z;

            FrontSpheres[0].transform.localPosition = new Vector3(0f, bottom + 0.05f, front) - this.transform.position;
            FrontSpheres[1].transform.localPosition = new Vector3(0f, top, front) - this.transform.position;

            float interval = (top - bottom + 0.05f) / 9;

            for (int i = 2; i < FrontSpheres.Count; i++)
            {
                FrontSpheres[i].transform.localPosition = new Vector3(0f, bottom + (interval * (i - 1)), front) - this.transform.position;
            }
        }

        public void Reposition_BackSpheres()
        {
            float bottom = owner.boxCollider.bounds.center.y - owner.boxCollider.bounds.extents.y;
            float top = owner.boxCollider.bounds.center.y + owner.boxCollider.bounds.extents.y;
            float back = owner.boxCollider.bounds.center.z - owner.boxCollider.bounds.extents.z;

            BackSpheres[0].transform.localPosition = new Vector3(0f, bottom + 0.05f, back) - this.transform.position;
            BackSpheres[1].transform.localPosition = new Vector3(0f, top, back) - this.transform.position;

            float interval = (top - bottom + 0.05f) / 9;

            for (int i = 2; i < BackSpheres.Count; i++)
            {
                BackSpheres[i].transform.localPosition = new Vector3(0f, bottom + (interval * (i - 1)), back) - this.transform.position;
            }
        }

        public void Reposition_BottomSpheres()
        {
            float bottom = owner.boxCollider.bounds.center.y - owner.boxCollider.bounds.extents.y;
            float front = owner.boxCollider.bounds.center.z + owner.boxCollider.bounds.extents.z;
            float back = owner.boxCollider.bounds.center.z - owner.boxCollider.bounds.extents.z;

            BottomSpheres[0].transform.localPosition = new Vector3(0f, bottom, back) - this.transform.position;
            BottomSpheres[1].transform.localPosition = new Vector3(0f, bottom, front) - this.transform.position;

            float interval = (front - back) / 4;

            for (int i = 2; i < BottomSpheres.Count; i++)
            {
                BottomSpheres[i].transform.localPosition = new Vector3(0f, bottom, back + (interval * (i - 1))) - this.transform.position;
            }
        }

        public void SetColliderSpheres()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject; //Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);

                BottomSpheres.Add(obj);
                obj.transform.parent = this.transform.Find("Bottom");
            }

            Reposition_BottomSpheres();

            for (int i = 0; i < 10; i++)
            {
                GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject; //Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);

                FrontSpheres.Add(obj);
                obj.transform.parent = this.transform.Find("Front");
            }
            Reposition_FrontSpheres();


            for (int i = 0; i < 10; i++)
            {
                GameObject obj = Instantiate(Resources.Load("ColliderEdge", typeof(GameObject)), Vector3.zero, Quaternion.identity) as GameObject; //Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);

                BackSpheres.Add(obj);
                obj.transform.parent = this.transform.Find("Back");
            }

            Reposition_BackSpheres();
        }

    }
}