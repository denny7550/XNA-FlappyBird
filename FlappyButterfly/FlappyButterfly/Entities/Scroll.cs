using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyButterfly.Entities
{
    public class Scroll
    {
        public Vector2 Position;
        public Texture2D texture;

        public int animTimer = 100;
        public double animElapsed = 0;
        //public int decalX = 0;

        public Scroll()
        {
            this.Position = new Vector2(0, 533);
            this.texture = Statics.CONTENT.Load<Texture2D>("Textures/scroll");
        }
        public void Update()
        {
            /*animElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animElapsed > animTimer)
            {
                this.decalX += 2;
                if (decalX > 7)
                    decalX = 0;
                animElapsed = 0;
            }*/
        }
        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(this.texture, this.Position, new Rectangle(this.decalX, 0, Statics.GAME_WIDTH, 7), Color.White);
        }

        public int decalX { get; set; }
    }
}
