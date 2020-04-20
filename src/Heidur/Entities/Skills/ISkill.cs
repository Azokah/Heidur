namespace Heidur.Entities.Skills
{
	public interface ISkill
	{
		string Name { get; set; }
		
		bool Execute(GameObject unit, GameObject objective);
	}
}
