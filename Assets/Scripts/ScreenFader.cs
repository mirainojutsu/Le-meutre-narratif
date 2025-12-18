using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{

    public CanvasGroup canvasGroup;

    Coroutine currentFade;

    void Awake()
    {
        canvasGroup.alpha = 0f;
    }

    public void FadeIn(float duration)
    {
        StartFade(0f, 1f, duration);
    }

    // Fade out instant -> noir, puis retour progressif
    public void FadeOut(float duration)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        canvasGroup.alpha = 1f; // noir instantané
        currentFade = StartCoroutine(FadeRoutine(1f, 0f, duration));
    }

    void StartFade(float from, float to, float duration)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeRoutine(from, to, duration));
    }

    IEnumerator FadeRoutine(float from, float to, float duration)
    {
        float t = 0f;
        canvasGroup.alpha = from;

        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }

        canvasGroup.alpha = to;
        currentFade = null;
    }
}