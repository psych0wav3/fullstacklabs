using monetize.domain.dtos;
using monetize.domain.entities;

namespace monetize.domain.services
{
    public interface IConvertBalanceService
    {
        void Execute(ConvertBalanceDTO balanceDTO);
    }
}