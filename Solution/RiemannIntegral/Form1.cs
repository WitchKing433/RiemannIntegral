using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using InterfaceEvaluator;
using DynamicLibraryTool;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiemannIntegral
{
    public partial class Form1 : Form
    {
        int epsilon;
        bool failPaint = false;
        bool darbouxCalc = false;
        double darbouxInf = 0;
        double darbouxSup = 0;

        IFunctionEvaluator functionEvaluator = null;

        public Form1()
        {
            InitializeComponent();
            CalcEpsilon();
        }

        private void CalcEpsilon()
        {
            if (functionEvaluator == null)
                return;
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            functionEvaluator.CenterX = (int)((width / 2) - width / 2.5);
            functionEvaluator.DrawWidth = width - functionEvaluator.CenterX * 2;
            epsilon = functionEvaluator.DrawWidth / trackBar1.Value;
            darbouxCalc = true;
            darbouxInf = 0;
            darbouxSup = 0;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (failPaint)
                return;
            try
            {
                if (functionEvaluator == null)
                    return;
                pictureBox1.Invalidate();
                Graphics g = e.Graphics;

                int width = pictureBox1.Width;
                int height = pictureBox1.Height;

                using (Brush brush = new SolidBrush(Color.White))
                {
                    int x = 0;
                    int y = 0;
                    g.FillRectangle(brush, x, y, width, height);
                }
                functionEvaluator.CenterX = (int)((width / 2) - width / 2.5);
                functionEvaluator.CenterY = (int)((height / 2) + height / 2.5);
                functionEvaluator.DrawWidth = width - functionEvaluator.CenterX * 2;
                functionEvaluator.DrawHeight = 2 * functionEvaluator.CenterY - height;


                Pen axisPen = new Pen(Color.Black, 2);

                g.DrawLine(axisPen, 0, functionEvaluator.CenterY, width, functionEvaluator.CenterY);

                g.DrawLine(axisPen, functionEvaluator.CenterX, 0, functionEvaluator.CenterX, height);

                DrawArrow(g, axisPen, new Point(width, functionEvaluator.CenterY), new Point(width - 10, functionEvaluator.CenterY - 5));
                DrawArrow(g, axisPen, new Point(width, functionEvaluator.CenterY), new Point(width - 10, functionEvaluator.CenterY + 5));
                DrawArrow(g, axisPen, new Point(functionEvaluator.CenterX, 0), new Point(functionEvaluator.CenterX - 5, 10));
                DrawArrow(g, axisPen, new Point(functionEvaluator.CenterX, 0), new Point(functionEvaluator.CenterX + 5, 10));

                int prevX = functionEvaluator.CenterX;
                int prevY = functionEvaluator.EvaluateX(prevX);
                for (int currentX = functionEvaluator.CenterX; currentX < (functionEvaluator.CenterX + functionEvaluator.DrawWidth); currentX++)
                {
                    int currentY = functionEvaluator.EvaluateX(currentX);
                    using (Pen pen = new Pen(Color.Black, 3))
                    {
                        Point punto1 = new Point(prevX, prevY);
                        Point punto2 = new Point(currentX, currentY);
                        e.Graphics.DrawLine(pen, punto1, punto2);
                    }
                    prevX = currentX;
                    prevY = currentY;
                }
                prevX = functionEvaluator.CenterX;
                prevY = functionEvaluator.EvaluateX(prevX);
                for (int currentX = functionEvaluator.CenterX + epsilon; currentX <= (functionEvaluator.CenterX + functionEvaluator.DrawWidth); currentX += epsilon)
                {
                    int maxY = -1;
                    int minY = int.MaxValue;
                    int currentY = functionEvaluator.EvaluateX(currentX);
                    Pen pen = new Pen(Color.Red, 3);
                    Point punto1 = new Point(currentX, currentY);
                    Point punto2 = new Point(currentX, functionEvaluator.CenterY);
                    e.Graphics.DrawLine(pen, punto1, punto2);
                    for (int bCurrentX = prevX; bCurrentX <= currentX; bCurrentX++)
                    {
                        int yFunction = functionEvaluator.EvaluateX(bCurrentX);
                        maxY = Math.Max(maxY, yFunction);
                        minY = Math.Min(minY, yFunction);
                    }
                    using (HatchBrush hatchBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Green, Color.Transparent))
                    {
                        g.FillRectangle(hatchBrush, prevX, minY, currentX - prevX, functionEvaluator.CenterY - minY);
                        g.DrawRectangle(pen, prevX, minY, currentX - prevX, functionEvaluator.CenterY - minY);
                    }
                    using (HatchBrush hatchBrush = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Blue, Color.Transparent))
                    {
                        g.FillRectangle(hatchBrush, prevX, maxY, currentX - prevX, functionEvaluator.CenterY - maxY);
                        g.DrawRectangle(pen, prevX, maxY, currentX - prevX, functionEvaluator.CenterY - maxY);
                    }
                    if (darbouxCalc)
                    {
                        darbouxInf += (functionEvaluator.EvaluateXFunction(currentX) - functionEvaluator.EvaluateXFunction(prevX)) * functionEvaluator.EvaluateYFunction(maxY);
                        darbouxSup += (functionEvaluator.EvaluateXFunction(currentX) - functionEvaluator.EvaluateXFunction(prevX)) * functionEvaluator.EvaluateYFunction(minY);
                    }
                    prevX = currentX;
                    prevY = currentY;
                }
                darbouxCalc = false;
                textBoxSupInt.Text = darbouxSup.ToString();
                textBoxInfInt.Text = darbouxInf.ToString();
            }
            catch (Exception exc)
            {
                failPaint = true;
                MessageBox.Show("La función a graficar debe ser continua y positva\n en el intervalo introducido para una correcta visualización\n reinicie la aplicación", "Error al graficar la función", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DrawArrow(Graphics g, Pen pen, Point start, Point end)
        {
            g.DrawLine(pen, start, end);
        }


        public void ChangePartition(int x)
        {
            if (x > 0 && functionEvaluator != null)
            {
                epsilon = functionEvaluator.DrawWidth / x;
                darbouxCalc = true;
                darbouxInf = 0;
                darbouxSup = 0;
            }
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ChangePartition(trackBar1.Value);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            CalcEpsilon();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            if (functionEvaluator != null)
            {
                functionEvaluator = null;
            }

            string source = $"{appPath}FuncionEvaluator\\FunctionEvaluatorCopy.cs";
            string destination = $"{appPath}FuncionEvaluator\\FunctionEvaluator.cs";
            File.Copy(source, destination, true);
            string functionEvaluatorCode = File.ReadAllText(destination);
            functionEvaluatorCode = functionEvaluatorCode.Replace("FUNCTIONPLACEHOLDER", textBoxFunction.Text).Replace("FUNCTIONINTERVALX", textBoxMaxX.Text).Replace("FUNCTIONINTERVALY", textBoxMaxY.Text);
            File.WriteAllText(destination, functionEvaluatorCode);
            if (CompileFunctionEvaluator($"{appPath}FuncionEvaluator\\FunctionEvaluator.csproj"))
            {
                try
                {
                    functionEvaluator = DinamicLibraryLoader.LoadAssembly<IFunctionEvaluator>($"{appPath}FuncionEvaluator\\bin\\Debug\\net9.0\\FunctionEvaluator.dll");
                    button1.Hide();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error al cargar la biblioteca evluador de funciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CalcEpsilon();
            pictureBox1.Invalidate(true);
        }

        bool CompileFunctionEvaluator(string projectPath)
        {
            Process proceso = new Process();
            proceso.StartInfo.FileName = "dotnet";
            proceso.StartInfo.Arguments = $"build \"{projectPath}\"";
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.RedirectStandardOutput = true;
            proceso.StartInfo.RedirectStandardError = true;
            proceso.StartInfo.CreateNoWindow = true;

            proceso.Start();

            string salida = proceso.StandardOutput.ReadToEnd();
            string errores = proceso.StandardError.ReadToEnd();

            proceso.WaitForExit();

            if (!string.IsNullOrEmpty(errores))
            {
                MessageBox.Show(errores, "Error de compilación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return proceso.ExitCode == 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
