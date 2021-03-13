using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validators
{
    public class ValidationError
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public ValidationError()
        {

        }
        public ValidationError(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
