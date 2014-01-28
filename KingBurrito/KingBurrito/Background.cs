﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace KingBurrito
{
    class Background
    {
        // class Background
        private Vector2 screenpos, origin, texturesize;
        private Texture2D mytexture;
        private int screenheight;
        private int screenwidth;
        public void Load(GraphicsDevice device, Texture2D backgroundTexture)
        {
            mytexture = backgroundTexture;
            screenheight = device.Viewport.Height;
            screenwidth = device.Viewport.Width;
            // Set the origin so that we're drawing from the 
            // center of the top edge.
            origin = new Vector2(0, mytexture.Height / 2);
            // Set the screen position to the center of the screen.
            screenpos = new Vector2(0, screenheight / 2);
            // Offset to draw the second texture, when necessary.
            texturesize = new Vector2(mytexture.Width, 0);
        }

        // Background.Update
        public void Update(float deltaX)
        {
            screenpos.X -= deltaX;
            screenpos.X = screenpos.X % mytexture.Width;
        }

        // Background.Draw
        public void Draw(SpriteBatch batch)
        {
            // Draw the texture, if it is still onscreen.
            if (screenpos.X < screenwidth)
            {
                batch.Draw(mytexture, screenpos, null,
                     Color.White, 0, origin, 1, SpriteEffects.None, 0f);
            }
            // Draw the texture a second time, behind the first,
            // to create the scrolling illusion.
            batch.Draw(mytexture, screenpos + texturesize, null,
                 Color.White, 0, origin, 1, SpriteEffects.None, 0f);
        }
    }
}
