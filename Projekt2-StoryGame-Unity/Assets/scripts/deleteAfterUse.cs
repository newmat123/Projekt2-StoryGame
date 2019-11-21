using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAfterUse : MonoBehaviour
{
    private int timeTo = 2;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeTo)
        {
            Destroy(this.gameObject);
        }
    }
}
