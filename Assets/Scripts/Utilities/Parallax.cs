using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    [SerializeField] private float offset;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;
    
    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float _temp = cam.transform.position.y * (1 - parallaxEffect);
        float _dist = ((cam.transform.position.y / 2) * parallaxEffect) + offset;

        transform.position = new Vector3(transform.position.x, startpos + _dist, transform.position.z);

        // if (_temp > startpos + length)
        // {
        //     startpos += length;
        // }
        // else if (_temp < startpos - length)
        // {
        //     startpos -= length;
        // }
    }
}
