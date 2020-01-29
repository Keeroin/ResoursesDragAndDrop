using System;
using UnityEngine;
using TMPro;

public class ScoreBehaviour : MonoBehaviour
{
    TextMeshProUGUI text;
    Animator animator;

    int score;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
    }

    public void AddScore(int scorePoints)
    {
        score = scorePoints + int.Parse(text.text);
        text.text = score.ToString();

        animator.SetTrigger("isAddScoreAnim");
    }

}
