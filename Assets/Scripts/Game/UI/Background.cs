using UnityEngine;

public class Background : MonoBehaviour
{
    private float _startPos;
    private void Start()
    {
        _startPos = transform.position.x;
    }
    private void Update()
    {
        if (transform.position.x <= -_startPos)
        {
            transform.position = new Vector3(_startPos, transform.position.y, transform.position.z);
        }
    }
}
