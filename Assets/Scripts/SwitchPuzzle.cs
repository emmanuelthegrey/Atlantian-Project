using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class SwitchPuzzle : MonoBehaviour, IPuzzle
	{
		public bool IsSolved { get; set; } = false;
		public event EventHandler Failure;

		public PuzzleSwitch redSwitch;
		public PuzzleSwitch greenSwitch;
		public PuzzleSwitch blueSwitch;
		public PuzzleSwitch purpleSwitch;

		private Animator animator;

		List<PuzzleSwitch> winCondition = new List<PuzzleSwitch>();
		int selectionIndex = 0;

		protected virtual void OnPuzzleFailure (object sender, EventArgs e)
		{
			Failure?.Invoke(sender, e);
		}

		public void Start ()
		{
			animator = GetComponent<Animator>();

			winCondition.Add(redSwitch);
			winCondition.Add(greenSwitch);
			winCondition.Add(purpleSwitch);
			winCondition.Add(blueSwitch);

			if (GameManager.crystals % 2 == 0)
			{
				winCondition.Reverse();
			}
		}

		public void Update ()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Debug.DrawRay(ray.origin, ray.direction, Color.red, 5);
				if (Physics.Raycast(ray, out var hitinfo))
				{
					var hitObject = hitinfo.collider.transform;

					if (hitObject.IsChildOf(transform) && hitObject.GetComponent<PuzzleSwitch>() != null)
					{
						animator.SetTrigger("TriggerSwitchOff");

						if (selectionIndex < winCondition.Count && winCondition[selectionIndex].transform == hitObject)
						{
							print("correct!");

							if (selectionIndex == 3)
							{
								IsSolved = true;
							}

							selectionIndex++;
						}
						else
						{
							print("wrong button!");

							var e = new EventArgs();
							OnPuzzleFailure(this, e);
						}

					}
				}
			}
		}
	}
}
