using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    private Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
    }
    
    public void Show()
    {
        canvas.enabled = true;
    }

    public void Hide()
    {
        canvas.enabled = false;
    }
}