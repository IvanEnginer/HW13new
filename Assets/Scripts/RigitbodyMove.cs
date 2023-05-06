using UnityEngine;

public class RigitbodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigitbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Joystick _joystick;
    private Vector2 _moveInpur;
    [SerializeField] private Animator _animator;

    private int _runAnimation = Animator.StringToHash("Run");

    private void Update()
    {
        _moveInpur = _joystick.Value;
        _animator.SetBool(_runAnimation, _joystick.IsPressed);

    }

    private void FixedUpdate()
    {
        _rigitbody.velocity = new Vector3(_moveInpur.x, 0f, _moveInpur.y) * _speed;

        if (_rigitbody.velocity != Vector3.zero )
        {
            transform.rotation = Quaternion.LookRotation(_rigitbody.velocity, Vector3.up);
        }
    }
}
