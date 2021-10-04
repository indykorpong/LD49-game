using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField] private bool repeat;

    [SerializeField] private bool checkUpper;
    [SerializeField] private float offset;
    [SerializeField] private Camera cam;
    [SerializeField] private float parallaxEffect;
    
    private float lowerCam, upperCam;
    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        float _pos = transform.position.y;
        float _dist = ((cam.transform.position.y / 2) * parallaxEffect) + offset;

        transform.position = new Vector3(transform.position.x, startpos + _dist, transform.position.z);

        if (repeat)
        {
            lowerCam = cam.ViewportToWorldPoint(new Vector3(0, cam.rect.min.y)).y;
            upperCam = cam.ViewportToWorldPoint(new Vector3(0, cam.rect.max.y)).y;

            if (!checkUpper)
            {
                if (_pos <= lowerCam - 10)
                {
                    var _newPos = Random.Range(0, 3f);
                    startpos = upperCam + _newPos;
                }
            }
            else
            {
                if (_pos <= upperCam + 10)
                {
                    startpos = upperCam + 30;
                }
            }
            
        }
        
    }
}
