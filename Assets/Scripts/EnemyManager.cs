using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _palyerTransform;
    [SerializeField] private float _creationRadius;
    [SerializeField] private ChapterSettings _chapterSettings;
    private List<Enemy> _enemyList = new List<Enemy>();


    public void StartNewWave(int wave)
    {
        StopAllCoroutines();

        for (int i = 0; i < _chapterSettings.EnemyWavesArray.Length; i++)
        {
            if (_chapterSettings.EnemyWavesArray[i].NumberPerSecond[wave] > 0)
            {
                StartCoroutine(CreatEnemyInSeconds(_chapterSettings.EnemyWavesArray[i].Enemy, _chapterSettings.EnemyWavesArray[i].NumberPerSecond[wave]));
            }
        }
    }

    private IEnumerator CreatEnemyInSeconds(Enemy enemy, float enemyPerSecond)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f / enemyPerSecond);
            Creat(enemy);
        }
    }

    public void Creat(Enemy enemy)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 position = new Vector3(randomPoint.x, 0, randomPoint.y) * _creationRadius + _palyerTransform.position;
        Enemy newEnemy = Instantiate(enemy, position, Quaternion.identity);
        newEnemy.Init(_palyerTransform, this);
        _enemyList.Add(newEnemy);
    }

    public void RemoveEnemt(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }
    
    public Enemy[] GetNearest(Vector3 point, int number)
    {
        _enemyList = _enemyList.OrderBy(x => Vector3.Distance(point, x.transform.position)).ToList();

        int returnNumber = Mathf.Min(number, _enemyList.Count);
        Enemy[] enemies = new Enemy[_enemyList.Count];

        for (int i = 0; i < returnNumber; i++)
        {
            enemies[i] = _enemyList[i];
        }

        return enemies;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Handles.color = Color.red;
        Handles.DrawWireDisc(_palyerTransform.position, Vector3.up, _creationRadius);
#endif
    }
}
