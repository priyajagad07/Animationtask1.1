using System.Collections;
using UnityEngine;

public class LevelCompletedScreen : BaseScreen
{
    public Transform panel;
    public override void Show()
    {
        base.Show();
        StartCoroutine(ZoomIn());
    }

    IEnumerator ZoomIn()
    {
        panel.localScale = Vector3.zero;
        float time = 0;

        while(time < 0.6f)
        {
            time += Time.unscaledDeltaTime;
            panel.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, time / 0.3f);
            yield return null;
        }
    }
}