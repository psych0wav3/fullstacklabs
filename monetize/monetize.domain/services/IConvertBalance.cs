using monetize.domain.dtos;

namespace monetize.domain.services
{
    public interface ICreateBalanceService
    {
        void Execute(CreateBalanceDTO createBalance);
    }
}