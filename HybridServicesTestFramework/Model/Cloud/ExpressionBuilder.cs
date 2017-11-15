using System;
using System.Linq.Expressions;

namespace HybridServicesTestFramework.Model.Cloud
{
	public static class ExpressionBuilder
	{
		public static Expression<Func<T, bool>> All<T>() where T : IPersistentModel
		{
			return entity => entity.Id != null;
		}

		public static Expression<Func<T, bool>> None<T>() where T : IPersistentModel
		{
			return entity => entity.Id == null;
		}

		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
			Expression<Func<T, bool>> expr2) where T : IPersistentModel
		{
			var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
			return Expression.Lambda<Func<T, bool>>
				(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
		}

		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
			Expression<Func<T, bool>> expr2) where T : IPersistentModel
		{
			var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);
			return Expression.Lambda<Func<T, bool>>
				(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
		}
	}
}