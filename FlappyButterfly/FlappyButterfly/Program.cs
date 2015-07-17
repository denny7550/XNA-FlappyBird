using System;

namespace FlappyButterfly
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FlappyGame game = new FlappyGame())
            {
                game.Run();
            }
        }
    }
#endif
}

