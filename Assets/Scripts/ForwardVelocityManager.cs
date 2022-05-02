using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ForwardVelocityManager : MonoBehaviour
{
    public float speed;

    private Coroutine coroutine;
    private Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public void StartMoving(float power)
    {
        StopMoving();
        coroutine = StartCoroutine(Move(power));
    }

    private void StopMoving()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator Move(float power)
    {
        while (true)
        {
            var newVelocity = transform.forward * (power * speed);
            newVelocity.y = myRigidbody.velocity.y;
            myRigidbody.velocity = newVelocity;
            yield return new WaitForFixedUpdate();
        }
    }
}
