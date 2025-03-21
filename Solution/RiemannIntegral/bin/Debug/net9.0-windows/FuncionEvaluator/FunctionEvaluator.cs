using InterfaceEvaluator;
using static System.Math;
namespace FuncionEvaluator
{
    public class FunctionEvaluator : IFunctionEvaluator
    {
        protected double functionWidth = 10;
        //2.0 * Math.PI;
        protected double functionHeight = 10;
        protected int centerX;
        protected int centerY;
        protected int drawWidth;
        protected int drawHeight;

        public double FunctionWidth { get => functionWidth; set => functionWidth = value; }
        public double FunctionHeight { get => functionHeight; set => functionHeight = value; }
        public int CenterX { get => centerX; set => centerX = value; }
        public int CenterY { get => centerY; set => centerY = value; }
        public int DrawWidth { get => drawWidth; set => drawWidth = value; }
        public int DrawHeight { get => drawHeight; set => drawHeight = value; }

        public int EvaluateX(int xPixel)
        {

            int yPixel = 0;
            double x = functionWidth * (xPixel - centerX) / drawWidth;

            double y = Sin(x)+Cos(x)*Atan(Sin(x*x))+4;
            //Cos(x) * x * Sin(3 * x) + 6
            yPixel = centerY - (int)(drawHeight * y / functionHeight);
            return yPixel;
        }
        public double EvaluateXFunction(int x)
        {
            return functionWidth * (x - centerX) / drawWidth;
        }
        public double EvaluateYFunction(int y)
        {
            return functionHeight * (y - centerY) / (-drawHeight);
        }
    }
}
