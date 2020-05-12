using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Describes the worklflow steps.  If a workflow varies between rockets, the rocket that differs from the generic flow will have its own
/// nested struct
/// 
/// for example see other right workflow steps
/// </summary>
public struct Isms
{
	public static readonly Isms AlwaysRaising = new Isms("Always raising our level of awareness.");
	public static readonly Isms InchesWeNeed = new Isms("The inches we need are everywhere around us.");
	public static readonly Isms RespondingWithUrgency = new Isms("Responding with a sense of urgency is the ante to play.");
	public static readonly Isms EveryClient = new Isms("Every client. Every time. No exceptions. No excuses.");
	public static readonly Isms FindingABetterWay = new Isms("Obsessed with finding a better way.");
	public static readonly Isms YesBeforeNo = new Isms("Yes before no.");
	public static readonly Isms IgnoreTheNoise = new Isms("Ignore the noise.");
	public static readonly Isms WhatIsRight = new Isms("It's not about WHO is right, it's about WHAT is right.");
	public static readonly Isms WeAreTheThey = new Isms("We are the 'they.'");
	public static readonly Isms RoastOutOfOven = new Isms("You have to take the roast out of the oven.");
	public static readonly Isms SeeItBelieveIt = new Isms("You'll see it when you believe it.");
	public static readonly Isms WellFigureItOut = new Isms("We'll figure it out.");
	public static readonly Isms EverySecondCounts = new Isms("Every second counts.");
	public static readonly Isms NumbersFollow = new Isms("Numbers and money follow; they do not lead.");
	public static readonly Isms APennySaved = new Isms("A penny saved is a penny.");
	public static readonly Isms WeEatDogFood = new Isms("We eat our own dog food.");
	public static readonly Isms SimplicityIsGenius = new Isms("Simplicity is genius.");
	public static readonly Isms InnovationIsRewarded = new Isms("Innovation is rewarded. Execution is worshipped.");
	public static readonly Isms DoTheRightThing = new Isms("Do the right thing.");

	public static readonly List<Isms> GetIsms = new List<Isms>() { AlwaysRaising, InchesWeNeed, RespondingWithUrgency, EveryClient, FindingABetterWay,
		YesBeforeNo, IgnoreTheNoise, WhatIsRight, WeAreTheThey, RoastOutOfOven, SeeItBelieveIt, WellFigureItOut, EverySecondCounts,
		NumbersFollow, APennySaved, WeEatDogFood, SimplicityIsGenius, InnovationIsRewarded, DoTheRightThing };

	public string Text { get; set; }
	private Isms (string tag)
	{
		this.Text = tag;

	}
	public override string ToString ()
	{
		return this.Text;
	}
	/// <summary>
	/// Checks equality based on code alone
	/// </summary>
	private bool Equals (Isms logFormatTag)
	{
		return this.Text.Equals(logFormatTag.Text);
	}
	public override bool Equals (object obj)
	{
		//if it is null, return false
		if (ReferenceEquals(null, obj))
			return false;
		//if they are the same object return true
		if (ReferenceEquals(this, obj))
			return true;
		//if they are not the same type, return false
		if (obj.GetType() != this.GetType())
			return false;
		//if we get this far, check equality on code
		return Equals((Isms)obj);
	}
	public override int GetHashCode ()
	{
		return this.Text.GetHashCode();
	}
	public static bool operator == (Isms left, Isms right)
	{
		return Equals(left, right);
	}
	public static bool operator != (Isms left, Isms right)
	{
		return !Equals(left, right);
	}
}