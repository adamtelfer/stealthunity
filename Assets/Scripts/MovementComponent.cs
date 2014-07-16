using UnityEngine;
using System.Collections;

public class MovementComponent : MonoBehaviour {

	public Rigidbody2D rigid;

    // Movement Controller
    public enum FacingDirection
    {
        Up,
        Down,
        Left,
        Right
    };
    private FacingDirection _facingDirection;
    public delegate void FacingDirectionUpdate(MovementComponent component);
    public FacingDirectionUpdate facingDirectionUpdateDelegate;

	public FacingDirection CurrentFacingDirection
	{
		get { return _facingDirection; }
	}

    public enum MovementState
    {
        Moving,
        Stopped,
        Disabled
    };
    private MovementState _movementState;
    public delegate void MovementStateUpdate (MovementComponent component);
    public MovementStateUpdate movementStateUpdateDelegate;

    public MovementState CurrentMovementState
    {
        get { return _movementState; }
    }

    private Vector3 currentTarget;
    private float currentSpeed;
    public void SetTarget(Vector3 worldPosition, float speed)
    {
        currentTarget = worldPosition;

        Vector3 direction = worldPosition - transform.position;
        direction.Normalize();
        if (direction.x > 0.5f)
        {
            _facingDirection = FacingDirection.Right;
        } else if (direction.x < -0.5f)
        {
            _facingDirection = FacingDirection.Left;
        } else if (direction.y < 0f)
        {
            _facingDirection = FacingDirection.Down;
        } else
        {
            _facingDirection = FacingDirection.Up;
        }
        facingDirectionUpdateDelegate(this);


        currentSpeed = speed;
        _movementState = MovementState.Moving;
        movementStateUpdateDelegate(this);
    }

    public float stopAtDistanceSQ = 0.5f;

    public float toVel = 2.5f;
    public float maxVel = 15.0f;
    public float maxForce = 40.0f;
    public float gain = 5f;

    void Start()
    {
        StopAllMovement();
    }

    void FixedUpdate()
    {
        if (_movementState == MovementState.Moving)
        {
            Vector3 dist = (currentTarget - transform.position) * currentSpeed;
            if (dist.sqrMagnitude > stopAtDistanceSQ)
            {
                // calc a target vel proportional to distance (clamped to maxVel)
                Vector3 tgtVel = Vector3.ClampMagnitude(toVel * dist, maxVel);
                // calculate the velocity error
				Vector3 error = tgtVel - new Vector3(rigid.velocity.x, rigid.velocity.y);
                // calc a force proportional to the error (clamped to maxForce)
                Vector3 force = Vector3.ClampMagnitude(gain * error, maxForce);
                rigid.AddForce(force);
            }
            else
            {
                StopAllMovement();
            }
        }
    }

    public void StopAllMovement()
    {
		rigid.velocity = Vector3.zero;
        currentTarget = Vector3.zero;
        currentSpeed = 0f;
        _movementState = MovementState.Stopped;
        if (movementStateUpdateDelegate != null)
        {
            movementStateUpdateDelegate(this);
        }
    }
}
