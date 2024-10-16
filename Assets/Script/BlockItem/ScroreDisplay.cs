using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScroreDisplay : MonoBehaviour
{
    public Text scoreText; // Nếu sử dụng Text
    // public TextMeshProUGUI scoreText; // Nếu sử dụng TextMeshPro

    void Update()
    {
        if (ScoreManager.Instance != null)
        {
            // Cập nhật giá trị score lên UI
            scoreText.text = ScoreManager.Instance.GetScore().ToString();
        }
    }
}
