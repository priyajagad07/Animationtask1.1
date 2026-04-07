using System.Collections;
using UnityEngine;

public class UIScreenAnimation : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float duration = 0.3f;

    void Awake()
    {
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        StopAllCoroutines();

        canvasGroup.alpha = 0;
        transform.localScale = Vector3.one * 0.8f;
        StartCoroutine(AnimationShow());
    }

    public void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(AnimationHide());
    }

    IEnumerator AnimationShow()
    {
        float time = 0;
        transform.localScale = Vector3.one * 0.8f;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            float t = time / duration;

            canvasGroup.alpha = t;
            transform.localScale = Vector3.Lerp(Vector3.one * 0.8f, Vector3.one, t);

            yield return null;
        }

        canvasGroup.alpha = 1;
        transform.localScale = Vector3.one;
    }

    IEnumerator AnimationHide()
    {
        float time = 0;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            float t = time / duration;

            canvasGroup.alpha = 1 - t;
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.8f, t);

            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}
