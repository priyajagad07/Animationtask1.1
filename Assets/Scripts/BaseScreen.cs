using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    private Canvas canvas;
    private UIScreenAnimation screenAnimation;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
        screenAnimation = GetComponent<UIScreenAnimation>();
    }

    public virtual void Show()
    {
        canvas.enabled = true;
        screenAnimation?.Show();
    }

    public virtual void Hide()
    {
        canvas.enabled = false;
    }
}   