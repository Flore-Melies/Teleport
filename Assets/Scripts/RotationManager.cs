using System.Collections;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public float speed;

    private Coroutine coroutine;

    public void StartRotation(float power)
    {
        StopRotation();
        coroutine = StartCoroutine(Rotate(power));
    }

    public void StopRotation()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator Rotate(float power)
    {
        while (true)
        {
            transform.Rotate(transform.up, speed * power);
            yield return null;
        }
    }
}
