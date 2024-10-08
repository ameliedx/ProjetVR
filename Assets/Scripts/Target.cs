using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject particleEffectPrefab;  // Prefab de l'effet de particules (explosion, fum�e, etc.)
    public float destroyDelay = 0.5f;        // D�lai avant de d�truire la cible (en secondes)

    void OnCollisionEnter(Collision collision)
    {
        // V�rifier si l'objet entrant est une balle
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // D�clencher l'effet de particules � l'endroit o� la cible a �t� touch�e
            Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

            // D�truire la cible avec un d�lai pour permettre aux particules de se jouer
            Destroy(gameObject, destroyDelay);
        }
    }
}
