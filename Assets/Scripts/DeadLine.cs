using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : Token
{
    void OnTriggerEnter2D(Collider2D other)
    {

        //陣地に敵が到着した時
        if (other.gameObject.tag == "Enemy")
        {
            MyCanvas.SetActive("TextGameover", true);
        }

        ///変更予定

        ///

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
