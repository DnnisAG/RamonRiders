using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    //Variables x,y,z para cambiar ubicacion de la camara
     private static float posX = -1.75f;
     private static float posY = 9.25f;
     private static float posZ = -10f;

    public GameObject player;

    private Vector3 ubicacion = new Vector3(posX,posY,posZ);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + ubicacion;
    }
}