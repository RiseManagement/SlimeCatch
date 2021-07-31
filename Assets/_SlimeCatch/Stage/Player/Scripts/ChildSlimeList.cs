using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSlimeList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> SlimeChild=new List<GameObject>();

    public void ChildSlimeRandomOff()
    {
        for (int i = 0; i < 2; i++)
        {
            var SlimeNum = Random.Range(0, SlimeChild.Count);
            GameObject SlimeChildList = SlimeChild[SlimeNum];
            SlimeChildList.SetActive(false);

            SlimeChild.RemoveAt(SlimeNum);
        }
    }

    public void SlimeColliderDecision(GameObject gameObject)
    {
        SlimeChild.Remove(gameObject);
    }
    
}
