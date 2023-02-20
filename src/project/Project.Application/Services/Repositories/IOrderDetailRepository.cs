﻿using Core.Persistence.Repositories;
using Project.Domain.Entities;

namespace Project.Application.Services.Repositories;

public interface IOrderDetailRepository : IAsyncRepository<OrderDetail>
{
}