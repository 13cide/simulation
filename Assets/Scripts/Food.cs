using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    internal Animal animal;
    [SerializeField] private GameObject particlesPrefab;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.Equals(animal.gameObject)) {
            GameObject particles = Instantiate(particlesPrefab);
            particles.transform.position = new Vector3(transform.position.x, particlesPrefab.transform.position.y, transform.position.z);
            particles.GetComponent<Renderer>().material.color = animal.animalColor; 
            StartCoroutine(DeleateParticles(particles));
            animal.FoodNextPosition();
        }
    }

    IEnumerator DeleateParticles(GameObject particles) {
        yield return new WaitForSeconds(1f);
        Destroy(particles);
    }
}
