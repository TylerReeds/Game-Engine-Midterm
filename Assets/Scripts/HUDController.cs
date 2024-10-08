using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HUDController : Observer
{
    private PlayerController playerController;
    private float _currentScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));

        // Display score
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Score: " + _currentScore);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
    public override void Notify(Subject subject)
    {
        if (!playerController)
            playerController = subject.GetComponent<PlayerController>();
        if (playerController)
        {

            _currentScore = playerController.CurrentScore;

        }
    }
}
