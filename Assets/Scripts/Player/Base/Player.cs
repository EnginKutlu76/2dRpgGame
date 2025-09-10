using UnityEngine;
using static Enemy;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMoveable
{
    public Rigidbody2D rb { get; set; }
    public bool IsFacingRight { get; set; }

    public PlayerStats stats;

    #region State Machine Variables
    public PlayerStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public MoveState MoveState { get; set; }
    public JumpState JumpState { get; set; }
    public AttackState AttackState { get; set; }
    public HitState HitState { get; set; }
    public DeathState DeathState { get; set; }

    #endregion

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(this,StateMachine);
        MoveState = new MoveState(this,StateMachine);
        JumpState = new JumpState(this,StateMachine);
        AttackState = new AttackState(this,StateMachine);
        HitState = new HitState(this,StateMachine);
        DeathState = new DeathState(this,StateMachine);
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        StateMachine.CurrentPlayerState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentPlayerState.PhysicsUpdate();
    }
    #region Movement&Flip
    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }
    public void MoveObject(Vector2 velocity)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentPlayerState.AnimationTriggerEvent(triggerType);
    }
    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayerFootstepSound
    }
}
