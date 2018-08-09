using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Saltuk.Utils.Validation;

namespace MigrationItems
{
    public class UserInput
    {
        [NotNull]
        private readonly Dictionary<string, UserInputParameter> _parameters =
            new Dictionary<string, UserInputParameter>();

        [NotNull]
        private readonly IReadOnlyDictionary<UserInputParameter, object> _values;

        internal UserInput([NotNull] IReadOnlyDictionary<UserInputParameter, object> values)
        {
            ThrowIf.Argument.IsNull(values, nameof(values));

            foreach (var userInputParameter in values.Keys.WithNullChecking())
            {
                _parameters.Add(userInputParameter.Name, userInputParameter);
            }

            _values = values;
        }

        public T GetParameterValue<T>(string name)
        {
            if (!_parameters.TryGetValue(name, out var parameter))
            {
                throw new ArgumentException($"Unknown user paraneter {name}");
            }

            if (parameter.Type != typeof(T))
            {
                throw new ArgumentException(
                    $"Type of user parameter {name} ({typeof(T).Name}) differs from original type {parameter.Type.Name}");
            }

            return (T) _values[parameter];
        }
    }
}