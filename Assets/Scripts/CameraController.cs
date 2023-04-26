using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform jugador;

    private float yOffset = 9.25f;
    private float zOffset = -10f;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Jugador").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(jugador.position.x,jugador.position.y + yOffset, jugador.position.z+zOffset);
    }
}
