using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantMove : MonoBehaviour
{
    public GameObject shadowPlayer;
    public AudioClip back_clip;
    bool iv = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(back_clip, Camera.main.transform.position);
            StartCoroutine(change_iv());
            GetComponent<Rigidbody>().position = shadowPlayer.transform.position;
        }
    }

    public bool get_iv()
    {
        return iv;
    }

    IEnumerator change_iv()
    {
        iv = true;
        yield return new WaitForSeconds(0.6f);
        iv = false;
    }
}
