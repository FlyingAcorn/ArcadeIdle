using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
namespace _GAME_.Scripts.Agents
{
    public class Agent : MonoBehaviour
    {
        [SerializeField] private Node targetNode;
        [SerializeField] protected NavMeshAgent agent;
        [SerializeField] protected Rigidbody myBody;
        [SerializeField] protected Animator animator;
        protected Coroutine currentCoroutine;

        public enum AgentBehaviourState
        {
            Moving,
            Acting,
            Idle
        }

        protected virtual void Start()
        {
            UpdateAgentState(AgentBehaviourState.Moving);
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
                currentCoroutine = StartCoroutine( MoveToTarget());
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


        private void Update()
        {       
        
        }
    }
}
