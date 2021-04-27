using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum CameraMode
    {
        QuaterView,
        BackView
    }

    public enum WorldObject
    {
        Player, //유저
        Enemy, //대부분 장르의 몬스터
        InterActionObject, //기믹, 유동적인 상황 생성
        ReactionObject, //위의 기믹과 연결될 상황오브젝트?
        NPC, //상점주인 등 고정 위치, 특정 행동 반복
        None
    }

    public enum Gamegenre
    {
        Roll,
        Run,
        FPS,
        RPG,
        ARPG,
        SRPG,
        Cliker,
        SNG
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        LClick, //클릭 후 때는 순간
        RClick,
        Wheel
    }

    public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
    }

    public enum State
    {
        Idle,
        Move,
        Atk,
        Hit,
        Die,
        None
    }

    public enum Sound
    {
        Bgm,
        Effect,
        Voice,
        MaxCount
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game
    }

    public enum EffectType
    {
        Common,
        Hit
    }
}
