using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesHolder : MonoBehaviour
{
   public List <GameObject> stagesPrefab;
   List<GameObject> stages = new List<GameObject>();
  [SerializeField] private int _countOfStage;
    public static int CountOfStage;

   [SerializeField] GameObject Finish;
    Stages stage;
    float dist = 0;
    int j = 0;
    int ID;
    int lastID = -1;
    int preLastId = -1;
    public static int staminaPotionCount;
    public int StaminaPotionCount;

    public static int StagePassedCount;
    private int prePassedCount = 0;

    private void Awake()
    {
        staminaPotionCount = StaminaPotionCount;
        CountOfStage = _countOfStage;
        
    }

 
    private IEnumerator Spawning()
    {
        while (stages.Count < _countOfStage)
        {
            if (stages.Count < _countOfStage)
            {
                if (prePassedCount < StagePassedCount)
                {
                    prePassedCount++;
                    SpawnObjectS(1);
                }
            }
            yield return new WaitForSeconds(3);
        }
         SpawnObject(Finish);
        StopCoroutine(Spawning());
    }
    private void Start()
    {
        StagePassedCount = 0;
        SpawnObjectS(3); 
        StartCoroutine(Spawning());

    }
    private void SpawnObjectS(int count)
    {
        while (count > 0)
        {
            ID = Random.Range(0, stagesPrefab.Count);
            if (ID != lastID && ID != preLastId)
            {
                SpawnObject(stagesPrefab[ID]);
                count--;
                preLastId = lastID;
                lastID = ID;
            }
        }
       
    }
    private void SpawnObject(GameObject obj)
    {
        stage = obj.GetComponent<Stages>();
        float baseDist = stage.Distance();
            stages.Add(Instantiate(obj));
            stages[j].transform.position = new Vector3 (0,0,dist);
            stages[j].name += j;
            dist += baseDist;
            j++;
    }
}

