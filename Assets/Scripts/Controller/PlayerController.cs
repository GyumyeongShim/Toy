using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_minHeight;

    private Movement m_movement;

    private void Start()
    {
        Managers.Input.m_keyAction -= OnKeyboard;
        Managers.Input.m_keyAction += OnKeyboard;

        m_movement = GetComponent<Movement>();
    }

    private void Update()
    {
        ChageSceneFallDown();
    }

    void OnKeyboard()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.forward;
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            //transform.position += Vector3.forward * Time.deltaTime * m_speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
        }

        m_movement.MoveTo(dir);
    }

    private void ChageSceneFallDown()
    {
        if (transform.position.y < m_minHeight)
        {
            Managers.Scene.RestartScene();
        }
    }
}
