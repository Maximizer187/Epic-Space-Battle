using GameEngine;
using MyGame.GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Reflection.Metadata.Ecma335;

namespace MyGame
{
    class Background    :   GameObject
    {

        private const float Speed = 0.1f;

        private readonly Sprite _sprite = new Sprite();
        private readonly Sprite _sprite2 = new Sprite();

        public Background(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/background.png");
            _sprite.Position = pos;
            _sprite2.Texture = Game.GetTexture("Resources/background.png");
            _sprite2.Position = new Vector2f(800f, pos.Y);
            AssignTag("Background");
            SetCollisionCheckEnabled(true);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
            Game.RenderWindow.Draw(_sprite2);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X < _sprite.GetGlobalBounds().Width * -1)
            {
                _sprite.Position = new Vector2f(800f, pos.Y);
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }

            Vector2f pos2 = _sprite2.Position;

            if (pos2.X < _sprite2.GetGlobalBounds().Width * -1)
            {
                _sprite2.Position = new Vector2f(800f, pos2.Y);
            }
            else
            {
                _sprite2.Position = new Vector2f(pos2.X - Speed * msElapsed, pos2.Y);
            }
        }
    }
}
