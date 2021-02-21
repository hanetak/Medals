using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRange : Token
{
    public Sprite atkR;
    // Start is called before the first frame update
    void Start()
    {
        atkR = Resources.Load<Sprite>("Sprites/UI/SelUIR");
        NonVisible();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NonVisible()
    {
        SetSprite(null);
    }

    public void CanVisible()
    {
        SetSprite(atkR);
    }

}
