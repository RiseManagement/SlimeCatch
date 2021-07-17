using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeExtend : MonoBehaviour
{
    private Vector3 m_mouseDownPosition = Vector3.zero;
    Quaternion rotation;
    
    BoxCollider2D m_Collider;
    float m_ScaleX, m_ScaleY;
    
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        m_ScaleX = 2.677196f;
        m_ScaleY = 1.575665f;
    }

    void OnMouseDown()
    {
        // マウスクリックした際の初期位置を保存。
        m_mouseDownPosition = transform.position;
        
    }

    void OnMouseDrag()
    {
        //マウスをドラッグしてる際の位置を取得
        Vector3 inputPosition   = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 9.5f );
        //スクリーン座標をワールド座標に変換する
        Vector3 mousePos        = Camera.main.ScreenToWorldPoint( inputPosition );
        float   dist            = Vector3.Distance( mousePos, m_mouseDownPosition );
        float distD = dist;
        
        float distx = Mathf.Clamp(dist, 0.05f, 4.0f);
        float distDs = Mathf.Clamp(distD, 1.478829f, 1.641793f);

        transform.localScale    = new Vector3( 0.5f,distx ,0.5f  );
        m_Collider.size = new Vector3(m_ScaleX, distDs);
    }
    
    

    void OnMouseUp()
    {
        // 位置、回転、スケールを元に戻す。
        transform.position      = m_mouseDownPosition;
        transform.rotation      = Quaternion.identity;
        transform.localScale    = Vector3.one;
    }
}
