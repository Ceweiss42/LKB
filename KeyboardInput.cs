using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roundbeargames_tutorial
{
	public class KeyboardInput : MonoBehaviour
	{
		void Update()
		{
			if (Input.GetKey(KeyCode.D))
			{
				if (Input.GetKey(KeyCode.C))
				{
					VirtualInputManager.Instance.Cartwheel = true;
				}
				else
				{
					VirtualInputManager.Instance.MoveRight = true;
					VirtualInputManager.Instance.Cartwheel = false;
				}

			}
			else
			{
				VirtualInputManager.Instance.MoveRight = false;
				VirtualInputManager.Instance.Cartwheel = false;

			}

			if (Input.GetKey(KeyCode.A))
			{
				if (Input.GetKey(KeyCode.C))
				{
					VirtualInputManager.Instance.Cartwheel = true;
				}
				else
				{
					VirtualInputManager.Instance.MoveLeft = true;
					VirtualInputManager.Instance.Cartwheel = false;
				}

			}
			else
			{
				VirtualInputManager.Instance.MoveLeft = false;
				VirtualInputManager.Instance.Cartwheel = false;

			}

			if (Input.GetKey(KeyCode.W))
			{
				VirtualInputManager.Instance.Jump = true;
			}
			else
			{
				VirtualInputManager.Instance.Jump = false;
			}

			if (Input.GetKey(KeyCode.C))
			{
				VirtualInputManager.Instance.Attack = true;
			}
			else
			{
				VirtualInputManager.Instance.Attack = false;
			}

			if (((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))) && (Input.GetKey(KeyCode.C)))
			{
				VirtualInputManager.Instance.Cartwheel = true;
			}
			else
			{
				VirtualInputManager.Instance.Cartwheel = false;
			}

			if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.C))
			{
				VirtualInputManager.Instance.Headbutt = true;
			}
			else
			{
				VirtualInputManager.Instance.Headbutt = false;
			}

            if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.C))
			{
				VirtualInputManager.Instance.BellyFlop = true;
			}
			else
			{
				VirtualInputManager.Instance.BellyFlop = false;
			}

            if(Input.GetKey(KeyCode.S))
			{
				VirtualInputManager.Instance.Down = true;
			}
			else
			{
				VirtualInputManager.Instance.Down = false;
			}

            if(Input.GetKey(KeyCode.V))
			{
				VirtualInputManager.Instance.Smash = true;
			}
			else
			{
				VirtualInputManager.Instance.Smash = false;
			}

            if(Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.W))
			{
				VirtualInputManager.Instance.Smash = false;
				VirtualInputManager.Instance.HammerDown = true;
				VirtualInputManager.Instance.Jump = false;
			}
			else
			{
				VirtualInputManager.Instance.HammerDown = false;
			}

			if (Input.GetKey(KeyCode.V) && ((Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.D))))
			{
				VirtualInputManager.Instance.Smash = false;
				VirtualInputManager.Instance.Sidekick = true;
			}
			else
			{
				VirtualInputManager.Instance.Sidekick = false;
			}

            if(Input.GetKey(KeyCode.LeftShift))
			{
				VirtualInputManager.Instance.Shift = true;
			}
			else
			{
				VirtualInputManager.Instance.Shift = false;
			}

		}
	}
}