using UnityEngine;
using UnityEngine.XR.ARFoundation;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))                               // 判斷玩家是否有點擊
        {
            pointMouse = Input.mousePosition;                                   //  遊戲滑鼠座標=玩家滑鼠座標
            print(pointMouse);
        } 
    }
   
    private void Update()                                                                   // 生成物件
    {
        Tap();
    }
}
