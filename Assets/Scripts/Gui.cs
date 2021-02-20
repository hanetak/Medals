using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui
{  
    //コスト
  TextObj _txtCost;

    // Start is called before the first frame update
    public Gui()
    { 
            // コストテキスト
    _txtCost = MyCanvas.Find<TextObj>("TextCost");
    _txtCost.Label = "";
    }

    // Update is called once per frame
    public void Update()
    {
    _txtCost.SetLabelFormat("Cost: {0}", Global.Cost);
    }
}
