using System.Collections;
using UnityEngine;

public class PauseGameScreen : BaseScreen
{
    public Transform panel;
    public override void Show()
    {
        base.Show();
        StartCoroutine(SlideDown());
        Debug.Log("Pause Animation Running");
    }

    IEnumerator SlideDown()
    {
        Vector3 start = new Vector3(0, 800, 0);
        Vector3 end = Vector3.zero;

        panel.localPosition = start;
        float time = 0;

        while(time < 0.4f)
        {
            time += Time.unscaledDeltaTime;
            panel.localPosition = Vector3.Lerp(start, end, time / 0.4f);
            yield return null;
        }
    }
}
