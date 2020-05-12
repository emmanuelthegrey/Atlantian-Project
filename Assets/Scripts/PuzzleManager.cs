using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class PuzzleManager
{
	List<IPuzzle> puzzles { get; } = new List<IPuzzle>();

	public PuzzleManager ()
	{ 
	
	}

	public void Add (IPuzzle puzzle)
	{
		puzzles.Add(puzzle);
	}

	public bool AreAllSolved ()
	{
		var allSolved = true;

		puzzles.ForEach(p =>
		{
			if (!p.IsSolved)
			{
				allSolved = false;
			}
		});

		return allSolved;
	}

}