using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChange : MonoBehaviour
{
    [SerializeField] _SlimeCatch.Player.SlimeExtend SlimeExtend;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //掴んでいる時に減らす
        if (SlimeExtend._initMousePosition != SlimeExtend._CurrentMousePosition)
        {
            player.layer = LayerMask.NameToLayer("Default");
        }
        else
        {
            player.layer = LayerMask.NameToLayer("CollisionOff");
        }
    }
}
