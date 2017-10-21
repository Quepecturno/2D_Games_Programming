using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
	public class PlayerSpaceShip : SpaceShipBase
	{
		public const string HorizontalAxis = "Horizontal";
		public const string VerticalAxis = "Vertical";
		public const string FireButtonName = "Fire1";

        public int PlayerLives;

        public override Type UnitType
		{
			get { return Type.Player; }
		}

        private Vector3 GetInputVector()
		{
			float horizontalInput = Input.GetAxis(HorizontalAxis);
			float verticalInput = Input.GetAxis(VerticalAxis);

			return new Vector3(horizontalInput, verticalInput);
		}

		protected override void Update()
		{
			base.Update();

			if(Input.GetButton(FireButtonName))
			{
				Shoot();
			}
		}

		protected override void Move()
		{
			Vector3 inputVector = GetInputVector();
			Vector2 movementVector = inputVector * Speed;
			transform.Translate(movementVector * Time.deltaTime);
		}

        protected override void Die()
        {
            if(PlayerLives > 0)
            {
                PlayerLives--;
                this.transform.position = new Vector2( 0, -4 );
                Health.IncreaseHealth(100);

                StartCoroutine(Blink(2.0f));
            } else
            {
                base.Die();
            }
        }

        private IEnumerator Blink(float waitTime)
        {
            var endTime = Time.time + waitTime;
            while (Time.time < endTime)
            {
                Physics2D.IgnoreLayerCollision(8, 11);
                //Flicker the ship after spawn
                GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(0.2f);
                GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
            Physics2D.IgnoreLayerCollision(8, 11, false);
        }
    }
}
