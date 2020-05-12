using System;

public interface IPuzzle
{
	bool IsSolved { get; }

	event EventHandler Failure;
}