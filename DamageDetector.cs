using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class DamageDetector : MonoBehaviour
    {
        CharacterControl control;

		[SerializeField]
		List<RuntimeAnimatorController> HitReactionList = new List<RuntimeAnimatorController>();

        GeneralBodyPart DamagedPart;

        public SwitchAnimator sa;

		[SerializeField]
		private float hp, stocks;
		public Transform spawner;


        private void Awake()
        {
            control = GetComponent<CharacterControl>();
        }

        private void Update()
        {
            if (AttackManager.Instance.CurrentAttacks.Count > 0)
            {
                CheckAttack();
            }
            if(IsDead())
			{
				Respawn();
				//stocks -= 1;
			}

            

        }

        public float GetHP()
		{
			return hp;
		}

        public float GetStocks()
		{
			return stocks;
		}

        private void CheckAttack()
        {
            foreach (AttackInfo info in AttackManager.Instance.CurrentAttacks)
            {
                if (info == null)
                {
                    continue;
                }

                if (!info.isRegisterd)
                {
                    continue;
                }

                if (info.isFinished)
                {
                    continue;
                }

                if (info.CurrentHits >= info.MaxHits)
                {
                    continue;
                }

                if (info.Attacker == control)
                {
                    continue;
                }

                if (info.MustFaceAttacker)
                {
                    Vector3 vec = this.transform.position - info.Attacker.transform.position;
                    if (vec.z * info.Attacker.transform.forward.z < 0f)
                    {
                        continue;
                    }
                }

                if (info.MustCollide)
                {
                    if (IsCollided(info))
                    {
                        TakeDamage(info);
                    }
                }
                else
                {
                    float dist = Vector3.SqrMagnitude(this.gameObject.transform.position - info.Attacker.transform.position);
                    if (dist <= info.LethalRange)
                    {
                        TakeDamage(info);
                    }
                }
            }
        }

        private bool IsCollided(AttackInfo info)
        {
            foreach(TriggerDetector trigger in control.GetAllTriggers())
            {
                foreach (Collider collider in trigger.CollidingParts)
                {
                    foreach (string name in info.ColliderNames)
                    {
                        if (name.Equals(collider.gameObject.name))
                        {
                            if(collider.transform.root.gameObject == info.Attacker.gameObject)
							{
								DamagedPart = trigger.generalBodyPart;
								return true;
							}
                            
                        }
                    }
                }
            }

            return false;
        }

        public bool IsDead()
		{
            if(hp >= 400)
			{
				return true;
			}
			return false;
		}

        private void TakeDamage(AttackInfo info)
        {
            control.CacheCharacterControl(control.SkinnedMeshAnimator);
            control.RIGID_BODY.velocity = Vector3.zero;
			float dam = info.AttackAbility.damage;
			float w = control.weight;
			float s = info.AttackAbility.scaler;
			float b = info.AttackAbility.baseMultiplier;

			if (control.FaceLeft)
			{
				control.RIGID_BODY.AddForce(Vector3.forward * (((((7*(dam + 2) * (hp)) / (w + 100)) + 9) * (2*s)) + b));
			}
            if(control.FaceRight)
			{
				control.RIGID_BODY.AddForce(-Vector3.forward * (((((7 * (dam + 2) * (hp)) / (w + 100)) + 9) * (2 * s)) + b));
			}
			
			if(info.CurrentHits != info.MaxHits)
			{
                if(info.MustCollide)
				{
					hp += info.AttackAbility.damage;
					info.CurrentHits++;
				}

			}

            if(IsDead())
			{
				Respawn();
			}

			else
			{
                control.SkinnedMeshAnimator.runtimeAnimatorController = null;
                control.SkinnedMeshAnimator.runtimeAnimatorController = HitReactionList[0];
                
                


            }
            


            Debug.Log(info.Attacker.gameObject.name + " hits: " + this.gameObject.name);
            Debug.Log(this.gameObject.name + " hit in " + DamagedPart.ToString());

            //control.SkinnedMeshAnimator.runtimeAnimatorController = info.AttackAbility.GetDeathAnimator();
            
        }

        private void Respawn()
		{
			control.transform.position = spawner.position;
			control.RIGID_BODY.velocity = Vector3.zero;
			control.RIGID_BODY.useGravity = true;
			stocks -= 1;
			hp = 0;
		}
    }
}
