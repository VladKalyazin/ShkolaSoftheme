using System;
using System.Collections.Generic;

namespace Calculator
{
    // Парсер строки для математических выражений
    public static class MathExpression
    {
        private const string ErrorMessage = "Invalid expression data";
        // Поддерживаемые операторы
        private static List<char> AvaibleOperators { get; } = new List<char>() { '^', '*', '/', '+', '-' };

        // Решение выражения
        public static double Solve(string expr)
        {
            foreach (var _operator in AvaibleOperators)
            {
                try
                {
                    return Convert.ToDouble(expr);
                }
                catch
                {
                    // Сокращение скобок
                    string newExpr = SimplifyBreaksOfExpression(expr);
                    if (!newExpr.Equals(expr))
                        return Solve(newExpr);
                    // Сокращение операторов
                    newExpr = SimplifyExpression(expr, _operator);
                    if (!newExpr.Equals(expr))
                        return Solve(newExpr);
                }
            }

            return Solve(expr);
        }

        // Упрощение операторов
        private static string SimplifyExpression(string expr, char _operator)
        {
            expr = expr.Replace('.', ',');
            for (int i = 0; i < expr.Length; i++)
            {
                if (!Char.IsDigit(expr[i]) && !IsAvaibleOperator(expr[i]) && expr[i] != ',')
                    throw new FormatException(ErrorMessage);

                if (expr[i] == _operator)
                {
                    if (i == 0)
                    {
                        if (_operator != '+' && _operator != '-')
                            throw new FormatException(ErrorMessage);
                        continue;
                    }

                    double firstValue, secondValue;
                    int beginIndex, endIndex;
                    firstValue = Convert.ToDouble(GetStringNumber(expr, i - 1, false, out beginIndex));
                    secondValue = Convert.ToDouble(GetStringNumber(expr, i + 1, true, out endIndex));
                    expr = expr.Remove(beginIndex, endIndex - beginIndex + 1);
                    string simplifiedExpr = Calculate(firstValue, secondValue, _operator).ToString();
                    if (Char.IsDigit(simplifiedExpr[0]))
                        simplifiedExpr = '+' + simplifiedExpr;
                    expr = expr.Insert(beginIndex, simplifiedExpr);
                }
            }

            return expr;
        }

        private static string SimplifyBreaksOfExpression(string expr)
        {
            bool OpenedBreakFind = false;
            int beginIndex = 0, endIndex = 0;
            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(')
                {
                    beginIndex = i;
                    OpenedBreakFind = true;
                }
                if (expr[i] == ')')
                {
                    if (!OpenedBreakFind)
                        throw new FormatException(ErrorMessage);
                    endIndex = i;
                    string subExpr = expr.Substring(beginIndex + 1, endIndex - beginIndex - 1);
                    expr = expr.Remove(beginIndex, endIndex - beginIndex + 1);
                    subExpr = Solve(subExpr).ToString();
                    expr = expr.Insert(beginIndex, subExpr);
                    break;
                }
            }

            return expr;
        }

        private static bool IsAvaibleOperator(char c)
        {
            foreach (var _operator in AvaibleOperators)
                if (_operator == c)
                    return true;
            return false;
        }

        private static string GetStringNumber(string expr, int beginIndex, bool ForwardDirection, out int endIndex)
        {
            bool PointExists = false;
            string strNumber = "";
            int j = beginIndex;
            if (j >= expr.Length)
                throw new FormatException(ErrorMessage);
            if (ForwardDirection && (expr[j] == '+' || expr[j] == '-'))
                strNumber += expr[j++];
            while (Char.IsDigit(expr[j]) || expr[j] == ',')
            {
                if (expr[j] == ',')
                {
                    if (PointExists)
                        throw new FormatException(ErrorMessage);
                    else
                        PointExists = true;
                }
                if (ForwardDirection)
                    strNumber += expr[j++];
                else
                    strNumber = expr[j--] + strNumber;
                if (j < 0 || j >= expr.Length)
                    break;
            }

            if (strNumber.Length == 0)
                throw new FormatException(ErrorMessage);

            if (ForwardDirection)
            {
                endIndex = j - 1;
            }
            else
            {
                if ((j >= 0) && (expr[j] == '+' || expr[j] == '-'))
                    strNumber = expr[j--] + strNumber;
                endIndex = j + 1;
            }

            return strNumber;
        }

        private static double Calculate(double a, double b, char _operator)
        {
            switch (_operator)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                case '^':
                    return Math.Pow(a, b);
                default:
                    return 0;
            }
        }
    }
}