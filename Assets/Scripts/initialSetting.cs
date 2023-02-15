using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialSetting : MonoBehaviour
{
    bool enable_set = true;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1455, 905, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnMouseDown()
    //{
    //    if (enable_set)
    //    {
    //        Screen.fullScreen = !Screen.fullScreen;
    //        enable_set = false;
    //    }
    //    
    //}
}
