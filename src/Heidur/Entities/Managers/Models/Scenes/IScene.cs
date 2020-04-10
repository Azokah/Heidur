namespace Heidur.Entities.Managers.Models.Scenes
{
	public interface IScene
	{
		Constants.Scene.SCENE_STATE State { get; set; }

		void Initialize(Game1 game);

		void LoadContent(Game1 game);

		void Update(float delta);

		void Draw(Game1 game);

		void CheckKeyboard(Game1 game, float delta);

		void CheckMouseActions(float delta);
	}
}
