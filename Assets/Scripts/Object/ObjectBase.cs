using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class ObjectBase : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Action OnStick;
    
    [SerializeField] private float breakForce = 300f;
    [SerializeField] private float breakTorque = 300f;
    [SerializeField] private float damping = 1f;
    [SerializeField] private float frequency = 5f;

    [SerializeField] private int maxStick = 2;
    
    
    private TargetJoint2D targetJoint2D;
    private bool isStick = false;
    private bool canDrag = true;
    private bool isFirstStick = false;
    private int currentStick = 0;
    
    private void OnValidate()
    {
        var _rb = GetComponent<Rigidbody2D>();
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        gameObject.tag = "Object";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Object") || currentStick > maxStick) return;
        
        FixedJoint2D _joint = gameObject.AddComponent<FixedJoint2D>();
        
        //_joint.anchor = other.contacts[0].point;

        _joint.breakForce = breakForce;
        _joint.breakTorque = breakTorque;
        _joint.connectedBody = other.gameObject.GetComponentInParent<Rigidbody2D>();
        _joint.enableCollision = true;

        if (!isFirstStick)
        {
            OnStick?.Invoke();
            isFirstStick = true;
        }
        
        isStick = true;
        canDrag = false;
        currentStick++;
    }

    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        isStick = false;
        currentStick--;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(!canDrag) return;
        
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
        StartDrag();
    }

    private void StartDrag()
    {
        if(!canDrag) return;
        targetJoint2D = gameObject.AddComponent<TargetJoint2D>();
        targetJoint2D.dampingRatio = damping;
        targetJoint2D.frequency = frequency;
    }
}
