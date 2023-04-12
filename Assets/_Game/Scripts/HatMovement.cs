using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private GameObject player;

    private GameController gameController;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        DragTouch();
    }

    private void DragTouch(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameController.gameStarted){
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
        }
    }
}
