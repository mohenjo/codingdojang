using System;

namespace CD252
{
    class Program
    {
        static void Main()
        {

            int a = GetInput("A");
            int b = GetInput("B");
            int c = GetInput("C");
            Equation eq = new Equation(a, b, c);
            Equation.EqType numRoots = eq.SolveEquation(out double rootA, out double rootB);
            _ = eq.SolveEquationByFormula(out double rootAF, out double rootBF);
            Console.WriteLine($"근의 개수: {numRoots}");
            if (numRoots == Equation.EqType.TwoRoots)
            {
                Console.WriteLine($"근사치로 구한 근은 {rootA}, {rootB}이며,");
                Console.WriteLine($"근의 공식으로 구한 근은 {rootAF}, {rootBF}입니다.");
            }
            else if (numRoots == Equation.EqType.OneRoot)
            {
                Console.WriteLine($"근사치로 구한 근은 {rootA}이며,");
                Console.WriteLine($"근의 공식으로 구한 근은 {rootAF}입니다.");
            }
            else
            {
                Console.WriteLine($"0에 가장 가까운 X값은 {rootA}입니다.");
            }
        }

        static int GetInput(string varName)
        {
            bool foo = false;
            int parsedValue = int.MaxValue;
            while (!foo || parsedValue < -10 || parsedValue > 10)
            {
                Console.Write($"계수 {varName}의 값을 입력하세요(단, -10 <= 변수(정수) <= 10): ");
                foo = int.TryParse(Console.ReadLine(), out parsedValue);
            }
            return parsedValue;
        }
    }

    // 좌표를 나타내는 구조체
    struct Pos
    {
        public double X, Y;

        public Pos(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    // 방정식을 나타내는 클래스
    class Equation
    {
        private int _A, _B, _C;

        private Pos _Inflection; // 변곡점의 좌표

        private double GetFuncValue(double x) // x에 대한 함수의 값 계산
        {
            return _A * x * x + _B * x + _C;
        }

        public Equation(int a, int b, int c)
        {
            (_A, _B, _C) = (a, b, c);

            // 2차 함수 f(x)에 대해 변곡점을 구하면, 
            // f'(x) = 2 A x + B = 0  ==> x = -B / (2 A)
            double fooX = -_B / (2.0 * _A);
            _Inflection = new Pos(fooX, GetFuncValue(fooX));
        }

        // 주어진 방정식 인스턴스의 해를 구함 (근사)
        public EqType SolveEquation(out double rootA, out double rootB)
        {
            rootA = default;
            rootB = default;

            EqType numberOfRoots; // 근의 개수

            // 근의 개수 판단
            switch (_Inflection.Y)
            {
                case double d when d == 0:
                    numberOfRoots = EqType.OneRoot;
                    rootA = _Inflection.X; // 근이 하나인 경우 변곡점
                    break;
                case double d when d * _A < 0:
                    numberOfRoots = EqType.TwoRoots;
                    break;
                default:
                    numberOfRoots = EqType.NoRoot;
                    rootA = _Inflection.X; // 근이 없는 경우 0에 가장 가까운 값
                    break;
            }

            // 근이 두 개인 경우 trial-error로 근 구함
            if (numberOfRoots == EqType.TwoRoots)
            {
                // X좌표값을 변곡점을 기준으로 epsilon만큼 증가시켜 가면서
                // Y값이 음->양 또는 양->음 되는 점(해)을 찾음
                // 변곡점을 기준으로 대칭된 반대의 위치에 있는 점이 또 다른 해임
                double epsilon = 0.0001;
                double prevX = _Inflection.X; // 이전 X좌표
                double tryX = _Inflection.X + epsilon; // 시도할 X좌표
                while (GetFuncValue(prevX) * GetFuncValue(tryX) > 0)
                {
                    tryX += epsilon;
                }
                rootA = tryX;
                rootB = _Inflection.X - (tryX - _Inflection.X);
            }

            return numberOfRoots;
        }

        // 주어진 방정식 인스턴스의 해를 구함 (근의 공식)
        public EqType SolveEquationByFormula(out double rootA, out double rootB)
        {
            rootA = default;
            rootB = default;

            EqType numberOfRoots;
            double checkFormula = _B * _B - 4.0 * _A * _C;
            if (checkFormula > 0)
            {
                numberOfRoots = EqType.TwoRoots;
                rootA = (-_B + Math.Sqrt(checkFormula)) / (2.0 * _A);
                rootB = (-_B - Math.Sqrt(checkFormula)) / (2.0 * _A);
            }
            else if (checkFormula == 0)
            {
                numberOfRoots = EqType.OneRoot;
                rootA = -_B / (2.0 * _A);
            }
            else
            {
                numberOfRoots = EqType.NoRoot;
            }

            return numberOfRoots;
        }

        public enum EqType // 근의 개수를 나타내는 열거형
        {
            NoRoot,
            OneRoot,
            TwoRoots
        }
    }
}
