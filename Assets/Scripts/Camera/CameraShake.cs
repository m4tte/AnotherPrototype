using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float magnitude = 0.1f;
    public float duration = 1.0f;
    public float frequency = 1.0f;
    public bool useSeed = true;
    public int seed = 0;

    private Vector3 originalPosition;
    private float elapsed = 0.0f;
    private System.Random random;

    void Start()
    {
        originalPosition = transform.localPosition;
        if (useSeed)
        {
            random = new System.Random(seed);
        }
    }

    public void Shake(float shakeDuration, float shakeMagnitude, float shakeFrequency)
    {
        magnitude = shakeMagnitude;
        duration = shakeDuration;
        frequency = shakeFrequency;
        elapsed = 0.0f;
        originalPosition = transform.localPosition;
    }
    void Update()
    {
        if (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            float x = (float)(random.NextDouble() * 2.0 - 1.0) * magnitude * damper;
            float y = (float)(random.NextDouble() * 2.0 - 1.0) * magnitude * damper;

            transform.localPosition = originalPosition + new Vector3(x, y, 0);

            if (elapsed >= duration)
            {
                transform.localPosition = originalPosition;
            }
        }
    }
}
