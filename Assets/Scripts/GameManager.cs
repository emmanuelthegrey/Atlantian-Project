﻿using Assets.Scripts;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    QuadrantManager quadrantManager;
    PuzzleManager puzzleManager;

    public List<GameObject> puzzlePrefabs;
    public List<GameObject> artPrefabs;
    public List<GameObject> anchorPoints;
    public TextMeshProUGUI strikes;
    public GameObject gameOver;
    public GameObject win;

    int failureCount = 0;

    public static Isms selectedIsm = Isms.AlwaysRaising;

    private void Awake ()
    {
        puzzleManager = new PuzzleManager();
        // print("# of an points " + anchorPoints.Count);
        //print("# of an puzzle " + puzzlePrefabs.Count);
        quadrantManager = (QuadrantManager)ScriptableObject.CreateInstance("QuadrantManager");
        quadrantManager.init(anchorPoints);

        selectedIsm = Isms.GetIsms[new System.Random().Next(0, Isms.GetIsms.Count-1)];
    }

    void Start()
    {
        puzzlePrefabs.ForEach(p =>
        {
            var puzzle = Instantiate(p);

            puzzleManager.Add(puzzle.GetComponent<IPuzzle>());
            puzzle.GetComponent<IPuzzle>().Failure += OnPuzzleFailure;

            quadrantManager.Add(puzzle);

        });

        artPrefabs.ForEach(a =>
        {
            quadrantManager.Add(Instantiate(a));
        });

        quadrantManager.Distribute();
    }

    // Update is called once per frame
    void Update()
    {

        if (puzzleManager.AreAllSolved())
        {
            win.SetActive(true);
        }
    }

    void OnPuzzleFailure (object sender, EventArgs e)
    {
        print("failure logged");
        failureCount++;

        strikes.text += "X";

        if(failureCount >= GameSettings.FAILURES)
        {
            gameOver.SetActive(true);
        }
    }
}
