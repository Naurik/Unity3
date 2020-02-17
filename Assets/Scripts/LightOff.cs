using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LightOff : MonoBehaviour
{
    [SerializeField]
    private Light flashLight;
    [SerializeField]
    private AudioSource audio;
    // Start is called before the first frame update

    private void Start()
    {
        audio.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Play();
            flashLight.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.Stop();
            flashLight.enabled = true;
        }
    }
}
