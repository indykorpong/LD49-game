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
    [SerializeField] private Rigidbody2D rb;
    
    private TargetJoint2D targetJoint2D;
    private bool isStick = false;
    private bool canDrag = true;
    private bool isFirstStick = false;
    private int currentStick = 0;
    private List<FixedJoint2D> fixedJoint2Ds = new List<FixedJoint2D>();
    private void OnValidate()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
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
        
        fixedJoint2Ds.Add(_joint);
        
        if (!isFirstStick)
        {
            OnStick?.Invoke();
            isFirstStick = true;
        }
        
        isStick = true;
        canDrag = false;
        currentStick++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("OutZone"))
        {
            if (!isFirstStick)
            {
                OnStick?.Invoke();
                isFirstStick = true;
            }

            if (isStick)
            {
                rb.bodyType = RigidbodyType2D.Static;
                foreach (var _joint in fixedJoint2Ds)
                {
                    Destroy(_joint);
                }
                fixedJoint2Ds.Clear();
            }
        }
        else if (other.gameObject.CompareTag("DestroyZone"))
        {
            OnStick?.Invoke();
            Destroy(this.gameObject);
        }
    }

    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        fixedJoint2Ds.Remove((FixedJoint2D)brokenJoint);
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
