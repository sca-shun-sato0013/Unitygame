
using UnityEngine;

public class MoveX : MonoBehaviour
{
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 10.0f + pos.x, pos.y, pos.z);  
    
    }
}
