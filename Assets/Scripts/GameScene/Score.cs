using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] Text _score;
    private int score_count = 0;

    private void Awake()
    {
        _score.text = "Score: 0000";
    }

    public void ChangeScoreEnemy()
    {
        score_count += 1;
        CorrectedValue();
    }
    public void ChangeScoreChild()
    {
        score_count += 5;
        CorrectedValue();
    }

    private void CorrectedValue()
    {
        if (score_count > 999 && score_count < 10000)
        {
            _score.text = "Score: " + score_count.ToString();
        }
        else if(score_count > 99 && score_count < 1000)
        {
            _score.text = "Score: 0" + score_count.ToString();
        }
        else if (score_count > 9 && score_count < 100)
        {
            _score.text = "Score: 00" + score_count.ToString();
        }
        else if (score_count < 10)
        {
            _score.text = "Score: 000" + score_count.ToString();
        }
        else
        {
            _score.text = "Score: MAX" + score_count.ToString();
        }    
    }
}


