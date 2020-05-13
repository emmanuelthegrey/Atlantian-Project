using Assets.Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    QuadrantManager quadrantManager;
    PuzzleManager puzzleManager;

    public List<GameObject> puzzlePrefabs;
    public List<GameObject> anchorPoints;


    int failureCount = 0;

    public static int crystals = 0;
    public static Isms selectedIsm = Isms.AlwaysRaising;

    private void Awake ()
    {
        puzzleManager = new PuzzleManager();
        print("# of an points " + anchorPoints.Count);
        print("# of an puzzle " + puzzlePrefabs.Count);
        quadrantManager = new QuadrantManager(anchorPoints);

        selectedIsm = Isms.GetIsms[new System.Random().Next(0, Isms.GetIsms.Count-1)];
    }

    void Start()
    {
        puzzlePrefabs.ForEach(p =>
        {
            var puzzleComponent = p.GetComponent<IPuzzle>();

            puzzleManager.Add(puzzleComponent);
            puzzleComponent.Failure += OnPuzzleFailure;

            quadrantManager.Add(Instantiate(p));

        });


        quadrantManager.Distribute();


    }

    // Update is called once per frame
    void Update()
    {

        if (puzzleManager.AreAllSolved())
        {
            print("you win!");
        }
    }

    void OnPuzzleFailure (object sender, EventArgs e)
    {
        print("failure logged");
        failureCount++;

        if(failureCount >= 3)
        {
            print("game over!");
        }
    }
}
