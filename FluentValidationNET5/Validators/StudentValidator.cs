using System;
using FluentValidation;
using FluentValidationNET5.Models;

namespace FluentValidationNET5.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FullName)
                .NotEmpty().WithMessage("O FullName não pode ser nulo")
                .MaximumLength(50).WithMessage("O FullName deve ser menor que 50 caracteres")
                .MinimumLength(5).WithMessage("O FullName deve ser maior que 5 caracteres");

            RuleFor(s => s.BirthDate)
                .LessThan(DateTime.Now.Date).WithMessage("A data de aniversário não deve ser maior hoje");
            
            RuleFor(s => s.Document)
                .Must(d => d.IsValidDocument()).WithMessage("Document é inválido");
        }
    }
}