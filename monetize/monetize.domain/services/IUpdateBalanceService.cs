using monetize.domain.dtos;

namespace monetize.domain.services
{
    public interface IUpdateBalanceService
    {
         void Execute(UpdateBalanceDTO updateBalace);
    }
}