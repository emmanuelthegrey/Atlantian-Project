using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class PuzzleButton : MonoBehaviour
	{
		float sizeUp = .02f;
		float sizeDown = .02f;
		Vector3 original;

		public void Start ()
		{
			original = transform.localScale;
		}

		private void OnMouseEnter ()
		{
			transform.localScale = new Vector3(original.x + sizeUp, original.y + sizeUp, original.z + sizeUp);
		}

		private void OnMouseExit ()
		{
			transform.localScale = original;
		}

		private void OnMouseDown ()
		{
			transform.localScale = new Vector3(original.x - sizeDown, original.y - sizeDown, original.z - sizeDown);
		}

		private void OnMouseUp ()
		{
			transform.localScale = new Vector3(original.x + sizeUp, original.y + sizeUp, original.z + sizeUp);
		}
	}
}
