using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevel2 : MonoBehaviour
{
    public void click()
    {
        print("aa");
        SceneManager.LoadScene("Level2");
    }
}
