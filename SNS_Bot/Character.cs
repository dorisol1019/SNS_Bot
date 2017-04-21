
using SNS_Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot
{
    public enum CharacterType
    {
        Yarimizu_Moe,Abe_Satomi
    }

    static public class Character
    {
        public static ICharacter Create(CharacterType type)
        {
            ICharacter character = null;
            switch (type)
            {
                case CharacterType.Yarimizu_Moe:
                    character = new Moe();
                    break;
                case CharacterType.Abe_Satomi:
                    character= new Satomi();
                    break;
                default:
                    break;
            }

            return character;
        }
    }
}
