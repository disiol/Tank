using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankMovement : MonoBehaviour
{
    private const int MoveVerticalStop = 0;
    private const int MoveVerticalBack = -1;
    private const int MoveVerticalForward = 1;

    [SerializeField] private float maxSpeed = 2000f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotateSpeed = 50f;

    [SerializeField] private float xAngle;

    private Rigidbody _rb;
    private Transform _hullLOD0;

    private void Awake()
    {
        // Присваиваем значение в переменную rb
        _rb = GetComponent<Rigidbody>();
        _rb.drag = maxSpeed;

        _hullLOD0 = transform.GetChild(0);


    }

    private void Update()
    {
        // Tilt tank
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Получаем данные от пользователя (нажатия на стрелочки или клавиши W и S)
        float moveVertical = Input.GetAxis("Vertical");

        // Вращаем объект без использования физики
        transform.Rotate(Vector3.up * rotateSpeed * moveHorizontal);

        // Задаем траекторию, основываясь на данных от пользователя
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;


        switch (moveVertical)
        {
            case MoveVerticalStop:
                //rb.velocity= Vector3.up;

                Movement(movement, moveVertical);
                //TODO во время торможения должен наклоняться вперед;
                TiltTank();

                break;
            case MoveVerticalBack:
                Movement(movement, moveVertical);
                TiltTank();

                //TODO Во время ускорения танк должен наклоняться назад

                break;
            case MoveVerticalForward:
                Movement(movement, moveVertical);
                TiltTank();

                //TODO нВо время ускорения танк должен наклоняться назад

                break;
        }
    }

    private void TiltTank()
    {
        if (_rb.velocity.magnitude != 0)
        {
            
                _hullLOD0.transform.rotation = new Quaternion(xAngle, 0, 0, 1f);
            
        }
        else if (_rb.velocity.magnitude == 0)
        {
            
            _hullLOD0.transform.rotation = new Quaternion(-xAngle, 0, 0, 1f);

            

        }
    }

    private void Movement(Vector3 movement, float moveVertical)
    {
        _rb.AddRelativeForce(transform.TransformDirection(movement));
    }
}