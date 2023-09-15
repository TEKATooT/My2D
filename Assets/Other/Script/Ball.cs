using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _ballSpeed;

    private GameObject _target;

    private void Start()
    {
        _target = GameObject.Find("blackHole");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _ballSpeed * Time.deltaTime);
    }
}
