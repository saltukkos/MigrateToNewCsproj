using System.Collections.Generic;
using JetBrains.Annotations;
using Saltuk.Utils.Validation;

namespace MigrationItems
{
    public class UserInputRequest
    {
        public UserInputRequest([NotNull] IReadOnlyList<UserInputParameter> requiredParameters)
        {
            ThrowIf.Argument.IsNull(requiredParameters, nameof(requiredParameters));
            
            RequiredParameters = requiredParameters;
            ResponseBuilder = new UserInputBuilder(requiredParameters);
        }

        [NotNull]
        [ItemNotNull]
        IReadOnlyList<UserInputParameter> RequiredParameters { get; }

        [NotNull]
        UserInputBuilder ResponseBuilder { get; }
    }
}