using UnityEngine;
using System.Collections;

public class EventHub : MonoBehaviour
{

    #region Event delegates
    public delegate void VoidEvent();
    public delegate void IntegerParamEvent(int value);
    public delegate void ObjectParamEvent(object value);
    public delegate void BoolParamEvent(bool value);
    public delegate void GameObjectParamEvent(GameObject obj);
    public delegate void GameObjectIntegerParamEvent(GameObject enemy, int value);
    public delegate void GameObjectBoolParamEvent(GameObject enemy, bool value);
    public delegate void MovementParamEvent(Vector3 position, Vector3 location, bool lerp = false, bool rotationReset = false);
    public delegate void GameObjectVector2Event(GameObject obj, Vector2 location);

    #endregion


    #region Events

    public event VoidEvent PlayerDied;
    public event VoidEvent GameWon;
    public event IntegerParamEvent PlayerReachedTopEvent;
    public event GameObjectParamEvent TestGOEvent;
    public event GameObjectParamEvent EnemyDied;

    #endregion

    #region Triggers
    public void TriggerPlayerDied()
    {
        if (PlayerDied != null)
            PlayerDied();
    }

    public void TriggerGameWon()
    {
        if (GameWon != null)
            GameWon();
    }

    public void TriggerUpdateObjectEvent(GameObject obj)
    {
        if (TestGOEvent != null)
            TestGOEvent(obj);
    }

    public void TriggerPlayerReachedTopEvent(int screen)
    {
        if (PlayerReachedTopEvent != null)
            PlayerReachedTopEvent(screen);
    }

    public void TriggerEnemyDied(GameObject obj)
    {
        if (EnemyDied != null)
            EnemyDied(obj);
    }


    //You get the idea on how this is done...
    //Generic .Invoke(...) cannot be done, as the event fields cannot be accessed from outside this class :(
    #endregion
}