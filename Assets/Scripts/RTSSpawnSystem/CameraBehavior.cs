using UnityEngine;

public class CameraBehavior : MonoBehaviour 
{
    [SerializeField]
    private float _MoveSpeed;
	[SerializeField]
	private RefCamera _Camera;
    private float _XInput;
    private float _ZInput;
    private Rigidbody _Rb;

    private void Awake()
    {
		_Camera.Value = GetComponent<Camera>();
        _Rb = GetComponent<Rigidbody>();
    }

	private void Update()
    {
        _XInput = Input.GetAxis("Horizontal");    
        _ZInput = Input.GetAxis("Vertical");    
    }

    private void FixedUpdate()
    {
        _Rb.velocity = new Vector3(_XInput * _MoveSpeed, 0, _ZInput * _MoveSpeed);
    }
}
