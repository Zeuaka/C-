namespace ClassWork
{
    internal class MyPoint
    {
        float xAxis;
        float yAxis;

        public float XAxis
        {
            get { return xAxis; }
            set { xAxis = value; }
        }

        public float YAxis
        {
            get { return yAxis; }
            set { yAxis = value; }
        }

        public MyPoint()
        {
            Random random = new Random();
            this.xAxis = random.Next(-10, 11);
            this.yAxis = random.Next(-10, 11);
        }

        public MyPoint(float x, float y)
        {
            this.XAxis = x;
            this.YAxis = y;
        }

        public override string ToString()
        {
            string xStr = xAxis.ToString("0.##");
            string yStr = yAxis.ToString("0.##");
            return "{" + xStr + ";" + yStr + "}";
        }
    }
}