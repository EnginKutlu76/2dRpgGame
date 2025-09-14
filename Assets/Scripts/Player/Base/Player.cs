using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour, IMoveable
{
    #region Movement&Flip Variables
    public Rigidbody2D rb { get; set; }
    public bool IsFacingRight { get; set; }
    #endregion

    public IPlayerInput Input;

    public PlayerStats stats;
    private Animator _animator;

    #region State Machine Variables
    public PlayerStateMachine StateMachine { get; set; }
    public IdleState IdleState { get; set; }
    public MoveState MoveState { get; set; }
    public JumpState JumpState { get; set; }
    public AttackState AttackState { get; set; }
    public HitState HitState { get; set; }
    public DeathState DeathState { get; set; }

    #endregion

    #region GroundCheck
    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    public bool IsGrounded;
    #endregion
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(this, StateMachine);
        MoveState = new MoveState(this, StateMachine);
        JumpState = new JumpState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);
        HitState = new HitState(this, StateMachine);
        DeathState = new DeathState(this, StateMachine);

        _animator = GetComponent<Animator>();
        Debug.Log("IdleState: " + (IdleState != null ? "Initialized" : "Null"));
    }
    private void Start()
    {
        Input = new NewInputSystemAdapter();
        rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
        Debug.Log("StateMachine Initialized with: " + (StateMachine.CurrentPlayerState != null ? StateMachine.CurrentPlayerState.GetType().Name : "Null"));
    }
    private void Update()
    {
        //StateMachine.CurrentPlayerState.FrameUpdate();
        StateMachine.LogicUpdate();
    }
    private void FixedUpdate()
    {
        //StateMachine.CurrentPlayerState.PhysicsUpdate();
        //HandleJump();
        if (StateMachine.CurrentPlayerState != null)
        {
            StateMachine.CurrentPlayerState.PhysicsUpdate();
            HandleJump();
        }
        else
        {
            Debug.LogError("CurrentPlayerState is null in FixedUpdate!");
        }
    }
    private void HandleJump()
    {
        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundLayer);
    }
    #region Movement&Flip Controller
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
        CheckForLeftOrRightFacing(velocity);
    }
    #endregion

    #region AnimationTypes
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)//Stateden Animatora tetik gönderme mekanizmasýdor
    {
        StateMachine.CurrentPlayerState.AnimationTriggerEvent(triggerType);
    }
    public void AnimationBoolEvent(AnimationBoolType boolType, bool value)
    {
        string boolName = boolType.ToString();
        if (_animator != null)
        {
            _animator.SetBool(boolName, value);
        }
        else
        {
            Debug.LogError("Animator null! Player GameObject'ine Animator ekleyin.");
        }
    }
    public enum AnimationTriggerType//hangi tetik olayýnýn gönderiliceðini belirler.
    {
        Attack,
        Hit,
        Death
    }
    public enum AnimationBoolType
    {
        Move,
        Jump
    }
    #endregion

}