using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

		public GameObject background;
		public float bgWidth, bgHeight;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {

            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;

			bgWidth = background.transform.localScale.x / background.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
			bgHeight = background.transform.localScale.y / background.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

			float x = newPos.x;
			float y = newPos.y;

			if (x < (-1 * (bgWidth / 2) - (Camera.main.aspect * 2f))) {
				x = -1 * (bgWidth / 2.0f + Camera.main.aspect * 2f);
			} else if (x > (bgWidth / 2) + (Camera.main.aspect * 2f)) {
				x = (bgWidth / 2) + (Camera.main.aspect * 2f);
			}

			if (y < (-1 * (bgHeight / 2) - (Camera.main.orthographicSize * 2f))) {
				y = -1*(bgHeight / 2.0f + Camera.main.orthographicSize * 2f);
			} else if (y > (bgHeight / 2) + (Camera.main.orthographicSize * 2f)) {
				y = ((bgHeight / 2) + (Camera.main.orthographicSize * 2f));
			}

			Vector3 myPos = new Vector3(x, y, -1);

			transform.position = myPos;
			m_LastTargetPosition = target.position;



        }
    }
}
