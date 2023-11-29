using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    int Poitns;
    public Text pointstext;

    // Update is called once per frame
    void Update()
    {
        pointstext.text = "Points: " + Poitns;
    }

    public void AddPoints(int points)
    {
        Poitns += points;
    }
}
