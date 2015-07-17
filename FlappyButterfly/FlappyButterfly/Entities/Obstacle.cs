using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyButterfly.Entities
{
    public class Obstacle
    {
        public Texture2D texture;
        public Vector2 position;

        public bool scored = false;

        public Obstacle()
        {
            this.texture = Statics.CONTENT.Load<Texture2D>("Textures/Obstacle");
            this.position = new Vector2(420, Statics.RANDOM.Next(-200,5));
        }
        public void Update() 
        {
            this.position.X -= 2f;
        }

        public Rectangle TopBound { get { return new Rectangle((int)this.position.X+3, (int)this.position.Y, 55, 320); } }
        public Rectangle BottomBound { get { return new Rectangle((int)this.position.X+3, (int)this.position.Y+480, 55, 320); } }

        public void Draw() 
        {
            Statics.SPRITEBATCH.Draw(this.texture, this.position, Color.White);

            if (Statics.DEBUG)
            {
                //Show Debug Top
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound, new Color(1f, 0f, 0f, 0.3f));
                //Show Debug Bottom
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.BottomBound, new Color(1f, 0f, 0f, 0.3f));
            }
        }
    }
}
