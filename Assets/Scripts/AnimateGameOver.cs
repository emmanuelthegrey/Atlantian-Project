using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimateGameOver : MonoBehaviour
{
    float animTime = 2;
    float timer = 0;
    float initialScale = 1;
    float addScale = 0.1f;

    TextMeshProUGUI text;

    private void Awake ()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, (timer / animTime));

        var size = initialScale + addScale * (timer / animTime);
        transform.localScale = new Vector3(size, size, 1);

        timer += Time.deltaTime;

        if (timer > animTime)
        {
            timer = animTime;
        }
    }
}
