using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseWallTrigger : MonoBehaviour
{
    GameObject winLoseController;
    // Start is called before the first frame update
    void Start()
    {
        winLoseController = GameObject.Find("WinLoseController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            winLoseController.GetComponent<winLoseControl>().lose_game();
        }

    }
}
