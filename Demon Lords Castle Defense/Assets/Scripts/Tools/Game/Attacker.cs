using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Controls an individual attacker

    // Written rules (Esther)
    // 

    private List<Vector3> path;
    private Vector3 pointA;
    private Vector3 pointB;
    private int currentPathPos = 0;
    private float pointLerp = 0;
    private float speed = 5;
    private int attackDamage = 1;
    private int health = 1;
    private int maxHealth = 1;
    private int soulReward = 1;
    private bool isMoving = false;

    public SpriteRenderer appearance;

    public void InitializeAttacker(List<Vector3> inPath, AttackerType type, Vector3 start)
    {
        transform.localPosition = start;
        path = inPath;

        NextPathPoint();
        isMoving = true;
    }

    private void NextPathPoint()
    {
        currentPathPos++;

        if (currentPathPos == path.Count)
        {
            // reached the end
            isMoving = false;
            return;
        }
        
        pointA = path[currentPathPos - 1];
        pointB = path[currentPathPos];
        pointLerp = 0;
    }

    private void Update()
    {
        if (!isMoving) return;

        pointLerp += (Time.deltaTime * speed) / 5;
        transform.localPosition = Vector3.Lerp(pointA, pointB, pointLerp);

        if (pointLerp > 1)
        {
            NextPathPoint();
        }
    }
}