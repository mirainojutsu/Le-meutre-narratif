using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightIntensityCurve : MonoBehaviour
{
    [Header("Intensity Range")]
    public float intensityA = 0f;
    public float intensityB = 2f;

    [Header("Curve Settings")]
    public AnimationCurve intensityCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    [Header("Timing")]
    public float duration = 2f;
    public bool pingPong = false;

    private Light _light;
    private float _time;

    void Awake()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        if (duration <= 0f) return;

        _time += Time.deltaTime;

        float t = _time / duration;

        if (pingPong)
        {
            t = Mathf.PingPong(t, 1f);
        }
        else
        {
            t = Mathf.Repeat(t, 1f);
        }

        float curveValue = intensityCurve.Evaluate(t);
        _light.intensity = Mathf.Lerp(intensityA, intensityB, curveValue);
    }
}