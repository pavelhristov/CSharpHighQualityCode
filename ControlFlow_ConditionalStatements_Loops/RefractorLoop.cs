public class RefractorLoop
{
	public void RefractoredLoop()
	{
		bool isExpectedFound = false;
		
		for ( int i = 0; i < 100; i++) 
		{
			Console.WriteLine(array[i]);
			if ((i % 10 == 0) && (array[i] == expectedValue ))
			{
				isExpectedFound = true;
				break;
			}
		}
		
		// More code here
		if (isExpectedFound)
		{
			Console.WriteLine("Value Found");
		}
	}
}