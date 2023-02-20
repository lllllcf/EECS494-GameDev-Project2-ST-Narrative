using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
