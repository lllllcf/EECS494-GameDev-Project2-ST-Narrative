using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantMove : MonoBehaviour
{
    public GameObject shadowPlayer;
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
        yield return new WaitForSeconds(1);
        iv = false;
    }
}
