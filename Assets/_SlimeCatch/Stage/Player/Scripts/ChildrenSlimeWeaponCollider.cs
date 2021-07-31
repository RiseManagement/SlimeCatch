using System;
using System.Collections.Generic;
using _SlimeCatch.Stage;
using UnityEngine;
using Random = System.Random;

public class ChildrenSlimeWeaponCollider : MonoBehaviour
{
    [SerializeField] private GameObject MolotovCocktail;
    public GameObject GameManager;
    ChildSlimeList _childSlimeList;
    void Start()
    {
        //_childSlimeList = GetComponent<ChildSlimeList>().SlimeChild();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //if (!other.gameObject.CompareTag("Weapon")) return;
        
        if (other.gameObject.CompareTag("MolotovCocktail")) 
        {
            GameManager.GetComponent<ChildSlimeList>().SlimeColliderDecision(this.gameObject);
            
            GameManager.GetComponent<ChildSlimeList>().ChildSlimeRandomOff();
        }

        gameObject.SetActive(false);
        other.gameObject.SetActive(false);

    }
    
}
