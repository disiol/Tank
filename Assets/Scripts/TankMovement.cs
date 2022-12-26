using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private const int MoveVerticalStop = 0;
    private const int MoveVerticalBack = -1;
    private const int MoveVerticalForward = 1;

    [SerializeField] private float maxSpeed = 2000f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotateSpeed = 50f;

    private Rigidbody rb;

    private void Awake()
    {
        // Присваиваем значение в переменную rb
        rb = GetComponent<Rigidbody>();
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
              

                //TODO наклон танка на зад при остановке

                break;
            case MoveVerticalBack:
                rb.AddRelativeForce(transform.TransformDirection(movement));

                //TODO наклон танка в пред при движении 

                break;
            case MoveVerticalForward:
                rb.AddRelativeForce(transform.TransformDirection(movement));
                //TODO наклон танка в пред при движении 

                break;
        }

        // Работаем со светом
        // Если двигаемся вперед и объект frontLights не активен,
        // то включаем этот объект, тем самым включаем передние фары
        if (moveVertical > 0)
        {
        }
    }
}