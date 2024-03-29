﻿using CoinGardenWorldMobileApp.Models.Attributes;
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
                .IgnoreAttributes(typeof(IgnoreOnDtoAttribute))
                //.PreserveReference(true)
                //.AlterType<Student, Person>()
                ;

            config.AdaptTo("[name]List", MapType.Map | MapType.MapToTarget | MapType.Projection)
                .ApplyDefaultRule()
                .IgnoreAttributes(typeof(IgnoreOnListAttribute))
                ;

            config.AdaptFrom("[name]Add", MapType.Map)
                .ApplyDefaultRule()
                .IgnoreAttributes(typeof(KeyAttribute), typeof(IgnoreOnListAttribute), typeof(IgnoreOnModifyAttribute))
                .IgnoreNoModifyProperties();

            //config.AdaptFrom("[name]Update", MapType.MapToTarget)
            //    .ApplyDefaultRule()
            //    .IgnoreAttributes(typeof(KeyAttribute))
            //    .IgnoreNoModifyProperties();

            config.AdaptFrom("[name]Merge", MapType.MapToTarget)
                .ApplyDefaultRule()
                .IgnoreAttributes(typeof(KeyAttribute), typeof(IgnoreOnListAttribute), typeof(IgnoreOnModifyAttribute))
                .IgnoreNoModifyProperties()
                .IgnoreNullValues(true);

            config.GenerateMapper("[name]Mapper")
                .ForType<Account>()
                .ForType<AccountRole>()
                .ForType<AccountExternalLogins>()
                .ForType<AccountBadge>()
                .ForType<Role>()
                .ForType<Badge>()
                .ForType<Post>()
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
                
                .ExcludeTypes(type =>
                {
                    if (type.IsEnum)
                        return true;
                    if(type == typeof(ServiceCollectionExtensions))
                        return true;
                    if (type == typeof(BaseEntity))
                        return true;

                    return false;
                })

                //.PreserveReference(true)
                .AlterType(type => type.IsEnum || Nullable.GetUnderlyingType(type)?.IsEnum == true, typeof(string))
                .ShallowCopyForSameType(true)

                .ForType<AccountExternalLogins>(cfg => cfg.Ignore(it => it.Account))
                 // .ForType<Post>(cfg => cfg.Ignore(it => it.Account))

                 .ForType<Garden>(cfg => cfg.Ignore(it => it.Flowers))
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