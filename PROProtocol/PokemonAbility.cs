using Newtonsoft.Json;

namespace PROProtocol
{
    public class PokemonAbility
    {
        public int Id { get; private set; }
        public string Name
        {
            get
            {
                if (Id < 0 || Id >= Abilities.Length)
                {
                    return null;
                }
                return Abilities[Id];
            }
        }

        public PokemonAbility(int id)
        {
            Id = id;
        }

        public static readonly string[] Abilities;
        static PokemonAbility()
        {
            Abilities = JsonConvert.DeserializeObject<string[]>(Properties.Resources.abilities);
        }
    }
}
