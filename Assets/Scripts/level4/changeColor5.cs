using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor5 : MonoBehaviour
{
    public Color newColor;
    bool collided = false;
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
        if(other.gameObject.tag == "Player" && !collided)
        {
            GetComponent<SpriteRenderer>().color = newColor;
            winLoseController.GetComponent<winLoseControlLevel5>().add_count();
            collided = true;
        }
        else if (other.gameObject.tag == "Player" && collided)
        {
            if (!other.gameObject.GetComponent<InstantMove>().get_iv())
                winLoseController.GetComponent<winLoseControlLevel5>().lose_game();
        }

    }
    
}
