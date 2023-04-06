using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transferToAnotherDoor : MonoBehaviour
{
    public GameObject desDoor;
    public GameObject player;
    public AudioClip tp_clip;

    private bool nearWater = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    private void Update()
    {
        if (nearWater && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            AudioSource.PlayClipAtPoint(tp_clip, Camera.main.transform.position);
            player.transform.position = desDoor.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) nearWater = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) nearWater = false;
    }
}
