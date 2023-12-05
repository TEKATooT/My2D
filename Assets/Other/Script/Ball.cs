using UnityEngine;

public class Ball : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float _ballSpeed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _ballSpeed * Time.deltaTime);
    }

    public void GetTarget(Transform target)
    {
        _target = target;
    }
}
