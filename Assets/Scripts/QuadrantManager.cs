using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadrantManager: ScriptableObject
{
	List<GameObject> puzzlesAndArt = new List<GameObject>();
	public List<GameObject> anchorPoints;
	private List<GameObject> subAnchors;
	List<Vector3> quadrants = new List<Vector3>();
	List<IArt> art = new List<IArt>();


	internal void init(List<GameObject> anchorPoints)
	{
		subAnchors = new List<GameObject>();
		this.anchorPoints = anchorPoints;

		//puzzle.transform.localPosition = new Vector3(.25f, -.25f, 0);
		///*top right*/
		//puzzle.transform.localPosition = new Vector3(-.25f, -.25f, 0);
		///*bottom left*/
		//puzzle.transform.localPosition = new Vector3(.25f, .25f, 0);
		///*bottom right*/
		//puzzle.transform.localPosition = new Vector3(-.25f, .25f, 0);

		quadrants.Add(new Vector3(.25f, -.25f, 0));
		quadrants.Add(new Vector3(-.25f, -.25f, 0));
		quadrants.Add(new Vector3(.25f, .25f, 0));
		quadrants.Add(new Vector3(-.25f, .25f, 0));

		for (int i = 0; i < anchorPoints.Count; i++)
		{
			for (int j = 0; j < quadrants.Count; j++)
			{
				var go = new GameObject();
				go.transform.SetParent(anchorPoints[i].transform, false);
				go.transform.localPosition = quadrants[j];
				go.transform.localScale = new Vector3(.50f, .50f, .50f);
				subAnchors.Add(go);
			}
		}
	}

	public void Add(GameObject go)
	{
		puzzlesAndArt.Add(go);
	}

	public void Distribute()
	{
		puzzlesAndArt.Shuffle();
		subAnchors.Shuffle();

		Queue<GameObject> puzzlesAndArtQueue = new Queue<GameObject>(puzzlesAndArt);
		Queue<GameObject> subAchorsQueue = new Queue<GameObject>(subAnchors);


		while(puzzlesAndArtQueue.Count > 0 && subAchorsQueue.Count > 0)
		{
			var puzzleAndArtgo = puzzlesAndArtQueue.Dequeue();
			var anchor = subAchorsQueue.Dequeue();

			puzzleAndArtgo.transform.SetParent(anchor.transform, false);

		}



	}

}

            

