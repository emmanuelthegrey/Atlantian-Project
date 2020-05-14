using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadrantManager
{
	List<GameObject> puzzlesAndArt = new List<GameObject>();
	public List<GameObject> anchorPoints;
	List<Vector3> quadrants = new List<Vector3>();
	List<IArt> art = new List<IArt>();


	public QuadrantManager(List<GameObject> anchorPoints)
	{
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
	}

	public void Add(GameObject go)
	{
		puzzlesAndArt.Add(go);
	}

	public void Distribute()
	{
		puzzlesAndArt.Shuffle();

		Queue<GameObject> gameObjects = new Queue<GameObject>(puzzlesAndArt);

		for (int i = 0; i < anchorPoints.Count; i++)
		{
			for (int j = 0; j < quadrants.Count; j++)
			{
				var go = gameObjects.Dequeue();
				go.transform.SetParent(anchorPoints[i].transform, false);
				go.transform.localPosition = quadrants[j];
				go.transform.localScale = new Vector3(.50f, .50f, .50f);
			}

		}

	}

}

            

