using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;
    public int lives = 3;
    public int score = 0;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        //TODO: Figure out a simpler formula
        if (asteroid.size < 0.75f)
        {
            this.score += 100;
        } else if (asteroid.size < 1.0f)
        {
            this.score += 50;
        } else
        {
            this.score += 25;
        }

        // TODO: Add the Score to Screen
        // TODO: Add the high score tracking in PlayerPrefs

    }
    
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        
        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        } else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);

        // TODO: Add the Game Over Screen and Restart Buttons

    }

}
