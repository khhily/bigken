using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConsoleApplication1
{
    public class LamdaExpressionTest
    {
        public static void Test()
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");

            ConstantExpression five = Expression.Constant(5, typeof(int));

            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);

            Expression<Func<int, bool>> lambda = Expression.Lambda<Func<int, bool>>(
                numLessThanFive,
                new ParameterExpression[] { numParam });

            Console.WriteLine(ExpressionToString(lambda.Body));

            Expression<Func<int, bool>> exp2 = x => x < 100;
            Console.WriteLine(ExpressionToString(exp2.Body));


            Console.WriteLine(lambda.Compile()(10));
            Console.Read();
        }

        public static string ExpressionToString(Expression body)
        {
            StringBuilder s = new StringBuilder();

            switch (body.NodeType)
            {
                case ExpressionType.LessThan:
                    s.Append(((BinaryExpression)body).Left);
                    s.Append("<");
                    s.Append(((BinaryExpression)body).Right);
                    break;
                case ExpressionType.Parameter:
                    s.Append(((ParameterExpression)body).Name);
                    break;
                case ExpressionType.Constant:
                    s.Append(((ConstantExpression)body).Value);
                    break;
                default:
                    break;
            }

            return s.ToString();
        }
    }
}
