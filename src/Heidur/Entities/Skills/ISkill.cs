using Heidur.Entities.GameObjects;

namespace Heidur.Entities.Skills
{
	public interface ISkill
	{
		bool Execute(GameObject unit, GameObject objective);
	}
}
