using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkRange : Token
{
    //攻撃時間
    const float ATK_TIMER = 1;

    float _tAtk = 0;
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
    private void OnTriggerStay2D(Collider2D other)
    {
        //味方の攻撃範囲内いる時
        if (other.gameObject.tag == "Enemy")
        {
            RaycastHit2D[] allHit = Physics2D.BoxCastAll(transform.position, new Vector2(3, 1), 0, Vector2.zero);
            _tAtk -= Time.deltaTime;
            if (_tAtk < 0)
            {
                if(allHit.Length == 1){ 
                other.GetComponent<Enemy>().Damage(1);
                }
                else
                {
                    allHit[0].collider.gameObject.GetComponent<Enemy>().Damage(3);

                }
                 _tAtk = ATK_TIMER;
            }

        }
    }
}
