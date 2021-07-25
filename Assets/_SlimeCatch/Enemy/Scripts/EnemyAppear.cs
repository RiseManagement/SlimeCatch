using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
	public enum EnemySize
	{
		S,
		M,
		L,
		XL
	}

	[System.Serializable]
	struct EnemyObj
	{
		[SerializeField] public GameObject enemy_S;
		[SerializeField] public GameObject enemy_M;
		[SerializeField] public GameObject enemy_L;
		[SerializeField] public GameObject enemy_XL;
	}
	[SerializeField] EnemyObj enemyobj;


	//出現した敵の取得（一体のみ）
	GameObject Getenemyobj;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

	public GameObject AppearEnemySize(EnemySize enemy)
	{
		switch (enemy)
		{
			case EnemySize.S:
				Getenemyobj = Instantiate(enemyobj.enemy_S);
				break;
			case EnemySize.M:
				Getenemyobj = Instantiate(enemyobj.enemy_M);
				break;
			case EnemySize.L:
				Getenemyobj = Instantiate(enemyobj.enemy_L);
				break;
			case EnemySize.XL:
				Getenemyobj = Instantiate(enemyobj.enemy_XL);
				break;
		}
		return Getenemyobj;
	}
}
