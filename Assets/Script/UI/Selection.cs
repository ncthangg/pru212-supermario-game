using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            ChangPosition(-1);
        if (Input.GetKeyDown(KeyCode.S))
            ChangPosition(1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Yes");
            Interact();
        }
    }

    private void ChangPosition(int _change)
    {
        currentPosition += _change;

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
        {
            currentPosition = 0;
        }

        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }

    private void Interact()
    {
        options[currentPosition].GetComponent<Button>().onClick.Invoke();

    }
}
