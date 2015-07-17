using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlappyButterfly.Screens
{
    public class GameScreen : Screen
    {
        public Texture2D background;
        public Texture2D wood;
        public Entities.Bird Bird;
        public Entities.Scroll Scroll;
        public SpriteFont Font;
        public int score = 0;

        public List<Entities.Obstacle> Obstacle;
        public int obstacleTimer = 2000;
        public double obstacleElapsed = 0;

        public GameScreen()
        {

        }
        public override void LoadContent()
        {
            background = Statics.CONTENT.Load<Texture2D>("Textures/background");
            wood = Statics.CONTENT.Load<Texture2D>("Textures/Wood");
            Font = Statics.CONTENT.Load<SpriteFont>("Fonts/font");
            gameover = Statics.CONTENT.Load<Texture2D>("Textures/gameover");

            Reset();
 	        base.LoadContent();
        }
        public void Reset()
        {
            Bird = new Entities.Bird();
            Scroll = new Entities.Scroll();

            Obstacle = new List<Entities.Obstacle>();
            Obstacle.Add(new Entities.Obstacle());
            score = 0;
        }
        public override void Update()
        {
            obstacleCreator();
            if (!Bird.dead)
            {
                for (int i = Obstacle.Count - 1; i > -1; i--)
                {
                    if (Obstacle[i].position.X < -50)
                        Obstacle.RemoveAt(i);
                    else
                    {
                        Obstacle[i].Update();
                        if (!Obstacle[i].scored && Bird.Position.X > Obstacle[i].position.X + 50)
                        {
                            Obstacle[i].scored = true;
                            score++;
                        }
                        if (Bird.Bound.Intersects(Obstacle[i].TopBound) || Bird.Bound.Intersects(Obstacle[i].BottomBound))
                        {
                            Bird.dead = true;
                        }
                    }
                }
                Bird.Update();
                Scroll.Update();
            }

            if(Bird.dead && Statics.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.Reset();
            }

            base.Update();
        }
        public void obstacleCreator()
        {
            obstacleElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (obstacleElapsed > obstacleTimer)
            {
                Obstacle.Add(new Entities.Obstacle());
                obstacleElapsed = 0;
            }
        }

        
        public override void Draw()
        {
            Statics.SPRITEBATCH.Begin();
            Statics.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);

            foreach (var item in Obstacle)
            {
                item.Draw();
            }
   
            Statics.SPRITEBATCH.Draw(this.wood, new Vector2(0, 533), Color.White);

            Scroll.Draw();
            Bird.Draw();

            Statics.SPRITEBATCH.DrawString(this.Font, "Score: " + this.score.ToString(), new Vector2(10, 10), Color.Red);

            if (Bird.dead)
            {

                Statics.SPRITEBATCH.Draw(Statics.PIXEL, new Rectangle(0, 0, Statics.GAME_WIDTH, Statics.GAME_HEIGHT), new Color(0.2f, 0.3f, 0.4f, 0.2f));
                Statics.SPRITEBATCH.Draw(this.gameover, new Vector2(0, 80), Color.White);
                Statics.SPRITEBATCH.DrawString(this.Font, "Score: " + this.score.ToString(), new Vector2(10, 10), Color.Red);
                
            }

            Statics.SPRITEBATCH.End();
            base.Draw();
        }

        public Texture2D gameover { get; set; }
    }
}
