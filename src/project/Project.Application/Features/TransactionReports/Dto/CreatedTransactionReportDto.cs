﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Dto;

namespace Project.Application.Features.TransactionReports.Dto
{
    public class CreatedTransactionReportDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CrewId { get; set; }
        public int OrderDetailId { get; set; }
    }
}
