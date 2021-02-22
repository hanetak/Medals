using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Token
{
    public int _hp = 20;

    public int _atk;

    public int _cost;

    public int _weight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    /// ダメージを受けた
    public void Damage(int val)
    {
        // HPを減らす
        _hp -= val;
        Debug.Log(val +"のダメージ");
        if (_hp <= 0)
        {
            // HPがなくなったので死亡
            MyCanvas.SetActive("TextGameclear", true);
            Vanish();
        }
    }
}
