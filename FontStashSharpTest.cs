using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Reflection;

namespace FontStashSharpTest
{

	public partial class FontStashSharpTest : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch _spriteBatch;
		private FontSystem _fontSystem;

		private static string ExecutingAssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().Location;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return Path.GetDirectoryName(path);
			}
		}

		public FontStashSharpTest()
		{
			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			_fontSystem = new FontSystem();

			var path = Path.Combine(ExecutingAssemblyDirectory, "DroidSans.ttf");
			_fontSystem.AddFont(File.ReadAllBytes(path));
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Render some text
			_spriteBatch.Begin();

			SpriteFontBase font = _fontSystem.GetFont(30);
			_spriteBatch.DrawString(font, "The quick brown\nfox jumps over\nthe lazy dog", 
				new Vector2(0, 80), Color.White, textStyle: TextStyle.Underline);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
