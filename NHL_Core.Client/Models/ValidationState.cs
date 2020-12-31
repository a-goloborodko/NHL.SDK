using System;
using System.Collections.Generic;

namespace NHL_Core.Client.Models
{
    public class ValidationState
    {
        private static readonly Lazy<ValidationState> _valid = new Lazy<ValidationState>(() => new ValidationState(null));

        public static readonly ValidationState Valid = _valid.Value;

        public bool IsValid { get; }
        public List<string> Errors { get; }

        private ValidationState(
           List<string> errors)
        {
            Errors = errors ?? new List<string>();
            IsValid = Errors.Count == 0;
        }
    }
}