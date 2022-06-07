using SoftGear.Strix.Unity.Runtime;
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
