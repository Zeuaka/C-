namespace ClassWork
{
    internal class MyLine
    {
        MyPoint startPoint;
        MyPoint endPoint;

        public MyPoint StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public MyPoint EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        public MyLine()
        {
            this.startPoint = new MyPoint();
            this.endPoint = new MyPoint();
        }

        public MyLine(MyPoint start, MyPoint end)
        {
            this.StartPoint = start;
            this.EndPoint = end;
        }

        public MyLine(int x1, int y1, int x2, int y2)
        {
            this.startPoint = new MyPoint(x1, y1);
            this.endPoint = new MyPoint(x2, y2);
        }

        public override string ToString()
        {
            if (startPoint.XAxis == endPoint.XAxis && startPoint.YAxis == endPoint.YAxis)
            {
                Console.WriteLine("Линия замкнута.");
            }
            return "Линия от " + startPoint.ToString() + " до " + endPoint.ToString();
        }
    }
}