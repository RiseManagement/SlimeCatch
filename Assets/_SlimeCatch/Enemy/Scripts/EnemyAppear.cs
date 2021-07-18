using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
	[System.Serializable]
	struct EnemyObj
	{
		[SerializeField] public GameObject enemy_S;
		[SerializeField] public GameObject enemy_M;
		[SerializeField] public GameObject enemy_L;
		[SerializeField] public GameObject enemy_XL;
	}
	[SerializeField]
	EnemyObj enemyobj;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void AppearEnemySize_S()
	{
		Debug.Log("Enemy_S" + "出現した");
		Instantiate(enemyobj.enemy_S);
	}

	public void AppearEnemySize_M()
	{
		Debug.Log("Enemy_M" + "出現した");
		Instantiate(enemyobj.enemy_M);
	}

	public void AppearEnemySize_L()
	{
		Debug.Log("Enemy_L" + "出現した");
		Instantiate(enemyobj.enemy_L);
	}

	public void AppearEnemySize_XL()
	{
		Debug.Log("Enemy_XL" + "出現した");
		Instantiate(enemyobj.enemy_XL);
	}
}
