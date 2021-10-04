using monetize.domain.enums;

namespace monetize.domain.dtos
{
    public class IConvertBalanceDTO
    {
        public double Value { get; set; }
        public Currency OldCurrency { get; set; }
        public Currency NewCurrency { get; set; }
    }
}