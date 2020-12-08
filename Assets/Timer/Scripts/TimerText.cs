using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    public float time = 0.0f;
    public int minutes = 0;
    public int seconds = 0;
    private TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        minutes = Mathf.RoundToInt(time) / 60;
        seconds = Mathf.RoundToInt(time) % 60;

        if (seconds < 10)
            textMeshPro.SetText("" + minutes + ":0" + seconds);
        else
            textMeshPro.SetText("" + minutes + ":" + seconds);
        textMeshPro.color = new Color32(255, 227, 245, 255);
    }

    public void PairPenalty()
    {
        int penalty = 5;
        time += penalty;
        textMeshPro.color = new Color32(255, 0, 0, 255);
    }
}