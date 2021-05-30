using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    float score = 0;
    public Text myText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Score: " + math.round(score);
        score += 1 * Time.deltaTime * 6;
    }

    public float GetScore()
    {
        return math.round(score);
    }
}
