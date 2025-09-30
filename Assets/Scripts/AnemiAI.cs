using System;
using UnityEngine;
using UnityEngine.AI;
using Knight_Adventyre.Ulls;


public class AnemiAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float DistonsionMax = 7f;
    [SerializeField] private float DistonsionMin = 4f;
    [SerializeField] private float roamingTimeMax = 2f;
    [SerializeField] private bool isChasingEnemy = false;
    [SerializeField] private bool _isAtackEnemy = false;
    [SerializeField] private float _atackeDistanse = 2f;
    [SerializeField] private float CasingSpidMyltiPlayer = 2f;
    [SerializeField] private float _casingDistanse = 4f;
    [SerializeField] private float _atackeRate = 2f;
    private float _nextAtacktime;


    private NavMeshAgent navMeshAgent;
    private State _curentState;
    private float roamingTime;
    private Vector3 roamingPosition;
    private Vector3 startPosition;

    private float _casingSpid;
    private float _roamingSpid;
    public event EventHandler onEnemiAtack;
    private float _nextCheckDistantionTime = 0f;
    private float _checkDirectionDuration = 0.1f;
    private Vector3 _lastPosition;

    private enum State
    {
        Idle,
        Roaming,
        Chasing,
        Attacking,
        Death,
    }
    
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        _curentState = startingState;
        _roamingSpid = navMeshAgent.speed;
        _casingSpid = navMeshAgent.speed * CasingSpidMyltiPlayer;
    }
    private void Update()
    {
        StateHendler();
        MoventDirertionHandler();
    }

    public void SetDeatStait()
    {
        navMeshAgent.ResetPath();
        _curentState = State.Death;
    }
    private void StateHendler()
    {
        switch (_curentState)
        {

            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimeMax;
                }
                ChekCerentState();
                break;
            case State.Chasing:
                ChasingTarget();
                ChekCerentState();
                break;

            case State.Attacking:
                AtackingTaget();
                ChekCerentState();
                break;
            case State.Death:
                break;
            default:
            case State.Idle:
                break;
        }
    }
   
    private void ChasingTarget()
    {
        navMeshAgent.SetDestination(Player.Instanse.transform.position);
    }
    private void ChekCerentState()
    {
        float dictanseToPlayer = Vector3.Distance(transform.position, Player.Instanse.transform.position);
        State newState = State.Roaming;
        
        if (isChasingEnemy)
        {if (dictanseToPlayer <= _casingDistanse)
            {
                newState = State.Chasing;
            }

        }


        if (_isAtackEnemy)
        {
            if (dictanseToPlayer <= _atackeDistanse) 
            {
                if (Player.Instanse.IsAlive())
                {
                    newState = State.Attacking;
                }
                else
                {
                    newState = State.Roaming;
                }
            
            }
        }


        if (newState != _curentState )
        {if (newState == State.Chasing)
            {
                navMeshAgent.ResetPath();
                navMeshAgent.speed = _casingSpid;
            }
        else if (newState == State.Roaming)
            {
                roamingTime = 0f;
                navMeshAgent.speed = _roamingSpid;
            }
        else if(newState  == State.Attacking)
            {
                navMeshAgent.ResetPath();
            }

            _curentState = newState;
        }
        
    }

    public float GetAnimationSpeed()
    {
        return navMeshAgent.speed / _roamingSpid;
    }
    public bool isRaning()
    {
        if (navMeshAgent.velocity == Vector3.zero) 
        {
            return false;
        } 
        else 
        {
            return true;
        }
            
    }
    private void AtackingTaget()
    {
        if (Time.time > _nextAtacktime)
        {
            onEnemiAtack?.Invoke(this, EventArgs.Empty);
            _nextAtacktime = Time.time + _atackeRate;
        }
        
    }

    private void MoventDirertionHandler()
    {
        if(Time.time > _nextCheckDistantionTime)
        {
            if (isRaning())
            {
                ChangeFacingDirection(_lastPosition, transform.position);
            }
            else if (_curentState == State.Attacking)
            {
                ChangeFacingDirection(transform.position, Player.Instanse.transform.position);
            }
            _lastPosition = transform.position;
            _nextCheckDistantionTime = Time.time + _checkDirectionDuration;
        }
    }

    private void Roaming()
    {
        startPosition = transform.position;
        roamingPosition = GetRoamingPosition();
        navMeshAgent.SetDestination(roamingPosition);
    }
    private Vector3 GetRoamingPosition()
    {
        return transform.position + Ulls.GetRoamingDir() * UnityEngine.Random.Range( DistonsionMin, DistonsionMax );
    }

    private void ChangeFacingDirection(Vector3 soursePosition, Vector3 targetPosition)
    {
        if (soursePosition.x > targetPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
