﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePiece : MonoBehaviour
{
    private GamePiece piece;
    private IEnumerator moveCoroutine;
    void Awake()
    {
        piece = GetComponent<GamePiece>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void Move(int newX, int newY, float time)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = MoveCoroutine(newX, newY, time);
        StartCoroutine(moveCoroutine);
    }

    private IEnumerator MoveCoroutine(int newX, int newY, float time)
    {
        piece.X = newX;
        piece.X = newY;
        Vector3 startPos = transform.position;
        Vector3 endPos = piece.GridRef.GetWorldPosition(newX, newY);
        print(startPos + " - " + endPos);
        for (float t = 0; t <= 1 * time; t += Time.deltaTime)
        {
            piece.transform.position = Vector3.Lerp(startPos, endPos, t / time);
            yield return 0;
        }
        piece.transform.position = endPos;
    }
}
