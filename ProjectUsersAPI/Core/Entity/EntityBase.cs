using FluentValidation;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace core.Entity
{
    public class EntityBase
    {
        [JsonIgnore]
        public bool Valid { get; private set; }

        [JsonIgnore]
        public bool Invalid => !Valid;

        [JsonIgnore]
        public ValidationResult ValidationResult { get; private set; }

        public List<string> Errors { get; private set; } = new List<string>();

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);

            Valid = ValidationResult.IsValid;

            Errors = ValidationResult.Errors
                .Select(e => $"{e.ErrorMessage}")
                .ToList();

            return Valid;
        }
    }
}
