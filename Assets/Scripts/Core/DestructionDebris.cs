using UnityEngine;

namespace Generals.Core.VFX
{
    /// <summary>
    /// Спавн обломков при уничтожении.
    /// </summary>
    public class DestructionDebris : MonoBehaviour
    {
        public GameObject[] debrisPrefabs;
        public int count = 3;

        public void SpawnDebris()
        {
            for (int i = 0; i < count; i++)
            {
                if (debrisPrefabs.Length == 0) return;

                GameObject debris = Instantiate(debrisPrefabs[Random.Range(0, debrisPrefabs.Length)], transform.position, Random.rotation);
                Rigidbody rb = debris.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(500f, transform.position, 5f);
                }
                Destroy(debris, 5f);
            }
        }
    }
}
