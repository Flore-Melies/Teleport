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

    public void StopMoving()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    private IEnumerator Move(float power)
    {
        while (true)
        {
            // On calcule une vélocité qui va devant l’avatar (transform.forward = devant)
            var newVelocity = transform.forward * (power * speed);
            // On applique la gravité de la frame précédente à notre velocité
            newVelocity.y = myRigidbody.velocity.y;
            // On applique la vélocité calculée à notre rigidbody
            myRigidbody.velocity = newVelocity;
            // On fait attention à exécuter ce code en même temps que la FixedUpdate() car on modifie un rigidbody
            yield return new WaitForFixedUpdate();
        }
    }
}
