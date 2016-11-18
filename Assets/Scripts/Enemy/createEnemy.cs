using UnityEngine;
using System.Collections;

public class createEnemy : MonoBehaviour
{
    public GameObject Enemyship;
    public int enemyCount;//定义生成的个数
    public float WaitTime;//定义一个时间，让怪物在游戏开始一段时间后才开始加载
    public float NextTime;//生成下一波怪物的时间间隔

    void Start()
    {   
        StartCoroutine(spawnWaves());//定义一个协同函数来限制怪物产生的时间
    }
    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(WaitTime); //在游戏开始后会在waittime时间后才开始执行

        while (true)
   {   
            for(int i = 0; i < enemyCount;)
            {
                Vector3 position = new Vector3(Random.Range(0,100 ), 1, Random.Range(0, 100)); //设置生成物体的随机坐标
               Instantiate(Enemyship, position, Quaternion.identity);
                // Rotation = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));//设置生成物体的随机角
             
      
                yield return new WaitForSeconds(NextTime);//限制生成时间间隔
            }
        }
    }
        
    // Update is called once per frame
    void Update()
    {
    }
}