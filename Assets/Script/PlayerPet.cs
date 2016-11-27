using UnityEngine;
using System.Collections;

// Pet State Define.
public enum PetState
{
    Idle, Eat, Play, Walk, Max
};

public class PlayerPet : MonoBehaviour {

    // Delegate Define //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    delegate void State();
    State[] petState = null;

    // Pet Data /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 여기에 Pet 필요 변수 선언.
    PetState state;



    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        petState = new State[(int)PetState.Max] { Idle, Eat, Play, Walk };

        // Init.
        Init();
    }

	public void Init()
    {
        // Init Define.
        state = PetState.Play;

        switch (state)
        {
            case PetState.Idle:
                break;
            case PetState.Eat:
                break;
            case PetState.Play:
                GameManager.Inst.InitStatePlay();

                break;
            case PetState.Walk:
                break;
        }
       
    }


    // Pet State별 function. /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Idle()
    {

    }
    void Eat()
    {
        
    }
    void Play()
    {
        
    }

    void Walk()
    {

    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Update ()
    {
        if (GameManager.Inst.isGameStop) return;
        petState[(int)state]();
    }
}
