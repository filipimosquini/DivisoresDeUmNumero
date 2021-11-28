using Flunt.Notifications;
using Flunt.Validations;

namespace FindNumbersDivider.Domain.Entities
{
    public class Number : Notifiable<Notification>
    {
        public Number(int algarism)
        {
            Algarism = algarism;
        }

        public int Algarism { get; private set; }

        public void SetNumber(int algarism)
        {
            AddNotifications(new Contract<Number>()
                .Requires()
                .IsGreaterThan(algarism, 0, "O número informado deve ser maior que zero"));

            Algarism = algarism;
        }
    }
}