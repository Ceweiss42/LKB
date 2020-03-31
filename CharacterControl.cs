using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
        Grounded,
        Attack,
        Cartwheel,
        Headbutt,
        BellyFlop,
        TransitionIndex,
        Smash,
        HammerDown,
        Sidekick,
        Shift,



    }

    public class CharacterControl : MonoBehaviour
    {
		public float weight;
		public PCT playableCharacterType;
        public Animator SkinnedMeshAnimator;
        public bool MoveRight;
        public bool MoveLeft;
		public bool FaceLeft, FaceRight;
        public bool Jump;
        public bool Attack;
		public bool Cartwheel;
		public bool Headbutt;
		public bool BellyFlop;
        public bool Down;
		public bool Smash;
		public bool HammerDown;
		public bool Sidekick;
		public bool Shift;

        public CollisionSpheres colS;
		public LedgeChecker lc;
		public GameObject spine, goalRight, goalLeft, player;
		public AnimationProgress ap;
        public CharacterState cs;
		public BoxCollider boxCollider;
		public Animator DefaultAnimator;

        //public GameObject ColliderEdgePrefab;
        
        public List<Collider> RagdollParts = new List<Collider>();


		private Dictionary<string, GameObject> ChildObjects = new Dictionary<string, GameObject>();


        public float GravityMultiplier;
        public float PullMultiplier;

        private List<TriggerDetector> TriggerDetectors = new List<TriggerDetector>();

        private Rigidbody rigid;
        public Rigidbody RIGID_BODY
        {
            get
            {
                if (rigid == null)
                {
                    rigid = GetComponent<Rigidbody>();
                }
                return rigid;
            }
        }

        public void CacheCharacterControl(Animator animator)
		{
			CharacterState[] arr = animator.GetBehaviours<CharacterState>();

            foreach(CharacterState s in arr)
			{
				s.characterControl = this;
			}
		}

		private void RegisterCharacter()
		{
			CharacterManager.Instance.Characters.Add(this);
            

        }
        private void Awake()
        {
			DefaultAnimator = GetComponent<Animator>();
			lc = GetComponentInChildren<LedgeChecker>();
			ap = GetComponent<AnimationProgress>();
			spine = GetComponent<GameObject>();
			boxCollider = GetComponent<BoxCollider>();
            colS = GetComponentInChildren<CollisionSpheres>();
            colS.owner = this;

			CacheCharacterControl(SkinnedMeshAnimator);

            colS.SetColliderSpheres();

			RegisterCharacter();
            
        }

        public void Teleport()
		{
            if (FaceLeft)
			{
				player.transform.position = goalRight.transform.position;
			}
			else
			{
				player.transform.position = goalLeft.transform.position;
			}
		}

        public List<TriggerDetector> GetAllTriggers()
        {
            if (TriggerDetectors.Count == 0)
            {
                TriggerDetector[] arr = this.gameObject.GetComponentsInChildren<TriggerDetector>();

                foreach(TriggerDetector d in arr)
                {
                    TriggerDetectors.Add(d);
                }
            }

            return TriggerDetectors;
        }

        /*private IEnumerator Start()
        {
            yield return new WaitForSeconds(5f);
            RIGID_BODY.AddForce(200f * Vector3.up);
            yield return new WaitForSeconds(0.5f);
            TurnOnRagdoll();
        }*/

        public void SetRagdollParts()
        {
            RagdollParts.Clear();

            Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

            foreach(Collider c in colliders)
            {
                if (c.gameObject != this.gameObject)
                {
                    c.isTrigger = true;
                    RagdollParts.Add(c);

                    if (c.GetComponent<TriggerDetector>() == null)
                    {
                        c.gameObject.AddComponent<TriggerDetector>();
                    }
                }
            }
        }

		public GameObject GetChildObj(string name)
		{
			if (ChildObjects.ContainsKey(name))
			{
				return ChildObjects[name];
			}

			Transform[] arr = this.gameObject.GetComponentsInChildren<Transform>();

			foreach (Transform t in arr)
			{
				if (t.gameObject.name.Equals(name))
				{
					ChildObjects.Add(name, t.gameObject);
					return t.gameObject;
				}
			}

			return null;
		}

		public void TurnOnRagdoll()
        {
            RIGID_BODY.useGravity = false;
            RIGID_BODY.velocity = Vector3.zero;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            SkinnedMeshAnimator.enabled = false;
            SkinnedMeshAnimator.avatar = null;

            foreach(Collider c in RagdollParts)
            {
                c.isTrigger = false;
                c.attachedRigidbody.velocity = Vector3.zero;
            }
        }

        
        public void UpdateBoxColliderSize()
		{
			if (!ap.Updating)
			{
				return;
			}
			
				boxCollider.size = Vector3.Lerp(boxCollider.size, ap.targetSize, Time.deltaTime * ap.sizeSpeed);
				ap.Updating_Spheres = true;
			
			colS.Reposition_FrontSpheres();
			colS.Reposition_BottomSpheres();
		}

        public void UpdateBoxColliderCenter()
		{
			if (!ap.Updating)
			{
				return;
			}
			
				boxCollider.center = Vector3.Lerp(boxCollider.center, ap.targetCenter, Time.deltaTime * ap.centerSpeed);
				ap.Updating_Spheres = true;
			
		}

        

		private void FixedUpdate()
		{
			if (RIGID_BODY.velocity.y < 0f)
			{
				RIGID_BODY.velocity += (-Vector3.up * GravityMultiplier);
			}

			if (RIGID_BODY.velocity.y > 0f && !Jump)
			{
				RIGID_BODY.velocity += (-Vector3.up * PullMultiplier);
			}

			ap.Updating_Spheres = false;

			if (ap.Updating_Spheres)
			{
				colS.Reposition_FrontSpheres();
				colS.Reposition_BottomSpheres();
			}

			if (transform.rotation.eulerAngles.y == 0)
			{
				FaceRight = true;
				FaceLeft = false;
			}
			else
			{
				FaceRight = false;
				FaceLeft = true;
			}

			UpdateBoxColliderSize();
			UpdateBoxColliderCenter();
		}

        public void MoveForward(float Speed, float SpeedGraph)
        {
            transform.Translate(Vector3.forward * Speed * SpeedGraph * Time.deltaTime);
        }

        public void FaceForward(bool forward)
        {
            if (forward)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        public bool IsFacingForward()
        {
            if (transform.forward.z > 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}