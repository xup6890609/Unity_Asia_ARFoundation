using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

// 點擊地面後生成物件; RC要求元件:在第一次點擊後套用腳本執行
[RequireComponent(typeof(ARRaycastManager))]
public class ARManager : MonoBehaviour
{
    [Header("點擊後生成的物件")]
    public GameObject obj;
    [Header("AR 管理器")]
    public ARRaycastManager arManager;

    // 滑鼠座標
    private Vector2 pointMouse;
    // 碰撞資訊
    private List<ARRaycastHit> hits;

    private void Tap()
    {
        // 判斷玩家是否有點擊
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { 
            // 遊戲滑鼠座標=玩家滑鼠座標
            pointMouse = Input.mousePosition;
            // 判斷是否打到物件
            if (arManager.Raycast(pointMouse,hits,TrackableType.PlaneWithinPolygon))
            {
                // 生成物件(物件,最標,角度)
                Instantiate(obj, hits[0].pose.position, Quaternion.identity);
            }
        } 
    }
   
    private void Update()                                                                   
    {
        Tap();
    }
}
