using Api.Domain.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Web.Validator {
    public class UserDtoValidator : AbstractValidator<UserDto> {
        public UserDtoValidator() {
            RuleFor(x => x.Nome).NotNull().NotEmpty();
            RuleFor(x => x.CPF).NotNull().NotEmpty().Length(14);
            RuleFor(x => x.Senha).NotNull().NotEmpty();
        }
    }
}
