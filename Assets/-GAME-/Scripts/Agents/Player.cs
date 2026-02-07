using System.Collections;
using UnityEngine;

namespace _GAME_.Scripts.Agents
{
    public class Player : Agent
    {
        private enum MovementMode
        {
            Auto,
            Manuel
        }
        [SerializeField] private MovementMode currentMode;
        protected override void Start()
        {
            currentCoroutine = StartCoroutine(FreeMovement()); // agent coroutini ile bu arasında sistem olucak
        }
        
        IEnumerator FreeMovement()
        {
            while (currentMode == MovementMode.Manuel)
            {
                animator.SetFloat("velocity", agent.velocity.magnitude);
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Began)
                    {
                        Ray ray = Camera.main!.ScreenPointToRay(touch.position);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            agent.destination = hit.point;
                        }
                    }
                }
                yield return null;
            }
        }
    }
}
