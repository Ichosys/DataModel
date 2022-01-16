﻿using Ichosoft.DataModel.Annotations;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System;

namespace Ichosoft.DataModel
{
    public class ModelMetadataService : IModelMetadataService
    {
        /// <inheritdoc/>
        public string DescriptionFor<TModel>(string memberName)
        {
            return DescriptionFor(typeof(TModel), memberName);
        }

        /// <inheritdoc/>
        public string GroupNameFor<TModel>(string memberName)
        {
            return GroupNameFor(typeof(TModel), memberName);
        }

        /// <inheritdoc/>
        public string NameFor<TModel>(string memberName)
        {
            return NameFor(typeof(TModel), memberName);
        }

        /// <inheritdoc/>
        public int? OrderFor<TModel>(string memberName)
        {
            return OrderFor(typeof(TModel), memberName);
        }

        /// <inheritdoc/>
        public string PromptFor<TModel>(string memberName)
        {
            return PromptFor(typeof(TModel), memberName);
        }

        /// <inheritdoc/>
        public string ShortNameFor<TModel>(string memberName)
        {
            return ShortNameFor(typeof(TModel), memberName);
        }

        /// <inheritdoc/>
        public string DescriptionFor(Type type, string memberName)
        {
            string result = GetDisplayAttribute(type, memberName)?.GetDescription();

            return result;
        }

        /// <inheritdoc/>
        public string GroupNameFor(Type type, string memberName)
        {
            string result = GetDisplayAttribute(type, memberName)?.GetGroupName();

            return result;
        }

        /// <inheritdoc/>
        public string NameFor(Type type, string memberName)
        {
            string result = GetDisplayAttribute(type, memberName)?.GetName();

            return result;
        }

        /// <inheritdoc/>
        public int? OrderFor(Type type, string memberName)
        {
            int? result = GetDisplayAttribute(type, memberName)?.GetOrder();

            return result;
        }

        /// <inheritdoc/>
        public string PromptFor(Type type, string memberName)
        {
            string result = GetDisplayAttribute(type, memberName)?.GetPrompt();

            return result;
        }

        /// <inheritdoc/>
        public string ShortNameFor(Type type, string memberName)
        {
            string result = GetDisplayAttribute(type, memberName)?.GetShortName();

            return result;
        }

        /// <inheritdoc/>
        private static DisplayAttribute GetDisplayAttribute(Type type, string memberName)
        {
            if (string.IsNullOrEmpty(memberName) || type is null)
                return null;

            MemberInfo memberInfo = type.GetMember(memberName: memberName);

            return memberInfo?.GetAttribute<DisplayAttribute>();
            
        }

        /// <inheritdoc/>
        private static DisplayAttribute GetDisplayAttribute<TModel>(string memberName)
        {
            return GetDisplayAttribute(typeof(TModel), memberName);
        }
    }
}
