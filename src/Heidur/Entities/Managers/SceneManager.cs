using Heidur.Entities.Managers.Models.Scenes;
using System.Collections.Generic;

namespace Heidur.Entities.Managers
{
	public class SceneManager
	{
		public List<IScene> Scenes;
		public IScene CurrentScene;


		public SceneManager()
		{
			Scenes = new List<IScene>();
			CurrentScene = null;
		}

		public SceneManager(IScene scene)
		{
			Scenes = new List<IScene>() { scene };
			CurrentScene = scene;
		}

		public void Initialize(Game1 game, IScene scene)
		{
			scene.Initialize(game);
		}

		public void Initialize(Game1 game)
		{
			CurrentScene.Initialize(game);
		}

		public void LoadContent(Game1 game, IScene scene)
		{
			scene.LoadContent(game);
		}

		public void LoadContent(Game1 game)
		{
			CurrentScene.LoadContent(game);
		}

		public void Update(IScene scene, float delta)
		{
			scene.Update(delta);
		}

		public void Update(float delta)
		{
			CurrentScene.Update(delta);
		}

		public void Draw(Game1 game, IScene scene)
		{
			scene.Draw(game);
		}

		public void Draw(Game1 game)
		{
			CurrentScene.Draw(game);
		}

		public void CheckKeyboard(Game1 game, float delta)
		{
			CurrentScene.CheckKeyboard(game, delta);
		}

		public void CheckKeyboard(Game1 game, float delta, IScene scene)
		{
			scene.CheckKeyboard(game, delta);
		}

		public void CheckMouseActions(float delta)
		{
			CurrentScene.CheckMouseActions(delta);
		}

		public void CheckMouseActions(float delta, IScene scene)
		{
			scene.CheckMouseActions(delta);
		}
	}
}
