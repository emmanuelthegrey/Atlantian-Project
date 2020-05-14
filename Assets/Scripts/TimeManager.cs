using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        seconds = GameSettings.GAME_TIME_SECONDS_EASY;
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;

        var minutes = (int)(seconds / 60);
        Timer.text = $"{minutes}:{Mathf.FloorToInt(seconds - minutes * 60)}";

    }
}
