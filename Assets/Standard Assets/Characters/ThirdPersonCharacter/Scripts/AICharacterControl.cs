using System;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        float idleWaitTime = 15f;
        Animator animator;
        float idleTime = 0f;
        bool performingIdleAnim;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;

            animator = GetComponent<Animator>();
            animator.SetBool("Alive", false);
            idleTime = UnityEngine.Random.Range(15, 35);
        }


        private void Update()
        {

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance && !performingIdleAnim) {
                character.Move(agent.desiredVelocity, false, false);
                idleTime = 0;
            }  else {
                character.Move(Vector3.zero, false, false);
            }

            if (idleTime > idleWaitTime && !performingIdleAnim) {
                performingIdleAnim = true;
                animator.Play("Dance");
                GetComponent<NavMeshAgent>().speed = 0;
            }
            if (animator.GetBool("Alive")) {
                idleTime += Time.deltaTime;
            }

        }

        public void StopDance() {
            GetComponent<NavMeshAgent>().speed = 1;
            performingIdleAnim = false;
            idleTime = 0;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
