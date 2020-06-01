using Newtonsoft.Json.Linq;

namespace Heidur.Entities.Factories
{
	public static class GameObjectFactory
	{
		public static GameObject CreateGameObject(JObject template)
		{
			var result = new GameObject()
			{
				 
			};

			return result;
		}

		public static GameObject CreateGameObject(string template)
		{
			return CreateGameObject(JObject.Parse(template));
		}
	}
}
