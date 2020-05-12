using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class SamplePuzzle : MonoBehaviour, IPuzzle
	{
		public bool IsSolved { get; set; } = false;
		public event EventHandler Failure;

		public PuzzleButton redButton;
		public PuzzleButton greenButton;
		public PuzzleButton blueButton;
		public PuzzleButton purpleButton;

		List<PuzzleButton> winCondition = new List<PuzzleButton>();
		int selectionIndex = 0;

		protected virtual void OnPuzzleFailure (object sender, EventArgs e)
		{
			Failure?.Invoke(sender, e);
		}

		public void Start ()
		{
			winCondition.Add(redButton);
			winCondition.Add(greenButton);
			winCondition.Add(purpleButton);
			winCondition.Add(blueButton);

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
