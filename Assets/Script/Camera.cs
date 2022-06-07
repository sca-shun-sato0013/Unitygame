using SoftGear.Strix.Unity.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : StrixBehaviour
{
    private GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.Find("irasutoya(Clone)/Main Camera");
    }
    void Update()
    {
        if (isLocal == false)
        {
            mainCamera.SetActive(false);
        }



    }

    
 
}
