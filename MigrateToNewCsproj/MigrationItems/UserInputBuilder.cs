using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Saltuk.Utils.Validation;

namespace MigrationItems
{
    public class UserInputBuilder
    {
        [NotNull]
        private readonly Dictionary<string, UserInputParameter> _notFilledParameters =
            new Dictionary<string, UserInputParameter>();

        [NotNull]
        private readonly Dictionary<UserInputParameter, object> _values = new Dictionary<UserInputParameter, object>();

        internal UserInputBuilder([ItemNotNull] [NotNull] IReadOnlyCollection<UserInputParameter> inputParameters)
        {
            foreach (var inputParameter in inputParameters.WithNullChecking())
            {
                _notFilledParameters.Add(inputParameter.Name, inputParameter);
            }
        }

        [NotNull]
        public UserInputBuilder AddParameter<T>([NotNull] string name, T value)
        {
            ThrowIf.Argument.IsNull(name, nameof(name));

            if (!_notFilledParameters.TryGetValue(name, out var parameter))
            {
                throw new ArgumentException($"User input parameter {name} was not requested");
            }

            if (parameter.Type != typeof(T))
            {
                throw new ArgumentException(
                    $"Type of user parameter {name} ({typeof(T).Name}) differs from original type {parameter.Type.Name}");
            }

            _values.Add(parameter, value);
            _notFilledParameters.Remove(name);

            return this;
        }

        [NotNull]
        public UserInput Buid()
        {
            if (_notFilledParameters.Count != 0)
            {
                throw new InvalidOperationException($"Not all user input parameters was filled: {string.Join(", ", _notFilledParameters.Keys)}");
            }

            return new UserInput(_values);
        }
    }
}