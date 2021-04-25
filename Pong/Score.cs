using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject leftScore;
    [SerializeField] GameObject rightScore;

    Text leftText, rightText;
    int leftCount, rightCount;


    private void OnEnable()
    {
        BallScript.ScorePoint += ScoreFunction;
    }

    // Start is called before the first frame update
    void Start()
    {
        leftText = leftScore.GetComponent<Text>();
        rightText = rightScore.GetComponent<Text>();
    }

    // triggers when the BallScript starts the score event
    void ScoreFunction(string s)
    {
        if (s == "left")
        {
            leftCount++;
            leftText.text = leftCount.ToString();
        }
        else if (s == "right")
        {
            rightCount++;
            rightText.text = rightCount.ToString();
        }
    }
}
