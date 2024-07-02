using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    // ʳ����� �����, �� ��� ���� �������� ��'���
    private Vector3 endPoint = new Vector3(20, 0, 0);

    // ��������� �����, � ��� ���������� ���
    private Vector3 startPoint;

    // ��������� ������� � ��������
    private float duration = 3f;

    // ���, �� ������� � ������� ������� �������
    private float elapsedTime;

    // ����� Start ����������� ��� ����������� ��'����
    private void Start()
    {
        // �������� ��������� ������� ��'����
        startPoint = transform.position;
    }

    // ����� Update ����������� ����� ����
    void Update()
    {
        // ������ �� elapsedTime ���, �� ������� � ���������� �����
        elapsedTime += Time.deltaTime;

        // ���������� ������� ���������� �������
        float percentageComplete = elapsedTime / duration;

        // ������������� Lerp ��� ���������� ���� ������� ��'����
        transform.position = Vector3.Lerp(startPoint, endPoint, percentageComplete);
    }
}