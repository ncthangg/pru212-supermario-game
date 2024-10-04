using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Follow Player
    [SerializeField] private Transform Mario;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float CameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Follow Player
        transform.position = new Vector3(Mario.position.x, Mario.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Mario.localScale.x), Time.deltaTime * CameraSpeed);
    }
}
