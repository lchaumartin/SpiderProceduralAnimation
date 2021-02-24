using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpiderController : MonoBehaviour
{
    public float _speed = 1f;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float multiplier = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = 2f;

        if (_rigidbody.velocity.magnitude < _speed * multiplier)
        {

            float value = Input.GetAxis("Vertical");
            if (value != 0)
                _rigidbody.AddForce(0, 0, value * Time.fixedDeltaTime * 1000f);
            value = Input.GetAxis("Horizontal");
            if (value != 0)
                _rigidbody.AddForce(value * Time.fixedDeltaTime * 1000f, 0f, 0f);
        }
    }
}
