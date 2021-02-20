using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : Token
{
    public float MOVE_X;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCam()
    {
        float x =this.transform.position.x;
        x += MOVE_X;
        this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
    }
}
