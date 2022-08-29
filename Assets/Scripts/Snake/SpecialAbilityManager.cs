using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpecialAbility{
    DISABLED, SHIELD, SCORE_BOOST, SPEED_UP
}
public class SpecialAbilityManager : MonoBehaviour
{
    bool shield;
    bool scoreBoost;
    bool speedUp;
    SpecialAbility activeSA;
    [SerializeField]float durationSA;
    [SerializeField]int scoreMultiplier;
    [SerializeField]float speedMultiplier;
    float remainingDurationSA;
    Snake snake;
    SpriteRenderer sprite;
    bool gamePaused;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void SetGamePaused(bool status){
        gamePaused = status;
    }

    void Update()
    {
        if(gamePaused)
            return;
        if(activeSA != SpecialAbility.DISABLED){
            remainingDurationSA -= Time.deltaTime;
            if(remainingDurationSA <= 0){
                activeSA = SpecialAbility.DISABLED;
                UpdateSAColor();
                GetComponent<SnakeController>().UpdateSpeed();
            }
        }
    }

    public void setSnake(Snake snake){
        this.snake = snake;
    }

    public void activateSpecialAbility(SpecialAbility specialAbility){
        activeSA = specialAbility;
        remainingDurationSA = durationSA;
        UpdateSAColor();
    }

    public void UpdateSAColor(){
        Color color = GetSAColor();
        for(int i = 1; i < snake.body.Count; i++)
            snake.body[i].GetComponent<SpriteRenderer>().color = color;
    }

    public Color GetSAColor(){
        Color color = Color.white;
        switch(activeSA){
            case SpecialAbility.DISABLED : color = Color.white; break;
            case SpecialAbility.SHIELD : color = Color.blue; break; 
            case SpecialAbility.SCORE_BOOST : color = Color.yellow; break; 
            case SpecialAbility.SPEED_UP : color = Color.red; break;  
        }
        return color;
    }

    public bool specialAbilityStatus(SpecialAbility specialAbility){
        if(activeSA == specialAbility)
            return true;
        else 
            return false;
    }

    public int GetSpecialScore(int score){
        return score * scoreMultiplier;
    }

    public float GetSpeedMultiplier(){
        if(activeSA == SpecialAbility.SPEED_UP)
            return speedMultiplier;
        else
            return 1;
    }
}
