using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    private float spawnDistanceXMin = 3.5f, spawnDistanceXMax = 4.5f;
    private float spawnDistanceYMin = -5f, spawnDistanceYMax = -1.9f;
    private bool _canSpawnPipe = true;
    private PlayerController _playerController;
    private GameObject _lastPipe;

    private void Start()
    {
        _playerController = PlayerController.Singleton;
        CalculatePipeDistance();
        SpawnPipe();
    }

    private void Update()
    {
        if (_lastPipe.transform.position.x < 6)
        {
            _canSpawnPipe = true;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        if (!_playerController.isDead && _canSpawnPipe)
        {
            var firstPipePos = CalculateFirstPipePos();
            var secondPipePos = CalculateSecondPipePos(firstPipePos);
            _lastPipe = Instantiate(pipe, firstPipePos, Quaternion.identity);
            Instantiate(pipe, secondPipePos, Quaternion.identity);
            _canSpawnPipe = false;
        }
    }

    private void CalculatePipeDistance()
    {
        int bestScore = DataManager.Singleton.GetGameData().bestScore;
        float spreadX = bestScore * 0.001f;
        float spreadY = bestScore * 0.0001f;
        spawnDistanceXMin -= spreadX; spawnDistanceXMax -= spreadX; // X
        spawnDistanceYMin -= spreadY; spawnDistanceYMax -= spreadY; // Y
        Debug.Log($"MinX: {spawnDistanceXMin}, MaxX: {spawnDistanceXMax}, MinY: {spawnDistanceYMin}, MaxY: {spawnDistanceYMax}");
    }
    
    private Vector3 CalculateFirstPipePos()
    {
        float posX;
        float posY;
        if (_lastPipe == null)
        {
            posX = _playerController.transform.position.x + 2f + Random.Range(spawnDistanceXMin, spawnDistanceXMax);
            posY = Random.Range(spawnDistanceYMin, spawnDistanceYMax);
        }
        else
        {
            posX = _lastPipe.transform.position.x + Random.Range(spawnDistanceXMin, spawnDistanceXMax);
            posY = Random.Range(spawnDistanceYMin, spawnDistanceYMax);
        }
        return new Vector3(posX, posY);
    }

    private Vector3 CalculateSecondPipePos(Vector3 parentPipePos)
    {
        var posX = parentPipePos.x;
        var posY = parentPipePos.y + Random.Range(8f, 10f);
        return new Vector3(posX, posY);
    }
}