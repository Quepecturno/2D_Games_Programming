using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class HealthPack : MonoBehaviour
    {

        [SerializeField]
        private float _timeDropIsUp;

        [SerializeField]
        private int _healAmount;

        protected void OnTriggerEnter2D(Collider2D other)
        {
            //PlayerSpaceShip player = other.GetComponent<PlayerSpaceShip>();
            //if (player != null)
            //{
                Debug.Log("Player picked up.");
                //player.GetComponent<Health>().IncreaseHealth(_healAmount);
            //}
        }

        private IEnumerator countTime()
        {
            yield return new WaitForSeconds(_timeDropIsUp);

            Destroy(gameObject);
        }
    }
}
