using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static UnityEvent OnTimeReachedHalfway = new UnityEvent();
    public static UnityEvent OnTimeReachedEnd = new UnityEvent();
}
