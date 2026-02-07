using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] private Node targetNode;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Rigidbody myBody;
    [SerializeField] private Animator animator;
    private Coroutine _currentCoroutine;

    public enum AgentBehaviourState
    {
        Moving,
        Acting,
        Idle
    }
    public static event Action<AgentBehaviourState> OnAgentStateChanged;
    public AgentBehaviourState currentBehaviour;

    public void UpdateAgentState(AgentBehaviourState state)
    {
        currentBehaviour = state;
        if (state == AgentBehaviourState.Idle)
        {
            
        }
        
        if (state == AgentBehaviourState.Moving)
        { 
            animator.SetBool("canRun",true);
            _currentCoroutine = StartCoroutine( MoveToTarget());
        }

        if (state == AgentBehaviourState.Acting)
        {
            
        }
        OnAgentStateChanged?.Invoke(state);
    }

    private IEnumerator MoveToTarget()
    {
        while (targetNode.transform.position != transform.position)
        {
            agent.destination = targetNode.transform.position;
            yield return null;
        }
        
    }
    void Start()
    {
        UpdateAgentState(AgentBehaviourState.Moving);
    }
    
    void Update()
    {
        
    }
}
