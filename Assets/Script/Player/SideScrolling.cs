using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;

        /*Camera be fixed on the right side*/
        cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);

        /*Camera can return to the left side of the map*/
        //cameraPosition.x = player.position.x;

        transform.position = cameraPosition;
    }
}
