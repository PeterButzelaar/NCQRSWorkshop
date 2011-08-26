using System;

namespace Domain.Exceptions
{
    public class NotEnoughCapacityLeftForCargoException : Exception
    {
        public NotEnoughCapacityLeftForCargoException(Guid voyageId, float capacityLeftIncludingOverbook, Guid cargoId, float cargoSize) : base("There is not enough capacity left for this cargo")
        {
        }
    }
}