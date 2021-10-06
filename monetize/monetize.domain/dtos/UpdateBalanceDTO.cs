using monetize.domain.enums;

namespace monetize.domain.dtos
{
    public class UpdateBalanceDTO
    {
        public double Value { get; set; }
        public Currency Currency { get; set; }
    }
}