using DataLibrary.Models;
using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.BusinessLogic
{
    /**
     * Author Oujun
     * This static class is used to communicate with the database, using queries.
     */
    public static class CharacterProcessor
    {
        public static int CreateCharacter(string name, string rarity, string birthday, 
            string allegiance, string element, string image, string description)
        {
            CharacterModel data = new CharacterModel()
            {
                Name = name,
                Rarity = rarity,
                Birthday = birthday,
                Allegiance = allegiance,
                Element = element,
                Image = image,
                Description = description
            };

            string sql = @"insert into dbo.GenshinCharactersTable (Name, Rarity, Birthday, Allegiance, Element, Image, Description)
                           values (@Name, @Rarity, @Birthday, @Allegiance, @Element, @Image, @Description);";

            return SqlDataAccess.SaveData(sql, data);

        }

        public static List<CharacterModel> GetAllCharacter()
        {
            string sql = @"select * from dbo.GenshinCharactersTable;";

            return SqlDataAccess.LoadData<CharacterModel>(sql);
        }

        public static List<CharacterModel> GetLatestCharacter()
        {
            string sql = "Select Name, Rarity, Allegiance, Element, Image, Description " +
                            "from dbo.NewlyReleasedCharacters " +
                            "Where Name in ('Raiden Shogun', 'Sangonomiya Kokomi')";

            return SqlDataAccess.LoadData<CharacterModel>(sql);
        }

        public static List<CharacterModel> DeleteCharacter(int id)
        {
            string sql = "Delete from dbo.GenshinCharactersTable " + "Where Id =" + id;

            return SqlDataAccess.LoadData<CharacterModel>(sql);
        }
    }
}
