namespace InterfaceEvaluator
{
    public interface IFunctionEvaluator
    {
        public double FunctionWidth { get; set; }
        public double FunctionHeight { get; set; }
        public int CenterX { get; set; }
        public int CenterY { get; set; }
        public int DrawWidth { get; set; }
        public int DrawHeight { get; set; }

        public int EvaluateX(int xPixel);
        public double EvaluateXFunction(int x);
        public double EvaluateYFunction(int x);
    }
}
