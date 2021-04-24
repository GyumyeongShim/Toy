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
        Moving,
        Die,
        None
    }

    public enum Sound
    {
        Bgm,
        Effect,
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
