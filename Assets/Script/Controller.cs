using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public abstract class Controller : MonoBehaviour
{
    private Unit unit;
    public Animator animator;
    private Rigidbody rigidBody;

    public bool isControllable = true;
    public bool isDodge = false;
    public bool isDamage;

    public Vector3 moveDirection;
    public Vector3 rotateVector;
    public float groundRayDistance;
    public int groundLayer;
    public float maxSlopeAngle;

    public RaycastHit slopeRayHit;
    public bool _isOnSlope;
    public bool _isOnGround;

    public Transform stairCheck;
    public float forwardCheck;

    public int attackPattern;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        unit = GetComponent<Unit>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        groundLayer = LayerMask.GetMask("Terrain");
        unit.transform.localEulerAngles = rotateVector;
    }

    public virtual void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        Move();
        
    }

    public void Move()
    {
        if (!isControllable)
            return;
        GetMoveDirection();

        animator.SetInteger("walkHorizon", (int)moveDirection.x);
        animator.SetInteger("walkVertical", (int)moveDirection.z);
        animator.SetBool("isWalk", moveDirection != Vector3.zero);

        _isOnSlope = SlopeCheck();
        _isOnGround = GroundCheck();

        Vector3 _velocity = transform.TransformDirection(moveDirection.normalized);
        Vector3 _gravity = Vector3.down * Mathf.Abs(rigidBody.velocity.y);

        if (_isOnSlope && _isOnGround)
        {
            _velocity = AdjustDirectionOnSlope(_velocity);
            _gravity = Vector3.zero;
            rigidBody.useGravity = false;
        }
        else
        {
            rigidBody.useGravity = true;
        }

        rigidBody.velocity = _velocity * unit.moveSpeed + _gravity;

    }

    public void Rotate()
    {
        GetRotateQuaternion();
        unit.transform.localEulerAngles = rotateVector;
    }

    public virtual void Attack()
    {
        isControllable = false;
        animator.SetTrigger("doAtk");
        animator.SetInteger("atkPtn", attackPattern);
        UpdateAttackPattern();
    }

    public void Controllablize()
    {
        isControllable = true;
    }

    public abstract void GetMoveDirection();
    public abstract void GetRotateQuaternion();
    public abstract void UpdateAttackPattern();

    public bool SlopeCheck()
    {
        Ray _ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * groundRayDistance, Color.yellow);

        if(Physics.Raycast(_ray, out slopeRayHit, groundRayDistance))
        {
            float _angle = Vector3.Angle(Vector3.up, slopeRayHit.normal);
            return _angle != 0f && _angle < maxSlopeAngle;
        }
        return false;
    }

    public Vector3 AdjustDirectionOnSlope(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeRayHit.normal).normalized;
    }

    public bool GroundCheck()
    {
        Vector3 _boxSize = new Vector3(transform.lossyScale.x, 0.1f, transform.lossyScale.z);
        return Physics.CheckBox(transform.position, _boxSize, Quaternion.identity, LayerMask.GetMask("Terrain"));
    }
}
