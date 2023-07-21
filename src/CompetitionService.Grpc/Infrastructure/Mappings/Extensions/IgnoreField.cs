using System.Linq.Expressions;
using AutoMapper;

namespace CompetitionService.Grpc.Infrastructure.Mappings.Extensions
{
    public static class IgnoreField
    {
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}