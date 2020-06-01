using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace Heidur.Entities
{
	public class Camera2D
	{
		public BoxingViewportAdapter viewportAdapter;
		public OrthographicCamera camera;
		public GameObject source;

		public Camera2D(Game1 game)
		{
			viewportAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, Constants.RESOLUTION_WIDTH*2, Constants.RESOLUTION_HEIGHT*2);
			camera = new OrthographicCamera(viewportAdapter);
		}

		public void SetCameraSource(GameObject gameObject)
		{
			source = gameObject;
		}

		public void Update(float delta)
		{
			if (source != null)
			{
				camera.Position = new Microsoft.Xna.Framework.Vector2(source.PhysicsComponent.position.X - viewportAdapter.VirtualWidth/2, source.PhysicsComponent.position.Y - viewportAdapter.VirtualHeight/2);
			}
		}
	}
}
