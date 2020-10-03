using Cabinet.Server.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Cabinet.Server.Extensions
{
    public static class CabinetExtensions
    {
        public static T GetValue<T>(this IConfigurationSection self, Expression<Func<CabinetConfigOptions, T>> expr)
        {
            return (T)(self.Value ?? CabinetConfigOptions.GetDefaultValue(expr));
        }

        public static string GetPlatformLocation(this string self)
        {
            // /var/cabinet.datadir;C:/Cabinet.DataDir
            var spt = self.Split(";");
            var (nix, win) = (spt[0], spt[1]);
            return Environment.OSVersion.Platform == PlatformID.Unix ? nix : win;
        }

        public static MemberInfo ToProperty(this LambdaExpression expr)
        {
            var expression = expr.Body;
            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null)
            {
                switch (unaryExpression.NodeType)
                {
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                        expression = unaryExpression.Operand;
                        break;
                }
            }
            var me = expression as MemberExpression;
            if (me == null)
            {
                throw new InvalidOperationException();
            }

            return me.Member;
        }
    }
}