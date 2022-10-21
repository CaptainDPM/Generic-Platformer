using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float speed;
    private float currentPositionx;
    private Vector3 velocity = Vector3.zero;
    

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionx, transform.position.y, transform.position.z),
        ref velocity, speed);
    }


    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPositionx = _newRoom.position.x;
    }
}
