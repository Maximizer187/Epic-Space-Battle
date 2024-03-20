﻿using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class laser : GameObject
    {
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        private const float Speed = 1.5f;

        private readonly Sprite _sprite = new Sprite();

        public laser(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/laser.png");
            _sprite.Position = pos;
            AssignTag("laser");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if(pos.X > Game.RenderWindow.Size.X)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X + Speed * msElapsed, pos.Y);
            }
        }
    }
}
