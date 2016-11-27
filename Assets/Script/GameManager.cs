using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // SINGLETON /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    static GameManager instance = null;

    // DontDestroyOnLoad 제어를 위한 변수
    private static int count = 0;
    private int index;

    public static GameManager Inst
    {
        get { return instance; }
    }
    void Awake()
    {
        instance = this;

        index = count;
        count++;

        if (index == 0)
            // 절대 삭제 불가 요청
            DontDestroyOnLoad(this);
        else
            Destroy(gameObject);
    }


    // Game Data /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 여기에 게임 필요 변수 선언.
    public bool isGameStop = false;




    



    // 모든 관계 연결.
    public PlayerPet playerPet;
    public Transform originalPos;                       // 펫의 처음 위치.

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    // Play Init.
    public bool isPlayReady = false;
    public void InitStatePlay()
    {
        // 1. 펫 대기상태.
        // isPlayReady = false;
    }

}
