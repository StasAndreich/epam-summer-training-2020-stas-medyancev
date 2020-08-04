using System.Collections.Generic;

namespace ServerServices
{
    /// <summary>
    /// Defines methods for encoding messages.
    /// </summary>
    public static class MessagesEncoder
    {
        private static Dictionary<char, string> letterPairs
            = new Dictionary<char, string>
        {
            {'а',"a" },
            {'б', "b" },
            {'в', "v" },
            {'г', "g" },
            {'д', "d" },
            {'е', "e" },
            {'ё', "ye" },
            {'ж', "zh" },
            {'з', "z" },
            {'и', "i" },
            {'й', "y" },
            {'к', "k" },
            {'л', "l" },
            {'м', "m" },
            {'н', "n" },
            {'о', "o" },
            {'п', "p" },
            {'р', "r" },
            {'с', "s" },
            {'т', "t" },
            {'у', "u" },
            {'ф', "f" },
            {'х', "h" },
            {'ц', "ts" },
            {'ч', "ch" },
            {'ш', "sh" },
            {'щ', "sh" },
            {'ы', "y" },
            {'э', "e" },
            {'ю', "yu" },
            {'я', "ya" }
        };

        /// <summary>
        /// Translits text from russian to english.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string TranslitToEng(string inputStr)
        {
            var translation = "";
            foreach (var item1 in inputStr)
            {
                foreach (var item2 in letterPairs)
                {
                    if (item1 == item2.Key)
                    {
                        translation += item2.Value;
                        break;
                    }
                }
            }
            return translation;
        }

        /// <summary>
        /// Translits text from english to russian.
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string TranslitToRus(string inputStr)
        {
            var translation = "";
            var buffer = "";
            var flag = false;

            for (var i = 0; i < inputStr.Length; i++)
            {
                buffer = "";
                flag = false;

                if (i != inputStr.Length - 1)
                {
                    buffer = $"{inputStr[i]}{inputStr[i + 1]}";
                    foreach (var item2 in letterPairs)
                    {
                        if (buffer == item2.Value)
                        {
                            translation += item2.Key;
                            i++;
                            flag = true;
                            break;
                        }
                    }
                }
                if ((i == inputStr.Length - 1)
                    || (flag == false))
                {
                    buffer = $"{inputStr[i]}";
                    foreach (var item2 in letterPairs)
                    {
                        if (buffer == item2.Value)
                        {
                            translation += item2.Key;
                            break;
                        }
                    }
                }
            }

            return translation;
        }

        private static string Desider(string inputStr)
        {
            var isRussian = false;
            var result = "";
            foreach (var item in letterPairs)
            {
                if (inputStr[0] == item.Key)
                {
                    isRussian = true;
                    break;
                }
            }

            if (isRussian)
                result = TranslitToEng(inputStr);
            else
                result = TranslitToRus(inputStr);

            return result;
        }
    }
}
