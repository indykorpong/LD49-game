using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectBase : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private float breakForce = 5f;
    [SerializeField] private float breakTorque = 5f;
    [SerializeField] private float damping = 1f;
    [SerializeField] private float frequency = 5f;
    private TargetJoint2D targetJoint2D;
    private bool isStick = false;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Object") || isStick) return;
        
        FixedJoint2D _joint = gameObject.AddComponent<FixedJoint2D>();
        
        _joint.anchor = other.contacts[0].point;

        _joint.breakForce = breakForce;
        _joint.breakTorque = breakTorque;
        _joint.connectedBody = other.gameObject.GetComponentInParent<Rigidbody2D>();
        _joint.enableCollision = false;
        
        isStick = true;
    }

    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        isStick = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (targetJoint2D)
        {
            targetJoint2D.target = _mousePos;
            //Debug.DrawLine (targetJoint2D.transform.TransformPoint (targetJoint2D.anchor), _mousePos, Color.green);
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(targetJoint2D);
        targetJoint2D = null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        targetJoint2D = gameObject.AddComponent<TargetJoint2D>();
        targetJoint2D.dampingRatio = damping;
        targetJoint2D.frequency = frequency;
        
    }
}
