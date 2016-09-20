public class RefractorStatements
{
	private bool IsVariableInRange(int x, int min, int max)
	{
		if(min >= x && x <= max)
		{
			return true;
		}
		
		return false;
	}
	
	public void RefractoredPotato()
	{
		Potato potato;
		//... 
		if (potato != null)
		{
			if(potato.hasBeenPeeled && !potato.isRotten)
			{
				Cook(potato);
			}
		}
	}
	
	public void RefractoredLongIf()
	{
		if (IsVariableInRange(x, MIN_X, MAX_X) && 
			IsVariableInRange(y, MIN_Y, MAX_Y) && 
			shouldVisitCell)
		{
			VisitCell();
		}
	}
}