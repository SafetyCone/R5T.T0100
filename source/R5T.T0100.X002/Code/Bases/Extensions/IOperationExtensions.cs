using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.Magyar;

using R5T.T0098;


// Use specific (non-System) namespace.
namespace R5T.T0100.X002
{
    public static class IOperationExtensions
    {
        /// <summary>
        /// Loads a file formatted as {extension method base namespaced type name}| {identity}, which sure, is inconvenient for human analysis, but is required since code file path is not unique. (TODO: provide some other file export of this data.)
        /// </summary>
        public static async Task<ExtensionMethodBaseNameSelection[]> LoadDuplicateExtensionMethodBaseNameSelectionsReturnEmptyIfNotExists(this IOperation _,
            string duplicateNameSelectionsTextFilePath)
        {
            var duplicateNameSelectionValues = Instances.FileSystemOperator.FileExists(duplicateNameSelectionsTextFilePath)
                ? await Instances.DuplicateValuesOperator.LoadDuplicateValueSelections(duplicateNameSelectionsTextFilePath)
                : new Dictionary<string, string>()
                ;

            // File is formatted as {extension method base namespaced type name}| {identity}, which sure, is inconvenient for human analysis, but is required since code file path is not unique. (TODO: provide some other file export of this data.)
            var duplicateNameSelections = duplicateNameSelectionValues
                .Select(xPair => new ExtensionMethodBaseNameSelection
                {
                    ExtensionMethodBaseIdentity = Instances.GuidOperator.FromStringStandard(xPair.Value),
                    ExtensionMethodBaseNamespacedTypeName = xPair.Key
                })
                .ToArray()
                ;

            return duplicateNameSelections;
        }

        /// <summary>
        /// Chooses <see cref="LoadDuplicateExtensionMethodBaseNameSelectionsReturnEmptyIfNotExists(IOperation, string)"/> as the default.
        /// </summary>
        public static async Task<ExtensionMethodBaseNameSelection[]> LoadDuplicateExtensionMethodBaseNameSelections(this IOperation _,
            string duplicateNameSelectionsTextFilePath)
        {
            var duplicateNameSelections = await _.LoadDuplicateExtensionMethodBaseNameSelectionsReturnEmptyIfNotExists(duplicateNameSelectionsTextFilePath);
            return duplicateNameSelections;
        }

        /// <summary>
        /// Saves a file formatted as {extension method base namespaced type name}| {identity}, which sure, is inconvenient for human analysis, but is required since code file path is not unique. (TODO: provide some other file export of this data.)
        /// </summary>
        public static async Task SaveExtensionMethodBaseNameSelections(this IOperation _,
            string nameSelectionsTextFilePath,
            IEnumerable<ExtensionMethodBaseNameSelection> duplicateExtensionMethodBaseNameSelections)
        {
            // File is formatted as {extension method base namespaced type name}| {identity}, which sure, is inconvenient for human analysis, but is required since code file path is not unique. (TODO: provide some other file export of this data.)
            var duplicateNameSelectionValues = duplicateExtensionMethodBaseNameSelections
                .OrderAlphabetically(xExtensionMethodBaseNameSelection => xExtensionMethodBaseNameSelection.ExtensionMethodBaseNamespacedTypeName)
                .ToDictionary(
                    xExtensionMethodBaseNameSelection => xExtensionMethodBaseNameSelection.ExtensionMethodBaseNamespacedTypeName,
                    xExtensionMethodBaseNameSelection => Instances.GuidOperator.ToStringStandard(xExtensionMethodBaseNameSelection.ExtensionMethodBaseIdentity));

            await Instances.DuplicateValuesOperator.SaveDuplicateValueSelections(
                nameSelectionsTextFilePath,
                duplicateNameSelectionValues);
        }
    }
}