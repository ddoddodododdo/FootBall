using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    public static string ballTag = "Ball";
    public Team team;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Team.gameManager.GoalIn(team.id);
        }
    }
}
