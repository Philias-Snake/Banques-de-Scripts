using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint; // Point de d�part de la plateforme
    public Transform endPoint;   // Point d'arriv�e de la plateforme
    public float speed = 2f;     // Vitesse de d�placement de la plateforme

    private Vector3 nextPoint;   // Prochain point de d�placement
    private bool movingToEnd = true; // Bool�en pour indiquer si la plateforme se d�place vers le point d'arriv�e ou le point de d�part

    void Start()
    {
        // Initialisation du premier point de d�placement
        nextPoint = endPoint.position;
    }

    void Update()
    {
        // D�placement de la plateforme
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);

        // V�rifier si la plateforme a atteint le prochain point
        if (Vector3.Distance(transform.position, nextPoint) < 0.1f)
        {
            // Changer la direction de d�placement
            if (movingToEnd)
            {
                nextPoint = startPoint.position;
            }
            else
            {
                nextPoint = endPoint.position;
            }

            // Inverser la direction de d�placement
            movingToEnd = !movingToEnd;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(startPoint.transform.position, 0.5f);
        Gizmos.DrawWireSphere(endPoint.transform.position, 0.5f);
        Gizmos.DrawLine(startPoint.transform.position, endPoint.transform.position);
    }
}
