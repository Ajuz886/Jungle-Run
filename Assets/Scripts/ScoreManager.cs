using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float pointsPerSecond;

    public Text scoreText;
    public Text hiScoreText;

    public float score ;
    private float hiScore;

    public bool isScoreIcreasing;

    void Start()
    {
        isScoreIcreasing = true;
         
        if (PlayerPrefs.HasKey("HiScore"))
        {
            hiScore = PlayerPrefs.GetFloat("HiScore");
        }
    }

    void Update()
    {
        if(isScoreIcreasing)
                     score += pointsPerSecond * Time.deltaTime;

        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }

      
        scoreText.text = Mathf.Round(score).ToString();
        hiScoreText.text = Mathf.Round(hiScore).ToString();
    }
}
