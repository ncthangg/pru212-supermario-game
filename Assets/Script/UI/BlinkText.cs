using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Nếu bạn sử dụng Text (UI), bỏ qua nếu sử dụng TMP_Text

public class BlinkText : MonoBehaviour
{
    public Text uiText; // Nếu sử dụng UI Text
    // public TMP_Text uiText; // Nếu sử dụng TextMeshPro
    public float blinkSpeed = 0.5f; // Tốc độ nhấp nháy
    private bool isBlinking = true;
    private UIManager uiManager;
    private void Start()
    {
        StartCoroutine(Blink());
        uiManager = FindObjectOfType<UIManager>();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Thực hiện hành động tiếp theo khi người chơi nhấn phím
            uiManager.Menu();
        }
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // Giảm alpha về 0 (ẩn chữ)
            SetTextAlpha(0f);
            yield return new WaitForSeconds(blinkSpeed);

            // Tăng alpha về 1 (hiện chữ)
            SetTextAlpha(1f);
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    private void SetTextAlpha(float alpha)
    {
        if (uiText != null)
        {
            Color color = uiText.color;
            color.a = alpha;  // Điều chỉnh alpha của Text
            uiText.color = color;
        }
    }
}
