using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SimpleAIShooting : MonoBehaviour
{
    public class SimpleAIMoving : MonoBehaviour, IMovemenet
    {
        [SerializeField] MoveSettings moveSettings;

        private Player player;


        private void Awake()
        {
            player = GameManager.instance.Player;
        }

        public void Move()
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)(moveSettings.Speed * direction * Time.deltaTime);
        }
    }
}