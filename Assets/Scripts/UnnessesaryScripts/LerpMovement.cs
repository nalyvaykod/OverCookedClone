using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    // Кінцева точка, до якої буде рухатися об'єкт
    private Vector3 endPoint = new Vector3(20, 0, 0);

    // Початкова точка, з якої починається рух
    private Vector3 startPoint;

    // Тривалість анімації в секундах
    private float duration = 3f;

    // Час, що пройшов з моменту початку анімації
    private float elapsedTime;

    // Метод Start викликається при ініціалізації об'єкта
    private void Start()
    {
        // Зберігаємо початкову позицію об'єкта
        startPoint = transform.position;
    }

    // Метод Update викликається кожен кадр
    void Update()
    {
        // Додаємо до elapsedTime час, що пройшов з останнього кадру
        elapsedTime += Time.deltaTime;

        // Обчислюємо відсоток завершення анімації
        float percentageComplete = elapsedTime / duration;

        // Використовуємо Lerp для обчислення нової позиції об'єкта
        transform.position = Vector3.Lerp(startPoint, endPoint, percentageComplete);
    }
}