using Newtonsoft.Json;

namespace PROProtocol
{
    public class PokemonNamesManager
    {
        private static PokemonNamesManager _instance;

        public static PokemonNamesManager Instance
        {
            get
            {
                return _instance ?? (_instance = new PokemonNamesManager());
            }
        }
        public string[] Names { get; private set; }

        public PokemonNamesManager()
        {
            Names = JsonConvert.DeserializeObject<string[]>(Properties.Resources.pokemon);
        }
    }
}
