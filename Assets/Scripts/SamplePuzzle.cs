using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class SamplePuzzle : MonoBehaviour, IPuzzle
	{
		public bool IsSolved { get; set; } = false;
		public event EventHandler Failure;

		public PuzzleButton waterButton;
		public PuzzleButton windButton;
		public PuzzleButton skullButton;
		public PuzzleButton moonButton;
		public PuzzleButton eyeButton;
		public PuzzleButton fireButton;
		public PuzzleButton treeButton;
		public PuzzleButton heartButton;
		public PuzzleButton sunButton;

		List<PuzzleButton> winCondition = new List<PuzzleButton>();
		int selectionIndex = 0;

		protected virtual void OnPuzzleFailure (object sender, EventArgs e)
		{
			Failure?.Invoke(sender, e);
		}

		public void Start ()
		{
			if (GameManager.crystals == 1)
			{
				winCondition.Add(waterButton);
				winCondition.Add(windButton);
				winCondition.Add(skullButton);
				winCondition.Add(moonButton);
			}
			else if (GameManager.crystals == 2)
			{
				winCondition.Add(eyeButton);
				winCondition.Add(fireButton);
				winCondition.Add(skullButton);
				winCondition.Add(treeButton);
			}
			else if (GameManager.crystals == 3)
			{
				winCondition.Add(skullButton);
				winCondition.Add(windButton);
				winCondition.Add(waterButton);
				winCondition.Add(fireButton);
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

					if (hitObject.IsChildOf(transform) && hitObject.GetComponent<PuzzleButton>() != null)
					{
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
