
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private Vector3[] _points;
    [SerializeField] private float _speed;
    private Vector3 _startPosition;
    private Vector3 _finishPosition;
    private Transform _transform;
    private float _currentTime;
    private int _indexNextPoint;
    private float _travelTime;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _indexNextPoint = 0;
        ChoseNewPosition(_indexNextPoint);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        _transform.position = Vector3.Lerp(_startPosition, _finishPosition, _currentTime/_travelTime);
        if (_transform.position==_finishPosition)
        {
            _indexNextPoint++;
            if (_indexNextPoint==_points.Length)
            {
                _indexNextPoint = 0;
            }
            ChoseNewPosition(_indexNextPoint);
            _currentTime = 0;
        }
    }

    private void ChoseNewPosition( int index)
    {

        _finishPosition = _points[index];
        _startPosition=index >= 1 ?  _points[index - 1] :  _transform.position;
        var distance = Vector3.Distance(_startPosition, _finishPosition);
        _travelTime = distance / _speed;
        Debug.Log($"Distance - {distance}, TravelTime - {_travelTime}");
    }
}