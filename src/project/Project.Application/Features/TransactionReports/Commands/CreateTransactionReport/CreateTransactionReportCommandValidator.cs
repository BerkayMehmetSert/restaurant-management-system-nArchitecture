using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Project.Application.Features.TransactionReports.Constants;

namespace Project.Application.Features.TransactionReports.Commands.CreateTransactionReport
{
    public class CreateTransactionReportCommandValidator : AbstractValidator<CreateTransactionReportCommand>
    {
        public CreateTransactionReportCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage(TransactionReportMessages.CustomerIdIsRequired);

            RuleFor(x => x.CrewId)
                .NotEmpty()
                .WithMessage(TransactionReportMessages.CrewIdIsRequired);

            RuleFor(x => x.OrderDetailId)
                .NotEmpty()
                .WithMessage(TransactionReportMessages.OrderDetailIdIsRequired);
        }
    }
}
