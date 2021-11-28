using Flunt.Notifications;
using Flunt.Validations;

namespace FindNumbersDivider.Domain.Entities
{
    public class Number : Notifiable<Notification>
    {
        public Number(int algarism)
        {
            SetAlgarism(algarism);
        }

        public int Algarism { get; private set; }

        public void SetAlgarism(int algarism)
        {
            AddNotifications(new Contract<Number>()
                .Requires()
                .IsGreaterThan(algarism, 0, "Number", "O número informado deve ser maior que zero"));

            Algarism = algarism;
        }
    }
}