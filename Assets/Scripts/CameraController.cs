using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float camMoveSpeed = 0.2f;
    // Update is called once per frame
    void Update()
    {
        var _transformPosition = transform.position;
        _transformPosition.y += camMoveSpeed * Time.deltaTime;
        transform.position = _transformPosition;
    }
}
