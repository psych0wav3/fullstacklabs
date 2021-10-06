using monetize.domain.enums;

namespace monetize.domain.dtos
{
    public class CreateBalanceDTO
    {
        public double Value { get; set; }
        public Currency Currency { get; set; }
    }
}