using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class GameController : MonoBehaviour {

    // PUBLIC INSTANCE VARIABLES ++++++++++++++++++
    public Text scoreLabel;
    public Text livesLabel;
    public Text gameOverLabel;

    // PRIVATE INSTANCE VARIABLES +++++++++++++++++
    private int _scoreValue;
    private int _livesValue;
    private bool gameOver;
    private GameObject[] player;

    // PUBLIC PROPERTIES ++++++++++++++++++++++++++
    public int Score
    {
        get
        {
            return this._scoreValue;
        }
        set
        {
            this._scoreValue = value;
            this._updateScoreBoard();
        }
    }

    // Add score to _scoreValue Instance Variable
    public void AddScore(int value){
        this._scoreValue += value;
        this._updateScoreBoard();
    }

    // Substract lives from _livesValue Instance Variable
    public void SubstractLives(int value)
    {
        this._livesValue -= value;
        if (this._livesValue <= 0)
        {
            Destroy(player[0]);
            this.gameOver = true;
            this.gameOverLabel.text = "Game Over!\nPress Fire2 to Restart";
        }
        this._updateScoreBoard();
    }

    public int Lives
    {
        get
        {
            return this._livesValue;
        }
        set
        {
            this._livesValue = value;
            this._updateScoreBoard();
        }
    }
    // Use this for initialization
    void Start () {
        this._scoreValue = 0;
        this._livesValue = 3;
        this._updateScoreBoard();
        this.gameOver = false;
        player = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	    if (this.gameOver)
        {
            if (CrossPlatformInputManager.GetButton("Fire2"))
            {
                Application.LoadLevel(Application.loadedLevel);
                this.gameOver = false;
            }
        }
	}

    // Private methods +++++++++++++++++++
    private void _updateScoreBoard()
    {
        this.scoreLabel.text = "Score: " + this._scoreValue;
        this.livesLabel.text = "Lives: " + this._livesValue;
    }
}
