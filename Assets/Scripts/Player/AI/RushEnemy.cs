using UnityEngine;
using System;

namespace Assets.Scripts.Player.AI
{
	/// <summary>
	/// Rushes the opponent to fire at close range.
	/// </summary>
	public class RushEnemy : IPolicy
	{
		/// <summary> The desired horizontal distance between the AI and the opponent. </summary>
		internal float targetDistance;

		/// <summary>
		/// Initializes a new AI.
		/// </summary>
		/// <param name="targetDistance">The desired horizontal distance between the AI and the opponent.</param>
		internal RushEnemy(float targetDistance) {
			this.targetDistance = targetDistance;
		}

		/// <summary>
		/// Picks an action for the character to do every tick.
		/// </summary>
		/// <param name="controller">The controller for the character.</param>
		public void ChooseAction(AIController controller)
		{
			controller.jump = false;
			float currentTargetDistance = targetDistance;
			Vector3 opponentOffset = controller.GetOpponentDistance();
			Vector3 targetOffset = opponentOffset;
			float distanceTolerance = 1f;
			RaycastHit hit;
			// Check if there is a platform in the way of shooting.
			Physics.Raycast(controller.transform.position + Vector3.up * 0.5f, opponentOffset, out hit, Vector3.Magnitude(opponentOffset), 1 | 1 << 13);
			if (hit.collider != null)
			{
				// If an obstacle is in the way, move around it.
				BoxCollider closest = null;
				float closestDistance = Mathf.Infinity;
				foreach (BoxCollider child in hit.collider.GetComponentsInChildren<BoxCollider>())
				{
					// Look for the closest ledge to grab or fall from.
					if (child.tag == "Ledge")
					{
						float currentDistance = Vector3.Distance(child.transform.position, controller.transform.position);
						if (currentDistance < closestDistance)
						{
							closest = child;
							closestDistance = currentDistance;
						}
					}
				}
				if (closest != null)
				{
					// Move towards the nearest ledge, jumping if needed.
					Vector3 closestVector = closest.transform.position - controller.transform.position;
					float ledgeOffset = 0.6f;
					if (closest.transform.position.x - hit.collider.transform.position.x > 0)
					{
						closestVector.x += ledgeOffset;
					}
					else
					{
						closestVector.x -= ledgeOffset;
					}
					if (Math.Abs(closestVector.x) < 1f)
					{
						controller.jump = opponentOffset.y > 0;
					}
					else
					{
						controller.jump = false;
					}
					currentTargetDistance = 0;
					distanceTolerance = 0.1f;
					targetOffset = closestVector;
				}
			}

			if (currentTargetDistance > 0 && targetOffset.y < 0)
			{
				// Move onto a platform if a ledge was just negotiated.
				if (!Physics.Raycast(controller.transform.position, Vector3.down, out hit, -targetOffset.y + 0.5f, 1 | 1 << 13))
				{
					currentTargetDistance = 0;
				}
			}

			// Move towards the opponent.
			float horizontalDistance = Mathf.Abs(targetOffset.x);
			if (horizontalDistance > currentTargetDistance)
			{
				controller.SetRunInDirection(targetOffset.x);
			}
			else if (horizontalDistance < currentTargetDistance - distanceTolerance)
			{
				controller.SetRunInDirection(-targetOffset.x);
			}
			else
			{
				controller.runSpeed = 0;
			}
			if (controller.runSpeed != 0)
			{
				// Don't chase an opponent off the map.
				Vector3 offsetPosition = controller.transform.position;
				offsetPosition.x += controller.runSpeed;
				offsetPosition.y += 0.5f;
				float heightDifference = Mathf.Abs(offsetPosition.y - opponentOffset.y);
				if (!Physics.Raycast(offsetPosition, Vector3.down, out hit, heightDifference + 0.5f, 1 | 1 << 13))
				{
					Debug.DrawRay(offsetPosition, Vector3.down * (heightDifference + 0.5f), Color.red, Time.deltaTime);
					if (controller.ParkourComponent.Sliding)
					{
						controller.SetRunInDirection(-opponentOffset.x);
					}
					else
					{
						controller.runSpeed = 0;
					}
					controller.slide = false;
				}
				else
				{
					// Slide if the opponent is far enough away for sliding to be useful.
					controller.slide = horizontalDistance > targetDistance * 2;
				}
			}
		}
	}
}