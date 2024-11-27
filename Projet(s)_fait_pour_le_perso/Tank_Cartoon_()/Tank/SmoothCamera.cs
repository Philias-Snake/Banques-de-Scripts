using System.Collections;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target; // La cible que la cam�ra doit suivre
    public Vector3 offset; // D�calage spatial entre la cam�ra et la cible
    public float smoothSpeed = 0.125f; // Vitesse de l'effet "smooth" pour le suivi de la cam�ra
    public float lookAheadDistance = 5f; // Distance � regarder devant la cible
    public bool Detached;

    void Start()
    {
        Detached = false;
    }
    void FixedUpdate()
    {
        if (!Detached)
        {
            StartCoroutine(WaitOneSec());
            // Calcule la position cible de la cam�ra bas�e sur l'offset et la rotation de la cible
            Vector3 desiredPosition = target.position + target.TransformDirection(offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Calcule la position � regarder en ajoutant un d�calage devant la cible
            Vector3 lookAheadPosition = target.position + target.forward * lookAheadDistance;

            // Applique la position liss�e � la cam�ra
            transform.position = smoothedPosition;

            // Fait en sorte que la cam�ra regarde la position d�cal�e devant la cible
            transform.LookAt(lookAheadPosition);
        }

        if (Detached)
        {
            // Calcule la position cible de la cam�ra bas�e sur l'offset et la rotation de la cible
            Vector3 desiredPosition = target.position + target.TransformDirection(offset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Calcule la position � regarder en ajoutant un d�calage devant la cible
            Vector3 lookAheadPosition = target.position + target.forward * lookAheadDistance;

            // Fait en sorte que la cam�ra regarde la position d�cal�e devant la cible
            transform.LookAt(lookAheadPosition);
        }


    }

    public IEnumerator WaitOneSec()
    {
        yield return new WaitForSeconds(3f);
        smoothSpeed = 0.125f;

    }
}