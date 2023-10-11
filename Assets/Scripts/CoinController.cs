using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float t = 0;
    public int p = 2;
    public float a = 0.7f;
    
    void Update()
    {
        t+=Time.deltaTime;
        if(t >= 0.5f)
        {
            t = 0;
            p++;
        }
        if(p > 2)
        {
            p = 1;
        }
        if(p == 1)
        {
            a += Time.deltaTime;
        } else
        {
            a -= Time.deltaTime;
        }
        transform.localScale = new Vector3(a, 0.7f, 0.7f);
    }
}
