using System;
using monetize.domain.enums;

namespace monetize.domain.dtos
{
    public class ICreateBalanceDTO
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public Currency Currency { get; set; }
    }
}