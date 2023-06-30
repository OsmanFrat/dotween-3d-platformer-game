using UnityEngine;
using DG.Tweening;
public class TweenManager : MonoBehaviour
{
    // First floor obstacles
    public Transform  beam, elevator_left, elevator_right;
    // Second floor obstacles
    public Transform[] sidePushesRight;
    public Transform[] sidePushesLeft;
    public Ease elevatorEase;
    void Start()
    {
        DOTween.KillAll();   
        
        BeamRotation();
        ElevatorLeft();
        ElevatorRight();
        SidePush();
    }

    // First floor functions for obstacles
    public void BeamRotation()
    {
        beam.transform.DORotate(new Vector3(0, 360f, 0), 4f, RotateMode.Fast)
        .SetLoops(-1, LoopType.Restart)
        .SetRelative()
        .SetEase(Ease.Linear);
    }

    public void ElevatorLeft()
    {
        elevator_left.DOScale(new Vector3(2.3f,8.5f,2f), 2.5f)
        .SetDelay(3)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(elevatorEase);
    }

    public void ElevatorRight()
    {
        // Vector3(44,-22,-35) finish
        // Vector3(44,-24,-35) start
        elevator_right.DOLocalMoveY(-22f, 2f, false)
        .SetDelay(1)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(elevatorEase);
    }
    
    public void SidePush()
    {
        foreach (Transform stick in sidePushesRight)
        {
            stick.DOLocalMoveZ(-1.5f, 1f)
            .SetDelay(1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(elevatorEase);
        }

        foreach (Transform stick in sidePushesLeft)
        {
            stick.DOLocalMoveZ(1.5f, 1f)
            .SetDelay(1f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(elevatorEase);
        }
    }


    //(ctrl + k) + (ctrl + c) = comment lines
    //(ctrl + k) + (ctrl + u) = undo comment lines
}
