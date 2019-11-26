using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    [SerializeField] private lightScript Fovs;
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        //finder musens pos i forhold til spilleren
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //udregner den vinkel spilleren skal have for at kikke mod musen
        var ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Fovs.SetAimDirection(dir);
        Fovs.SetOrigin(transform.position);
        //sætter så spilleresn rotation til den udregnede vinkel
        //transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);

    }

}
