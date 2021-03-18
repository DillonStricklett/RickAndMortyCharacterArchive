using RickAndMortyAPICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyCharacterArchive.Models
{
    /// <summary>
    /// Information for a single 
    /// RickAndMorty Character entry.
    /// </summary>
    public class RickAndMortyCharacterEntryViewModel
    {
        /// <summary>
        /// Name of the character.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The characters ID.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The status of character.
        /// Ex: Alive, Dead or Unknown.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The species of the character.
        /// </summary>
        public string Species { get; set; }
        /// <summary>
        /// The type or subspecies of the character.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The gender of the character.
        /// Ex: Female, Male, Genderless or Unknown.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Name and link to the characters origin location.
        /// </summary>
        public Origin Origin { get; set; }
        /// <summary>
        /// Name and link to the characters last known location.
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// The URL to the image of the character.
        /// Image is 300x300 px.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// List of episodes in which this character appeared.
        /// </summary>
        public string[] episode { get; set; }
    }
}
