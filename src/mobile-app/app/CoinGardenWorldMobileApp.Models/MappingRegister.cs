using CoinGardenWorldMobileApp.Models.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.Models
{
    public class MappingRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            config.AdaptTo("[name]Dto", MapType.Map | MapType.MapToTarget | MapType.Projection)
                .ApplyDefaultRule()
                //.PreserveReference(true)
                //.AlterType<Student, Person>()
                ;

            config.AdaptFrom("[name]Add", MapType.Map)
                .ApplyDefaultRule()
                .IgnoreNoModifyProperties();

            config.AdaptFrom("[name]Update", MapType.MapToTarget)
                .ApplyDefaultRule()
                .IgnoreAttributes(typeof(KeyAttribute))
                .IgnoreNoModifyProperties();

            config.AdaptFrom("[name]Merge", MapType.MapToTarget)
                .ApplyDefaultRule()
                .IgnoreAttributes(typeof(KeyAttribute))
                .IgnoreNoModifyProperties()
                .IgnoreNullValues(true);

            config.GenerateMapper("[name]Mapper")
                .ForType<Account>()
                .ForType<Garden>()
                .ForType<Flower>();
        }

    }

    static class RegisterExtensions
    {
        public static AdaptAttributeBuilder ApplyDefaultRule(this AdaptAttributeBuilder builder)
        {
            return builder
                .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "CoinGardenWorldMobileApp.Models.Entities")

                .ExcludeTypes(typeof(ServiceCollectionExtensions))
                .ExcludeTypes(type => type.IsEnum)
                .ExcludeTypes(typeof(BaseEntity))

                //.PreserveReference(true)

                .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string))
                .ShallowCopyForSameType(true)
                 .ForType<Account>(cfg => cfg.Ignore(it => it.CreatedFrom))
                 .ForType<Account>(cfg => cfg.Ignore(it => it.UpdatedFrom))

                .ForType<Garden>(cfg => cfg.Ignore(it => it.Flowers))
                .ForType<Flower>(cfg => cfg.Ignore(it => it.Garden))
                ;
        }

        public static AdaptAttributeBuilder IgnoreNoModifyProperties(this AdaptAttributeBuilder builder)
        {
            //  return builder
            //    .ForType<Enrollment>(cfg => cfg.Ignore(it => it.Student));

            return builder;
        }
    }
}