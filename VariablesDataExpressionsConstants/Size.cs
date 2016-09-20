public class Size
{
    private double width;
	private double height;
	
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }
	
	public double Width
	{
		get
		{
			return this.width;
		}
		set
		{
			this.width = value;
		}
	}
	
	public double Height
	{
		get
		{
			return this.height;
		}
		set
		{
			this.height = value;
		}
	}

    public static Size GetRotatedSize(Size size, double angle)
    {
		double rotatedWidth = (Math.Abs(Math.Cos(angle)) * size.width) + (Math.Abs(Math.Sin(angle)) * size.height);
		double rotatedHeight = (Math.Abs(Math.Sin(angle)) * size.width) + (Math.Abs(Math.Cos(angle)) * size.height);
		
        return new Size(rotatedWidth, rotatedHeight);
    }
}