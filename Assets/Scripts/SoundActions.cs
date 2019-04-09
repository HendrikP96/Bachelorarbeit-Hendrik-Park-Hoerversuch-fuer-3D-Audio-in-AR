using HoloToolkit.Unity.InputModule;
using UnityEngine;
using HoloToolkit.Unity;

namespace Academy
{
    [RequireComponent(typeof(Interpolator))]
    public class SoundActions : MonoBehaviour
    {
         

        [Tooltip("The speed at which the Sphere is to move.")]
        [Range(5.0f, 60.0f)]
        public float MoveSpeed = 60.0f;


        private Interpolator interpolator;

        void Start()
        {
            interpolator = GetComponent<Interpolator>();

            interpolator.PositionPerSecond = MoveSpeed;
            interpolator.SmoothLerpToTarget = true;

            interpolator.InterpolationDone += Interpolator_InterpolationDone;
        }

        private void Interpolator_InterpolationDone()
        {
            transform.LookAt(Camera.main.transform.position);
        }

        public void ComeBack()
        {
            Vector3 basePosition = GameObject.Find("Position gehörte Schallquelle").transform.position;
            interpolator.SetTargetPosition(basePosition);
        }

    }
}
