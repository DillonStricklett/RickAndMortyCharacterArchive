using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMortyAPICore
{
    /// <summary>
    /// A single character from the show Rick and Morty.
    /// </summary>
    /// A good way to quickly generate this class is to 
    /// copy a JSON response from API, create a new
    /// class and then click edit and click paste special
    /// to paste the JSON data into classes.
    /// or go to https://json2csharp.com/ for conversion.

    public class CharacterSearchResults
    {
        /// <summary>
        /// Info on amount of characters returned.
        /// </summary>
        public Info info { get; set; }
        /// <summary>
        /// Array of characters that match search criteria.
        /// </summary>
        public Result[] results { get; set; }
    }

    public class Info
    {
        /// <summary>
        /// The number of returned characters.
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// THe number of pages of characters that are returned.
        /// </summary>
        public int pages { get; set; }
        /// <summary>
        /// The next page.
        /// </summary>
        public string next { get; set; }
        /// <summary>
        /// The previous page, will be null if on first page.
        /// </summary>
        public object prev { get; set; }
    }

    public class Result // Character
    {
        /// <summary>
        /// The character id.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// The status of the character. (Ex: Alive, Dead, Unknown)
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// The characters species.
        /// </summary>
        public string species { get; set; }
        /// <summary>
        /// The type or subspecies of the character.
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// The gender of the character.
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// Name and link to characters origin location.
        /// </summary>
        public Origin origin { get; set; }
        /// <summary>
        /// Name and link to characters last known location.
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// A url link to the characters image.
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// List of episodes in which the character appeared.
        /// </summary>
        public string[] episode { get; set; }
        /// <summary>
        /// Link to the character's own url.
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// Time at which the character was created in database.
        /// </summary>
        public DateTime created { get; set; }
    }

    /// <summary>
    /// Name and link to characters origin location.
    /// </summary>
    public class Origin
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    /// <summary>
    /// Name and link to characters last known location.
    /// </summary>
    public class Location
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
