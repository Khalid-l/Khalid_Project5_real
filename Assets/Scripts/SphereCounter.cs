using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereCounter : MonoBehaviour
{
    int Sphere = 0;
    int Star = 0;
    public Text SphereText;
    public Text StarText;
    [SerializeField] AudioSource collictionSoundSphere;
    [SerializeField] AudioSource collictionSoundStars;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            Destroy(other.gameObject);
            Sphere++;
            SphereText.text = "Spheres :" + Sphere;
           collictionSoundSphere.Play();
        }
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            Star++;
            StarText.text = "Stars :" + Star;
            collictionSoundStars.Play();

        }
    }
}