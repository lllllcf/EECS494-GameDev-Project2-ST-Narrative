using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winLoseControl : MonoBehaviour
{
    public int total_count;
    private int count;
    private bool lose = false;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == total_count)
        {
            SceneManager.LoadScene("ChooseLevel");
        }

        if (lose)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void add_count()
    {
        count += 1;
    }

    public void lose_game()
    {
        lose = true;
    }

}
