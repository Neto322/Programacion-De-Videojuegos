using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoretext;

    int currentpoints;
    void Start()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
        AddPoints(currentpoints);
    }

    public void AddPoints(int points)

    {
        currentpoints += points;
        scoretext.text = "<b>Score:</b>  <color=#ffff> " + currentpoints + " </color>";
    }
}
