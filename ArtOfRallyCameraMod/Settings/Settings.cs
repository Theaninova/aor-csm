using UnityModManagerNet;

// ReSharper disable ConvertToConstant.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace ArtOfRallyCSM.Settings
{
    public class Settings : UnityModManager.ModSettings, IDrawable
    {
        [Draw("Leaderboard URI")]
        public string LeaderboardURI = "https://art-of-rally-championship.liteproject.de/api/finish-line";
        
        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void OnChange()
        {
            // TODO
        }
    }
}