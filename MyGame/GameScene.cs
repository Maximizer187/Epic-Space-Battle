using GameEngine;
using SFML.System;

namespace MyGame
{
    class GameScene : Scene
    {
        private int _background;
        private int _score;
        private int _lives = 3;
        public GameScene()
        {
            Background background = new Background(new Vector2f(10.0f, 10.0f));
            AddGameObject(background);

            Ship ship = new Ship();
            AddGameObject(ship);

            MeteorSpawners meteorSpawner = new MeteorSpawners();
            AddGameObject(meteorSpawner);

            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);

            
        }

        // Get current score.
        public int GetScore()
        {
            return _score;
        }

        // Increase the score
        public void IncreaseScore()
        {
            ++_score;
        }

        // Get the number of lives.
        public int GetLives()
        {
            return _lives;
        }

        //decrease the number of lives
        public void DecreaseLives()
        {
            --_lives;

            if ( _lives == 0 )
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }
    }
}