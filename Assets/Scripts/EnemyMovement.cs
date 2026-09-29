using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private Transform _targetTransform;
	[SerializeField, Min(0f)] private float _moveSpeed = 2f;
	[SerializeField] private float distanceThreshold = 0.1f;
	[SerializeField] private int _damageAmount = 10;

	private void Update()
	{
		if (Vector3.Distance(transform.position, _targetTransform.position) <= distanceThreshold)
		{
			Debug.Log("Reached!");
			Damage(_damageAmount);
			DestroySelf();
			return;
		}

		Vector3 moveDir = (_targetTransform.position - transform.position).normalized;
		transform.position += moveDir * _moveSpeed * Time.deltaTime;
	}

	private void SetTargetTransform(Transform targetTransform)
	{
		_targetTransform = targetTransform;
	}

	private void Damage(int damageAmount)
	{
		PlayerHealth playerHealth = _targetTransform.GetComponent<PlayerHealth>();
		if (!playerHealth)
		{
			Debug.LogError("Couldn't reach to PlayerHealth.");
			return;
		}

		playerHealth.TakeDamage(damageAmount);
	}

	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}
