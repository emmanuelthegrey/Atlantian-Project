using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadrantManager
{
	List<GameObject> puzzles = new List<GameObject>();
	List<IArt> art = new List<IArt>();

	public QuadrantManager () 
	{ 
		
	}

	public void Add (GameObject go)
	{
		puzzles.Add(go);
	}

	public void Distribute ()
	{ 
	
	}
}