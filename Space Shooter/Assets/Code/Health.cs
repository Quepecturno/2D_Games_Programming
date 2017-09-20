using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Health class to calculate health.
    /// </summary>
    /// <remarks>
    /// Health class contains the necessary methods to calculate the health of units.
    /// </remarks>
    public class Health : MonoBehaviour, IHealth
    {
        /// <summary>
        /// Store for the minimun health.
        /// </summary>
        [SerializeField]
        private int _minHealth;

        /// <summary>
        /// Store for the maximum health.
        /// </summary>
        [SerializeField]
        private int _maxHealth;

        /// <summary>
        /// Store for the current health.
        /// </summary>
        [SerializeField]
        private int _currentHealth;

        /// <summary>
        /// The CurrentHealth property represents the current health of the unit.
        /// </summary>
        /// <value>
        /// The CurrentHealth property gets the value of the integer _currentHealth.
        /// </value>
        public int CurrentHealth
        {
            // Get the current health value.
            get
            {
                return _currentHealth;
            }
        }

        /// <summary>
        /// DecreaseHealth is a method in the Health class. It is used to decrease the health of a unit.
        /// </summary>
        /// <param name="amount">Used to specify the decreased amount.</param>
        public void DecreaseHealth(int amount)
        {
            // Checks if the health would go under the minimum.
            // If it doesn't, calculates the new health value.
            if(_currentHealth - amount > _minHealth)
            {
                _currentHealth = _currentHealth - amount;

            }
            // Or if it does, sets it to minimum.
            else
            {
                _currentHealth = _minHealth;
            }
        }

        /// <summary>
        /// IncreaseHealth is a method in the Health class. It is used to increase the health of a unit.
        /// </summary>
        /// <param name="amount">Used to specify the increased amount.</param>
        public void IncreaseHealth(int amount)
        {
            // Checks if the health would go over the maximum.
            // If it doesn't, calculates the new health value.
            if (_currentHealth + amount < _maxHealth)
            {
                _currentHealth = _currentHealth + amount;

            }
            // Or if it does, sets it to maximum.
            else
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}