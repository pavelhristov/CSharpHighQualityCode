public static class Printer
{
	public void PrintStatistics(double[] arr, int count)
	{
		double max = Int64.MinValue;
		double min = Int64.MaxValue;
		double sum = 0;
		
		for (int i = 0; i < count; i++)
		{
			if (arr[i] > max)
			{
				max = arr[i];
			}
			
			if (arr[i] < min)
			{
				min = arr[i];
			}
			
			sum += arr[i];
		}
		
		double avarage = sum/count;
		
		// there could be one Print method
		PrintMax(max);
		PrintMin(min);
		PrintAvg(avarage);
	}
}